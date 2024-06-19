
namespace LincolnTest
{
    partial class ScoreOCV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreOCV));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.nextFButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.prevFButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timelineTrackBar = new System.Windows.Forms.TrackBar();
            this.brightTrackBar = new System.Windows.Forms.TrackBar();
            this.speedComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.eventListView = new System.Windows.Forms.ListView();
            this.col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cam1button = new System.Windows.Forms.Button();
            this.cam2button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.panLeftButton = new System.Windows.Forms.Button();
            this.panRightButton = new System.Windows.Forms.Button();
            this.panUpButton = new System.Windows.Forms.Button();
            this.panDownButton = new System.Windows.Forms.Button();
            this.camSelect1 = new System.Windows.Forms.RadioButton();
            this.camSelect2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.keysTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.video1picbox = new System.Windows.Forms.PictureBox();
            this.frameUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.video2picbox = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.outputsListBox = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timelineTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.video1picbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.video2picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // nextFButton
            // 
            this.nextFButton.Location = new System.Drawing.Point(851, 705);
            this.nextFButton.Name = "nextFButton";
            this.nextFButton.Size = new System.Drawing.Size(75, 23);
            this.nextFButton.TabIndex = 3;
            this.nextFButton.Text = "Next Frame";
            this.nextFButton.UseVisualStyleBackColor = true;
            this.nextFButton.Click += new System.EventHandler(this.nextFButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(763, 705);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 4;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // prevFButton
            // 
            this.prevFButton.Location = new System.Drawing.Point(672, 705);
            this.prevFButton.Name = "prevFButton";
            this.prevFButton.Size = new System.Drawing.Size(75, 23);
            this.prevFButton.TabIndex = 5;
            this.prevFButton.Text = "Prev Frame";
            this.prevFButton.UseVisualStyleBackColor = true;
            this.prevFButton.Click += new System.EventHandler(this.prevFButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(714, 783);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Playback Speed";
            // 
            // timelineTrackBar
            // 
            this.timelineTrackBar.Location = new System.Drawing.Point(264, 634);
            this.timelineTrackBar.Minimum = 1;
            this.timelineTrackBar.Name = "timelineTrackBar";
            this.timelineTrackBar.Size = new System.Drawing.Size(720, 45);
            this.timelineTrackBar.TabIndex = 7;
            this.timelineTrackBar.Value = 1;
            this.timelineTrackBar.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.timelineTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.timelineTrackBar_MouseUp);
            // 
            // brightTrackBar
            // 
            this.brightTrackBar.Location = new System.Drawing.Point(1113, 162);
            this.brightTrackBar.Maximum = 170;
            this.brightTrackBar.Minimum = 100;
            this.brightTrackBar.Name = "brightTrackBar";
            this.brightTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.brightTrackBar.Size = new System.Drawing.Size(45, 234);
            this.brightTrackBar.SmallChange = 11;
            this.brightTrackBar.TabIndex = 8;
            this.brightTrackBar.Value = 100;
            this.brightTrackBar.ValueChanged += new System.EventHandler(this.brightTrackBar_Scroll);
            // 
            // speedComboBox
            // 
            this.speedComboBox.FormattingEnabled = true;
            this.speedComboBox.Location = new System.Drawing.Point(805, 779);
            this.speedComboBox.Name = "speedComboBox";
            this.speedComboBox.Size = new System.Drawing.Size(121, 21);
            this.speedComboBox.TabIndex = 11;
            this.speedComboBox.SelectedIndexChanged += new System.EventHandler(this.speedComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1101, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Brightness";
            // 
            // eventListView
            // 
            this.eventListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1,
            this.col2});
            this.eventListView.FullRowSelect = true;
            this.eventListView.GridLines = true;
            this.eventListView.HideSelection = false;
            this.eventListView.Location = new System.Drawing.Point(12, 21);
            this.eventListView.MultiSelect = false;
            this.eventListView.Name = "eventListView";
            this.eventListView.Size = new System.Drawing.Size(188, 806);
            this.eventListView.TabIndex = 17;
            this.eventListView.UseCompatibleStateImageBehavior = false;
            this.eventListView.View = System.Windows.Forms.View.Details;
            this.eventListView.SelectedIndexChanged += new System.EventHandler(this.eventListView_SelectedIndexChanged);
            // 
            // col1
            // 
            this.col1.Text = "Event";
            this.col1.Width = 120;
            // 
            // col2
            // 
            this.col2.Text = "Frame";
            // 
            // cam1button
            // 
            this.cam1button.Location = new System.Drawing.Point(459, 21);
            this.cam1button.Name = "cam1button";
            this.cam1button.Size = new System.Drawing.Size(75, 23);
            this.cam1button.TabIndex = 19;
            this.cam1button.Text = "Camera 1";
            this.cam1button.UseVisualStyleBackColor = true;
            this.cam1button.Click += new System.EventHandler(this.cam1button_Click);
            // 
            // cam2button
            // 
            this.cam2button.Location = new System.Drawing.Point(574, 21);
            this.cam2button.Name = "cam2button";
            this.cam2button.Size = new System.Drawing.Size(75, 23);
            this.cam2button.TabIndex = 20;
            this.cam2button.Text = "Camera 2";
            this.cam2button.UseVisualStyleBackColor = true;
            this.cam2button.Click += new System.EventHandler(this.cam2button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(698, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Split Screen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.LargeChange = 16;
            this.zoomTrackBar.Location = new System.Drawing.Point(1027, 146);
            this.zoomTrackBar.Maximum = 100;
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.zoomTrackBar.Size = new System.Drawing.Size(45, 259);
            this.zoomTrackBar.SmallChange = 16;
            this.zoomTrackBar.TabIndex = 22;
            this.zoomTrackBar.TickFrequency = 5;
            this.zoomTrackBar.Scroll += new System.EventHandler(this.zoomTrackBar_Scroll);
            // 
            // panLeftButton
            // 
            this.panLeftButton.Location = new System.Drawing.Point(42, 46);
            this.panLeftButton.Name = "panLeftButton";
            this.panLeftButton.Size = new System.Drawing.Size(32, 23);
            this.panLeftButton.TabIndex = 23;
            this.panLeftButton.Text = "<";
            this.panLeftButton.UseVisualStyleBackColor = true;
            this.panLeftButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // panRightButton
            // 
            this.panRightButton.Location = new System.Drawing.Point(118, 46);
            this.panRightButton.Name = "panRightButton";
            this.panRightButton.Size = new System.Drawing.Size(31, 23);
            this.panRightButton.TabIndex = 24;
            this.panRightButton.Text = ">";
            this.panRightButton.UseVisualStyleBackColor = true;
            this.panRightButton.Click += new System.EventHandler(this.panRightButton_Click);
            // 
            // panUpButton
            // 
            this.panUpButton.Location = new System.Drawing.Point(79, 20);
            this.panUpButton.Name = "panUpButton";
            this.panUpButton.Size = new System.Drawing.Size(32, 23);
            this.panUpButton.TabIndex = 25;
            this.panUpButton.Text = "^";
            this.panUpButton.UseVisualStyleBackColor = true;
            this.panUpButton.Click += new System.EventHandler(this.panUpButton_Click);
            // 
            // panDownButton
            // 
            this.panDownButton.Location = new System.Drawing.Point(79, 76);
            this.panDownButton.Name = "panDownButton";
            this.panDownButton.Size = new System.Drawing.Size(32, 23);
            this.panDownButton.TabIndex = 26;
            this.panDownButton.Text = "v";
            this.panDownButton.UseVisualStyleBackColor = true;
            this.panDownButton.Click += new System.EventHandler(this.panDownButton_Click);
            // 
            // camSelect1
            // 
            this.camSelect1.AutoSize = true;
            this.camSelect1.Checked = true;
            this.camSelect1.Location = new System.Drawing.Point(190, 35);
            this.camSelect1.Name = "camSelect1";
            this.camSelect1.Size = new System.Drawing.Size(70, 17);
            this.camSelect1.TabIndex = 27;
            this.camSelect1.TabStop = true;
            this.camSelect1.Text = "Camera 1";
            this.camSelect1.UseVisualStyleBackColor = true;
            this.camSelect1.CheckedChanged += new System.EventHandler(this.camSelect1_CheckedChanged);
            // 
            // camSelect2
            // 
            this.camSelect2.AutoSize = true;
            this.camSelect2.Location = new System.Drawing.Point(190, 61);
            this.camSelect2.Name = "camSelect2";
            this.camSelect2.Size = new System.Drawing.Size(70, 17);
            this.camSelect2.TabIndex = 28;
            this.camSelect2.Text = "Camera 2";
            this.camSelect2.UseVisualStyleBackColor = true;
            this.camSelect2.CheckedChanged += new System.EventHandler(this.camSelect2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panLeftButton);
            this.groupBox1.Controls.Add(this.camSelect2);
            this.groupBox1.Controls.Add(this.camSelect1);
            this.groupBox1.Controls.Add(this.panRightButton);
            this.groupBox1.Controls.Add(this.panUpButton);
            this.groupBox1.Controls.Add(this.panDownButton);
            this.groupBox1.Location = new System.Drawing.Point(269, 685);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 112);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zoom/Pan Controls";
            // 
            // keysTextBox
            // 
            this.keysTextBox.Enabled = false;
            this.keysTextBox.Location = new System.Drawing.Point(1002, 731);
            this.keysTextBox.Multiline = true;
            this.keysTextBox.Name = "keysTextBox";
            this.keysTextBox.Size = new System.Drawing.Size(156, 90);
            this.keysTextBox.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1027, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Zoom";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(1002, 21);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(156, 72);
            this.saveButton.TabIndex = 33;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // video1picbox
            // 
            this.video1picbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.video1picbox.Location = new System.Drawing.Point(257, 72);
            this.video1picbox.Margin = new System.Windows.Forms.Padding(2);
            this.video1picbox.Name = "video1picbox";
            this.video1picbox.Size = new System.Drawing.Size(719, 523);
            this.video1picbox.TabIndex = 34;
            this.video1picbox.TabStop = false;
            // 
            // frameUpDown
            // 
            this.frameUpDown.Location = new System.Drawing.Point(813, 746);
            this.frameUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.frameUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frameUpDown.Name = "frameUpDown";
            this.frameUpDown.Size = new System.Drawing.Size(80, 20);
            this.frameUpDown.TabIndex = 35;
            this.frameUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(714, 748);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Frames to move by";
            // 
            // video2picbox
            // 
            this.video2picbox.Location = new System.Drawing.Point(257, 72);
            this.video2picbox.Margin = new System.Windows.Forms.Padding(2);
            this.video2picbox.Name = "video2picbox";
            this.video2picbox.Size = new System.Drawing.Size(719, 523);
            this.video2picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.video2picbox.TabIndex = 37;
            this.video2picbox.TabStop = false;
            this.video2picbox.Visible = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(568, 584);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(0, 36);
            this.scoreLabel.TabIndex = 38;
            // 
            // outputsListBox
            // 
            this.outputsListBox.FormattingEnabled = true;
            this.outputsListBox.Location = new System.Drawing.Point(1002, 438);
            this.outputsListBox.Name = "outputsListBox";
            this.outputsListBox.Size = new System.Drawing.Size(156, 264);
            this.outputsListBox.TabIndex = 39;
            this.outputsListBox.SelectedIndexChanged += new System.EventHandler(this.outputsListBox_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(574, 783);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(107, 17);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "Invert Look Input";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ScoreOCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 833);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.outputsListBox);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.frameUpDown);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keysTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zoomTrackBar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cam2button);
            this.Controls.Add(this.cam1button);
            this.Controls.Add(this.eventListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.brightTrackBar);
            this.Controls.Add(this.timelineTrackBar);
            this.Controls.Add(this.prevFButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.nextFButton);
            this.Controls.Add(this.video1picbox);
            this.Controls.Add(this.video2picbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScoreOCV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Score";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Score_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Score_FormClosed);
            this.Load += new System.EventHandler(this.ScoreOCV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timelineTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.video1picbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.video2picbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button nextFButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button prevFButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar timelineTrackBar;
        private System.Windows.Forms.TrackBar brightTrackBar;
        private System.Windows.Forms.ComboBox speedComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView eventListView;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ColumnHeader col2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cam2button;
        private System.Windows.Forms.Button cam1button;
        private System.Windows.Forms.TrackBar zoomTrackBar;
        private System.Windows.Forms.Button panUpButton;
        private System.Windows.Forms.Button panRightButton;
        private System.Windows.Forms.Button panLeftButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton camSelect2;
        private System.Windows.Forms.RadioButton camSelect1;
        private System.Windows.Forms.Button panDownButton;
        private System.Windows.Forms.TextBox keysTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.PictureBox video1picbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown frameUpDown;
        private System.Windows.Forms.PictureBox video2picbox;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.ListBox outputsListBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}