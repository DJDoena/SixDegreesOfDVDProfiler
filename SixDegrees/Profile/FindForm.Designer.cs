namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler.Profile
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
            System.Windows.Forms.Label LeftTitleLabel;
            System.Windows.Forms.GroupBox RightGroupBox;
            System.Windows.Forms.Label RightTitleLabel;
            System.Windows.Forms.Label MaxSearchDepthLabel;
            System.Windows.Forms.Label label2;
            this.LeftLookupButton = new System.Windows.Forms.Button();
            this.LeftTitleTextBox = new System.Windows.Forms.TextBox();
            this.RightLookupButton = new System.Windows.Forms.Button();
            this.RightTitleTextBox = new System.Windows.Forms.TextBox();
            this.IncludeCastCheckBox = new System.Windows.Forms.CheckBox();
            this.IncludeCrewCheckBox = new System.Windows.Forms.CheckBox();
            this.MaxSearchDepthUpDown = new System.Windows.Forms.NumericUpDown();
            this.StartShortSearchButton = new System.Windows.Forms.Button();
            this.OnlyIncludeOwnedProfilesCheckBox = new System.Windows.Forms.CheckBox();
            this.ProfilesLoadedLabel = new System.Windows.Forms.Label();
            LoadXmlButton = new System.Windows.Forms.Button();
            LeftGroupBox = new System.Windows.Forms.GroupBox();
            LeftTitleLabel = new System.Windows.Forms.Label();
            RightGroupBox = new System.Windows.Forms.GroupBox();
            RightTitleLabel = new System.Windows.Forms.Label();
            MaxSearchDepthLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            LeftGroupBox.SuspendLayout();
            RightGroupBox.SuspendLayout();
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
            LeftGroupBox.Controls.Add(this.LeftLookupButton);
            LeftGroupBox.Controls.Add(LeftTitleLabel);
            LeftGroupBox.Controls.Add(this.LeftTitleTextBox);
            LeftGroupBox.Location = new System.Drawing.Point(12, 162);
            LeftGroupBox.Name = "LeftGroupBox";
            LeftGroupBox.Size = new System.Drawing.Size(325, 81);
            LeftGroupBox.TabIndex = 11;
            LeftGroupBox.TabStop = false;
            // 
            // LeftLookupTitleButton
            // 
            this.LeftLookupButton.Location = new System.Drawing.Point(105, 45);
            this.LeftLookupButton.Name = "LeftLookupTitleButton";
            this.LeftLookupButton.Size = new System.Drawing.Size(200, 23);
            this.LeftLookupButton.TabIndex = 9;
            this.LeftLookupButton.Text = "Look up title";
            this.LeftLookupButton.UseVisualStyleBackColor = true;
            this.LeftLookupButton.Click += new System.EventHandler(this.OnLeftLookupButtonClick);
            // 
            // LeftTitleLabel
            // 
            LeftTitleLabel.AutoSize = true;
            LeftTitleLabel.Location = new System.Drawing.Point(6, 22);
            LeftTitleLabel.Name = "LeftTitleLabel";
            LeftTitleLabel.Size = new System.Drawing.Size(27, 13);
            LeftTitleLabel.TabIndex = 0;
            LeftTitleLabel.Text = "Title";
            // 
            // LeftTitleTextBox
            // 
            this.LeftTitleTextBox.Location = new System.Drawing.Point(105, 19);
            this.LeftTitleTextBox.Name = "LeftTitleTextBox";
            this.LeftTitleTextBox.Size = new System.Drawing.Size(200, 20);
            this.LeftTitleTextBox.TabIndex = 1;
            // 
            // RightGroupBox
            // 
            RightGroupBox.Controls.Add(this.RightLookupButton);
            RightGroupBox.Controls.Add(RightTitleLabel);
            RightGroupBox.Controls.Add(this.RightTitleTextBox);
            RightGroupBox.Location = new System.Drawing.Point(343, 162);
            RightGroupBox.Name = "RightGroupBox";
            RightGroupBox.Size = new System.Drawing.Size(325, 81);
            RightGroupBox.TabIndex = 12;
            RightGroupBox.TabStop = false;
            // 
            // RightLookupTitleButton
            // 
            this.RightLookupButton.Location = new System.Drawing.Point(105, 45);
            this.RightLookupButton.Name = "RightLookupTitleButton";
            this.RightLookupButton.Size = new System.Drawing.Size(200, 23);
            this.RightLookupButton.TabIndex = 9;
            this.RightLookupButton.Text = "Look up title";
            this.RightLookupButton.UseVisualStyleBackColor = true;
            this.RightLookupButton.Click += new System.EventHandler(this.OnRightLookupButtonClick);
            // 
            // RightTitleLabel
            // 
            RightTitleLabel.AutoSize = true;
            RightTitleLabel.Location = new System.Drawing.Point(6, 22);
            RightTitleLabel.Name = "RightTitleLabel";
            RightTitleLabel.Size = new System.Drawing.Size(30, 13);
            RightTitleLabel.TabIndex = 0;
            RightTitleLabel.Text = "Title:";
            // 
            // RightTitleTextBox
            // 
            this.RightTitleTextBox.Location = new System.Drawing.Point(105, 19);
            this.RightTitleTextBox.Name = "RightTitleTextBox";
            this.RightTitleTextBox.Size = new System.Drawing.Size(200, 20);
            this.RightTitleTextBox.TabIndex = 1;
            // 
            // MaxSearchDepthLabel
            // 
            MaxSearchDepthLabel.AutoSize = true;
            MaxSearchDepthLabel.Location = new System.Drawing.Point(9, 258);
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
            this.MaxSearchDepthUpDown.Location = new System.Drawing.Point(117, 256);
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
            this.StartShortSearchButton.Location = new System.Drawing.Point(12, 282);
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
            this.ClientSize = new System.Drawing.Size(709, 336);
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
            this.MaximumSize = new System.Drawing.Size(725, 375);
            this.MinimumSize = new System.Drawing.Size(725, 375);
            this.Name = "FindForm";
            this.Text = "Six Degrees of DVD Profiler";
            LeftGroupBox.ResumeLayout(false);
            LeftGroupBox.PerformLayout();
            RightGroupBox.ResumeLayout(false);
            RightGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSearchDepthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox IncludeCastCheckBox;
        private System.Windows.Forms.CheckBox IncludeCrewCheckBox;
        private System.Windows.Forms.TextBox LeftTitleTextBox;
        private System.Windows.Forms.TextBox RightTitleTextBox;
        private System.Windows.Forms.NumericUpDown MaxSearchDepthUpDown;
        private System.Windows.Forms.Button LeftLookupButton;
        private System.Windows.Forms.Button RightLookupButton;
        private System.Windows.Forms.Button StartShortSearchButton;
        private System.Windows.Forms.CheckBox OnlyIncludeOwnedProfilesCheckBox;
        private System.Windows.Forms.Label ProfilesLoadedLabel;
    }
}

