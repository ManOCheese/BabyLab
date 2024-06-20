namespace LincolnTest
{
    partial class NewBlockTextInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewBlockTextInput));
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.blockNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.visualSelect = new System.Windows.Forms.RadioButton();
            this.audioSelect = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Block name";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(58, 195);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(84, 29);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // blockNameTextBox
            // 
            this.blockNameTextBox.Location = new System.Drawing.Point(158, 55);
            this.blockNameTextBox.Name = "blockNameTextBox";
            this.blockNameTextBox.Size = new System.Drawing.Size(156, 26);
            this.blockNameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Block type";
            // 
            // visualSelect
            // 
            this.visualSelect.AutoSize = true;
            this.visualSelect.Checked = true;
            this.visualSelect.Location = new System.Drawing.Point(158, 109);
            this.visualSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.visualSelect.Name = "visualSelect";
            this.visualSelect.Size = new System.Drawing.Size(77, 24);
            this.visualSelect.TabIndex = 5;
            this.visualSelect.TabStop = true;
            this.visualSelect.Text = "Visual";
            this.visualSelect.UseVisualStyleBackColor = true;
            // 
            // audioSelect
            // 
            this.audioSelect.AutoSize = true;
            this.audioSelect.Location = new System.Drawing.Point(158, 146);
            this.audioSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.audioSelect.Name = "audioSelect";
            this.audioSelect.Size = new System.Drawing.Size(75, 24);
            this.audioSelect.TabIndex = 6;
            this.audioSelect.Text = "Audio";
            this.audioSelect.UseVisualStyleBackColor = true;
            // 
            // NewBlockTextInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 262);
            this.Controls.Add(this.audioSelect);
            this.Controls.Add(this.visualSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.blockNameTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewBlockTextInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Block";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox blockNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton visualSelect;
        private System.Windows.Forms.RadioButton audioSelect;
    }
}