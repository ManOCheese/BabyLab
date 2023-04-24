
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.browseAudioButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseVisButton
            // 
            this.browseVisButton.Location = new System.Drawing.Point(313, 31);
            this.browseVisButton.Name = "browseVisButton";
            this.browseVisButton.Size = new System.Drawing.Size(75, 23);
            this.browseVisButton.TabIndex = 0;
            this.browseVisButton.Text = "Browse...";
            this.browseVisButton.UseVisualStyleBackColor = true;
            this.browseVisButton.Click += new System.EventHandler(this.browseVisButton_Click);
            // 
            // attnVisFIleText
            // 
            this.attnVisFIleText.Enabled = false;
            this.attnVisFIleText.Location = new System.Drawing.Point(6, 33);
            this.attnVisFIleText.Name = "attnVisFIleText";
            this.attnVisFIleText.Size = new System.Drawing.Size(293, 20);
            this.attnVisFIleText.TabIndex = 1;
            this.attnVisFIleText.Text = "<none>";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(6, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(293, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "<none>";
            // 
            // browseAudioButton
            // 
            this.browseAudioButton.Location = new System.Drawing.Point(313, 35);
            this.browseAudioButton.Name = "browseAudioButton";
            this.browseAudioButton.Size = new System.Drawing.Size(75, 23);
            this.browseAudioButton.TabIndex = 3;
            this.browseAudioButton.Text = "Browse...";
            this.browseAudioButton.UseVisualStyleBackColor = true;
            this.browseAudioButton.Click += new System.EventHandler(this.browseAudioButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.attnVisFIleText);
            this.groupBox1.Controls.Add(this.browseVisButton);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 173);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visual Stimulus";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.browseAudioButton);
            this.groupBox2.Location = new System.Drawing.Point(34, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 165);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audio Stimulus";
            // 
            // AttnGetterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 396);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button browseAudioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}