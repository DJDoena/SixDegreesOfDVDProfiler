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
            System.Windows.Forms.Button LoadXmlButton;
            System.Windows.Forms.Label WelcomeLabel;
            System.Windows.Forms.Label InfoLabel;
            System.Windows.Forms.GroupBox LeftGroupBox;
            System.Windows.Forms.Label LeftBirthYearLabel;
            System.Windows.Forms.Label LeftLastNameLabel;
            System.Windows.Forms.Label LeftMiddleNameLabel;
            System.Windows.Forms.Label LeftFirstNameLabel;
            System.Windows.Forms.Label LeftBirthYearInfoLabel;
            System.Windows.Forms.GroupBox RightGroupBox;
            System.Windows.Forms.Label RightBirthYearLabel;
            System.Windows.Forms.Label RightLastNameLabel;
            System.Windows.Forms.Label RightMiddleNameLabel;
            System.Windows.Forms.Label RightFirstNameLabel;
            System.Windows.Forms.Label RightBirthYearInfoLabel;
            System.Windows.Forms.Label MaxSearchDepthLabel;
            System.Windows.Forms.LinkLabel KevinBaconLinkLabel;
            System.Windows.Forms.LinkLabel SixDegreesLinkLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LeftLookupNameButton = new System.Windows.Forms.Button();
            this.LeftBirthYearUpDown = new System.Windows.Forms.NumericUpDown();
            this.LeftLastNameTextBox = new System.Windows.Forms.TextBox();
            this.LeftMiddleNameTextBox = new System.Windows.Forms.TextBox();
            this.LeftFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.RightLookupNameButton = new System.Windows.Forms.Button();
            this.RightBirthYearUpDown = new System.Windows.Forms.NumericUpDown();
            this.RightLastNameTextBox = new System.Windows.Forms.TextBox();
            this.RightMiddleNameTextBox = new System.Windows.Forms.TextBox();
            this.RightFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.IncludeCastCheckBox = new System.Windows.Forms.CheckBox();
            this.IncludeCrewCheckBox = new System.Windows.Forms.CheckBox();
            this.MaxSearchDepthUpDown = new System.Windows.Forms.NumericUpDown();
            this.StartShortSearchButton = new System.Windows.Forms.Button();
            this.StartLongSearchButton = new System.Windows.Forms.Button();
            this.OnlyIncludeOwnedProfilesCheckBox = new System.Windows.Forms.CheckBox();
            LoadXmlButton = new System.Windows.Forms.Button();
            WelcomeLabel = new System.Windows.Forms.Label();
            InfoLabel = new System.Windows.Forms.Label();
            LeftGroupBox = new System.Windows.Forms.GroupBox();
            LeftBirthYearLabel = new System.Windows.Forms.Label();
            LeftLastNameLabel = new System.Windows.Forms.Label();
            LeftMiddleNameLabel = new System.Windows.Forms.Label();
            LeftFirstNameLabel = new System.Windows.Forms.Label();
            LeftBirthYearInfoLabel = new System.Windows.Forms.Label();
            RightGroupBox = new System.Windows.Forms.GroupBox();
            RightBirthYearLabel = new System.Windows.Forms.Label();
            RightLastNameLabel = new System.Windows.Forms.Label();
            RightMiddleNameLabel = new System.Windows.Forms.Label();
            RightFirstNameLabel = new System.Windows.Forms.Label();
            RightBirthYearInfoLabel = new System.Windows.Forms.Label();
            MaxSearchDepthLabel = new System.Windows.Forms.Label();
            KevinBaconLinkLabel = new System.Windows.Forms.LinkLabel();
            SixDegreesLinkLabel = new System.Windows.Forms.LinkLabel();
            LeftGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftBirthYearUpDown)).BeginInit();
            RightGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightBirthYearUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSearchDepthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadXmlButton
            // 
            LoadXmlButton.Location = new System.Drawing.Point(12, 155);
            LoadXmlButton.Name = "LoadXmlButton";
            LoadXmlButton.Size = new System.Drawing.Size(175, 23);
            LoadXmlButton.TabIndex = 6;
            LoadXmlButton.Text = "Load DVD Profiler XML file";
            LoadXmlButton.UseVisualStyleBackColor = true;
            LoadXmlButton.Click += new System.EventHandler(this.OnLoadXmlButtonClick);
            // 
            // WelcomeLabel
            // 
            WelcomeLabel.AutoSize = true;
            WelcomeLabel.Location = new System.Drawing.Point(9, 9);
            WelcomeLabel.Name = "WelcomeLabel";
            WelcomeLabel.Size = new System.Drawing.Size(210, 13);
            WelcomeLabel.TabIndex = 0;
            WelcomeLabel.Text = "Welcome to \"Six Degrees of DVD Profiler\".";
            // 
            // InfoLabel
            // 
            InfoLabel.AutoSize = true;
            InfoLabel.Location = new System.Drawing.Point(9, 30);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new System.Drawing.Size(655, 13);
            InfoLabel.TabIndex = 1;
            InfoLabel.Text = "This program is based on the idea of \"Six Degrees of Kevin Bacon\" which is in tur" +
    "n based on the concept of \"Six Degrees of Separation\".";
            // 
            // LeftGroupBox
            // 
            LeftGroupBox.Controls.Add(this.LeftLookupNameButton);
            LeftGroupBox.Controls.Add(LeftBirthYearLabel);
            LeftGroupBox.Controls.Add(LeftLastNameLabel);
            LeftGroupBox.Controls.Add(LeftMiddleNameLabel);
            LeftGroupBox.Controls.Add(LeftFirstNameLabel);
            LeftGroupBox.Controls.Add(LeftBirthYearInfoLabel);
            LeftGroupBox.Controls.Add(this.LeftBirthYearUpDown);
            LeftGroupBox.Controls.Add(this.LeftLastNameTextBox);
            LeftGroupBox.Controls.Add(this.LeftMiddleNameTextBox);
            LeftGroupBox.Controls.Add(this.LeftFirstNameTextBox);
            LeftGroupBox.Location = new System.Drawing.Point(12, 200);
            LeftGroupBox.Name = "LeftGroupBox";
            LeftGroupBox.Size = new System.Drawing.Size(325, 160);
            LeftGroupBox.TabIndex = 8;
            LeftGroupBox.TabStop = false;
            LeftGroupBox.Text = "Left person";
            // 
            // LeftLookupNameButton
            // 
            this.LeftLookupNameButton.Location = new System.Drawing.Point(105, 123);
            this.LeftLookupNameButton.Name = "LeftLookupNameButton";
            this.LeftLookupNameButton.Size = new System.Drawing.Size(200, 23);
            this.LeftLookupNameButton.TabIndex = 9;
            this.LeftLookupNameButton.Text = "Look up name";
            this.LeftLookupNameButton.UseVisualStyleBackColor = true;
            this.LeftLookupNameButton.Click += new System.EventHandler(this.OnLeftLookupNameButtonClick);
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
            // LeftBirthYearInfoLabel
            // 
            LeftBirthYearInfoLabel.AutoSize = true;
            LeftBirthYearInfoLabel.Location = new System.Drawing.Point(242, 99);
            LeftBirthYearInfoLabel.Name = "LeftBirthYearInfoLabel";
            LeftBirthYearInfoLabel.Size = new System.Drawing.Size(63, 13);
            LeftBirthYearInfoLabel.TabIndex = 8;
            LeftBirthYearInfoLabel.Text = "(0 = not set)";
            // 
            // LeftBirthYearUpDown
            // 
            this.LeftBirthYearUpDown.Location = new System.Drawing.Point(105, 97);
            this.LeftBirthYearUpDown.Name = "LeftBirthYearUpDown";
            this.LeftBirthYearUpDown.Size = new System.Drawing.Size(131, 20);
            this.LeftBirthYearUpDown.TabIndex = 7;
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
            RightGroupBox.Controls.Add(this.RightLookupNameButton);
            RightGroupBox.Controls.Add(RightBirthYearLabel);
            RightGroupBox.Controls.Add(RightLastNameLabel);
            RightGroupBox.Controls.Add(RightMiddleNameLabel);
            RightGroupBox.Controls.Add(RightFirstNameLabel);
            RightGroupBox.Controls.Add(RightBirthYearInfoLabel);
            RightGroupBox.Controls.Add(this.RightBirthYearUpDown);
            RightGroupBox.Controls.Add(this.RightLastNameTextBox);
            RightGroupBox.Controls.Add(this.RightMiddleNameTextBox);
            RightGroupBox.Controls.Add(this.RightFirstNameTextBox);
            RightGroupBox.Location = new System.Drawing.Point(343, 200);
            RightGroupBox.Name = "RightGroupBox";
            RightGroupBox.Size = new System.Drawing.Size(325, 160);
            RightGroupBox.TabIndex = 9;
            RightGroupBox.TabStop = false;
            RightGroupBox.Text = "Right person";
            // 
            // RightLookupNameButton
            // 
            this.RightLookupNameButton.Location = new System.Drawing.Point(105, 123);
            this.RightLookupNameButton.Name = "RightLookupNameButton";
            this.RightLookupNameButton.Size = new System.Drawing.Size(200, 23);
            this.RightLookupNameButton.TabIndex = 9;
            this.RightLookupNameButton.Text = "Look up name";
            this.RightLookupNameButton.UseVisualStyleBackColor = true;
            this.RightLookupNameButton.Click += new System.EventHandler(this.OnRightLookupNameButtonClick);
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
            // RightBirthYearInfoLabel
            // 
            RightBirthYearInfoLabel.AutoSize = true;
            RightBirthYearInfoLabel.Location = new System.Drawing.Point(242, 99);
            RightBirthYearInfoLabel.Name = "RightBirthYearInfoLabel";
            RightBirthYearInfoLabel.Size = new System.Drawing.Size(63, 13);
            RightBirthYearInfoLabel.TabIndex = 8;
            RightBirthYearInfoLabel.Text = "(0 = not set)";
            // 
            // RightBirthYearUpDown
            // 
            this.RightBirthYearUpDown.Location = new System.Drawing.Point(105, 97);
            this.RightBirthYearUpDown.Name = "RightBirthYearUpDown";
            this.RightBirthYearUpDown.Size = new System.Drawing.Size(131, 20);
            this.RightBirthYearUpDown.TabIndex = 7;
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
            MaxSearchDepthLabel.Location = new System.Drawing.Point(9, 382);
            MaxSearchDepthLabel.Name = "MaxSearchDepthLabel";
            MaxSearchDepthLabel.Size = new System.Drawing.Size(95, 13);
            MaxSearchDepthLabel.TabIndex = 10;
            MaxSearchDepthLabel.Text = "Max search depth:";
            // 
            // KevinBaconLinkLabel
            // 
            KevinBaconLinkLabel.AutoSize = true;
            KevinBaconLinkLabel.Location = new System.Drawing.Point(9, 51);
            KevinBaconLinkLabel.Name = "KevinBaconLinkLabel";
            KevinBaconLinkLabel.Size = new System.Drawing.Size(193, 13);
            KevinBaconLinkLabel.TabIndex = 2;
            KevinBaconLinkLabel.TabStop = true;
            KevinBaconLinkLabel.Text = "Wikipedia: Six Degrees of Kevin Bacon";
            KevinBaconLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnKevinBaconLinkLabelLinkClicked);
            // 
            // SixDegreesLinkLabel
            // 
            SixDegreesLinkLabel.AutoSize = true;
            SixDegreesLinkLabel.Location = new System.Drawing.Point(9, 72);
            SixDegreesLinkLabel.Name = "SixDegreesLinkLabel";
            SixDegreesLinkLabel.Size = new System.Drawing.Size(183, 13);
            SixDegreesLinkLabel.TabIndex = 3;
            SixDegreesLinkLabel.TabStop = true;
            SixDegreesLinkLabel.Text = "Wikipedia: Six Degrees of Separation";
            SixDegreesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnSixDegreesLinkLabelLinkClicked);
            // 
            // IncludeCastCheckBox
            // 
            this.IncludeCastCheckBox.AutoSize = true;
            this.IncludeCastCheckBox.Checked = true;
            this.IncludeCastCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncludeCastCheckBox.Location = new System.Drawing.Point(12, 109);
            this.IncludeCastCheckBox.Name = "IncludeCastCheckBox";
            this.IncludeCastCheckBox.Size = new System.Drawing.Size(130, 17);
            this.IncludeCastCheckBox.TabIndex = 4;
            this.IncludeCastCheckBox.Text = "Include cast in search";
            this.IncludeCastCheckBox.UseVisualStyleBackColor = true;
            this.IncludeCastCheckBox.CheckedChanged += new System.EventHandler(this.OnIncludeCastCheckBoxCheckedChanged);
            // 
            // IncludeCrewCheckBox
            // 
            this.IncludeCrewCheckBox.AutoSize = true;
            this.IncludeCrewCheckBox.Location = new System.Drawing.Point(12, 132);
            this.IncludeCrewCheckBox.Name = "IncludeCrewCheckBox";
            this.IncludeCrewCheckBox.Size = new System.Drawing.Size(133, 17);
            this.IncludeCrewCheckBox.TabIndex = 5;
            this.IncludeCrewCheckBox.Text = "Include crew in search";
            this.IncludeCrewCheckBox.UseVisualStyleBackColor = true;
            this.IncludeCrewCheckBox.CheckedChanged += new System.EventHandler(this.OnIncludeCrewCheckBoxCheckedChanged);
            // 
            // MaxSearchDepthUpDown
            // 
            this.MaxSearchDepthUpDown.Location = new System.Drawing.Point(117, 380);
            this.MaxSearchDepthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxSearchDepthUpDown.Name = "MaxSearchDepthUpDown";
            this.MaxSearchDepthUpDown.Size = new System.Drawing.Size(120, 20);
            this.MaxSearchDepthUpDown.TabIndex = 11;
            this.MaxSearchDepthUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // StartShortSearchButton
            // 
            this.StartShortSearchButton.Location = new System.Drawing.Point(12, 406);
            this.StartShortSearchButton.Name = "StartShortSearchButton";
            this.StartShortSearchButton.Size = new System.Drawing.Size(225, 23);
            this.StartShortSearchButton.TabIndex = 12;
            this.StartShortSearchButton.Text = "Search shortest link";
            this.StartShortSearchButton.UseVisualStyleBackColor = true;
            this.StartShortSearchButton.Click += new System.EventHandler(this.OnStartShortSearchButtonClick);
            // 
            // StartLongSearchButton
            // 
            this.StartLongSearchButton.Location = new System.Drawing.Point(12, 435);
            this.StartLongSearchButton.Name = "StartLongSearchButton";
            this.StartLongSearchButton.Size = new System.Drawing.Size(225, 23);
            this.StartLongSearchButton.TabIndex = 13;
            this.StartLongSearchButton.Text = "Search longest link";
            this.StartLongSearchButton.UseVisualStyleBackColor = true;
            this.StartLongSearchButton.Click += new System.EventHandler(this.OnStartLongSearchButtonClick);
            // 
            // OnlyIncludeOwnedProfilesCheckBox
            // 
            this.OnlyIncludeOwnedProfilesCheckBox.AutoSize = true;
            this.OnlyIncludeOwnedProfilesCheckBox.Checked = true;
            this.OnlyIncludeOwnedProfilesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OnlyIncludeOwnedProfilesCheckBox.Location = new System.Drawing.Point(193, 159);
            this.OnlyIncludeOwnedProfilesCheckBox.Name = "OnlyIncludeOwnedProfilesCheckBox";
            this.OnlyIncludeOwnedProfilesCheckBox.Size = new System.Drawing.Size(161, 17);
            this.OnlyIncludeOwnedProfilesCheckBox.TabIndex = 7;
            this.OnlyIncludeOwnedProfilesCheckBox.Text = "Only included owned profiles";
            this.OnlyIncludeOwnedProfilesCheckBox.UseVisualStyleBackColor = true;
            this.OnlyIncludeOwnedProfilesCheckBox.CheckedChanged += new System.EventHandler(this.OnOnlyIncludeOwnedProfilesCheckBoxCheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 486);
            this.Controls.Add(this.OnlyIncludeOwnedProfilesCheckBox);
            this.Controls.Add(this.StartLongSearchButton);
            this.Controls.Add(this.StartShortSearchButton);
            this.Controls.Add(MaxSearchDepthLabel);
            this.Controls.Add(this.MaxSearchDepthUpDown);
            this.Controls.Add(RightGroupBox);
            this.Controls.Add(LeftGroupBox);
            this.Controls.Add(SixDegreesLinkLabel);
            this.Controls.Add(KevinBaconLinkLabel);
            this.Controls.Add(InfoLabel);
            this.Controls.Add(WelcomeLabel);
            this.Controls.Add(this.IncludeCrewCheckBox);
            this.Controls.Add(this.IncludeCastCheckBox);
            this.Controls.Add(LoadXmlButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 525);
            this.Name = "MainForm";
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
        private System.Windows.Forms.NumericUpDown LeftBirthYearUpDown;
        private System.Windows.Forms.TextBox LeftLastNameTextBox;
        private System.Windows.Forms.TextBox LeftMiddleNameTextBox;
        private System.Windows.Forms.NumericUpDown RightBirthYearUpDown;
        private System.Windows.Forms.TextBox RightLastNameTextBox;
        private System.Windows.Forms.TextBox RightMiddleNameTextBox;
        private System.Windows.Forms.TextBox RightFirstNameTextBox;
        private System.Windows.Forms.NumericUpDown MaxSearchDepthUpDown;
        private System.Windows.Forms.Button LeftLookupNameButton;
        private System.Windows.Forms.Button RightLookupNameButton;
        private System.Windows.Forms.Button StartShortSearchButton;
        private System.Windows.Forms.Button StartLongSearchButton;
        private System.Windows.Forms.CheckBox OnlyIncludeOwnedProfilesCheckBox;
    }
}

