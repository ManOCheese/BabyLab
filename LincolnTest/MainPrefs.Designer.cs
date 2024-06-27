
namespace LincolnTest
{
    partial class MainPrefs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPrefs));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.vStimFolderText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.screenBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.monitorInfo = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.aStimFolderText = new System.Windows.Forms.TextBox();
            this.leftCamIPLabel = new System.Windows.Forms.Label();
            this.rightCamIPLabel = new System.Windows.Forms.Label();
            this.leftIPTextBox = new System.Windows.Forms.TextBox();
            this.rightIPTextBox = new System.Windows.Forms.TextBox();
            this.camScanButton = new System.Windows.Forms.Button();
            this.swapCamButton = new System.Windows.Forms.Button();
            this.camPreviewButton = new System.Windows.Forms.Button();
            this.camPreviewPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.camPreviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // vStimFolderText
            // 
            this.vStimFolderText.Location = new System.Drawing.Point(139, 30);
            this.vStimFolderText.Name = "vStimFolderText";
            this.vStimFolderText.Size = new System.Drawing.Size(479, 20);
            this.vStimFolderText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Visual Stimuli Folder";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(513, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Select Folder...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // screenBox
            // 
            this.screenBox.FormattingEnabled = true;
            this.screenBox.Location = new System.Drawing.Point(159, 125);
            this.screenBox.Name = "screenBox";
            this.screenBox.Size = new System.Drawing.Size(121, 21);
            this.screenBox.TabIndex = 6;
            this.screenBox.SelectedIndexChanged += new System.EventHandler(this.screenBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Stimuli Monitor";
            // 
            // monitorInfo
            // 
            this.monitorInfo.AutoSize = true;
            this.monitorInfo.Location = new System.Drawing.Point(32, 164);
            this.monitorInfo.Name = "monitorInfo";
            this.monitorInfo.Size = new System.Drawing.Size(100, 13);
            this.monitorInfo.TabIndex = 8;
            this.monitorInfo.Text = "Screen Resolution: ";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(600, 300);
            this.okButton.Margin = new System.Windows.Forms.Padding(2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(104, 31);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "Save";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(513, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Select Folder...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Audio Stimuli Folder";
            // 
            // aStimFolderText
            // 
            this.aStimFolderText.Location = new System.Drawing.Point(139, 83);
            this.aStimFolderText.Name = "aStimFolderText";
            this.aStimFolderText.Size = new System.Drawing.Size(479, 20);
            this.aStimFolderText.TabIndex = 10;
            // 
            // leftCamIPLabel
            // 
            this.leftCamIPLabel.AutoSize = true;
            this.leftCamIPLabel.Location = new System.Drawing.Point(35, 210);
            this.leftCamIPLabel.Name = "leftCamIPLabel";
            this.leftCamIPLabel.Size = new System.Drawing.Size(77, 13);
            this.leftCamIPLabel.TabIndex = 13;
            this.leftCamIPLabel.Text = "Left Camera IP";
            // 
            // rightCamIPLabel
            // 
            this.rightCamIPLabel.AutoSize = true;
            this.rightCamIPLabel.Location = new System.Drawing.Point(35, 286);
            this.rightCamIPLabel.Name = "rightCamIPLabel";
            this.rightCamIPLabel.Size = new System.Drawing.Size(84, 13);
            this.rightCamIPLabel.TabIndex = 14;
            this.rightCamIPLabel.Text = "Right Camera IP";
            // 
            // leftIPTextBox
            // 
            this.leftIPTextBox.Location = new System.Drawing.Point(38, 226);
            this.leftIPTextBox.Name = "leftIPTextBox";
            this.leftIPTextBox.Size = new System.Drawing.Size(100, 20);
            this.leftIPTextBox.TabIndex = 15;
            this.leftIPTextBox.Text = "169.254.72.175";
            // 
            // rightIPTextBox
            // 
            this.rightIPTextBox.Location = new System.Drawing.Point(38, 302);
            this.rightIPTextBox.Name = "rightIPTextBox";
            this.rightIPTextBox.Size = new System.Drawing.Size(100, 20);
            this.rightIPTextBox.TabIndex = 16;
            this.rightIPTextBox.Text = "169.254.78.175";
            // 
            // camScanButton
            // 
            this.camScanButton.Location = new System.Drawing.Point(38, 333);
            this.camScanButton.Name = "camScanButton";
            this.camScanButton.Size = new System.Drawing.Size(75, 23);
            this.camScanButton.TabIndex = 17;
            this.camScanButton.Text = "Scan";
            this.camScanButton.UseVisualStyleBackColor = true;
            this.camScanButton.Click += new System.EventHandler(this.camScanButton_Click);
            // 
            // swapCamButton
            // 
            this.swapCamButton.Location = new System.Drawing.Point(38, 252);
            this.swapCamButton.Name = "swapCamButton";
            this.swapCamButton.Size = new System.Drawing.Size(75, 23);
            this.swapCamButton.TabIndex = 18;
            this.swapCamButton.Text = "^ Swap v";
            this.swapCamButton.UseVisualStyleBackColor = true;
            this.swapCamButton.Click += new System.EventHandler(this.swapCamButton_Click);
            // 
            // camPreviewButton
            // 
            this.camPreviewButton.Location = new System.Drawing.Point(144, 223);
            this.camPreviewButton.Name = "camPreviewButton";
            this.camPreviewButton.Size = new System.Drawing.Size(75, 23);
            this.camPreviewButton.TabIndex = 19;
            this.camPreviewButton.Text = "Preview";
            this.camPreviewButton.UseVisualStyleBackColor = true;
            this.camPreviewButton.Click += new System.EventHandler(this.camPreviewButton_Click);
            // 
            // camPreviewPictureBox
            // 
            this.camPreviewPictureBox.InitialImage = global::LincolnTest.Properties.Resources.horizline;
            this.camPreviewPictureBox.Location = new System.Drawing.Point(246, 226);
            this.camPreviewPictureBox.Name = "camPreviewPictureBox";
            this.camPreviewPictureBox.Size = new System.Drawing.Size(239, 146);
            this.camPreviewPictureBox.TabIndex = 20;
            this.camPreviewPictureBox.TabStop = false;
            // 
            // MainPrefs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 410);
            this.Controls.Add(this.camPreviewPictureBox);
            this.Controls.Add(this.camPreviewButton);
            this.Controls.Add(this.swapCamButton);
            this.Controls.Add(this.camScanButton);
            this.Controls.Add(this.rightIPTextBox);
            this.Controls.Add(this.leftIPTextBox);
            this.Controls.Add(this.rightCamIPLabel);
            this.Controls.Add(this.leftCamIPLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aStimFolderText);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.monitorInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.screenBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vStimFolderText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPrefs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPrefs";
            ((System.ComponentModel.ISupportInitialize)(this.camPreviewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TextBox vStimFolderText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox screenBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label monitorInfo;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox aStimFolderText;
        private System.Windows.Forms.Label leftCamIPLabel;
        private System.Windows.Forms.Label rightCamIPLabel;
        private System.Windows.Forms.TextBox leftIPTextBox;
        private System.Windows.Forms.TextBox rightIPTextBox;
        private System.Windows.Forms.Button camScanButton;
        private System.Windows.Forms.Button swapCamButton;
        private System.Windows.Forms.Button camPreviewButton;
        private System.Windows.Forms.PictureBox camPreviewPictureBox;
    }
}