
namespace LincolnTest
{
    partial class Score
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Score));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openButton1 = new System.Windows.Forms.Button();
            this.videoView1 = new LibVLCSharp.WinForms.VideoView();
            this.nextFButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.prevFButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timelineTrackBar = new System.Windows.Forms.TrackBar();
            this.brightTrackBar = new System.Windows.Forms.TrackBar();
            this.contrastTrackBar = new System.Windows.Forms.TrackBar();
            this.gammaTrackBar = new System.Windows.Forms.TrackBar();
            this.speedComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.eventListView = new System.Windows.Forms.ListView();
            this.col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.videoView2 = new LibVLCSharp.WinForms.VideoView();
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
            this.openButton2 = new System.Windows.Forms.Button();
            this.keysTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timelineTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openButton1
            // 
            this.openButton1.Location = new System.Drawing.Point(18, 34);
            this.openButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openButton1.Name = "openButton1";
            this.openButton1.Size = new System.Drawing.Size(112, 35);
            this.openButton1.TabIndex = 1;
            this.openButton1.Text = "Open Cam 1";
            this.openButton1.UseVisualStyleBackColor = true;
            this.openButton1.Click += new System.EventHandler(this.openButton_Click);
            // 
            // videoView1
            // 
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Location = new System.Drawing.Point(396, 118);
            this.videoView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.videoView1.MediaPlayer = null;
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(1080, 623);
            this.videoView1.TabIndex = 2;
            this.videoView1.Text = "videoView1";
            this.videoView1.Click += new System.EventHandler(this.videoView1_Click);
            // 
            // nextFButton
            // 
            this.nextFButton.Location = new System.Drawing.Point(1276, 860);
            this.nextFButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nextFButton.Name = "nextFButton";
            this.nextFButton.Size = new System.Drawing.Size(112, 35);
            this.nextFButton.TabIndex = 3;
            this.nextFButton.Text = "Next Frame";
            this.nextFButton.UseVisualStyleBackColor = true;
            this.nextFButton.Click += new System.EventHandler(this.nextFButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(1144, 860);
            this.playButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(112, 35);
            this.playButton.TabIndex = 4;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // prevFButton
            // 
            this.prevFButton.Location = new System.Drawing.Point(1008, 860);
            this.prevFButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.prevFButton.Name = "prevFButton";
            this.prevFButton.Size = new System.Drawing.Size(112, 35);
            this.prevFButton.TabIndex = 5;
            this.prevFButton.Text = "Prev Frame";
            this.prevFButton.UseVisualStyleBackColor = true;
            this.prevFButton.Click += new System.EventHandler(this.prevFButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1071, 929);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Playback Speed";
            // 
            // timelineTrackBar
            // 
            this.timelineTrackBar.Location = new System.Drawing.Point(396, 751);
            this.timelineTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timelineTrackBar.Name = "timelineTrackBar";
            this.timelineTrackBar.Size = new System.Drawing.Size(1080, 69);
            this.timelineTrackBar.TabIndex = 7;
            this.timelineTrackBar.Scroll += new System.EventHandler(this.timelineTrackBar_Scroll);
            this.timelineTrackBar.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // brightTrackBar
            // 
            this.brightTrackBar.Location = new System.Drawing.Point(1516, 242);
            this.brightTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.brightTrackBar.Maximum = 170;
            this.brightTrackBar.Minimum = 100;
            this.brightTrackBar.Name = "brightTrackBar";
            this.brightTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.brightTrackBar.Size = new System.Drawing.Size(69, 360);
            this.brightTrackBar.SmallChange = 11;
            this.brightTrackBar.TabIndex = 8;
            this.brightTrackBar.Value = 100;
            this.brightTrackBar.Scroll += new System.EventHandler(this.brightTrackBar_Scroll);
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Location = new System.Drawing.Point(1593, 242);
            this.contrastTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.contrastTrackBar.Maximum = 170;
            this.contrastTrackBar.Minimum = 80;
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.contrastTrackBar.Size = new System.Drawing.Size(69, 360);
            this.contrastTrackBar.TabIndex = 9;
            this.contrastTrackBar.Value = 100;
            this.contrastTrackBar.Scroll += new System.EventHandler(this.contrastTrackBar_Scroll);
            // 
            // gammaTrackBar
            // 
            this.gammaTrackBar.Location = new System.Drawing.Point(1670, 242);
            this.gammaTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gammaTrackBar.Maximum = 250;
            this.gammaTrackBar.Minimum = -50;
            this.gammaTrackBar.Name = "gammaTrackBar";
            this.gammaTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.gammaTrackBar.Size = new System.Drawing.Size(69, 360);
            this.gammaTrackBar.TabIndex = 10;
            this.gammaTrackBar.Value = 100;
            this.gammaTrackBar.Scroll += new System.EventHandler(this.gammaTrackBar_Scroll);
            // 
            // speedComboBox
            // 
            this.speedComboBox.FormattingEnabled = true;
            this.speedComboBox.Location = new System.Drawing.Point(1208, 923);
            this.speedComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.speedComboBox.Name = "speedComboBox";
            this.speedComboBox.Size = new System.Drawing.Size(180, 28);
            this.speedComboBox.TabIndex = 11;
            this.speedComboBox.SelectedIndexChanged += new System.EventHandler(this.speedComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1498, 217);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Brightness | Contrast | Gamma";
            // 
            // eventListView
            // 
            this.eventListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1,
            this.col2});
            this.eventListView.FullRowSelect = true;
            this.eventListView.GridLines = true;
            this.eventListView.HideSelection = false;
            this.eventListView.Location = new System.Drawing.Point(18, 118);
            this.eventListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eventListView.MultiSelect = false;
            this.eventListView.Name = "eventListView";
            this.eventListView.Size = new System.Drawing.Size(280, 706);
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
            this.col2.Text = "Time(ms)";
            // 
            // videoView2
            // 
            this.videoView2.BackColor = System.Drawing.Color.Black;
            this.videoView2.Location = new System.Drawing.Point(396, 118);
            this.videoView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.videoView2.MediaPlayer = null;
            this.videoView2.Name = "videoView2";
            this.videoView2.Size = new System.Drawing.Size(1080, 623);
            this.videoView2.TabIndex = 18;
            this.videoView2.Text = "videoView2";
            // 
            // cam1button
            // 
            this.cam1button.Enabled = false;
            this.cam1button.Location = new System.Drawing.Point(696, 74);
            this.cam1button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cam1button.Name = "cam1button";
            this.cam1button.Size = new System.Drawing.Size(112, 35);
            this.cam1button.TabIndex = 19;
            this.cam1button.Text = "Camera 1";
            this.cam1button.UseVisualStyleBackColor = true;
            this.cam1button.Click += new System.EventHandler(this.cam1button_Click);
            // 
            // cam2button
            // 
            this.cam2button.Enabled = false;
            this.cam2button.Location = new System.Drawing.Point(868, 74);
            this.cam2button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cam2button.Name = "cam2button";
            this.cam2button.Size = new System.Drawing.Size(112, 35);
            this.cam2button.TabIndex = 20;
            this.cam2button.Text = "Camera 2";
            this.cam2button.UseVisualStyleBackColor = true;
            this.cam2button.Click += new System.EventHandler(this.cam2button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1054, 72);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 35);
            this.button2.TabIndex = 21;
            this.button2.Text = "Split Screen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.LargeChange = 16;
            this.zoomTrackBar.Location = new System.Drawing.Point(309, 445);
            this.zoomTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zoomTrackBar.Maximum = 100;
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.zoomTrackBar.Size = new System.Drawing.Size(69, 557);
            this.zoomTrackBar.SmallChange = 16;
            this.zoomTrackBar.TabIndex = 22;
            this.zoomTrackBar.TickFrequency = 5;
            this.zoomTrackBar.Scroll += new System.EventHandler(this.zoomTrackBar_Scroll);
            // 
            // panLeftButton
            // 
            this.panLeftButton.Location = new System.Drawing.Point(63, 71);
            this.panLeftButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panLeftButton.Name = "panLeftButton";
            this.panLeftButton.Size = new System.Drawing.Size(48, 35);
            this.panLeftButton.TabIndex = 23;
            this.panLeftButton.Text = "<";
            this.panLeftButton.UseVisualStyleBackColor = true;
            this.panLeftButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // panRightButton
            // 
            this.panRightButton.Location = new System.Drawing.Point(177, 71);
            this.panRightButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panRightButton.Name = "panRightButton";
            this.panRightButton.Size = new System.Drawing.Size(46, 35);
            this.panRightButton.TabIndex = 24;
            this.panRightButton.Text = ">";
            this.panRightButton.UseVisualStyleBackColor = true;
            this.panRightButton.Click += new System.EventHandler(this.panRightButton_Click);
            // 
            // panUpButton
            // 
            this.panUpButton.Location = new System.Drawing.Point(118, 31);
            this.panUpButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panUpButton.Name = "panUpButton";
            this.panUpButton.Size = new System.Drawing.Size(48, 35);
            this.panUpButton.TabIndex = 25;
            this.panUpButton.Text = "^";
            this.panUpButton.UseVisualStyleBackColor = true;
            this.panUpButton.Click += new System.EventHandler(this.panUpButton_Click);
            // 
            // panDownButton
            // 
            this.panDownButton.Location = new System.Drawing.Point(118, 117);
            this.panDownButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panDownButton.Name = "panDownButton";
            this.panDownButton.Size = new System.Drawing.Size(48, 35);
            this.panDownButton.TabIndex = 26;
            this.panDownButton.Text = "v";
            this.panDownButton.UseVisualStyleBackColor = true;
            this.panDownButton.Click += new System.EventHandler(this.panDownButton_Click);
            // 
            // camSelect1
            // 
            this.camSelect1.AutoSize = true;
            this.camSelect1.Checked = true;
            this.camSelect1.Location = new System.Drawing.Point(285, 54);
            this.camSelect1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.camSelect1.Name = "camSelect1";
            this.camSelect1.Size = new System.Drawing.Size(103, 24);
            this.camSelect1.TabIndex = 27;
            this.camSelect1.TabStop = true;
            this.camSelect1.Text = "Camera 1";
            this.camSelect1.UseVisualStyleBackColor = true;
            this.camSelect1.CheckedChanged += new System.EventHandler(this.camSelect1_CheckedChanged);
            // 
            // camSelect2
            // 
            this.camSelect2.AutoSize = true;
            this.camSelect2.Location = new System.Drawing.Point(285, 94);
            this.camSelect2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.camSelect2.Name = "camSelect2";
            this.camSelect2.Size = new System.Drawing.Size(103, 24);
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
            this.groupBox1.Location = new System.Drawing.Point(404, 829);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(423, 172);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zoom/Pan Controls";
            // 
            // openButton2
            // 
            this.openButton2.Location = new System.Drawing.Point(158, 34);
            this.openButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openButton2.Name = "openButton2";
            this.openButton2.Size = new System.Drawing.Size(112, 35);
            this.openButton2.TabIndex = 30;
            this.openButton2.Text = "Open Cam 2";
            this.openButton2.UseVisualStyleBackColor = true;
            this.openButton2.Click += new System.EventHandler(this.openButton2_Click);
            // 
            // keysTextBox
            // 
            this.keysTextBox.Enabled = false;
            this.keysTextBox.Location = new System.Drawing.Point(1503, 658);
            this.keysTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.keysTextBox.Multiline = true;
            this.keysTextBox.Name = "keysTextBox";
            this.keysTextBox.Size = new System.Drawing.Size(232, 382);
            this.keysTextBox.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 415);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Zoom";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(1503, 32);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(234, 111);
            this.saveButton.TabIndex = 33;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1758, 1062);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keysTextBox);
            this.Controls.Add(this.openButton2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zoomTrackBar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cam2button);
            this.Controls.Add(this.cam1button);
            this.Controls.Add(this.eventListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gammaTrackBar);
            this.Controls.Add(this.contrastTrackBar);
            this.Controls.Add(this.brightTrackBar);
            this.Controls.Add(this.timelineTrackBar);
            this.Controls.Add(this.prevFButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.nextFButton);
            this.Controls.Add(this.videoView1);
            this.Controls.Add(this.openButton1);
            this.Controls.Add(this.videoView2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Score";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Score";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Score_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Score_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Score_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timelineTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button openButton1;
        private LibVLCSharp.WinForms.VideoView videoView1;
        private System.Windows.Forms.Button nextFButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button prevFButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar timelineTrackBar;
        private System.Windows.Forms.TrackBar brightTrackBar;
        private System.Windows.Forms.TrackBar contrastTrackBar;
        private System.Windows.Forms.TrackBar gammaTrackBar;
        private System.Windows.Forms.ComboBox speedComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView eventListView;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ColumnHeader col2;
        private LibVLCSharp.WinForms.VideoView videoView2;
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
        private System.Windows.Forms.Button openButton2;
        private System.Windows.Forms.TextBox keysTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
    }
}