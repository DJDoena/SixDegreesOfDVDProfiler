namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
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
            System.Windows.Forms.ColumnHeader StartingTitleColumn;
            System.Windows.Forms.ColumnHeader EndingTitleColumn;
            System.Windows.Forms.ColumnHeader TitleColumn;
            System.Windows.Forms.ColumnHeader LeftPersonNameColumn;
            System.Windows.Forms.ColumnHeader LeftPersonJobColumn;
            System.Windows.Forms.ColumnHeader RightPersonNameColumn;
            System.Windows.Forms.ColumnHeader RightPersonJobColumn;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
            this.ResultListView = new System.Windows.Forms.ListView();
            this.StepsListView = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GraphWizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WhatIsGraphWizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadGraphWizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigureGraphWizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunGraphWizWithResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DegreeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            StartingTitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            EndingTitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            TitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            LeftPersonNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            LeftPersonJobColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            RightPersonNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            RightPersonJobColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DegreeColumn
            // 
            DegreeColumn.Text = "Degree of separation";
            DegreeColumn.Width = 120;
            // 
            // StartingTitleColumn
            // 
            StartingTitleColumn.Text = "Starting title";
            StartingTitleColumn.Width = 200;
            // 
            // EndingTitleColumn
            // 
            EndingTitleColumn.Text = "Ending title";
            EndingTitleColumn.Width = 200;
            // 
            // TitleColumn
            // 
            TitleColumn.Text = "Title";
            TitleColumn.Width = 200;
            // 
            // LeftPersonNameColumn
            // 
            LeftPersonNameColumn.Text = "Left person";
            LeftPersonNameColumn.Width = 150;
            // 
            // LeftPersonJobColumn
            // 
            LeftPersonJobColumn.Text = "Left person\'s job";
            LeftPersonJobColumn.Width = 150;
            // 
            // RightPersonNameColumn
            // 
            RightPersonNameColumn.Text = "Right person";
            RightPersonNameColumn.Width = 150;
            // 
            // RightPersonJobColumn
            // 
            RightPersonJobColumn.Text = "Right person\'s job";
            RightPersonJobColumn.Width = 150;
            // 
            // ResultListView
            // 
            this.ResultListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            DegreeColumn,
            StartingTitleColumn,
            EndingTitleColumn});
            this.ResultListView.FullRowSelect = true;
            this.ResultListView.HideSelection = false;
            this.ResultListView.Location = new System.Drawing.Point(12, 27);
            this.ResultListView.MultiSelect = false;
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(825, 231);
            this.ResultListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ResultListView.TabIndex = 0;
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
            TitleColumn,
            LeftPersonNameColumn,
            LeftPersonJobColumn,
            RightPersonNameColumn,
            RightPersonJobColumn});
            this.StepsListView.FullRowSelect = true;
            this.StepsListView.HideSelection = false;
            this.StepsListView.Location = new System.Drawing.Point(12, 264);
            this.StepsListView.MultiSelect = false;
            this.StepsListView.Name = "StepsListView";
            this.StepsListView.Size = new System.Drawing.Size(825, 210);
            this.StepsListView.TabIndex = 1;
            this.StepsListView.UseCompatibleStateImageBehavior = false;
            this.StepsListView.View = System.Windows.Forms.View.Details;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GraphWizToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(849, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GraphWizToolStripMenuItem
            // 
            this.GraphWizToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WhatIsGraphWizToolStripMenuItem,
            this.DownloadGraphWizToolStripMenuItem,
            this.ConfigureGraphWizToolStripMenuItem,
            this.RunGraphWizWithResultToolStripMenuItem});
            this.GraphWizToolStripMenuItem.Name = "GraphWizToolStripMenuItem";
            this.GraphWizToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.GraphWizToolStripMenuItem.Text = "GraphWiz";
            // 
            // WhatIsGraphWizToolStripMenuItem
            // 
            this.WhatIsGraphWizToolStripMenuItem.Name = "WhatIsGraphWizToolStripMenuItem";
            this.WhatIsGraphWizToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.WhatIsGraphWizToolStripMenuItem.Text = "What is GraphWiz?";
            this.WhatIsGraphWizToolStripMenuItem.Click += new System.EventHandler(this.OnWhatIsGraphWizToolStripMenuItemClick);
            // 
            // DownloadGraphWizToolStripMenuItem
            // 
            this.DownloadGraphWizToolStripMenuItem.Name = "DownloadGraphWizToolStripMenuItem";
            this.DownloadGraphWizToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.DownloadGraphWizToolStripMenuItem.Text = "Download GraphWiz";
            this.DownloadGraphWizToolStripMenuItem.Click += new System.EventHandler(this.OnDownloadGraphWizToolStripMenuItemClick);
            // 
            // ConfigureGraphWizToolStripMenuItem
            // 
            this.ConfigureGraphWizToolStripMenuItem.Name = "ConfigureGraphWizToolStripMenuItem";
            this.ConfigureGraphWizToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.ConfigureGraphWizToolStripMenuItem.Text = "Configure GraphWiz";
            this.ConfigureGraphWizToolStripMenuItem.Click += new System.EventHandler(this.OnConfigureGraphWizToolStripMenuItemClick);
            // 
            // RunGraphWizWithResultToolStripMenuItem
            // 
            this.RunGraphWizWithResultToolStripMenuItem.Name = "RunGraphWizWithResultToolStripMenuItem";
            this.RunGraphWizWithResultToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.RunGraphWizWithResultToolStripMenuItem.Text = "Export Result as an image with GraphWiz";
            this.RunGraphWizWithResultToolStripMenuItem.Click += new System.EventHandler(this.OnRunGraphWizWithResultToolStripMenuItemClick);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 486);
            this.Controls.Add(this.StepsListView);
            this.Controls.Add(this.ResultListView);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(865, 525);
            this.Name = "ResultForm";
            this.Text = "Six Degrees of DVD Profiler: Result";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ResultListView;
        private System.Windows.Forms.ListView StepsListView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GraphWizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WhatIsGraphWizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigureGraphWizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunGraphWizWithResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownloadGraphWizToolStripMenuItem;
    }
}

