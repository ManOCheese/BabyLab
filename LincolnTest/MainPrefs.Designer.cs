
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
            this.stimFolderText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.screenBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.monitorInfo = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
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
            // stimFolderText
            // 
            this.stimFolderText.Location = new System.Drawing.Point(161, 46);
            this.stimFolderText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stimFolderText.Name = "stimFolderText";
            this.stimFolderText.Size = new System.Drawing.Size(715, 26);
            this.stimFolderText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stimuli Folder";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(723, 82);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Select Folder...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // screenBox
            // 
            this.screenBox.FormattingEnabled = true;
            this.screenBox.Location = new System.Drawing.Point(237, 154);
            this.screenBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.screenBox.Name = "screenBox";
            this.screenBox.Size = new System.Drawing.Size(180, 28);
            this.screenBox.TabIndex = 6;
            this.screenBox.SelectedIndexChanged += new System.EventHandler(this.screenBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Stimuli Monitor";
            // 
            // monitorInfo
            // 
            this.monitorInfo.AutoSize = true;
            this.monitorInfo.Location = new System.Drawing.Point(185, 213);
            this.monitorInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.monitorInfo.Name = "monitorInfo";
            this.monitorInfo.Size = new System.Drawing.Size(0, 20);
            this.monitorInfo.TabIndex = 8;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(789, 253);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(156, 48);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // MainPrefs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 313);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.monitorInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.screenBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stimFolderText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainPrefs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPrefs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TextBox stimFolderText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox screenBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label monitorInfo;
        private System.Windows.Forms.Button okButton;
    }
}