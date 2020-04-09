namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    partial class LookUpNameForm
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
            System.Windows.Forms.ColumnHeader FirstNameColumn;
            System.Windows.Forms.ColumnHeader MiddleNameColumn;
            System.Windows.Forms.ColumnHeader LastNameColumn;
            System.Windows.Forms.ColumnHeader BirthYearColumn;
            System.Windows.Forms.Button LookupNameButton;
            System.Windows.Forms.Label BirthYearLabel;
            System.Windows.Forms.Label LastNameLabel;
            System.Windows.Forms.Label MiddleNameLabel;
            System.Windows.Forms.Label FirstNameLabel;
            System.Windows.Forms.Button ChooseButton;
            System.Windows.Forms.Button AbortButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LookUpNameForm));
            this.BirthYearUpDown = new System.Windows.Forms.NumericUpDown();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.MiddleNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.ResultListView = new System.Windows.Forms.ListView();
            this.ResetBirthYearCheckBox = new System.Windows.Forms.CheckBox();
            FirstNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            MiddleNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            LastNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            BirthYearColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            LookupNameButton = new System.Windows.Forms.Button();
            BirthYearLabel = new System.Windows.Forms.Label();
            LastNameLabel = new System.Windows.Forms.Label();
            MiddleNameLabel = new System.Windows.Forms.Label();
            FirstNameLabel = new System.Windows.Forms.Label();
            ChooseButton = new System.Windows.Forms.Button();
            AbortButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BirthYearUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstNameColumn
            // 
            FirstNameColumn.Text = "First (given) name";
            FirstNameColumn.Width = 150;
            // 
            // MiddleNameColumn
            // 
            MiddleNameColumn.Text = "Middle name";
            MiddleNameColumn.Width = 150;
            // 
            // LastNameColumn
            // 
            LastNameColumn.Text = "Last name";
            LastNameColumn.Width = 150;
            // 
            // BirthYearColumn
            // 
            BirthYearColumn.Text = "Birth year";
            // 
            // LookupNameButton
            // 
            LookupNameButton.Location = new System.Drawing.Point(111, 116);
            LookupNameButton.Name = "LookupNameButton";
            LookupNameButton.Size = new System.Drawing.Size(200, 23);
            LookupNameButton.TabIndex = 9;
            LookupNameButton.Text = "Look up name";
            LookupNameButton.UseVisualStyleBackColor = true;
            LookupNameButton.Click += new System.EventHandler(this.OnLookupNameButtonClick);
            // 
            // BirthYearLabel
            // 
            BirthYearLabel.AutoSize = true;
            BirthYearLabel.Location = new System.Drawing.Point(12, 92);
            BirthYearLabel.Name = "BirthYearLabel";
            BirthYearLabel.Size = new System.Drawing.Size(54, 13);
            BirthYearLabel.TabIndex = 6;
            BirthYearLabel.Text = "Birth year:";
            // 
            // LastNameLabel
            // 
            LastNameLabel.AutoSize = true;
            LastNameLabel.Location = new System.Drawing.Point(12, 67);
            LastNameLabel.Name = "LastNameLabel";
            LastNameLabel.Size = new System.Drawing.Size(59, 13);
            LastNameLabel.TabIndex = 4;
            LastNameLabel.Text = "Last name:";
            // 
            // MiddleNameLabel
            // 
            MiddleNameLabel.AutoSize = true;
            MiddleNameLabel.Location = new System.Drawing.Point(12, 41);
            MiddleNameLabel.Name = "MiddleNameLabel";
            MiddleNameLabel.Size = new System.Drawing.Size(70, 13);
            MiddleNameLabel.TabIndex = 2;
            MiddleNameLabel.Text = "Middle name:";
            // 
            // FirstNameLabel
            // 
            FirstNameLabel.AutoSize = true;
            FirstNameLabel.Location = new System.Drawing.Point(12, 15);
            FirstNameLabel.Name = "FirstNameLabel";
            FirstNameLabel.Size = new System.Drawing.Size(93, 13);
            FirstNameLabel.TabIndex = 0;
            FirstNameLabel.Text = "First (given) name:";
            // 
            // ChooseButton
            // 
            ChooseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            ChooseButton.Location = new System.Drawing.Point(336, 366);
            ChooseButton.Name = "ChooseButton";
            ChooseButton.Size = new System.Drawing.Size(145, 23);
            ChooseButton.TabIndex = 11;
            ChooseButton.Text = "Choose selected person";
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
            // BirthYearUpDown
            // 
            this.BirthYearUpDown.Location = new System.Drawing.Point(111, 90);
            this.BirthYearUpDown.Name = "BirthYearUpDown";
            this.BirthYearUpDown.Size = new System.Drawing.Size(112, 20);
            this.BirthYearUpDown.TabIndex = 7;
            this.BirthYearUpDown.ValueChanged += new System.EventHandler(this.OnBirthYearUpDownValueChanged);
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(111, 64);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.LastNameTextBox.TabIndex = 5;
            // 
            // MiddleNameTextBox
            // 
            this.MiddleNameTextBox.Location = new System.Drawing.Point(111, 38);
            this.MiddleNameTextBox.Name = "MiddleNameTextBox";
            this.MiddleNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.MiddleNameTextBox.TabIndex = 3;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(111, 12);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.FirstNameTextBox.TabIndex = 1;
            // 
            // ResultListView
            // 
            this.ResultListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            FirstNameColumn,
            MiddleNameColumn,
            LastNameColumn,
            BirthYearColumn});
            this.ResultListView.FullRowSelect = true;
            this.ResultListView.HideSelection = false;
            this.ResultListView.Location = new System.Drawing.Point(12, 160);
            this.ResultListView.MultiSelect = false;
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(550, 200);
            this.ResultListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ResultListView.TabIndex = 10;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            this.ResultListView.View = System.Windows.Forms.View.Details;
            this.ResultListView.DoubleClick += new System.EventHandler(this.OnResultListViewDoubleClick);
            // 
            // ResetBirthYearCheckBox
            // 
            this.ResetBirthYearCheckBox.AutoSize = true;
            this.ResetBirthYearCheckBox.Checked = true;
            this.ResetBirthYearCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ResetBirthYearCheckBox.Location = new System.Drawing.Point(229, 91);
            this.ResetBirthYearCheckBox.Name = "ResetBirthYearCheckBox";
            this.ResetBirthYearCheckBox.Size = new System.Drawing.Size(82, 17);
            this.ResetBirthYearCheckBox.TabIndex = 8;
            this.ResetBirthYearCheckBox.Text = "(0 = not set)";
            this.ResetBirthYearCheckBox.UseVisualStyleBackColor = true;
            this.ResetBirthYearCheckBox.CheckedChanged += new System.EventHandler(this.OnResetBirthYearCheckBoxCheckedChanged);
            // 
            // LookUpNameForm
            // 
            this.AcceptButton = ChooseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = AbortButton;
            this.ClientSize = new System.Drawing.Size(584, 406);
            this.Controls.Add(this.ResetBirthYearCheckBox);
            this.Controls.Add(AbortButton);
            this.Controls.Add(ChooseButton);
            this.Controls.Add(this.ResultListView);
            this.Controls.Add(LookupNameButton);
            this.Controls.Add(BirthYearLabel);
            this.Controls.Add(LastNameLabel);
            this.Controls.Add(MiddleNameLabel);
            this.Controls.Add(FirstNameLabel);
            this.Controls.Add(this.BirthYearUpDown);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.MiddleNameTextBox);
            this.Controls.Add(this.FirstNameTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 445);
            this.Name = "LookUpNameForm";
            this.Text = "Six Degrees of DVD Profiler: Look up Name";
            ((System.ComponentModel.ISupportInitialize)(this.BirthYearUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown BirthYearUpDown;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox MiddleNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.ListView ResultListView;
        private System.Windows.Forms.CheckBox ResetBirthYearCheckBox;
    }
}

