namespace MemeMananger
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Gameplay", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Weapons", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Misc", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.folderPath = new System.Windows.Forms.TextBox();
            this.gornFolderLabel = new System.Windows.Forms.Label();
            this.showDirectoryButton = new System.Windows.Forms.Button();
            this.selectGornFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.gornStatusLabel = new System.Windows.Forms.Label();
            this.installButton = new System.Windows.Forms.Button();
            this.listViewMods = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // folderPath
            // 
            this.folderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderPath.Enabled = false;
            this.folderPath.Location = new System.Drawing.Point(12, 29);
            this.folderPath.Name = "folderPath";
            this.folderPath.Size = new System.Drawing.Size(398, 20);
            this.folderPath.TabIndex = 0;
            this.folderPath.Text = "...";
            // 
            // gornFolderLabel
            // 
            this.gornFolderLabel.AutoSize = true;
            this.gornFolderLabel.Location = new System.Drawing.Point(13, 13);
            this.gornFolderLabel.Name = "gornFolderLabel";
            this.gornFolderLabel.Size = new System.Drawing.Size(90, 13);
            this.gornFolderLabel.TabIndex = 1;
            this.gornFolderLabel.Text = "Gorn Folder Path:";
            // 
            // showDirectoryButton
            // 
            this.showDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showDirectoryButton.Location = new System.Drawing.Point(415, 27);
            this.showDirectoryButton.Name = "showDirectoryButton";
            this.showDirectoryButton.Size = new System.Drawing.Size(22, 23);
            this.showDirectoryButton.TabIndex = 2;
            this.showDirectoryButton.Text = "..";
            this.showDirectoryButton.UseVisualStyleBackColor = true;
            this.showDirectoryButton.Click += new System.EventHandler(this.showDirectoryButton_Click);
            // 
            // selectGornFolder
            // 
            this.selectGornFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // gornStatusLabel
            // 
            this.gornStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gornStatusLabel.AutoSize = true;
            this.gornStatusLabel.Location = new System.Drawing.Point(13, 419);
            this.gornStatusLabel.Name = "gornStatusLabel";
            this.gornStatusLabel.Size = new System.Drawing.Size(43, 13);
            this.gornStatusLabel.TabIndex = 3;
            this.gornStatusLabel.Text = "Status: ";
            // 
            // installButton
            // 
            this.installButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.installButton.Location = new System.Drawing.Point(344, 414);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(93, 23);
            this.installButton.TabIndex = 4;
            this.installButton.Text = "Install/Update";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // listViewMods
            // 
            this.listViewMods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMods.CheckBoxes = true;
            this.listViewMods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnAuthor,
            this.columnVersion});
            this.listViewMods.FullRowSelect = true;
            listViewGroup1.Header = "Gameplay";
            listViewGroup1.Name = "groupGameplay";
            listViewGroup2.Header = "Weapons";
            listViewGroup2.Name = "groupWeapons";
            listViewGroup3.Header = "Misc";
            listViewGroup3.Name = "groupMisc";
            this.listViewMods.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.listViewMods.Location = new System.Drawing.Point(13, 56);
            this.listViewMods.Name = "listViewMods";
            this.listViewMods.Size = new System.Drawing.Size(425, 352);
            this.listViewMods.TabIndex = 5;
            this.listViewMods.UseCompatibleStateImageBehavior = false;
            this.listViewMods.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 172;
            // 
            // columnAuthor
            // 
            this.columnAuthor.Text = "Author";
            this.columnAuthor.Width = 143;
            // 
            // columnVersion
            // 
            this.columnVersion.Text = "Version";
            this.columnVersion.Width = 102;
            // 
            // MainWindow
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.listViewMods);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.gornStatusLabel);
            this.Controls.Add(this.showDirectoryButton);
            this.Controls.Add(this.gornFolderLabel);
            this.Controls.Add(this.folderPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Meme Manager";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox folderPath;
        private System.Windows.Forms.Label gornFolderLabel;
        private System.Windows.Forms.Button showDirectoryButton;
        private System.Windows.Forms.FolderBrowserDialog selectGornFolder;
        private System.Windows.Forms.Label gornStatusLabel;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.ListView listViewMods;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnAuthor;
        private System.Windows.Forms.ColumnHeader columnVersion;
    }
}

