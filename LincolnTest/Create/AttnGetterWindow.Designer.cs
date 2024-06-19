
namespace LincolnTest
{
    partial class AttnGetterWindow
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
            this.browseVisButton = new System.Windows.Forms.Button();
            this.attnVisFIleText = new System.Windows.Forms.TextBox();
            this.attnAudioFIleText = new System.Windows.Forms.TextBox();
            this.browseAudioButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseVisButton
            // 
            this.browseVisButton.Location = new System.Drawing.Point(470, 48);
            this.browseVisButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseVisButton.Name = "browseVisButton";
            this.browseVisButton.Size = new System.Drawing.Size(112, 35);
            this.browseVisButton.TabIndex = 0;
            this.browseVisButton.Text = "Browse...";
            this.browseVisButton.UseVisualStyleBackColor = true;
            this.browseVisButton.Click += new System.EventHandler(this.browseVisButton_Click);
            // 
            // attnVisFIleText
            // 
            this.attnVisFIleText.Enabled = false;
            this.attnVisFIleText.Location = new System.Drawing.Point(9, 51);
            this.attnVisFIleText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.attnVisFIleText.Name = "attnVisFIleText";
            this.attnVisFIleText.Size = new System.Drawing.Size(438, 26);
            this.attnVisFIleText.TabIndex = 1;
            this.attnVisFIleText.Text = "<none>";
            // 
            // attnAudioFIleText
            // 
            this.attnAudioFIleText.Enabled = false;
            this.attnAudioFIleText.Location = new System.Drawing.Point(9, 60);
            this.attnAudioFIleText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.attnAudioFIleText.Name = "attnAudioFIleText";
            this.attnAudioFIleText.Size = new System.Drawing.Size(438, 26);
            this.attnAudioFIleText.TabIndex = 2;
            this.attnAudioFIleText.Text = "<none>";
            // 
            // browseAudioButton
            // 
            this.browseAudioButton.Location = new System.Drawing.Point(470, 54);
            this.browseAudioButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseAudioButton.Name = "browseAudioButton";
            this.browseAudioButton.Size = new System.Drawing.Size(112, 35);
            this.browseAudioButton.TabIndex = 3;
            this.browseAudioButton.Text = "Browse...";
            this.browseAudioButton.UseVisualStyleBackColor = true;
            this.browseAudioButton.Click += new System.EventHandler(this.browseAudioButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.attnVisFIleText);
            this.groupBox1.Controls.Add(this.browseVisButton);
            this.groupBox1.Location = new System.Drawing.Point(42, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(646, 266);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visual Stimulus";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.attnAudioFIleText);
            this.groupBox2.Controls.Add(this.browseAudioButton);
            this.groupBox2.Location = new System.Drawing.Point(51, 294);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(638, 254);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audio Stimulus";
            // 
            // AttnGetterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 609);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttnGetterWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttnGetterWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AttnGetterWindow_FormClosing);
            this.Load += new System.EventHandler(this.AttnGetterWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button browseVisButton;
        private System.Windows.Forms.TextBox attnVisFIleText;
        private System.Windows.Forms.TextBox attnAudioFIleText;
        private System.Windows.Forms.Button browseAudioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}