
namespace LincolnTest
{
    partial class PresentKBOp
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.settingsDataGridView = new System.Windows.Forms.DataGridView();
            this.Function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.presentKBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.settingsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.presentKBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsDataGridView
            // 
            this.settingsDataGridView.AllowUserToAddRows = false;
            this.settingsDataGridView.AllowUserToDeleteRows = false;
            this.settingsDataGridView.AllowUserToResizeColumns = false;
            this.settingsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.settingsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.settingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.settingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Function,
            this.Key,
            this.name});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.settingsDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.settingsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.settingsDataGridView.Name = "settingsDataGridView";
            this.settingsDataGridView.RowHeadersVisible = false;
            this.settingsDataGridView.Size = new System.Drawing.Size(243, 311);
            this.settingsDataGridView.TabIndex = 0;
            this.settingsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.settingsDataGridView_CellDoubleClick);
            // 
            // Function
            // 
            this.Function.DividerWidth = 2;
            this.Function.HeaderText = "Function";
            this.Function.Name = "Function";
            this.Function.ReadOnly = true;
            this.Function.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Function.Width = 160;
            // 
            // Key
            // 
            this.Key.DataPropertyName = "Properties.PresentKB.Default.Properties";
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            this.Key.ReadOnly = true;
            this.Key.Width = 80;
            // 
            // name
            // 
            this.name.HeaderText = "name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Visible = false;
            // 
            // presentKBBindingSource
            // 
            this.presentKBBindingSource.DataSource = typeof(LincolnTest.Properties.PresentKB);
            // 
            // PresentKBOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 409);
            this.Controls.Add(this.settingsDataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PresentKBOp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PresentKBOp_FormClosed);
            this.Shown += new System.EventHandler(this.PresentKBOp_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.settingsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.presentKBBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView settingsDataGridView;
        private System.Windows.Forms.BindingSource presentKBBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Function;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
    }
}