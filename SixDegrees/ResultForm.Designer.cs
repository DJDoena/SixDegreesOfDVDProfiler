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
            this.WhatIsGraphvizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadGraphvizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigureGraphvizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunGraphvizWithResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.WhatIsGraphvizToolStripMenuItem,
            this.DownloadGraphvizToolStripMenuItem,
            this.ConfigureGraphvizToolStripMenuItem,
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
            // RunGraphvizWithResultToolStripMenuItem
            // 
            this.RunGraphvizWithResultToolStripMenuItem.Name = "RunGraphvizWithResultToolStripMenuItem";
            this.RunGraphvizWithResultToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.RunGraphvizWithResultToolStripMenuItem.Text = "Export Result as an image with Graphviz";
            this.RunGraphvizWithResultToolStripMenuItem.Click += new System.EventHandler(this.OnRunGraphvizWithResultToolStripMenuItemClick);
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
        private System.Windows.Forms.ToolStripMenuItem WhatIsGraphvizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigureGraphvizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunGraphvizWithResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownloadGraphvizToolStripMenuItem;
    }
}

