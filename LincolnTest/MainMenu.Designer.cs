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
            this.errorMessage = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Enabled = false;
            this.createButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(116, 388);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(198, 66);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // presentButton
            // 
            this.presentButton.Enabled = false;
            this.presentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presentButton.Location = new System.Drawing.Point(375, 388);
            this.presentButton.Name = "presentButton";
            this.presentButton.Size = new System.Drawing.Size(198, 66);
            this.presentButton.TabIndex = 1;
            this.presentButton.Text = "Present";
            this.presentButton.UseVisualStyleBackColor = true;
            this.presentButton.Click += new System.EventHandler(this.PresentButton_Click);
            // 
            // scoreButton
            // 
            this.scoreButton.Enabled = false;
            this.scoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreButton.Location = new System.Drawing.Point(116, 495);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(198, 66);
            this.scoreButton.TabIndex = 2;
            this.scoreButton.Text = "Score";
            this.scoreButton.UseVisualStyleBackColor = true;
            this.scoreButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // analyseButton
            // 
            this.analyseButton.Enabled = false;
            this.analyseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyseButton.Location = new System.Drawing.Point(375, 495);
            this.analyseButton.Name = "analyseButton";
            this.analyseButton.Size = new System.Drawing.Size(198, 66);
            this.analyseButton.TabIndex = 3;
            this.analyseButton.Text = "Analyse";
            this.analyseButton.UseVisualStyleBackColor = true;
            this.analyseButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(704, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(82, 29);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(158, 34);
            this.newToolStripMenuItem.Text = "New..";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(158, 34);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.AutoSize = true;
            this.projectNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectNameLabel.Location = new System.Drawing.Point(36, 77);
            this.projectNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(95, 29);
            this.projectNameLabel.TabIndex = 5;
            this.projectNameLabel.Text = "Project:";
            // 
            // experimentInfoLabel
            // 
            this.experimentInfoLabel.AutoSize = true;
            this.experimentInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.experimentInfoLabel.Location = new System.Drawing.Point(36, 165);
            this.experimentInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.experimentInfoLabel.Name = "experimentInfoLabel";
            this.experimentInfoLabel.Size = new System.Drawing.Size(153, 29);
            this.experimentInfoLabel.TabIndex = 6;
            this.experimentInfoLabel.Text = "Experiments:";
            // 
            // projectName
            // 
            this.projectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectName.Location = new System.Drawing.Point(134, 77);
            this.projectName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(439, 51);
            this.projectName.TabIndex = 7;
            this.projectName.Text = "<none>";
            // 
            // experimentCount
            // 
            this.experimentCount.AutoSize = true;
            this.experimentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.experimentCount.Location = new System.Drawing.Point(196, 165);
            this.experimentCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.experimentCount.Name = "experimentCount";
            this.experimentCount.Size = new System.Drawing.Size(26, 29);
            this.experimentCount.TabIndex = 8;
            this.experimentCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 226);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Scored:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 195);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Presented:";
            // 
            // presentCount
            // 
            this.presentCount.AutoSize = true;
            this.presentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presentCount.Location = new System.Drawing.Point(196, 195);
            this.presentCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.presentCount.Name = "presentCount";
            this.presentCount.Size = new System.Drawing.Size(26, 29);
            this.presentCount.TabIndex = 11;
            this.presentCount.Text = "0";
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorMessage.Location = new System.Drawing.Point(162, 327);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(356, 29);
            this.errorMessage.TabIndex = 12;
            this.errorMessage.Text = "Error: No stimulus images found";
            this.errorMessage.Visible = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 686);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.presentCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.experimentCount);
            this.Controls.Add(this.projectName);
            this.Controls.Add(this.experimentInfoLabel);
            this.Controls.Add(this.projectNameLabel);
            this.Controls.Add(this.analyseButton);
            this.Controls.Add(this.scoreButton);
            this.Controls.Add(this.presentButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Lincoln Infant Lab";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Label errorMessage;
    }
}