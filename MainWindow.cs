using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace MemeMananger
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            SetStatus("Loading");
        }

        private void SetStatus(string status)
        {
            gornStatusLabel.Text = $"Status: {status}";
        }

        private void showDirectoryButton_Click(object sender = null, EventArgs e = null)
        {
            DialogResult res = selectGornFolder.ShowDialog();
            if(res != DialogResult.Cancel)
            {
                SetPath(selectGornFolder.SelectedPath, true, false, true);
            }
        }

        private void GuessGornFolder()
        {
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                string target = Path.Combine(d.Name, "Program Files (x86)\\Steam\\SteamApps\\common\\GORN\\");
                if (SetPath(target, false))
                    return;
            }
            MessageBox.Show("Could not find GORN folder. Please select manually.", "MemeManager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            showDirectoryButton_Click(null, null);
        }

        private bool SetPath(string path, bool warnUser = true, bool guessOnFail = false, bool reopen = false)
        {

            // Target is not a directory.
            if (!Directory.Exists(path))
            {
                if (warnUser)
                {
                    MessageBox.Show("Target is not a directory, or does not exist.", "MemeManager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (guessOnFail)
                {
                    GuessGornFolder();
                }
                if (reopen)
                {
                    showDirectoryButton_Click();
                }
                return false;
            }

            // No Gorn Executable.
            if (!File.Exists(Path.Combine(path, "GORN.exe")))
            {
                if (warnUser)
                {
                    MessageBox.Show("Folder does not contain a valid GORN.exe", "MemeManager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (guessOnFail)
                {
                    GuessGornFolder();
                }
                if (reopen)
                {
                    showDirectoryButton_Click();
                }
                return false;
            }

            folderPath.Text = path;
            Properties.Settings.Default["gornFolder"] = path;
            Properties.Settings.Default.Save();
            return true;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ListViewItem i = listViewMods.Items.Add("MemeManager");
            i.Checked = true;
            i.SubItems.AddRange(new string[] { ".MemeMan", "" });
            i.Group = listViewMods.Groups[0];
            

            SetPath((string)Properties.Settings.Default["gornFolder"], true, true);

        }

        private void installButton_Click(object sender, EventArgs e)
        {
            string GORN = folderPath.Text;
            string GORN_Data = Path.Combine(GORN, "GORN_Data");
            string Managed = Path.Combine(GORN_Data, "Managed");

            string AssemblyCsharp = Path.Combine(Managed, "Assembly-CSharp.dll");
            string AssemblyCsharpFirstPass = Path.Combine(Managed, "Assembly-CSharp-firstpass.dll");

            // Check existance of Non-modloader assebly.
            if (!Directory.Exists(GORN))
            {
                MessageBox.Show("Could not install MemeManager! Could not not find GORN Folder!", "MemeManager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(GORN_Data))
            {
                MessageBox.Show("Could not install MemeManager! Could not not find GORN>GORN_Data Folder!", "MemeManager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(Managed))
            {
                MessageBox.Show("Could not install MemeManager! Could not not find GORN>GORN_Data>Managed Folder!", "MemeManager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check CRC of Non-modloader assembly.
            if (!File.Exists(AssemblyCsharpFirstPass))
            {
                MessageBox.Show("You don't seem to be running a Compatible version of GORN! Ensure you're running Gorn on Steam, and are not opt into any Beta Branches. Then try again!\nAssembly-CSharp-firstpass.dll not found.", "MemeManager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Crc32 crcChecker = new Crc32();
                FileStream assembly = File.OpenRead(AssemblyCsharpFirstPass);
                byte[] buff = new byte[assembly.Length];
                assembly.Read(buff, 0, (int)assembly.Length);
                uint crc = crcChecker.Get(buff);
                if(crc.ToString("X") != "44B540D3")
                {
                    throw new Exception("Did not match registered GORN stable build.");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"You don't seem to be running a Compatible version of GORN! Ensure you're running Gorn on Steam, and are not opt into any Beta Branches. Then try again!{"\n"}{er.Message}", "MemeManager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Directory.CreateDirectory(Path.Combine(GORN_Data, "mods"));
                string downloadZip = Path.GetTempFileName();
                string tempFolder = Path.Combine(Path.GetTempPath(), $"MemeManagerDownload - {DateTime.Now.Millisecond.ToString("X")}");
                
                using (var client = new WebClient())
                {
                    SetStatus("Downloading MemeLoader");
                    client.DownloadFile("http://www.gornmods.com/download/56", downloadZip);
                    SetStatus("Extracting MemeLoader");
                    if (!Directory.Exists(tempFolder))
                        Directory.CreateDirectory(tempFolder);
                    System.IO.Compression.ZipFile.ExtractToDirectory(downloadZip, tempFolder);
                    SetStatus("Confirming MemeLoader Download");
                    if(!File.Exists(Path.Combine(tempFolder, "Assembly-CSharp.dll")) || !Directory.Exists(Path.Combine(tempFolder, "MemeLoader")))
                    {
                        try { File.Delete(downloadZip); } catch (Exception) { };
                        try { Directory.Delete(tempFolder, true); } catch (Exception) { };
                        MessageBox.Show($"MemeLoader failed to download. Try updating to the latest MemeManager.", "MemeManager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SetStatus("Installing MemeLoader");
                    File.Copy(Path.Combine(tempFolder, "Assembly-CSharp.dll"), AssemblyCsharp, true);
                    var SourcePath = Path.Combine(tempFolder, "MemeLoader");
                    var DestinationPath = Path.Combine(GORN_Data, "mods", "MemeLoader");
                    foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                        SearchOption.AllDirectories))
                        Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
                    foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                        SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
                    try { File.Delete(downloadZip); } catch (Exception) { };
                    try { Directory.Delete(tempFolder, true); } catch (Exception) { };
                    MessageBox.Show("MemeLoader installed successfully!");
                }
            }
            catch(Exception er)
            {
                MessageBox.Show($"Failed to install modloader.{"\n"}{er.Message}", "MemeManager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetStatus("Finished");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void modList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
