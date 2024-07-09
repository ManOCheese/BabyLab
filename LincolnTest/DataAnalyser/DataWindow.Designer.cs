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
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.expListBox = new System.Windows.Forms.ListBox();
            this.blockListBox = new System.Windows.Forms.ListBox();
            this.outputDGV = new System.Windows.Forms.DataGridView();
            this.trialUpDown = new System.Windows.Forms.NumericUpDown();
            this.partInfoLabel = new System.Windows.Forms.Label();
            this.totalsDGV = new System.Windows.Forms.DataGridView();
            this.Stat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perPartCheck = new System.Windows.Forms.CheckBox();
            this.includeCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cutPointBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trialUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(802, 764);
            this.okButton.Margin = new System.Windows.Forms.Padding(2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(106, 37);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Process";
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
            this.cutPointBox.ValueChanged += new System.EventHandler(this.cutPointBox_ValueChanged);
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
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.checkBox3);
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
            this.label9.Location = new System.Drawing.Point(264, 56);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "ms of latency";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(200, 54);
            this.numericUpDown5.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown5.TabIndex = 18;
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 56);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Post naming first look after cutoff plus";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(5, 30);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(97, 17);
            this.checkBox3.TabIndex = 14;
            this.checkBox3.Text = "Latency Delay:";
            this.checkBox3.UseVisualStyleBackColor = true;
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
            this.partInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partInfoLabel.Location = new System.Drawing.Point(773, 26);
            this.partInfoLabel.Name = "partInfoLabel";
            this.partInfoLabel.Size = new System.Drawing.Size(46, 24);
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
            // perPartCheck
            // 
            this.perPartCheck.AutoSize = true;
            this.perPartCheck.Location = new System.Drawing.Point(812, 732);
            this.perPartCheck.Name = "perPartCheck";
            this.perPartCheck.Size = new System.Drawing.Size(96, 17);
            this.perPartCheck.TabIndex = 11;
            this.perPartCheck.Text = "Output Per File";
            this.perPartCheck.UseVisualStyleBackColor = true;
            // 
            // includeCheckBox
            // 
            this.includeCheckBox.AutoSize = true;
            this.includeCheckBox.Checked = true;
            this.includeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.includeCheckBox.Location = new System.Drawing.Point(942, 25);
            this.includeCheckBox.Name = "includeCheckBox";
            this.includeCheckBox.Size = new System.Drawing.Size(206, 28);
            this.includeCheckBox.TabIndex = 12;
            this.includeCheckBox.Text = "Include in final output";
            this.includeCheckBox.UseVisualStyleBackColor = true;
            this.includeCheckBox.CheckedChanged += new System.EventHandler(this.includeCheckBox_CheckedChanged);
            // 
            // DataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1676, 876);
            this.Controls.Add(this.includeCheckBox);
            this.Controls.Add(this.perPartCheck);
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView outputDGV;
        private System.Windows.Forms.NumericUpDown trialUpDown;
        private System.Windows.Forms.Label partInfoLabel;
        private System.Windows.Forms.ListBox blockListBox;
        private System.Windows.Forms.ListBox expListBox;
        private System.Windows.Forms.DataGridView totalsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.CheckBox perPartCheck;
        private System.Windows.Forms.CheckBox includeCheckBox;
    }
}