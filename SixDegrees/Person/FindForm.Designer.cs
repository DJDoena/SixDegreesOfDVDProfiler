﻿namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler.Person
{
    partial class FindForm
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
            System.Windows.Forms.Button LoadXmlButton;
            System.Windows.Forms.GroupBox LeftGroupBox;
            System.Windows.Forms.Label LeftBirthYearLabel;
            System.Windows.Forms.Label LeftLastNameLabel;
            System.Windows.Forms.Label LeftMiddleNameLabel;
            System.Windows.Forms.Label LeftFirstNameLabel;
            System.Windows.Forms.GroupBox RightGroupBox;
            System.Windows.Forms.Label RightBirthYearLabel;
            System.Windows.Forms.Label RightLastNameLabel;
            System.Windows.Forms.Label RightMiddleNameLabel;
            System.Windows.Forms.Label RightFirstNameLabel;
            System.Windows.Forms.Label MaxSearchDepthLabel;
            System.Windows.Forms.Label label2;
            this.LeftResetBirthYearCheckBox = new System.Windows.Forms.CheckBox();
            this.LeftBirthYearUpDown = new System.Windows.Forms.NumericUpDown();
            this.LeftLookupButton = new System.Windows.Forms.Button();
            this.LeftLastNameTextBox = new System.Windows.Forms.TextBox();
            this.LeftMiddleNameTextBox = new System.Windows.Forms.TextBox();
            this.LeftFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.RightResetBirthYearCheckBox = new System.Windows.Forms.CheckBox();
            this.RightBirthYearUpDown = new System.Windows.Forms.NumericUpDown();
            this.RightLookupButton = new System.Windows.Forms.Button();
            this.RightLastNameTextBox = new System.Windows.Forms.TextBox();
            this.RightMiddleNameTextBox = new System.Windows.Forms.TextBox();
            this.RightFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.IncludeCastCheckBox = new System.Windows.Forms.CheckBox();
            this.IncludeCrewCheckBox = new System.Windows.Forms.CheckBox();
            this.MaxSearchDepthUpDown = new System.Windows.Forms.NumericUpDown();
            this.StartShortSearchButton = new System.Windows.Forms.Button();
            this.OnlyIncludeOwnedProfilesCheckBox = new System.Windows.Forms.CheckBox();
            this.ProfilesLoadedLabel = new System.Windows.Forms.Label();
            LoadXmlButton = new System.Windows.Forms.Button();
            LeftGroupBox = new System.Windows.Forms.GroupBox();
            LeftBirthYearLabel = new System.Windows.Forms.Label();
            LeftLastNameLabel = new System.Windows.Forms.Label();
            LeftMiddleNameLabel = new System.Windows.Forms.Label();
            LeftFirstNameLabel = new System.Windows.Forms.Label();
            RightGroupBox = new System.Windows.Forms.GroupBox();
            RightBirthYearLabel = new System.Windows.Forms.Label();
            RightLastNameLabel = new System.Windows.Forms.Label();
            RightMiddleNameLabel = new System.Windows.Forms.Label();
            RightFirstNameLabel = new System.Windows.Forms.Label();
            MaxSearchDepthLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            LeftGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftBirthYearUpDown)).BeginInit();
            RightGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightBirthYearUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSearchDepthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadXmlButton
            // 
            LoadXmlButton.Location = new System.Drawing.Point(12, 96);
            LoadXmlButton.Name = "LoadXmlButton";
            LoadXmlButton.Size = new System.Drawing.Size(175, 23);
            LoadXmlButton.TabIndex = 8;
            LoadXmlButton.Text = "Load DVD Profiler XML file";
            LoadXmlButton.UseVisualStyleBackColor = true;
            LoadXmlButton.Click += new System.EventHandler(this.OnLoadXmlButtonClick);
            // 
            // LeftGroupBox
            // 
            LeftGroupBox.Controls.Add(this.LeftResetBirthYearCheckBox);
            LeftGroupBox.Controls.Add(this.LeftBirthYearUpDown);
            LeftGroupBox.Controls.Add(this.LeftLookupButton);
            LeftGroupBox.Controls.Add(LeftBirthYearLabel);
            LeftGroupBox.Controls.Add(LeftLastNameLabel);
            LeftGroupBox.Controls.Add(LeftMiddleNameLabel);
            LeftGroupBox.Controls.Add(LeftFirstNameLabel);
            LeftGroupBox.Controls.Add(this.LeftLastNameTextBox);
            LeftGroupBox.Controls.Add(this.LeftMiddleNameTextBox);
            LeftGroupBox.Controls.Add(this.LeftFirstNameTextBox);
            LeftGroupBox.Location = new System.Drawing.Point(12, 162);
            LeftGroupBox.Name = "LeftGroupBox";
            LeftGroupBox.Size = new System.Drawing.Size(325, 160);
            LeftGroupBox.TabIndex = 11;
            LeftGroupBox.TabStop = false;
            LeftGroupBox.Text = "Left person";
            // 
            // LeftResetBirthYearCheckBox
            // 
            this.LeftResetBirthYearCheckBox.AutoSize = true;
            this.LeftResetBirthYearCheckBox.Checked = true;
            this.LeftResetBirthYearCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LeftResetBirthYearCheckBox.Location = new System.Drawing.Point(223, 98);
            this.LeftResetBirthYearCheckBox.Name = "LeftResetBirthYearCheckBox";
            this.LeftResetBirthYearCheckBox.Size = new System.Drawing.Size(82, 17);
            this.LeftResetBirthYearCheckBox.TabIndex = 8;
            this.LeftResetBirthYearCheckBox.Text = "(0 = not set)";
            this.LeftResetBirthYearCheckBox.UseVisualStyleBackColor = true;
            this.LeftResetBirthYearCheckBox.CheckedChanged += new System.EventHandler(this.OnLeftResetBirthYearCheckBoxCheckedChanged);
            // 
            // LeftBirthYearUpDown
            // 
            this.LeftBirthYearUpDown.Location = new System.Drawing.Point(105, 97);
            this.LeftBirthYearUpDown.Name = "LeftBirthYearUpDown";
            this.LeftBirthYearUpDown.Size = new System.Drawing.Size(112, 20);
            this.LeftBirthYearUpDown.TabIndex = 7;
            this.LeftBirthYearUpDown.ValueChanged += new System.EventHandler(this.OnLeftBirthYearUpDownValueChanged);
            // 
            // LeftLookupNameButton
            // 
            this.LeftLookupButton.Location = new System.Drawing.Point(105, 123);
            this.LeftLookupButton.Name = "LeftLookupNameButton";
            this.LeftLookupButton.Size = new System.Drawing.Size(200, 23);
            this.LeftLookupButton.TabIndex = 9;
            this.LeftLookupButton.Text = "Look up name";
            this.LeftLookupButton.UseVisualStyleBackColor = true;
            this.LeftLookupButton.Click += new System.EventHandler(this.OnLeftLookupButtonClick);
            // 
            // LeftBirthYearLabel
            // 
            LeftBirthYearLabel.AutoSize = true;
            LeftBirthYearLabel.Location = new System.Drawing.Point(6, 99);
            LeftBirthYearLabel.Name = "LeftBirthYearLabel";
            LeftBirthYearLabel.Size = new System.Drawing.Size(54, 13);
            LeftBirthYearLabel.TabIndex = 6;
            LeftBirthYearLabel.Text = "Birth year:";
            // 
            // LeftLastNameLabel
            // 
            LeftLastNameLabel.AutoSize = true;
            LeftLastNameLabel.Location = new System.Drawing.Point(6, 74);
            LeftLastNameLabel.Name = "LeftLastNameLabel";
            LeftLastNameLabel.Size = new System.Drawing.Size(59, 13);
            LeftLastNameLabel.TabIndex = 4;
            LeftLastNameLabel.Text = "Last name:";
            // 
            // LeftMiddleNameLabel
            // 
            LeftMiddleNameLabel.AutoSize = true;
            LeftMiddleNameLabel.Location = new System.Drawing.Point(6, 48);
            LeftMiddleNameLabel.Name = "LeftMiddleNameLabel";
            LeftMiddleNameLabel.Size = new System.Drawing.Size(70, 13);
            LeftMiddleNameLabel.TabIndex = 2;
            LeftMiddleNameLabel.Text = "Middle name:";
            // 
            // LeftFirstNameLabel
            // 
            LeftFirstNameLabel.AutoSize = true;
            LeftFirstNameLabel.Location = new System.Drawing.Point(6, 22);
            LeftFirstNameLabel.Name = "LeftFirstNameLabel";
            LeftFirstNameLabel.Size = new System.Drawing.Size(93, 13);
            LeftFirstNameLabel.TabIndex = 0;
            LeftFirstNameLabel.Text = "First (given) name:";
            // 
            // LeftLastNameTextBox
            // 
            this.LeftLastNameTextBox.Location = new System.Drawing.Point(105, 71);
            this.LeftLastNameTextBox.Name = "LeftLastNameTextBox";
            this.LeftLastNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.LeftLastNameTextBox.TabIndex = 5;
            // 
            // LeftMiddleNameTextBox
            // 
            this.LeftMiddleNameTextBox.Location = new System.Drawing.Point(105, 45);
            this.LeftMiddleNameTextBox.Name = "LeftMiddleNameTextBox";
            this.LeftMiddleNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.LeftMiddleNameTextBox.TabIndex = 3;
            // 
            // LeftFirstNameTextBox
            // 
            this.LeftFirstNameTextBox.Location = new System.Drawing.Point(105, 19);
            this.LeftFirstNameTextBox.Name = "LeftFirstNameTextBox";
            this.LeftFirstNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.LeftFirstNameTextBox.TabIndex = 1;
            // 
            // RightGroupBox
            // 
            RightGroupBox.Controls.Add(this.RightResetBirthYearCheckBox);
            RightGroupBox.Controls.Add(this.RightBirthYearUpDown);
            RightGroupBox.Controls.Add(this.RightLookupButton);
            RightGroupBox.Controls.Add(RightBirthYearLabel);
            RightGroupBox.Controls.Add(RightLastNameLabel);
            RightGroupBox.Controls.Add(RightMiddleNameLabel);
            RightGroupBox.Controls.Add(RightFirstNameLabel);
            RightGroupBox.Controls.Add(this.RightLastNameTextBox);
            RightGroupBox.Controls.Add(this.RightMiddleNameTextBox);
            RightGroupBox.Controls.Add(this.RightFirstNameTextBox);
            RightGroupBox.Location = new System.Drawing.Point(343, 162);
            RightGroupBox.Name = "RightGroupBox";
            RightGroupBox.Size = new System.Drawing.Size(325, 160);
            RightGroupBox.TabIndex = 12;
            RightGroupBox.TabStop = false;
            RightGroupBox.Text = "Right person";
            // 
            // RightResetBirthYearCheckBox
            // 
            this.RightResetBirthYearCheckBox.AutoSize = true;
            this.RightResetBirthYearCheckBox.Checked = true;
            this.RightResetBirthYearCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RightResetBirthYearCheckBox.Location = new System.Drawing.Point(223, 98);
            this.RightResetBirthYearCheckBox.Name = "RightResetBirthYearCheckBox";
            this.RightResetBirthYearCheckBox.Size = new System.Drawing.Size(82, 17);
            this.RightResetBirthYearCheckBox.TabIndex = 8;
            this.RightResetBirthYearCheckBox.Text = "(0 = not set)";
            this.RightResetBirthYearCheckBox.UseVisualStyleBackColor = true;
            this.RightResetBirthYearCheckBox.CheckedChanged += new System.EventHandler(this.OnRightResetBirthYearCheckBoxCheckedChanged);
            // 
            // RightBirthYearUpDown
            // 
            this.RightBirthYearUpDown.Location = new System.Drawing.Point(105, 97);
            this.RightBirthYearUpDown.Name = "RightBirthYearUpDown";
            this.RightBirthYearUpDown.Size = new System.Drawing.Size(112, 20);
            this.RightBirthYearUpDown.TabIndex = 7;
            this.RightBirthYearUpDown.ValueChanged += new System.EventHandler(this.OnRightBirthYearUpDownValueChanged);
            // 
            // RightLookupNameButton
            // 
            this.RightLookupButton.Location = new System.Drawing.Point(105, 123);
            this.RightLookupButton.Name = "RightLookupNameButton";
            this.RightLookupButton.Size = new System.Drawing.Size(200, 23);
            this.RightLookupButton.TabIndex = 9;
            this.RightLookupButton.Text = "Look up name";
            this.RightLookupButton.UseVisualStyleBackColor = true;
            this.RightLookupButton.Click += new System.EventHandler(this.OnRightLookupButtonClick);
            // 
            // RightBirthYearLabel
            // 
            RightBirthYearLabel.AutoSize = true;
            RightBirthYearLabel.Location = new System.Drawing.Point(6, 99);
            RightBirthYearLabel.Name = "RightBirthYearLabel";
            RightBirthYearLabel.Size = new System.Drawing.Size(54, 13);
            RightBirthYearLabel.TabIndex = 6;
            RightBirthYearLabel.Text = "Birth year:";
            // 
            // RightLastNameLabel
            // 
            RightLastNameLabel.AutoSize = true;
            RightLastNameLabel.Location = new System.Drawing.Point(6, 74);
            RightLastNameLabel.Name = "RightLastNameLabel";
            RightLastNameLabel.Size = new System.Drawing.Size(59, 13);
            RightLastNameLabel.TabIndex = 4;
            RightLastNameLabel.Text = "Last name:";
            // 
            // RightMiddleNameLabel
            // 
            RightMiddleNameLabel.AutoSize = true;
            RightMiddleNameLabel.Location = new System.Drawing.Point(6, 48);
            RightMiddleNameLabel.Name = "RightMiddleNameLabel";
            RightMiddleNameLabel.Size = new System.Drawing.Size(70, 13);
            RightMiddleNameLabel.TabIndex = 2;
            RightMiddleNameLabel.Text = "Middle name:";
            // 
            // RightFirstNameLabel
            // 
            RightFirstNameLabel.AutoSize = true;
            RightFirstNameLabel.Location = new System.Drawing.Point(6, 22);
            RightFirstNameLabel.Name = "RightFirstNameLabel";
            RightFirstNameLabel.Size = new System.Drawing.Size(93, 13);
            RightFirstNameLabel.TabIndex = 0;
            RightFirstNameLabel.Text = "First (given) name:";
            // 
            // RightLastNameTextBox
            // 
            this.RightLastNameTextBox.Location = new System.Drawing.Point(105, 71);
            this.RightLastNameTextBox.Name = "RightLastNameTextBox";
            this.RightLastNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.RightLastNameTextBox.TabIndex = 5;
            // 
            // RightMiddleNameTextBox
            // 
            this.RightMiddleNameTextBox.Location = new System.Drawing.Point(105, 45);
            this.RightMiddleNameTextBox.Name = "RightMiddleNameTextBox";
            this.RightMiddleNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.RightMiddleNameTextBox.TabIndex = 3;
            // 
            // RightFirstNameTextBox
            // 
            this.RightFirstNameTextBox.Location = new System.Drawing.Point(105, 19);
            this.RightFirstNameTextBox.Name = "RightFirstNameTextBox";
            this.RightFirstNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.RightFirstNameTextBox.TabIndex = 1;
            // 
            // MaxSearchDepthLabel
            // 
            MaxSearchDepthLabel.AutoSize = true;
            MaxSearchDepthLabel.Location = new System.Drawing.Point(9, 344);
            MaxSearchDepthLabel.Name = "MaxSearchDepthLabel";
            MaxSearchDepthLabel.Size = new System.Drawing.Size(95, 13);
            MaxSearchDepthLabel.TabIndex = 13;
            MaxSearchDepthLabel.Text = "Max search depth:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 138);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(578, 13);
            label2.TabIndex = 10;
            label2.Text = "For performance reasons try to put the less relevant person on the left side. It\'" +
    "s easier to find the elephant than the mouse.";
            // 
            // IncludeCastCheckBox
            // 
            this.IncludeCastCheckBox.AutoSize = true;
            this.IncludeCastCheckBox.Checked = true;
            this.IncludeCastCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncludeCastCheckBox.Location = new System.Drawing.Point(12, 27);
            this.IncludeCastCheckBox.Name = "IncludeCastCheckBox";
            this.IncludeCastCheckBox.Size = new System.Drawing.Size(130, 17);
            this.IncludeCastCheckBox.TabIndex = 5;
            this.IncludeCastCheckBox.Text = "Include cast in search";
            this.IncludeCastCheckBox.UseVisualStyleBackColor = true;
            this.IncludeCastCheckBox.CheckedChanged += new System.EventHandler(this.OnIncludeCastCheckBoxCheckedChanged);
            // 
            // IncludeCrewCheckBox
            // 
            this.IncludeCrewCheckBox.AutoSize = true;
            this.IncludeCrewCheckBox.Location = new System.Drawing.Point(12, 50);
            this.IncludeCrewCheckBox.Name = "IncludeCrewCheckBox";
            this.IncludeCrewCheckBox.Size = new System.Drawing.Size(133, 17);
            this.IncludeCrewCheckBox.TabIndex = 6;
            this.IncludeCrewCheckBox.Text = "Include crew in search";
            this.IncludeCrewCheckBox.UseVisualStyleBackColor = true;
            this.IncludeCrewCheckBox.CheckedChanged += new System.EventHandler(this.OnIncludeCrewCheckBoxCheckedChanged);
            // 
            // MaxSearchDepthUpDown
            // 
            this.MaxSearchDepthUpDown.Location = new System.Drawing.Point(117, 342);
            this.MaxSearchDepthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxSearchDepthUpDown.Name = "MaxSearchDepthUpDown";
            this.MaxSearchDepthUpDown.Size = new System.Drawing.Size(120, 20);
            this.MaxSearchDepthUpDown.TabIndex = 14;
            this.MaxSearchDepthUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // StartShortSearchButton
            // 
            this.StartShortSearchButton.Location = new System.Drawing.Point(12, 368);
            this.StartShortSearchButton.Name = "StartShortSearchButton";
            this.StartShortSearchButton.Size = new System.Drawing.Size(225, 23);
            this.StartShortSearchButton.TabIndex = 15;
            this.StartShortSearchButton.Text = "Search shortest link";
            this.StartShortSearchButton.UseVisualStyleBackColor = true;
            this.StartShortSearchButton.Click += new System.EventHandler(this.OnStartShortSearchButtonClick);
            // 
            // OnlyIncludeOwnedProfilesCheckBox
            // 
            this.OnlyIncludeOwnedProfilesCheckBox.AutoSize = true;
            this.OnlyIncludeOwnedProfilesCheckBox.Checked = true;
            this.OnlyIncludeOwnedProfilesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OnlyIncludeOwnedProfilesCheckBox.Location = new System.Drawing.Point(12, 73);
            this.OnlyIncludeOwnedProfilesCheckBox.Name = "OnlyIncludeOwnedProfilesCheckBox";
            this.OnlyIncludeOwnedProfilesCheckBox.Size = new System.Drawing.Size(161, 17);
            this.OnlyIncludeOwnedProfilesCheckBox.TabIndex = 7;
            this.OnlyIncludeOwnedProfilesCheckBox.Text = "Only included owned profiles";
            this.OnlyIncludeOwnedProfilesCheckBox.UseVisualStyleBackColor = true;
            this.OnlyIncludeOwnedProfilesCheckBox.CheckedChanged += new System.EventHandler(this.OnOnlyIncludeOwnedProfilesCheckBoxCheckedChanged);
            // 
            // ProfilesLoadedLabel
            // 
            this.ProfilesLoadedLabel.AutoSize = true;
            this.ProfilesLoadedLabel.Location = new System.Drawing.Point(193, 101);
            this.ProfilesLoadedLabel.Name = "ProfilesLoadedLabel";
            this.ProfilesLoadedLabel.Size = new System.Drawing.Size(0, 13);
            this.ProfilesLoadedLabel.TabIndex = 9;
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 411);
            this.Controls.Add(this.ProfilesLoadedLabel);
            this.Controls.Add(label2);
            this.Controls.Add(this.OnlyIncludeOwnedProfilesCheckBox);
            this.Controls.Add(this.StartShortSearchButton);
            this.Controls.Add(MaxSearchDepthLabel);
            this.Controls.Add(this.MaxSearchDepthUpDown);
            this.Controls.Add(RightGroupBox);
            this.Controls.Add(LeftGroupBox);
            this.Controls.Add(this.IncludeCrewCheckBox);
            this.Controls.Add(this.IncludeCastCheckBox);
            this.Controls.Add(LoadXmlButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(725, 450);
            this.MinimumSize = new System.Drawing.Size(725, 450);
            this.Name = "FindForm";
            this.Text = "Six Degrees of DVD Profiler";
            LeftGroupBox.ResumeLayout(false);
            LeftGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftBirthYearUpDown)).EndInit();
            RightGroupBox.ResumeLayout(false);
            RightGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightBirthYearUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSearchDepthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox IncludeCastCheckBox;
        private System.Windows.Forms.CheckBox IncludeCrewCheckBox;
        private System.Windows.Forms.TextBox LeftFirstNameTextBox;
        private System.Windows.Forms.TextBox LeftLastNameTextBox;
        private System.Windows.Forms.TextBox LeftMiddleNameTextBox;
        private System.Windows.Forms.TextBox RightLastNameTextBox;
        private System.Windows.Forms.TextBox RightMiddleNameTextBox;
        private System.Windows.Forms.TextBox RightFirstNameTextBox;
        private System.Windows.Forms.NumericUpDown MaxSearchDepthUpDown;
        private System.Windows.Forms.Button LeftLookupButton;
        private System.Windows.Forms.Button RightLookupButton;
        private System.Windows.Forms.Button StartShortSearchButton;
        private System.Windows.Forms.CheckBox OnlyIncludeOwnedProfilesCheckBox;
        private System.Windows.Forms.CheckBox LeftResetBirthYearCheckBox;
        private System.Windows.Forms.NumericUpDown LeftBirthYearUpDown;
        private System.Windows.Forms.CheckBox RightResetBirthYearCheckBox;
        private System.Windows.Forms.NumericUpDown RightBirthYearUpDown;
        private System.Windows.Forms.Label ProfilesLoadedLabel;
    }
}

