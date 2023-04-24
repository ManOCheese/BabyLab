
namespace LincolnTest
{
    partial class viewSettings
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
            this.scaleUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stimulus Scale";
            // 
            // scaleUpDown
            // 
            this.scaleUpDown.DecimalPlaces = 2;
            this.scaleUpDown.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.scaleUpDown.Location = new System.Drawing.Point(95, 29);
            this.scaleUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.scaleUpDown.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.scaleUpDown.Name = "scaleUpDown";
            this.scaleUpDown.Size = new System.Drawing.Size(57, 20);
            this.scaleUpDown.TabIndex = 1;
            this.scaleUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.scaleUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.scaleUpDown.ValueChanged += new System.EventHandler(this.scaleUpDown_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // viewSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 163);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scaleUpDown);
            this.Controls.Add(this.label1);
            this.Name = "viewSettings";
            this.Text = "viewSettings";
            this.Load += new System.EventHandler(this.viewSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scaleUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown scaleUpDown;
        private System.Windows.Forms.Button button1;
    }
}