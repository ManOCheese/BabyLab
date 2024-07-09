using Basler.Pylon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using System.Xml;

namespace LincolnTest
{
    public partial class Present : Form
    {
        //Init XML interface
        CreateXML myXML = new CreateXML();
        XmlDocument doc = new XmlDocument();

        //BlockInfo blockInfo = new BlockInfo();
        //TrialInfo trialInfo = new TrialInfo();

        XmlNodeList trialList = null;

        // XML tracking variables
        XmlNode selectedBlock = null;
        // XmlNode selectedTrial = null;

        // Create Child windows Window
        PresentKBOp presWindow = new PresentKBOp();
        viewSettings viewSettingsWindow = new viewSettings();
        StimWind stimWindow = new StimWind();

        private static System.Timers.Timer previewTimer;
        private static System.Timers.Timer camPreviewTimer;

        // Background workers for video recording
        private BackgroundWorker cam1Worker;
        private BackgroundWorker cam2Worker;

        Bitmap preview = new Bitmap(1920, 1080);
        Rectangle rec = new Rectangle(0, 0, 1920, 1080);
        private delegate void SafeCallDelegate(Object source, ElapsedEventArgs e);

        // Temp lists for counterbalance button
        List<string> tempStimsL = new List<string>();
        List<string> tempStimsR = new List<string>();
        List<string> tempAudioStims = new List<string>();
        List<string> tempAudioStimsCB = new List<string>();

        // Basler Cameras
        BaslerCam camera;
        BaslerCam camera2;
        bool cameraHidden;
        string camOutputPath = "";



        float keyFrame = 0;

        private PixelDataConverter converter = new PixelDataConverter();

        public Present()
        {
            InitializeComponent();
            PopulateExpListBox();
            UpdateKeysText();


        }

        private bool setupCameras()
        {
            // TODO: Don't hard code the IP addresses

            camera = new BaslerCam("169.254.72.175");
            camera2 = new BaslerCam("169.254.78.175");

            // If we have both cameras, set the camera path and name
            // Camera name is the name of the trial, so we can load the correct video
            if (camera.found && camera2.found)
            {
                Debug.WriteLine("Cams found");
                string taskFileName = (string)expListBox.Text;
                string[] taskName = taskFileName.Split('.');

                camOutputPath = Properties.Settings.Default.ExpPath + "\\CamOutput\\";
                Directory.CreateDirectory(camOutputPath);

                return true;
            }
            scanCamButton.Enabled = true;

            return false;
        }

        // Start the continuous shots on both cameras
        private void startCameras()
        {
            showCamButton.Enabled = false;
            hideCamButton.Enabled = true;

            // Timer to update the camera preview
            camPreviewTimer = new System.Timers.Timer(120);

            camPreviewTimer.Elapsed += cameraPreview;
            camPreviewTimer.AutoReset = true;
            camPreviewTimer.Enabled = true;

            camera2.cam_name = trialListBox.Text + "_Right";
            camera2.camPath = camOutputPath;
            camera.camPath = camOutputPath;
            Debug.WriteLine("Trial name: " + trialListBox.Text);
            camera.cam_name = trialListBox.Text + "_Left";
            
            if (camera.found)
            {
                Debug.WriteLine("Starting cam1");
                camera.conShot();
            }
            else
            {
                Debug.WriteLine("Cam not found");
            }

            

            if (camera2.found)
            {
                Debug.WriteLine("Starting cam2");
                camera2.conShot();
            }
            else
            {
                Debug.WriteLine("Cam2 not found");
            }
            camera.writing = true;
            camera2.writing = true;
        }


        // Populate the experiment list box with the .bex files in the experiment directory
        private void PopulateExpListBox()
        {
            DirectoryInfo dinfo = new DirectoryInfo(Properties.Settings.Default.ExpPath);
            FileInfo[] Files = dinfo.GetFiles("*.bex");
            expListBox.Items.Clear();

            foreach (FileInfo file in Files)
            {
                expListBox.Items.Add(file.Name);
                Debug.WriteLine(file.Name);
            }
        }

