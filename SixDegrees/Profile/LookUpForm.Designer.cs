namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler.Profile
{
    partial class LookUpForm
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
            System.Windows.Forms.ColumnHeader TitleColumn;
            System.Windows.Forms.ColumnHeader OriginalTitleColumn;
            System.Windows.Forms.ColumnHeader ProductionYearColumn;
            System.Windows.Forms.Button LookupTitleButton;
            System.Windows.Forms.Label FirstNameLabel;
            System.Windows.Forms.Button ChooseButton;
            System.Windows.Forms.Button AbortButton;
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.ResultListView = new System.Windows.Forms.ListView();
            TitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            OriginalTitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ProductionYearColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            LookupTitleButton = new System.Windows.Forms.Button();
            FirstNameLabel = new System.Windows.Forms.Label();
            ChooseButton = new System.Windows.Forms.Button();
            AbortButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleColumn
            // 
            TitleColumn.Text = "Title";
            TitleColumn.Width = 150;
            // 
            // OriginalTitleColumn
            // 
            OriginalTitleColumn.Text = "Original title";
            OriginalTitleColumn.Width = 150;
            // 
            // ProductionYearColumn
            // 
            ProductionYearColumn.Text = "Production year";
            ProductionYearColumn.Width = 150;
            // 
            // LookupTitleButton
            // 
            LookupTitleButton.Location = new System.Drawing.Point(48, 38);
            LookupTitleButton.Name = "LookupTitleButton";
            LookupTitleButton.Size = new System.Drawing.Size(263, 23);
            LookupTitleButton.TabIndex = 9;
            LookupTitleButton.Text = "Look up title";
            LookupTitleButton.UseVisualStyleBackColor = true;
            LookupTitleButton.Click += new System.EventHandler(this.OnLookupNameButtonClick);
            // 
            // FirstNameLabel
            // 
            FirstNameLabel.AutoSize = true;
            FirstNameLabel.Location = new System.Drawing.Point(12, 15);
            FirstNameLabel.Name = "FirstNameLabel";
            FirstNameLabel.Size = new System.Drawing.Size(30, 13);
            FirstNameLabel.TabIndex = 0;
            FirstNameLabel.Text = "Title:";
            // 
            // ChooseButton
            // 
            ChooseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            ChooseButton.Location = new System.Drawing.Point(336, 366);
            ChooseButton.Name = "ChooseButton";
            ChooseButton.Size = new System.Drawing.Size(145, 23);
            ChooseButton.TabIndex = 11;
            ChooseButton.Text = "Choose selected title";
            ChooseButton.UseVisualStyleBackColor = true;
            ChooseButton.Click += new System.EventHandler(this.OnChooseButtonClick);
            // 
            // AbortButton
            // 
            AbortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            AbortButton.Location = new System.Drawing.Point(487, 366);
            AbortButton.Name = "AbortButton";
            AbortButton.Size = new System.Drawing.Size(75, 23);
            AbortButton.TabIndex = 12;
            AbortButton.Text = "Cancel";
            AbortButton.UseVisualStyleBackColor = true;
            AbortButton.Click += new System.EventHandler(this.OnAbortButtonClick);
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(48, 12);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(263, 20);
            this.TitleTextBox.TabIndex = 1;
            // 
            // ResultListView
            // 
            this.ResultListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            TitleColumn,
            OriginalTitleColumn,
            ProductionYearColumn});
            this.ResultListView.FullRowSelect = true;
            this.ResultListView.HideSelection = false;
            this.ResultListView.Location = new System.Drawing.Point(12, 67);
            this.ResultListView.MultiSelect = false;
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(550, 293);
            this.ResultListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ResultListView.TabIndex = 10;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            this.ResultListView.View = System.Windows.Forms.View.Details;
            this.ResultListView.DoubleClick += new System.EventHandler(this.OnResultListViewDoubleClick);
            // 
            // LookUpTitleForm
            // 
            this.AcceptButton = ChooseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = AbortButton;
            this.ClientSize = new System.Drawing.Size(584, 406);
            this.Controls.Add(AbortButton);
            this.Controls.Add(ChooseButton);
            this.Controls.Add(this.ResultListView);
            this.Controls.Add(LookupTitleButton);
            this.Controls.Add(FirstNameLabel);
            this.Controls.Add(this.TitleTextBox);
            this.MinimumSize = new System.Drawing.Size(600, 445);
            this.Name = "LookUpTitleForm";
            this.Text = "Six Degrees of DVD Profiler: Look up Title";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.ListView ResultListView;
    }
}

