namespace LincolnTest.utils
{
    partial class NewProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProject));
            this.createButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.projNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.projectFolderTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Enabled = false;
            this.createButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(776, 348);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(137, 54);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project Name";
            // 
            // projNameTextBox
            // 
            this.projNameTextBox.Location = new System.Drawing.Point(169, 51);
            this.projNameTextBox.Name = "projNameTextBox";
            this.projNameTextBox.Size = new System.Drawing.Size(180, 26);
            this.projNameTextBox.TabIndex = 2;
            this.projNameTextBox.TextChanged += new System.EventHandler(this.projNameTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Project Folder";
            // 
            // projectFolderTextBox
            // 
            this.projectFolderTextBox.Location = new System.Drawing.Point(169, 103);
            this.projectFolderTextBox.Name = "projectFolderTextBox";
            this.projectFolderTextBox.Size = new System.Drawing.Size(744, 26);
            this.projectFolderTextBox.TabIndex = 4;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(762, 136);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(128, 45);
            this.browseButton.TabIndex = 5;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // NewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 424);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.projectFolderTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.projNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewProject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox projNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox projectFolderTextBox;
        private System.Windows.Forms.Button browseButton;
    }
}