using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LibVLCSharp.Shared;
using System.Windows.Forms;

namespace LincolnTest
{
    public partial class Score : Form
    {
        //VLC stuff
        public LibVLC _libVLC;
        public LibVLC _libVLC2;
        public LibVLCSharp.Shared.MediaPlayer _mp;
        public LibVLCSharp.Shared.MediaPlayer _mp2;
        public Media media1;
        public bool isFullscreen = false;
        public bool isPlaying = false;
        public Size fullVideoSize = new Size(720, 405);
        public Size halfVideoSize = new Size(360, 405);
        public Size oldFormSize;
        public Point fullVideoLocation;
        public Point splitVideoLocation;
        float myMS = 33;
        string filename;
        string marquee = "";
        List<string> lines;
        Media video01;
        Media video02;
        float vidWidth;
        float vidHeight;
        float zoomModifier = 1;
        babyUtils myUtils = new babyUtils();
        int panRightValue;
        int panUpValue;
        int zoom1;
        int zoom2;
        

        private static System.Timers.Timer aTimer;

        private delegate void SafeCallDelegate(string text);


        public Score()
        {
            InitializeComponent();

            Core.Initialize();
            this.KeyPreview = true;
            oldFormSize = this.Size;
            fullVideoLocation = videoView1.Location;
            splitVideoLocation = Point.Add(videoView1.Location, new Size(360,0));


            IniFile MyIni = new IniFile(Properties.Settings.Default.ExpPath + "/project.ini");
            filename = MyIni.Read("ScoreFile");

            //VLC stuff
            _libVLC = new LibVLC("--start-paused", "--no-audio");
            _libVLC2 = new LibVLC("--start-paused", "--no-audio");
            _mp2 = new LibVLCSharp.Shared.MediaPlayer(_libVLC2);
            _mp = new LibVLCSharp.Shared.MediaPlayer(_libVLC);
            videoView1.MediaPlayer = _mp;
            videoView2.MediaPlayer = _mp2;
            _mp.EnableHardwareDecoding = true;
            _mp2.EnableHardwareDecoding = false;

            // Create a timer with a ms interval.
            aTimer = new System.Timers.Timer(100);

            timelineTrackBar.Minimum = 0;
            timelineTrackBar.Maximum = 500;

            _mp.TimeChanged += OnTimeChange;
            _mp.LengthChanged += initTimelineEvent;

            string[] speeds = new string[7];
            speeds[0] = "0.1";
            speeds[1] = "0.2";
            speeds[2] = "0.5";
            speeds[3] = "1.0";
            speeds[4] = "1.5";
            speeds[5] = "2.0";
            speeds[6] = "3.0";
            foreach (var speed in speeds)
            {
                speedComboBox.Items.Add(speed);
            }

            speedComboBox.SelectedIndex = 3;

            updateKeysText();

        }

        private void updateKeysText()
        {
            foreach (SettingsProperty setting in ScoreKB.Default.Properties)
            {
                keysTextBox.AppendText(setting.Name + " : " + ScoreKB.Default[setting.Name] + Environment.NewLine);
            }
        }

        private void markLook(string direction)
        {
            int index = 0;

            foreach (string line in lines)
            {

                string[] listData = line.Split('-');

                int listTime = int.Parse(listData[1]);

                if (listTime > _mp.Time)
                {
                    lines.Insert(index - 1, direction + "-" + _mp.Time.ToString());
                    break;
                }
                index++;
            }
            refreshEvents(lines);
        }

        private void updateTime(string myTime)
        {
            if (!isPlaying) { return; }

            if (label1.InvokeRequired)
            {
                var d = new SafeCallDelegate(updateTime);
                try
                {
                    label1.Invoke(d, new object[] { myTime });
                }
                catch
                {

                }
            }
            else
            {
                label1.Text = myTime;
            }
        }

        private void initTimelineEvent(object sender, EventArgs e)
        {
            initTimeline(_mp.Length.ToString());
        }

