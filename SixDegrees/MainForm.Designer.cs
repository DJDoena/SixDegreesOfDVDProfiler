namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    partial class MainForm
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
            System.Windows.Forms.Label WelcomeLabel;
            System.Windows.Forms.Label InfoLabel;
            System.Windows.Forms.LinkLabel KevinBaconLinkLabel;
            System.Windows.Forms.LinkLabel SixDegreesLinkLabel;
            this.RootMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ByPersonButton = new System.Windows.Forms.Button();
            this.ByTitleButton = new System.Windows.Forms.Button();
            WelcomeLabel = new System.Windows.Forms.Label();
            InfoLabel = new System.Windows.Forms.Label();
            KevinBaconLinkLabel = new System.Windows.Forms.LinkLabel();
            SixDegreesLinkLabel = new System.Windows.Forms.LinkLabel();
            this.RootMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            WelcomeLabel.AutoSize = true;
            WelcomeLabel.Location = new System.Drawing.Point(12, 24);
            WelcomeLabel.Name = "WelcomeLabel";
            WelcomeLabel.Size = new System.Drawing.Size(210, 13);
            WelcomeLabel.TabIndex = 1;
            WelcomeLabel.Text = "Welcome to \"Six Degrees of DVD Profiler\".";
            // 
            // InfoLabel
            // 
            InfoLabel.AutoSize = true;
            InfoLabel.Location = new System.Drawing.Point(12, 45);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new System.Drawing.Size(655, 13);
            InfoLabel.TabIndex = 2;
            InfoLabel.Text = "This program is based on the idea of \"Six Degrees of Kevin Bacon\" which is in tur" +
    "n based on the concept of \"Six Degrees of Separation\".";
            // 
            // KevinBaconLinkLabel
            // 
            KevinBaconLinkLabel.AutoSize = true;
            KevinBaconLinkLabel.Location = new System.Drawing.Point(12, 66);
            KevinBaconLinkLabel.Name = "KevinBaconLinkLabel";
            KevinBaconLinkLabel.Size = new System.Drawing.Size(193, 13);
            KevinBaconLinkLabel.TabIndex = 3;
            KevinBaconLinkLabel.TabStop = true;
            KevinBaconLinkLabel.Text = "Wikipedia: Six Degrees of Kevin Bacon";
            KevinBaconLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnKevinBaconLinkLabelLinkClicked);
            // 
            // SixDegreesLinkLabel
            // 
            SixDegreesLinkLabel.AutoSize = true;
            SixDegreesLinkLabel.Location = new System.Drawing.Point(12, 87);
            SixDegreesLinkLabel.Name = "SixDegreesLinkLabel";
            SixDegreesLinkLabel.Size = new System.Drawing.Size(183, 13);
            SixDegreesLinkLabel.TabIndex = 4;
            SixDegreesLinkLabel.TabStop = true;
            SixDegreesLinkLabel.Text = "Wikipedia: Six Degrees of Separation";
            SixDegreesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnSixDegreesLinkLabelLinkClicked);
            // 
            // RootMenuStrip
            // 
            this.RootMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.RootMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.RootMenuStrip.Name = "RootMenuStrip";
            this.RootMenuStrip.Size = new System.Drawing.Size(709, 24);
            this.RootMenuStrip.TabIndex = 0;
            this.RootMenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.ExitToolStripMenuItem.Text = "&Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItemClick);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckForUpdatesToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpToolStripMenuItem.Text = "&Help";
            // 
            // CheckForUpdatesToolStripMenuItem
            // 
            this.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem";
            this.CheckForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.CheckForUpdatesToolStripMenuItem.Text = "&Check for Updates";
            this.CheckForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.OnCheckForUpdatesToolStripMenuItemClick);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.AboutToolStripMenuItem.Text = "&About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolStripMenuItemClick);
            // 
            // ByPersonButton
            // 
            this.ByPersonButton.Location = new System.Drawing.Point(12, 117);
            this.ByPersonButton.Name = "ByPersonButton";
            this.ByPersonButton.Size = new System.Drawing.Size(225, 23);
            this.ByPersonButton.TabIndex = 15;
            this.ByPersonButton.Text = "Search by Person";
            this.ByPersonButton.UseVisualStyleBackColor = true;
            this.ByPersonButton.Click += new System.EventHandler(this.OnSearchByPersonButtonClick);
            // 
            // ByTitleButton
            // 
            this.ByTitleButton.Location = new System.Drawing.Point(12, 146);
            this.ByTitleButton.Name = "ByTitleButton";
            this.ByTitleButton.Size = new System.Drawing.Size(225, 23);
            this.ByTitleButton.TabIndex = 16;
            this.ByTitleButton.Text = "Search by Title";
            this.ByTitleButton.UseVisualStyleBackColor = true;
            this.ByTitleButton.Click += new System.EventHandler(this.OnByTitleButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 186);
            this.Controls.Add(this.ByTitleButton);
            this.Controls.Add(this.ByPersonButton);
            this.Controls.Add(SixDegreesLinkLabel);
            this.Controls.Add(KevinBaconLinkLabel);
            this.Controls.Add(InfoLabel);
            this.Controls.Add(WelcomeLabel);
            this.Controls.Add(this.RootMenuStrip);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(725, 225);
            this.MinimumSize = new System.Drawing.Size(725, 225);
            this.Name = "MainForm";
            this.Text = "Six Degrees of DVD Profiler";
            this.RootMenuStrip.ResumeLayout(false);
            this.RootMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip RootMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.Button ByPersonButton;
        private System.Windows.Forms.Button ByTitleButton;
    }
}

