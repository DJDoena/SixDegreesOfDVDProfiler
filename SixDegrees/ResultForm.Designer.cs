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
            DegreeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            StartingTitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            EndingTitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            TitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            LeftPersonNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            LeftPersonJobColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            RightPersonNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            RightPersonJobColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.ResultListView.Location = new System.Drawing.Point(12, 12);
            this.ResultListView.MultiSelect = false;
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(825, 190);
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
            this.StepsListView.Location = new System.Drawing.Point(12, 208);
            this.StepsListView.MultiSelect = false;
            this.StepsListView.Name = "StepsListView";
            this.StepsListView.Size = new System.Drawing.Size(825, 266);
            this.StepsListView.TabIndex = 1;
            this.StepsListView.UseCompatibleStateImageBehavior = false;
            this.StepsListView.View = System.Windows.Forms.View.Details;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 486);
            this.Controls.Add(this.StepsListView);
            this.Controls.Add(this.ResultListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(865, 525);
            this.Name = "ResultForm";
            this.Text = "Six Degrees of DVD Profiler: Result";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnResultFormFormClosing);
            this.Load += new System.EventHandler(this.OnResultFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ResultListView;
        private System.Windows.Forms.ListView StepsListView;
    }
}

