namespace LincolnTest
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.createButton = new System.Windows.Forms.Button();
            this.presentButton = new System.Windows.Forms.Button();
            this.scoreButton = new System.Windows.Forms.Button();
            this.analyseButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectNameLabel = new System.Windows.Forms.Label();
            this.experimentInfoLabel = new System.Windows.Forms.Label();
            this.projectName = new System.Windows.Forms.Label();
            this.experimentCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.presentCount = new System.Windows.Forms.Label();
            this.stimCountText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stimCountV = new System.Windows.Forms.Label();
            this.stimCountA = new System.Windows.Forms.Label();
            this.audioStimText = new System.Windows.Forms.Label();
            this.scoredCountText = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Enabled = false;
            this.createButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(11, 8);
            this.createButton.Margin = new System.Windows.Forms.Padding(2);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(132, 43);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // presentButton
            // 
            this.presentButton.Enabled = false;
            this.presentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presentButton.Location = new System.Drawing.Point(184, 8);
            this.presentButton.Margin = new System.Windows.Forms.Padding(2);
            this.presentButton.Name = "presentButton";
            this.presentButton.Size = new System.Drawing.Size(132, 43);
            this.presentButton.TabIndex = 1;
            this.presentButton.Text = "Present";
            this.presentButton.UseVisualStyleBackColor = true;
            this.presentButton.Click += new System.EventHandler(this.PresentButton_Click);
            // 
            // scoreButton
            // 
            this.scoreButton.Enabled = false;
            this.scoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreButton.Location = new System.Drawing.Point(11, 78);
            this.scoreButton.Margin = new System.Windows.Forms.Padding(2);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(132, 43);
            this.scoreButton.TabIndex = 2;
            this.scoreButton.Text = "Score";
            this.scoreButton.UseVisualStyleBackColor = true;
            this.scoreButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // analyseButton
            // 
            this.analyseButton.Enabled = false;
            this.analyseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyseButton.Location = new System.Drawing.Point(184, 78);
            this.analyseButton.Margin = new System.Windows.Forms.Padding(2);
            this.analyseButton.Name = "analyseButton";
            this.analyseButton.Size = new System.Drawing.Size(132, 43);
            this.analyseButton.TabIndex = 3;
            this.analyseButton.Text = "Analyse";
            this.analyseButton.UseVisualStyleBackColor = true;
            this.analyseButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(469, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.newToolStripMenuItem.Text = "New..";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.AutoSize = true;
            this.projectNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectNameLabel.Location = new System.Drawing.Point(24, 50);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(62, 20);
            this.projectNameLabel.TabIndex = 5;
            this.projectNameLabel.Text = "Project:";
            // 
            // experimentInfoLabel
            // 
            this.experimentInfoLabel.AutoSize = true;
            this.experimentInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.experimentInfoLabel.Location = new System.Drawing.Point(24, 107);
            this.experimentInfoLabel.Name = "experimentInfoLabel";
            this.experimentInfoLabel.Size = new System.Drawing.Size(101, 20);
            this.experimentInfoLabel.TabIndex = 6;
            this.experimentInfoLabel.Text = "Experiments:";
            // 
            // projectName
            // 
            this.projectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectName.Location = new System.Drawing.Point(89, 50);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(293, 19);
            this.projectName.TabIndex = 7;
            this.projectName.Text = "<none>";
            // 
            // experimentCount
            // 
            this.experimentCount.AutoSize = true;
            this.experimentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.experimentCount.Location = new System.Drawing.Point(131, 107);
            this.experimentCount.Name = "experimentCount";
            this.experimentCount.Size = new System.Drawing.Size(18, 20);
            this.experimentCount.TabIndex = 8;
            this.experimentCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Scored:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Presented:";
            // 
            // presentCount
            // 
            this.presentCount.AutoSize = true;
            this.presentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presentCount.Location = new System.Drawing.Point(131, 127);
            this.presentCount.Name = "presentCount";
            this.presentCount.Size = new System.Drawing.Size(18, 20);
            this.presentCount.TabIndex = 11;
            this.presentCount.Text = "0";
            // 
            // stimCountText
            // 
            this.stimCountText.AutoSize = true;
            this.stimCountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stimCountText.Location = new System.Drawing.Point(25, 187);
            this.stimCountText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stimCountText.Name = "stimCountText";
            this.stimCountText.Size = new System.Drawing.Size(135, 20);
            this.stimCountText.TabIndex = 12;
            this.stimCountText.Text = "Stimulus Images: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Directory:";
            // 
            // directoryLabel
            // 
            this.directoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directoryLabel.Location = new System.Drawing.Point(99, 77);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(293, 19);
            this.directoryLabel.TabIndex = 14;
            this.directoryLabel.Text = "<none>";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.presentButton);
            this.panel1.Controls.Add(this.analyseButton);
            this.panel1.Controls.Add(this.createButton);
            this.panel1.Controls.Add(this.scoreButton);
            this.panel1.Location = new System.Drawing.Point(71, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 129);
            this.panel1.TabIndex = 15;
            // 
            // stimCountV
            // 
            this.stimCountV.AutoSize = true;
            this.stimCountV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stimCountV.Location = new System.Drawing.Point(153, 187);
            this.stimCountV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stimCountV.Name = "stimCountV";
            this.stimCountV.Size = new System.Drawing.Size(18, 20);
            this.stimCountV.TabIndex = 16;
            this.stimCountV.Text = "0";
            // 
            // stimCountA
            // 
            this.stimCountA.AutoSize = true;
            this.stimCountA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stimCountA.Location = new System.Drawing.Point(153, 217);
            this.stimCountA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stimCountA.Name = "stimCountA";
            this.stimCountA.Size = new System.Drawing.Size(18, 20);
            this.stimCountA.TabIndex = 18;
            this.stimCountA.Text = "0";
            // 
            // audioStimText
            // 
            this.audioStimText.AutoSize = true;
            this.audioStimText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioStimText.Location = new System.Drawing.Point(25, 217);
            this.audioStimText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.audioStimText.Name = "audioStimText";
            this.audioStimText.Size = new System.Drawing.Size(137, 20);
            this.audioStimText.TabIndex = 17;
            this.audioStimText.Text = "Stimulus Sounds: ";
            // 
            // scoredCountText
            // 
            this.scoredCountText.AutoSize = true;
            this.scoredCountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoredCountText.Location = new System.Drawing.Point(131, 147);
            this.scoredCountText.Name = "scoredCountText";
            this.scoredCountText.Size = new System.Drawing.Size(18, 20);
            this.scoredCountText.TabIndex = 19;
            this.scoredCountText.Text = "0";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 409);
            this.Controls.Add(this.scoredCountText);
            this.Controls.Add(this.stimCountA);
            this.Controls.Add(this.audioStimText);
            this.Controls.Add(this.stimCountV);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stimCountText);
            this.Controls.Add(this.presentCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.experimentCount);
            this.Controls.Add(this.projectName);
            this.Controls.Add(this.experimentInfoLabel);
            this.Controls.Add(this.projectNameLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Lincoln Infant Lab";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button presentButton;
        private System.Windows.Forms.Button scoreButton;
        private System.Windows.Forms.Button analyseButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.Label projectNameLabel;
        private System.Windows.Forms.Label experimentInfoLabel;
        private System.Windows.Forms.Label projectName;
        private System.Windows.Forms.Label experimentCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Label presentCount;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label stimCountText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label stimCountV;
        private System.Windows.Forms.Label stimCountA;
        private System.Windows.Forms.Label audioStimText;
        private System.Windows.Forms.Label scoredCountText;
    }
}