namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler.Profile
{
    partial class ResultForm
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
            System.Windows.Forms.ColumnHeader DegreeColumn;
            System.Windows.Forms.ColumnHeader StartingPersonColumn;
            System.Windows.Forms.ColumnHeader EndingPersonColumn;
            System.Windows.Forms.ColumnHeader PersonNameColumn;
            System.Windows.Forms.ColumnHeader LeftTitleColumn;
            System.Windows.Forms.ColumnHeader LeftPersonJobColumn;
            System.Windows.Forms.ColumnHeader RightTitleeColumn;
            System.Windows.Forms.ColumnHeader RightPersonJobColumn;
            this.ResultListView = new System.Windows.Forms.ListView();
            this.StepsListView = new System.Windows.Forms.ListView();
            this.RootMenuStrip = new System.Windows.Forms.MenuStrip();
            this.GraphWizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WhatIsGraphvizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadGraphvizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigureGraphvizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPeoplesJobInImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunGraphvizWithResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DegreeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            StartingPersonColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            EndingPersonColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            PersonNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            LeftTitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            LeftPersonJobColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            RightTitleeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            RightPersonJobColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RootMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // DegreeColumn
            // 
            DegreeColumn.Text = "Degree of separation";
            DegreeColumn.Width = 120;
            // 
            // StartingPersonColumn
            // 
            StartingPersonColumn.Text = "Starting person";
            StartingPersonColumn.Width = 200;
            // 
            // EndingPersonColumn
            // 
            EndingPersonColumn.Text = "Ending person";
            EndingPersonColumn.Width = 200;
            // 
            // PersonNameColumn
            // 
            PersonNameColumn.Text = "Person";
            PersonNameColumn.Width = 200;
            // 
            // LeftTitleColumn
            // 
            LeftTitleColumn.Text = "Left title";
            LeftTitleColumn.Width = 150;
            // 
            // LeftPersonJobColumn
            // 
            LeftPersonJobColumn.Text = "Person\'s job on left title";
            LeftPersonJobColumn.Width = 150;
            // 
            // RightTitleeColumn
            // 
            RightTitleeColumn.Text = "Right title";
            RightTitleeColumn.Width = 150;
            // 
            // RightPersonJobColumn
            // 
            RightPersonJobColumn.Text = "Person\'s job on right title";
            RightPersonJobColumn.Width = 150;
            // 
            // ResultListView
            // 
            this.ResultListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            DegreeColumn,
            StartingPersonColumn,
            EndingPersonColumn});
            this.ResultListView.FullRowSelect = true;
            this.ResultListView.HideSelection = false;
            this.ResultListView.Location = new System.Drawing.Point(12, 27);
            this.ResultListView.MultiSelect = false;
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(825, 231);
            this.ResultListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ResultListView.TabIndex = 1;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            this.ResultListView.View = System.Windows.Forms.View.Details;
            this.ResultListView.SelectedIndexChanged += new System.EventHandler(this.OnResultListViewSelectedIndexChanged);
            // 
            // StepsListView
            // 
            this.StepsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StepsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            PersonNameColumn,
            LeftTitleColumn,
            LeftPersonJobColumn,
            RightTitleeColumn,
            RightPersonJobColumn});
            this.StepsListView.FullRowSelect = true;
            this.StepsListView.HideSelection = false;
            this.StepsListView.Location = new System.Drawing.Point(12, 264);
            this.StepsListView.MultiSelect = false;
            this.StepsListView.Name = "StepsListView";
            this.StepsListView.Size = new System.Drawing.Size(825, 210);
            this.StepsListView.TabIndex = 2;
            this.StepsListView.UseCompatibleStateImageBehavior = false;
            this.StepsListView.View = System.Windows.Forms.View.Details;
            // 
            // RootMenuStrip
            // 
            this.RootMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GraphWizToolStripMenuItem});
            this.RootMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.RootMenuStrip.Name = "RootMenuStrip";
            this.RootMenuStrip.Size = new System.Drawing.Size(849, 24);
            this.RootMenuStrip.TabIndex = 0;
            this.RootMenuStrip.Text = "menuStrip1";
            // 
            // GraphWizToolStripMenuItem
            // 
            this.GraphWizToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WhatIsGraphvizToolStripMenuItem,
            this.DownloadGraphvizToolStripMenuItem,
            this.ConfigureGraphvizToolStripMenuItem,
            this.ShowPeoplesJobInImageToolStripMenuItem,
            this.RunGraphvizWithResultToolStripMenuItem});
            this.GraphWizToolStripMenuItem.Name = "GraphWizToolStripMenuItem";
            this.GraphWizToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.GraphWizToolStripMenuItem.Text = "Graphviz";
            // 
            // WhatIsGraphvizToolStripMenuItem
            // 
            this.WhatIsGraphvizToolStripMenuItem.Name = "WhatIsGraphvizToolStripMenuItem";
            this.WhatIsGraphvizToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.WhatIsGraphvizToolStripMenuItem.Text = "What is Graphviz?";
            this.WhatIsGraphvizToolStripMenuItem.Click += new System.EventHandler(this.OnWhatIsGraphvizToolStripMenuItemClick);
            // 
            // DownloadGraphvizToolStripMenuItem
            // 
            this.DownloadGraphvizToolStripMenuItem.Name = "DownloadGraphvizToolStripMenuItem";
            this.DownloadGraphvizToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.DownloadGraphvizToolStripMenuItem.Text = "Download Graphviz";
            this.DownloadGraphvizToolStripMenuItem.Click += new System.EventHandler(this.OnDownloadGraphvizToolStripMenuItemClick);
            // 
            // ConfigureGraphvizToolStripMenuItem
            // 
            this.ConfigureGraphvizToolStripMenuItem.Name = "ConfigureGraphvizToolStripMenuItem";
            this.ConfigureGraphvizToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.ConfigureGraphvizToolStripMenuItem.Text = "Configure Graphviz";
            this.ConfigureGraphvizToolStripMenuItem.Click += new System.EventHandler(this.OnConfigureGraphvizToolStripMenuItemClick);
            // 
            // ShowPeoplesJobInImageToolStripMenuItem
            // 
            this.ShowPeoplesJobInImageToolStripMenuItem.CheckOnClick = true;
            this.ShowPeoplesJobInImageToolStripMenuItem.Name = "ShowPeoplesJobInImageToolStripMenuItem";
            this.ShowPeoplesJobInImageToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.ShowPeoplesJobInImageToolStripMenuItem.Text = "Show people\'s job in image";
            this.ShowPeoplesJobInImageToolStripMenuItem.Click += new System.EventHandler(this.OnShowPeoplesJobInImageToolStripMenuItemClick);
            // 
            // RunGraphvizWithResultToolStripMenuItem
            // 
            this.RunGraphvizWithResultToolStripMenuItem.Name = "RunGraphvizWithResultToolStripMenuItem";
            this.RunGraphvizWithResultToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.RunGraphvizWithResultToolStripMenuItem.Text = "Export Result as an image with Graphviz";
            this.RunGraphvizWithResultToolStripMenuItem.Click += new System.EventHandler(this.OnRunGraphvizWithResultToolStripMenuItemClick);
            // 
            // ProfileResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 486);
            this.Controls.Add(this.StepsListView);
            this.Controls.Add(this.ResultListView);
            this.Controls.Add(this.RootMenuStrip);
            this.MainMenuStrip = this.RootMenuStrip;
            this.MinimumSize = new System.Drawing.Size(865, 525);
            this.Name = "ProfileResultForm";
            this.Text = "Six Degrees of DVD Profiler: Result";
            this.RootMenuStrip.ResumeLayout(false);
            this.RootMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ResultListView;
        private System.Windows.Forms.ListView StepsListView;
        private System.Windows.Forms.MenuStrip RootMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem GraphWizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WhatIsGraphvizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigureGraphvizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunGraphvizWithResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownloadGraphvizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowPeoplesJobInImageToolStripMenuItem;
    }
}

