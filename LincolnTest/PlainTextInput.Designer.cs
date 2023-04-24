namespace LincolnTest
{
    partial class PlainTextInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlainTextInput));
            this.button1 = new System.Windows.Forms.Button();
            this.projectLabel = new System.Windows.Forms.Label();
            this.pnameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // projectLabel
            // 
            resources.ApplyResources(this.projectLabel, "projectLabel");
            this.projectLabel.Name = "projectLabel";
            this.projectLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnameTextBox
            // 
            resources.ApplyResources(this.pnameTextBox, "pnameTextBox");
            this.pnameTextBox.Name = "pnameTextBox";
            // 
            // PlainTextInput
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnameTextBox);
            this.Controls.Add(this.projectLabel);
            this.Controls.Add(this.button1);
            this.Name = "PlainTextInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label projectLabel;
        private System.Windows.Forms.TextBox pnameTextBox;
    }
}