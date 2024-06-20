using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

using OpenCvSharp;
using OpenCvSharp.Extensions;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using Image = System.Drawing.Image;
using Message = System.Windows.Forms.Message;

namespace LincolnTest
{
    public partial class ScoreOCV : Form
    {
        //OpenCV video parameters

        public bool isFullscreen = false;
        public bool isPlaying = false;
        private bool settingFrame = false;
        public System.Drawing.Size fullVideoSize;
        float myMS = 33;
        List<string> lines;
        float zoomModifier = 0.5f;
        int panRightValue;
        int panUpValue;
        int zoom1;
        int zoom2;
        float playbackSpeed = 1;
        int frameCache = 1;
        private bool isSaved = false;
        float brightness = 1;
        private string currTrial = "Trial 1";

        private static System.Timers.Timer aTimer;

        // Background workers for video reading and garbage collection
        private BackgroundWorker cam1Worker;
        private BackgroundWorker cam2Worker;
        private BackgroundWorker GCWorker;

        // Video file names
        string video1fullName;
        string video2fullName;


        private delegate void SafeCallDelegate(string text);

        Mat img1 = new Mat();
        int currFrame = 0;
        int newFrame = 0;
        private bool singleFrame;


        public ScoreOCV()
        {
            InitializeComponent();

            // Create background workers for reading video and garbage collection
            // These are used to keep the UI responsive while the video is playing

            cam1Worker = new BackgroundWorker();
            cam1Worker.WorkerReportsProgress = true;
            cam1Worker.DoWork += new DoWorkEventHandler(worker1_DoWork);
            cam1Worker.ProgressChanged += new ProgressChangedEventHandler(worker1_ProgressChanged);

            cam2Worker = new BackgroundWorker();
            cam2Worker.WorkerReportsProgress = true;
            cam2Worker.DoWork += new DoWorkEventHandler(worker2_DoWork);
            cam2Worker.ProgressChanged += new ProgressChangedEventHandler(worker2_ProgressChanged);

            GCWorker = new BackgroundWorker();
            GCWorker.WorkerReportsProgress = true;
            GCWorker.DoWork += new DoWorkEventHandler(GCWorker_DoWork);
            GCWorker.ProgressChanged += new ProgressChangedEventHandler(GCWorker_ProgressChanged);



            fullVideoSize = video2picbox.Size;

            IniFile MyIni = new IniFile(Properties.Settings.Default.ExpPath + "/project.ini");

            loadOutputs();

            // Create a timer with a ms interval
            aTimer = new System.Timers.Timer(100);

            timelineTrackBar.Minimum = 0;
            timelineTrackBar.Maximum = 500;

            // Create a list of playback speeds any numbers are fine
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
        // Garbage collection worker to keep memory usage low - Currently always runs every 10 seconds
        private void GCWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            while (true)
            {
                bw.ReportProgress(0);
                System.Threading.Thread.Sleep(10000); // 10 seconds - Can be changed if more optimisation is needed
            }
        }
        // Garbage collection worker action
        private void GCWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            GC.Collect();
        }

        // Background worker for reading video 1
        // This worker reads the video file and updates the video1picbox with the current frame
        // It also updates the timelineTrackBar with the current frame
        // Incorporates a playback speed to allow for slow motion playback

        private void worker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            Debug.WriteLine("Loading: " + video1fullName);

