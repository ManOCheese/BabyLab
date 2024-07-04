namespace LincolnTest

{
    partial class DataWindow
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
            this.okButton = new System.Windows.Forms.Button();
            this.trialListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cutPointBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.expListBox = new System.Windows.Forms.ListBox();
            this.blockListBox = new System.Windows.Forms.ListBox();
            this.outputDGV = new System.Windows.Forms.DataGridView();
            this.trialUpDown = new System.Windows.Forms.NumericUpDown();
            this.partInfoLabel = new System.Windows.Forms.Label();
            this.totalsDGV = new System.Windows.Forms.DataGridView();
            this.Stat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cutPointBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trialUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(362, 235);
            this.okButton.Margin = new System.Windows.Forms.Padding(2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(106, 37);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Load";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // trialListBox
            // 
            this.trialListBox.FormattingEnabled = true;
            this.trialListBox.Location = new System.Drawing.Point(204, 19);
            this.trialListBox.Margin = new System.Windows.Forms.Padding(2);
            this.trialListBox.Name = "trialListBox";
            this.trialListBox.Size = new System.Drawing.Size(86, 173);
            this.trialListBox.TabIndex = 1;
            this.trialListBox.SelectedIndexChanged += new System.EventHandler(this.dataFilesList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 246);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cut Point";
            // 
            // cutPointBox
            // 
            this.cutPointBox.Location = new System.Drawing.Point(84, 245);
            this.cutPointBox.Margin = new System.Windows.Forms.Padding(2);
            this.cutPointBox.Maximum = new decimal(new int[] {
            12000,
            0,
            0,
            0});
            this.cutPointBox.Name = "cutPointBox";
            this.cutPointBox.Size = new System.Drawing.Size(80, 20);
            this.cutPointBox.TabIndex = 3;
            this.cutPointBox.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 246);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ms";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numericUpDown5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numericUpDown6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericUpDown3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numericUpDown4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(31, 284);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(469, 243);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Optional Settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(328, 204);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "ms after cut point";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(264, 203);
            this.numericUpDown5.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown5.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(228, 204);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "ms to";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(163, 203);
            this.numericUpDown6.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown6.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 204);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Include switches which began";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(5, 178);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(109, 17);
            this.checkBox3.TabIndex = 14;
            this.checkBox3.Text = "Latency Window:";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 148);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "ms after cut point";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(198, 146);
            this.numericUpDown3.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown3.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(162, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "ms to";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(97, 146);
            this.numericUpDown4.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown4.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 148);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Calculate from";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(5, 119);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(129, 17);
            this.checkBox4.TabIndex = 8;
            this.checkBox4.Text = "Post-naming Window:";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "ms";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(198, 91);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "ms to";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(97, 91);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Calculate from";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(5, 64);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(124, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Pre-naming Window:";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(5, 36);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(139, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Enter Cut Point Per Trial";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.expListBox);
            this.groupBox2.Controls.Add(this.blockListBox);
            this.groupBox2.Controls.Add(this.trialListBox);
            this.groupBox2.Location = new System.Drawing.Point(25, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 213);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Files Found";
            // 
            // expListBox
            // 
            this.expListBox.FormattingEnabled = true;
            this.expListBox.Location = new System.Drawing.Point(11, 19);
            this.expListBox.Name = "expListBox";
            this.expListBox.Size = new System.Drawing.Size(91, 173);
            this.expListBox.TabIndex = 3;
            this.expListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // blockListBox
            // 
            this.blockListBox.FormattingEnabled = true;
            this.blockListBox.Location = new System.Drawing.Point(103, 19);
            this.blockListBox.Name = "blockListBox";
            this.blockListBox.Size = new System.Drawing.Size(94, 173);
            this.blockListBox.TabIndex = 2;
            this.blockListBox.SelectedIndexChanged += new System.EventHandler(this.blockListBox_SelectedIndexChanged);
            // 
            // outputDGV
            // 
            this.outputDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputDGV.Location = new System.Drawing.Point(516, 67);
            this.outputDGV.Name = "outputDGV";
            this.outputDGV.Size = new System.Drawing.Size(670, 607);
            this.outputDGV.TabIndex = 7;
            // 
            // trialUpDown
            // 
            this.trialUpDown.Location = new System.Drawing.Point(563, 30);
            this.trialUpDown.Name = "trialUpDown";
            this.trialUpDown.Size = new System.Drawing.Size(120, 20);
            this.trialUpDown.TabIndex = 8;
            this.trialUpDown.ValueChanged += new System.EventHandler(this.trialUpDown_ValueChanged);
            // 
            // partInfoLabel
            // 
            this.partInfoLabel.AutoSize = true;
            this.partInfoLabel.Location = new System.Drawing.Point(799, 32);
            this.partInfoLabel.Name = "partInfoLabel";
            this.partInfoLabel.Size = new System.Drawing.Size(27, 13);
            this.partInfoLabel.TabIndex = 9;
            this.partInfoLabel.Text = "Trial";
            // 
            // totalsDGV
            // 
            this.totalsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.totalsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stat,
            this.Value});
            this.totalsDGV.Location = new System.Drawing.Point(1221, 11);
            this.totalsDGV.Name = "totalsDGV";
            this.totalsDGV.Size = new System.Drawing.Size(429, 843);
            this.totalsDGV.TabIndex = 10;
            // 
            // Stat
            // 
            this.Stat.HeaderText = "Stat";
            this.Stat.Name = "Stat";
            this.Stat.ReadOnly = true;
            this.Stat.Width = 260;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // DataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1676, 876);
            this.Controls.Add(this.totalsDGV);
            this.Controls.Add(this.partInfoLabel);
            this.Controls.Add(this.trialUpDown);
            this.Controls.Add(this.outputDGV);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cutPointBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DataWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScoreWindow";
            ((System.ComponentModel.ISupportInitialize)(this.cutPointBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outputDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trialUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ListBox trialListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown cutPointBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView outputDGV;
        private System.Windows.Forms.NumericUpDown trialUpDown;
        private System.Windows.Forms.Label partInfoLabel;
        private System.Windows.Forms.ListBox blockListBox;
        private System.Windows.Forms.ListBox expListBox;
        private System.Windows.Forms.DataGridView totalsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}