        private void UpdateKeysText()
        {
            foreach (SettingsProperty setting in Properties.PresentKB.Default.Properties)
            {
                string text;

                if (setting.Name.Length > 8)
                {
                    text = setting.Name + ":\t" + Properties.PresentKB.Default[setting.Name] + Environment.NewLine;
                }
                else
                {
                    text = setting.Name + ":\t\t" + Properties.PresentKB.Default[setting.Name] + Environment.NewLine;
                }

                keyTextBox.AppendText(text);
            }
        }
        // Refresh the block list box with the blocks in the selected experiment
        private void refreshBlockList()
        {
            // Clear current list
            blockListBox.Items.Clear();

            // Get reader to read the blocks
            List<string> blocks = myXML.getBlockList(expListBox.Text);

            Debug.WriteLine("Read " + blocks.Count + " lines");
            if (blocks.Count == 0) return;

            foreach (string block in blocks)
            {
                blockListBox.Items.Add(block);
            }
        }
        // Refresh the trial list box with the trials in the selected block
        private void refresh_trialListBox()
        {
            // Clear current list
            trialListBox.Items.Clear();

            // Get reader to read the blocks
            List<string> trials = myXML.getTrialList(blockListBox.Text);

            if (trials.Count == 0) return;

            foreach (string trial in trials)
            {
                trialListBox.Items.Add(trial);
            }
        }
        // Enable the start button if a trial is selected in the trial list box and disable it if not
        private void readyToStart()
        {
            if (trialListBox.SelectedItems.Count > 0)
            {
                startButton.Enabled = true;
            }
            else
            {
                startButton.Enabled = false;
            }
        }
        // Start the experiment
        private void startButton_Click(object sender, EventArgs e)
        {
            if (trialListBox.SelectedItems.Count == 0) return;

            if (setupCameras())
            {
                startCameras();
            }

            // Parent window is this window
            stimWindow.parentWindow = this;
            stimWindow.isAutoPlay = autoRunCheckBox.Checked;

            // Send the selected trial to the stimwindow
            int i = trialListBox.SelectedIndex;

            stimWindow.blockInfo = myXML.getBlockInfo(blockListBox.SelectedIndex);
            stimWindow.trialInfo = myXML.getTrialInfo(trialListBox.Items[i].ToString());

            stimWindow.trialInfo.isPresented = true;
            stimWindow.trialInfo.partAge  = dateTimePicker1.Value.ToString();
            myXML.updateTrial(trialListBox.SelectedIndex, stimWindow.trialInfo);

            // Init the stim window and start it sending preview images back
            stimWindow.SetupExperiment();
            stimWindow.DrawToBitmap(preview, rec);
            stimWindow.Show();
            stimWindow.isShuffled = shuffleCheckBox.Checked;

            // Update preview image
            StimWinPreview.Image = preview;

            // Timer to update the preview image
            previewTimer = new System.Timers.Timer(60);
            // previewTimer.Elapsed += refreshPreview;
            previewTimer.AutoReset = true;
            previewTimer.Enabled = true;

            // Start the cameras writing to video
            startButton.Enabled = false;;
        }

        // Update the experiment preview image
        private void refreshPreview(Object source, ElapsedEventArgs e)
        {
            if (stimWindow == null)
            {
                return;
            }
            if (stimWindow.InvokeRequired)
            {
                var d = new SafeCallDelegate(refreshPreview);
                try
                {
                    stimWindow.Invoke(d, new object[] { source, e });
                }
                catch
                {
                    Console.WriteLine("Failed hide");
                }
            }
            else
            {
                if (!stimWindow.IsDisposed)
                {
                    stimWindow.DrawToBitmap(preview, rec);
                    StimWinPreview.Image = preview;
                }
            }
        }
        //Update the camera preview image
        private void cameraPreview(Object source, ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                var d = new SafeCallDelegate(cameraPreview);
                try
                {
                    this.Invoke(d, new object[] { source, e });
                }
                catch
                {
                    Console.WriteLine("Failed hide");
                }
            }
            else
            {
                if (camera.grabResult != null && !cameraHidden)
                {
                    if (statusLabel1.Text == "Offline")
                    {
                        statusLabel1.Text = "Online";
                    }
                    cameraImageBox1.Image = camera.bitmap;
                    cameraImageBox2.Image = camera2.bitmap;
                }
            }
        }

        // Called when the stim window is closed
        public void stimWindowClosed()
        {

            stimWindow.Invoke((MethodInvoker)delegate
            {
                // Hide the stim window and stop the cameras
                this.startButton.Enabled = true;
                stimWindow.Hide();
                previewTimer.Stop();
                camera.Stop();
                camera2.Stop();
            });
        }


        // TODO: Implement this check
        private bool checkStimulusFile(string stimulus)
        {
            if (stimulus == "") { return true; }

            if (File.Exists(Properties.Settings.Default.stimPathVisual + "/" + stimulus))
            {
                return true;
            }
            else
            {
                // errorMessage("Image " + stimulus + " not found", "");
                return false;
            }
        }

        public float getCameraFrames()
        {

            keyFrame = camera.getKeyFrame();


            return keyFrame;
        }

        private void keySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presWindow.ShowDialog();
        }

        private void viewSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewSettingsWindow.Show();
        }

        private void newProjectMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToExistingMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void expListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => refreshBlockList()));
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        // Check if the camera is connected
        private void scanCamButton_Click(object sender, EventArgs e)
        {
            if (setupCameras())
            {
                Debug.WriteLine("Found");
                scanCamButton.Enabled = false;
            }
            else
            {
                Debug.WriteLine("Not Found");
            }
        }

        // TODO: Lock the cursor so StimWindow doesn't lose focus
        private void lockCursor(bool isLocked)
        {
            if (isLocked)
            {
                var rc = stimWindow.RectangleToScreen(new Rectangle(System.Drawing.Point.Empty, stimWindow.ClientSize));
                Cursor.Position = new System.Drawing.Point(rc.Left + rc.Width / 2, rc.Top + rc.Height / 2);
                Cursor.Clip = rc;
                stimWindow.Capture = true;
                stimWindow.Cursor = Cursors.Cross;
                stimWindow.Focus();
            }
            else
            {
                Cursor.Clip = new Rectangle(0, 0, 0, 0);
                stimWindow.Capture = false;
                stimWindow.Cursor = Cursors.Default;
            }
        }


        private void showCamButton_Click(object sender, EventArgs e)
        {
            cameraHidden = false;
            showCamButton.Enabled = false;
            hideCamButton.Enabled = true;
        }

        private void hideCamButton_Click(object sender, EventArgs e)
        {
            cameraHidden = true;
            showCamButton.Enabled = true;
            hideCamButton.Enabled = false;
        }

        private void trialListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => readyToStart()));


        }


        private void blockListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => refresh_trialListBox()));
        }

        private void shuffleCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan diff = DateTime.Now.Subtract(dateTimePicker1.Value);
            ageLabel.Text = diff.Days.ToString() + " days old";
        }
    }

}

