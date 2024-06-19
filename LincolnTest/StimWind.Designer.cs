namespace LincolnTest
{
    partial class StimWind
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
            this.label1 = new System.Windows.Forms.Label();
            this.leftStimPic = new System.Windows.Forms.PictureBox();
            this.rightStimPic = new System.Windows.Forms.PictureBox();
            this.attentionPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.leftStimPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightStimPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attentionPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // leftStimPic
            // 
            this.leftStimPic.InitialImage = global::LincolnTest.Properties.Resources.horizline;
            this.leftStimPic.Location = new System.Drawing.Point(41, 277);
            this.leftStimPic.Name = "leftStimPic";
            this.leftStimPic.Size = new System.Drawing.Size(328, 215);
            this.leftStimPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.leftStimPic.TabIndex = 1;
            this.leftStimPic.TabStop = false;
            // 
            // rightStimPic
            // 
            this.rightStimPic.Location = new System.Drawing.Point(690, 277);
            this.rightStimPic.Name = "rightStimPic";
            this.rightStimPic.Size = new System.Drawing.Size(340, 215);
            this.rightStimPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rightStimPic.TabIndex = 2;
            this.rightStimPic.TabStop = false;
            // 
            // attentionPicBox
            // 
            this.attentionPicBox.BackColor = System.Drawing.Color.DimGray;
            this.attentionPicBox.InitialImage = null;
            this.attentionPicBox.Location = new System.Drawing.Point(375, 277);
            this.attentionPicBox.Name = "attentionPicBox";
            this.attentionPicBox.Size = new System.Drawing.Size(309, 215);
            this.attentionPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.attentionPicBox.TabIndex = 4;
            this.attentionPicBox.TabStop = false;
            // 
            // StimWind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.ControlBox = false;
            this.Controls.Add(this.attentionPicBox);
            this.Controls.Add(this.rightStimPic);
            this.Controls.Add(this.leftStimPic);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StimWind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StimWind_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.leftStimPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightStimPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attentionPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox leftStimPic;
        private System.Windows.Forms.PictureBox rightStimPic;
        private System.Windows.Forms.PictureBox attentionPicBox;
    }
}