            using (VideoCapture capture1 = new VideoCapture(video1fullName))
            {
                int interval = (int)((1000 / capture1.Fps) / playbackSpeed);
                Mat image1 = new Mat();

                capture1.PosFrames = currFrame;

                OpenCvSharp.Point myPoint = new OpenCvSharp.Point(550, 950);
                Scalar fontColour = new Scalar(112255);

                // Different processes for single frame and continuous playback
                // Singleframe is used for moving to a specific frame and then pausing
                if (singleFrame)
                {

                    initTimeline(capture1.FrameCount.ToString());

                    capture1.Read(image1);
                    image1.PutText(currTrial, myPoint, HersheyFonts.HersheyComplex, 2, fontColour, 4);
                    updateTimeline(capture1.PosFrames);
                    bw.ReportProgress(0, image1);
                    singleFrame = false;
                    System.Threading.Thread.Sleep(150);                    
                    return;
                }
                

                while (isPlaying)
                {
                    if (capture1.Read(image1))
                    {
                        image1.PutText(currTrial, myPoint, HersheyFonts.HersheyComplex, 2, fontColour, 4);
                        updateTimeline(capture1.PosFrames);
                        bw.ReportProgress(0, image1);
                        System.Threading.Thread.Sleep(interval);
                    }
                }

            }

        }
        // Worker action for video 1
        private void worker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Mat image1 = (Mat)e.UserState;

            //if (!isPlaying && !singleFrame) return;

            //video1picbox.Image = image.ToBitmap();
            if (camSelect1.Checked)
            {
                video1picbox.Image = adjustBrightness(resizeImg(image1, video1picbox));
                video1picbox.Refresh();
            }
        }
        // Same as worker1 but for video 2
        private void worker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            using (VideoCapture capture2 = new VideoCapture(video2fullName))
            {
                int interval = (int)((1000 / capture2.Fps) / playbackSpeed);
                Mat image2 = new Mat();

                capture2.PosFrames = currFrame;

                OpenCvSharp.Point myPoint = new OpenCvSharp.Point(550, 950);
                Scalar fontColour = new Scalar(112255);

                // Different processes for single frame and continuous playback
                // Singleframe is used for moving to a specific frame and then pausing
                if (singleFrame)
                {
                    initTimeline(capture2.FrameCount.ToString());
                    Debug.WriteLine("Trying to draw single frame");
                    capture2.Read(image2);
                    image2.PutText(currTrial, myPoint, HersheyFonts.HersheyComplex, 2, fontColour, 4);
                    updateTimeline(capture2.PosFrames);
                    bw.ReportProgress(0, image2);
                    singleFrame = false;
                    System.Threading.Thread.Sleep(150);
                    return;
                }


                while (isPlaying)
                {
                    if (capture2.Read(image2))
                    {
                        image2.PutText(currTrial, myPoint, HersheyFonts.HersheyComplex, 2, fontColour, 4);
                        updateTimeline(capture2.PosFrames);
                        bw.ReportProgress(0, image2);
                        System.Threading.Thread.Sleep(interval);
                    }
                }

            }


        }
        // Worker action for video 2
        private void worker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Mat image2 = (Mat)e.UserState;

            //if (!isPlaying) return;
            if (camSelect2.Checked)
            {
                video2picbox.Image = adjustBrightness(resizeImg(image2, video2picbox));
                video2picbox.Refresh();
            }
        }

        // Load the outputs from the current project, uses the task name so we can load the related video files
        void loadOutputs()
        {
            DirectoryInfo dinfo = new DirectoryInfo(Properties.Settings.Default.LastProject + "\\Output");
            FileInfo[] Files = dinfo.GetFiles("*.out", SearchOption.AllDirectories);

            foreach (FileInfo file in Files)
            {
                string taskFileName = (string)file.Name;
                string[] taskName = taskFileName.Split('.');
                outputsListBox.Items.Add(taskName[0]);
            }
        }

        private void updateKeysText()
        {
            foreach (SettingsProperty setting in ScoreKB.Default.Properties)
            {
                keysTextBox.AppendText(setting.Name + " : " + ScoreKB.Default[setting.Name] + Environment.NewLine);
            }
        }
        // Process the key presses for marking the look direction
        private void markLook(string direction)
        {
            foreach (ListViewItem item in eventListView.Items)
            {
                //if (int.Parse(item.SubItems[1].Text) == (int)video1.PosFrames)
                if (int.Parse(item.SubItems[1].Text) == timelineTrackBar.Value)
                {
                    if (item.SubItems[0].Text == "Left" || item.SubItems[0].Text == "Right" || item.SubItems[0].Text == "Other")
                    {
                        item.Text = direction;
                        Debug.WriteLine("Score" + (item.Index) + direction + timelineTrackBar.Value);
                        return;
                    }
                }
                if (int.Parse(item.SubItems[1].Text) > timelineTrackBar.Value)
                {
                    string[] arr = new string[4];
                    arr[0] = direction;
                    arr[1] = timelineTrackBar.Value.ToString();
                    ListViewItem newItem = new ListViewItem(arr);
                    eventListView.Items.Insert(item.Index, newItem);
                    Debug.WriteLine("Score" + (item.Index) + direction + timelineTrackBar.Value);
                    return;
                }
            }
            // Change to save file refreshEvents(lines);
        }
        // Set up the timeline trackbar with the correct values
        private void initTimeline(string myTime)
        {
            if (timelineTrackBar.InvokeRequired)
            {
                var d = new SafeCallDelegate(initTimeline);
                try
                {
                    timelineTrackBar.Invoke(d, new object[] { myTime });
                }
                catch { }
            }
            else
            {
                timelineTrackBar.Maximum = int.Parse(myTime);
                timelineTrackBar.SmallChange = 1;
                timelineTrackBar.LargeChange = 10;
                timelineTrackBar.TickFrequency = 60;
            }
        }
        // Open the video files and the output file for the current task
        private void openCams(string task)
        {
            if (!Directory.Exists(Properties.Settings.Default.ExpPath))
            {
                var result = MessageBox.Show("Project folder not found: " + Properties.Settings.Default.ExpPath, "File error", MessageBoxButtons.OK);
                return;
            }

            string videoPath = Properties.Settings.Default.ExpPath + "\\CamOutput\\";

            video1fullName = videoPath + task + "_Left.mkv";
            video2fullName = videoPath + task + "_Right.mkv";

            if (!File.Exists(video1fullName) || !File.Exists(video2fullName))
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                // TODO : Fix error message
                result = MessageBox.Show("Video " + video1fullName + " not found", "Error", buttons);
                return;
            }

            timelineTrackBar.Maximum = 1500;
            lines = System.IO.File.ReadAllLines(Properties.Settings.Default.ExpPath + @"\output\" + task + ".out").ToList<string>();

            refreshEvents(lines);

            singleFrame = true;
            cam1Worker.RunWorkerAsync();
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
                if (eventListView.Items[i].Text.StartsWith("Trial")) eventListView.Items[i].BackColor = Color.LightSalmon;
                if (eventListView.Items[i].Text.StartsWith("show")) eventListView.Items[i].BackColor = Color.LightCyan;
                if (eventListView.Items[i].Text.StartsWith("hide")) eventListView.Items[i].BackColor = Color.LightBlue;
                if (eventListView.Items[i].Text.StartsWith("Audio")) eventListView.Items[i].BackColor = Color.LightGray;
            }
        }

        private void nextFButton_Click(object sender, EventArgs e)
        {
            // TODO: Add next frame for new video functions
            //setFrame((int)frameUpDown.Value);
        }

       
        // Resize the image to the zoom setting
        // TODO: Realign doesn't work properly
        private Bitmap resizeImg(Mat imgIn, PictureBox picBox)
        {
            Mat tmpImg = new Mat();
            if (imgIn.Width == 0) return null;

            OpenCvSharp.Size newSize = new OpenCvSharp.Size(imgIn.Width * zoomModifier, imgIn.Height * zoomModifier);
            InterpolationFlags interpolation = InterpolationFlags.Linear;
            Cv2.Resize(imgIn, tmpImg, newSize, zoomModifier, zoomModifier, interpolation);

            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(tmpImg);
        }
        // Uses a colour matrix to fake a brightness adjustment
        private Bitmap adjustBrightness(Bitmap tempBitmap)
        {
            float FinalValue = brightness;// / 255.0f;
            ImageAttributes imageAttributes = new ImageAttributes();
            Bitmap newBitmap = new Bitmap(tempBitmap.Width, tempBitmap.Height);
            Graphics NewGraphics = Graphics.FromImage(newBitmap);

            float[][] colorMatrixElements = {
                new float[] {FinalValue,  0,  0,  0, 0},
                new float[] {0,FinalValue,  0,  0, 0},
                new float[] {0,  0,FinalValue,  0, 0},
                new float[] {0,  0,  0,  1, 0},
                new float[] {0, 0, 0, 0, 1}};

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(
               colorMatrix,
               ColorMatrixFlag.Default,
               ColorAdjustType.Bitmap);

            ImageAttributes Attributes = new ImageAttributes();
            Attributes.SetColorMatrix(colorMatrix);

            int zoomX = (int)(0 - ((zoomModifier - 0.5f) * (tempBitmap.Width / 2)));
            int zoomY = (int)(0 - ((zoomModifier - 0.5f) * (tempBitmap.Height / 2)));

            // Debug.WriteLine(zoomModifier + ":" + zoomX);

            NewGraphics.DrawImage(tempBitmap,
                new Rectangle(zoomX, zoomY, tempBitmap.Width, tempBitmap.Height),
                0, 0, tempBitmap.Width, tempBitmap.Height, GraphicsUnit.Pixel, Attributes);

            tempBitmap.Dispose();
            Attributes.Dispose();
            NewGraphics.Dispose();

            return newBitmap;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            playPause();
        }

        private void playPause()
        {
            if (isPlaying) // if is playing
            {
                //videoTimer.Enabled = false;
                isPlaying = false;
            }
            else // it's not playing?
            {
                isPlaying = true;
                cam1Worker.RunWorkerAsync();
            }
        }


        private void prevFButton_Click(object sender, EventArgs e)
        {
            // TODO: Add previous frame for new video functions
            //setFrame((int)frameUpDown.Value * -1);
        }

        private void lastFrame()
        {
            //if (video1.PosFrames >= myMS)
            //{
            //    video1.PosFrames = video1.PosFrames - 1;
            //}
        }
        // Check if saved before closing
        // TODO: isSaved needs to be set
        private void Score_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSaved)
            {
                // Display a MsgBox asking the user to save changes or abort.
                if (MessageBox.Show("Quit without saving?", "Unsaved changes",
                   MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                    // Call method to save file...
                }
            }

            aTimer.Enabled = false;
            aTimer.Stop();
            aTimer.Close();            
        }

        private void Score_FormClosed(object sender, FormClosedEventArgs e)
        {
            aTimer.Stop();
            aTimer.Close();
        }

        
        // Update the timeline trackbar with the current frame
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = "Frame: " + timelineTrackBar.Value;
            int change = timelineTrackBar.Value - currFrame;
            //setFrame(change);
            currFrame = timelineTrackBar.Value;
        }


        private void speedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            playbackSpeed = float.Parse(speedComboBox.Text);
        }
        private void eventListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eventListView.SelectedIndices.Count != 1) return;

            int index = eventListView.SelectedIndices[0];

            if (eventListView.SelectedItems.Count == 1)
            {
                while (!eventListView.Items[index].Text.StartsWith("Trial"))
                {
                    if (index == 0) break;
                    index--;
                }
            
            }
            Debug.WriteLine("Attemting to change: " + int.Parse(eventListView.SelectedItems[0].SubItems[1].Text));
            int desiredFrame = int.Parse(eventListView.SelectedItems[0].SubItems[1].Text);
            //setFrame(desiredFrame);
            //_mp.Time = int.Parse(eventListView.SelectedItems[0].SubItems[1].Text);

            // Only update the timeline if the video is not playing
            if (!cam1Worker.IsBusy)
            {
                singleFrame = true;
                currFrame = desiredFrame;
                cam1Worker.RunWorkerAsync();
            }
        }

        private void updateTimeline(int value)
        {
            if (timelineTrackBar.InvokeRequired)
            {
                timelineTrackBar.Invoke(new Action<int>(updateTimeline), value);
                return;
            }
            if (value >= 0)
            {

                foreach (ListViewItem item in eventListView.Items)
                {

                    Debug.WriteLine(currTrial);
                    if (int.Parse(item.SubItems[1].Text) == timelineTrackBar.Value)
                    {
                        Debug.WriteLine(currTrial);
                        if (item.SubItems[0].Text.StartsWith("Trial"))
                        {
                            currTrial = item.SubItems[0].Text;
                        }
                        if (item.SubItems[0].Text.StartsWith("hide"))
                        {
                            currTrial = "  ";
                        }
                    }
                }
                timelineTrackBar.Value = value;
            }
        }
        private void updateScore(int newFrame)
        {
            if (scoreLabel.InvokeRequired)
            {
                scoreLabel.Invoke(new Action<int>(updateScore), newFrame);
                return;
            }

            foreach (ListViewItem item in eventListView.Items)
            {
                if (item.SubItems[1].Text == newFrame.ToString())
                {
                    scoreLabel.Text = item.SubItems[0].Text;
                }
                else
                {
                    scoreLabel.Text = "";
                }
            }


        }


        // Override key presses for marking the look direction
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                markLook("Left");
                return true;
            }
            if (keyData == Keys.Right)
            {
                markLook("Right");
                return true;
            }
            if (keyData == Keys.Down)
            {
                markLook("Other");
                return true;
            }
            if (keyData == Keys.Up)
            {
                return true;
            }
            if (keyData == Keys.Space)
            {
                playPause();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cam1button_Click(object sender, EventArgs e)
        {
            video1picbox.Size = fullVideoSize;
            video2picbox.Size = fullVideoSize;
            video1picbox.Visible = true;
            video2picbox.Visible = false;
            zoomModifier = 0.5f;
            camSelect1.Checked = true;
        }

        private void cam2button_Click(object sender, EventArgs e)
        {
            video2picbox.Location = video1picbox.Location;
            video1picbox.Size = fullVideoSize;
            video2picbox.Size = fullVideoSize;
            video1picbox.Visible = false;
            video2picbox.Visible = true;
            zoomModifier = 0.5f;

            camSelect2.Checked = true;

            singleFrame = true;
            cam2Worker.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            video1picbox.Visible = true;
            video2picbox.Visible = true;
            video1picbox.Size = new System.Drawing.Size(fullVideoSize.Width / 2, fullVideoSize.Height / 2);
            video2picbox.Size = new System.Drawing.Size(fullVideoSize.Width / 2, fullVideoSize.Height / 2);
            video2picbox.Location = new System.Drawing.Point(video1picbox.Location.X + video2picbox.Width, video1picbox.Location.Y);

            zoomModifier = 0.5f;

        }

        private void zoomTrackBar_Scroll(object sender, EventArgs e)
        {
            if (settingFrame) return;
            zoomModifier = (zoomTrackBar.Value / 100.0f) + 0.5f;
            //setFrame(0);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            panRightValue -= 10;
        }

        private void panRightButton_Click(object sender, EventArgs e)
        {
            panRightValue += 10;
        }

        private void panUpButton_Click(object sender, EventArgs e)
        {
            panUpValue += 10;
        }

        private void panDownButton_Click(object sender, EventArgs e)
        {
            panUpValue -= 10;
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
            List<string> output = new List<string>();
            output.Add("Event,Frame,Time");

            foreach (ListViewItem item in eventListView.Items)
            {
                Int32.TryParse(item.SubItems[1].Text, out int frameInMS);
                string a = item.SubItems[0].Text;
                string b = item.SubItems[1].Text;
                string c = (frameInMS * 60).ToString();

                output.Add(a + "," + b + "," + c);
            }
            Directory.CreateDirectory(Properties.Settings.Default.LastProject + @"\output\scored\");
            string outPath = Properties.Settings.Default.LastProject + @"\output\scored\";
            
            int existingCount = Directory.GetFiles(outPath, outputsListBox.Text+"*").Count();
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(outPath, outputsListBox.Text + "_scored"+ existingCount + ".csv")))
            {
                foreach (string line in output)
                    outputFile.WriteLine(line);
                outputFile.Close();
            }
        }

        private void videoView1_Click(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            //currTrial++;
        }

        private void ScoreOCV_Load(object sender, EventArgs e)
        {

        }

        private void outputsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            openCams(outputsListBox.Text);
        }

        private void timelineTrackBar_MouseUp(object sender, MouseEventArgs e)
        {

            singleFrame = true;
            cam1Worker.RunWorkerAsync();
        }

        private void brightTrackBar_Scroll(object sender, EventArgs e)
        {
            brightness = (float)brightTrackBar.Value / 100;
            if (!cam1Worker.IsBusy)
            {
                singleFrame = true;
                cam1Worker.RunWorkerAsync();
            }
        }
    }

}