        private void initTimeline(string myTime)
        {
            if (timelineTrackBar.InvokeRequired)
            {
                var d = new SafeCallDelegate(initTimeline);
                try
                {
                    timelineTrackBar.Invoke(d, new object[] { myTime });
                }
                catch{}
            }
            else
            {
                timelineTrackBar.Maximum = int.Parse(myTime);
                timelineTrackBar.SmallChange = (int)myMS;
                timelineTrackBar.LargeChange = (int)myMS * 10;
                timelineTrackBar.TickFrequency = (int)myMS * 25;
            }
        }

        private void updateTimelineEvent(object sender, EventArgs e)
        {
            updateTimeline(_mp.Time.ToString());
        }

        private void updateTimeline(string myTime)
        {
            if (timelineTrackBar.InvokeRequired)
            {
                var d = new SafeCallDelegate(updateTimeline);
                try
                {
                    timelineTrackBar.Invoke(d, new object[] { myTime });
                }
                catch
                {

                }
            }
            else
            {
                timelineTrackBar.Value = int.Parse(myTime);
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            _mp.Stop();
            _mp2.Stop();
            OpenFileDialog myOpenDialog = new OpenFileDialog();

            DialogResult result =  myOpenDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                lines = System.IO.File.ReadAllLines(Properties.Settings.Default.LastProject + @"\output\" + filename).ToList<string>();

                refreshEvents(lines);

                video01 = new Media(_libVLC, myOpenDialog.FileName);

                _mp.Play(video01);
                _mp.SetMarqueeInt(VideoMarqueeOption.Enable, 1);
                _mp.SetMarqueeInt(VideoMarqueeOption.Size, 128);
                _mp.SetMarqueeInt(VideoMarqueeOption.Position, 8);
                _mp.SetMarqueeString(VideoMarqueeOption.Text, "");
                _mp.SetRate(float.Parse(speedComboBox.SelectedItem.ToString()));
                cam1button.Enabled = true;
            }
        }
        private void openButton2_Click(object sender, EventArgs e)
        {
            _mp.Stop();
            _mp2.Stop();
            OpenFileDialog myOpenDialog = new OpenFileDialog();

            DialogResult result = myOpenDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                //refreshEvents(lines);
                video02 = new Media(_libVLC2, myOpenDialog.FileName);
                _mp2.Play(video02);
                _mp2.SetMarqueeInt(VideoMarqueeOption.Enable, 1);
                _mp2.SetMarqueeInt(VideoMarqueeOption.Size, 128);
                _mp2.SetMarqueeInt(VideoMarqueeOption.Position, 8);
                _mp2.SetMarqueeString(VideoMarqueeOption.Text, "");
                _mp2.SetRate(float.Parse(speedComboBox.SelectedItem.ToString()));
                cam2button.Enabled = true;
            }
        }

        private void refreshEvents(List<string> lines)
        {
            eventListView.Items.Clear();


            foreach (string line in lines)
            {
                Console.WriteLine(line);
                string[] listData = line.Split('-');
                var itm = new ListViewItem(listData);
                eventListView.Items.Add(itm);
            }

            for (int i = 0; i < eventListView.Items.Count; i++)
            {
                if(eventListView.Items[i].Text.StartsWith("Trial")) eventListView.Items[i].BackColor = Color.LightSkyBlue;
            }
        }

        private void nextFButton_Click(object sender, EventArgs e)
        {
            nextFrame();
        }

        private void nextFrame()
        {
            _mp.NextFrame();
            _mp2.NextFrame();
            label1.Text = _mp.Time.ToString();
            Console.WriteLine("Time: " + _mp.Time.ToString());
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            
            playPause();
        }

