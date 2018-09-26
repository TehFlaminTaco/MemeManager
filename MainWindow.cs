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
            MessageBox.Show("Could not find GORN folder. Please select manually.", "Memeloader Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            showDirectoryButton_Click(null, null);
        }

        private bool SetPath(string path, bool warnUser = true, bool guessOnFail = false, bool reopen = false)
        {

            // Target is not a directory.
            if (!Directory.Exists(path))
            {
                if (warnUser)
                {
                    MessageBox.Show("Target is not a directory, or does not exist.", "Memeloader Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Folder does not contain a valid GORN.exe", "Memeloader Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ListViewItem i = listViewMods.Items.Add("GornieForce");
            i.Checked = true;
            i.SubItems.AddRange(new string[] { "Teh Flamin' Taco", "V2.2" });
            i.Group = listViewMods.Groups[0];

            SetPath((string)Properties.Settings.Default["gornFolder"], true, true);

        }

        private void installButton_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void modList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