        private void playPause()
        {           
            if (_mp.State == VLCState.Playing) // if is playing
            {
                _mp.Pause(); // pause
                _mp2.Pause(); // pause
                isPlaying = false;
            }
            else // it's not playing?
            {
                Console.WriteLine("Playing");
                _mp.Play(); // play
                _mp2.Play();
                isPlaying = true;
            }
            zoom_video();
        }
        private void prevFButton_Click(object sender, EventArgs e)
        {
            lastFrame();
        }

        private void lastFrame()
        {
            if (_mp.Time >= myMS)
            {
                _mp.Time = _mp.Time - (int)myMS;
                _mp2.Time = _mp.Time - (int)myMS;
            }
        }

        private void Score_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mp.Dispose();
            _mp2.Dispose();

            aTimer.Enabled = false;
            aTimer.Stop();
            aTimer.Close();
        }

        private void Score_FormClosed(object sender, FormClosedEventArgs e)
        {

            aTimer.Stop();
            aTimer.Close();
        }

        private void OnTimeChange(object sender, EventArgs e)
        {
            timeChanged();
        }

        private void timeChanged()
        {
            // label1.Text = _mp.Time.ToString();
            updateTime(_mp.Time.ToString());
            updateTimeline(_mp.Time.ToString());
            myMS = 1000 / _mp.Fps;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = "" + timelineTrackBar.Value;
        }

        private void brightTrackBar_Scroll(object sender, EventArgs e)
        {
            _mp.SetAdjustInt(VideoAdjustOption.Enable, 1);
            float brightness = (float)brightTrackBar.Value / 100;
            _mp.SetAdjustFloat(VideoAdjustOption.Brightness, brightness);
        }

        private void contrastTrackBar_Scroll(object sender, EventArgs e)
        {
            _mp.SetAdjustInt(VideoAdjustOption.Enable, 1);
            float contrast = (float)contrastTrackBar.Value / 100;
            _mp.SetAdjustFloat(VideoAdjustOption.Contrast, contrast);
        }

        private void gammaTrackBar_Scroll(object sender, EventArgs e)
        {
            _mp.SetAdjustInt(VideoAdjustOption.Enable, 1);
            float contrast = (float)gammaTrackBar.Value / 100;
            _mp.SetAdjustFloat(VideoAdjustOption.Contrast, contrast);
        }

        private void timelineTrackBar_Scroll(object sender, EventArgs e)
        {
            _mp.Time = timelineTrackBar.Value;
            _mp2.Time = timelineTrackBar.Value;
        }

        private void speedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_mp.IsPlaying == true)
            {
                _mp.Pause();
                _mp2.Pause();
            }
            _mp.SetRate(float.Parse(speedComboBox.SelectedItem.ToString()));
            _mp2.SetRate(float.Parse(speedComboBox.SelectedItem.ToString()));
        }
        private void eventListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eventListView.SelectedIndices.Count != 1) return;

            int index = eventListView.SelectedIndices[0];

            if(eventListView.SelectedItems.Count == 1)
            {
                while (!eventListView.Items[index].Text.StartsWith("Trial"))
                {
                    if (index == 0) break;
                    index--;
                }

                // marquee = eventListView.SelectedItems[0].Text;
                marquee = eventListView.Items[index].Text.ToString();
                _mp.SetMarqueeString(VideoMarqueeOption.Text, marquee);

                _mp.SetMarqueeString(VideoMarqueeOption.Text, "Left");
            }

            _mp.Time = int.Parse(eventListView.SelectedItems[0].SubItems[1].Text);



        }

        private void Score_KeyDown(object sender, KeyEventArgs e)
        {
            label1.Focus();

            string inputKey = myUtils.getScoreInput(e);

            switch (inputKey)
            {
                case "NextFrame":
                    nextFrame();
                    break;
                case "LastFrame":
                    lastFrame();
                    break;
                case "PlayPause":
                    playPause();
                    break;
                case "Left":
                    markLook("Left");
                    break;
                case "Right":
                    markLook("Right");
                    break;
                case "none":
                    // Do nowt
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                // Process keys
                markLook("left");
                return true;
            }

            if (keyData == Keys.Right)
            {
                // Process keys
                markLook("right");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cam1button_Click(object sender, EventArgs e)
        {
            videoView1.Visible = true;
            videoView1.Size = fullVideoSize;
            videoView2.Visible = false;
            zoomModifier = 1;
            camSelect1.Checked = true;
            zoom_video();
        }

        private void cam2button_Click(object sender, EventArgs e)
        {
            videoView2.Visible = true;
            videoView2.Size = fullVideoSize;
            videoView2.Location = fullVideoLocation;
            videoView1.Visible = false;
            zoomModifier = 1;

            camSelect2.Checked = true;
            zoom_video();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            videoView2.Visible = true;
            videoView1.Visible = true;
            videoView1.Size = halfVideoSize;
            videoView2.Size = halfVideoSize;
            videoView2.Location = splitVideoLocation;

            zoomModifier = 0.5f;
            zoom_video();

        }

        private void zoomTrackBar_Scroll(object sender, EventArgs e)
        {
            // videoView1.MediaPlayer.Scale = zoomTrackBar.Value /100.0f;
            // Console.WriteLine(videoView1.MediaPlayer.Scale);
            zoom_video();
        }

        private void zoom_video()
        {
            var rect = new Rectangle();
            float value = zoomTrackBar.Value * zoomModifier;

            if (camSelect1.Checked)
            {
                vidWidth = video01.Tracks[0].Data.Video.Width;
                vidHeight = video01.Tracks[0].Data.Video.Height;
                zoomTrackBar.Maximum = (int)video01.Tracks[0].Data.Video.Width / 4;

                float ratio = (float)vidHeight/ vidWidth;
                rect.Width = (int)(vidWidth - value);
                rect.Height = (int)(rect.Width * ratio);
                rect.X = (int)value;// (int)vidWidth;
                rect.Y = (int)(value * ratio); // (int)vidHeight;
            
                _mp.CropGeometry = $"{rect.Width + panRightValue}x{rect.Height + panUpValue}+{rect.X + panRightValue}+{rect.Y + panUpValue}";
                zoom1 = zoomTrackBar.Value;
                Console.WriteLine(_mp.CropGeometry + "  Ratio: " + ratio + "  Width: "+ vidWidth + "   Height: "+ vidHeight);
            }
            else
            {
                vidWidth = video02.Tracks[0].Data.Video.Width;
                vidHeight = video02.Tracks[0].Data.Video.Height;
                zoomTrackBar.Maximum = (int)video02.Tracks[0].Data.Video.Width / 4;

                float ratio = (float)vidHeight / vidWidth;

                rect.Width = (int)(vidWidth - value);
                rect.Height = (int)(rect.Width * ratio);
                rect.X = (int)value;// (int)vidWidth;
                rect.Y = (int)(value * ratio); // (int)vidHeight;
                _mp2.CropGeometry = $"{rect.Width + panRightValue}x{rect.Height + panUpValue}+{rect.X + panRightValue}+{rect.Y + panUpValue}";
                zoom2 = zoomTrackBar.Value;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panRightValue -= 10;
            zoom_video();
        }

        private void panRightButton_Click(object sender, EventArgs e)
        {
            panRightValue += 10;
            zoom_video();
        }

        private void panUpButton_Click(object sender, EventArgs e)
        {
            panUpValue += 10;
            zoom_video();
        }

        private void panDownButton_Click(object sender, EventArgs e)
        {
            panUpValue -= 10;
            zoom_video();
        }

        private void camSelect1_CheckedChanged(object sender, EventArgs e)
        {
            zoomTrackBar.Value = zoom1;
        }

        private void camSelect2_CheckedChanged(object sender, EventArgs e)
        {
            zoomTrackBar.Value = zoom2;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void videoView1_Click(object sender, EventArgs e)
        {

        }
    }
        
}
