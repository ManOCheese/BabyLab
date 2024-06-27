using Basler.Pylon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace LincolnTest
{
    public partial class MainPrefs : Form
    {
        String monInfo = "";
        string displayID = Properties.Settings.Default.stimulusDisplay;
        public string stimPathVisual = Properties.Settings.Default.stimPathVisual;
        public string stimPathAudio = Properties.Settings.Default.stimPathAudio;

        public MainPrefs()
        {
            InitializeComponent();

            vStimFolderText.Text = Properties.Settings.Default.stimPathVisual;
            aStimFolderText.Text = Properties.Settings.Default.stimPathAudio;

            screenBox.Items.Add("None");

            foreach (var aScreen in Screen.AllScreens)
            {
                screenBox.Items.Add( aScreen.DeviceName);
            }

        }
        private void screenBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var aScreen in Screen.AllScreens)
            {
                monInfo = "";

                if (screenBox.Text == aScreen.DeviceName)
                {
                    monInfo += "Screen Resolution: " + aScreen.Bounds.Width + "x" + aScreen.Bounds.Height;
                    monitorInfo.Text = monInfo;
                    displayID = aScreen.DeviceName;
                }
                else
                {
                    monitorInfo.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog myOpenDialog = new FolderBrowserDialog();

            if (myOpenDialog.ShowDialog() == DialogResult.OK)
            {
                vStimFolderText.Text = myOpenDialog.SelectedPath;
                stimPathVisual = vStimFolderText.Text;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.stimulusDisplay = displayID;
            Properties.Settings.Default.stimPathVisual = vStimFolderText.Text;
            Properties.Settings.Default.stimPathAudio = aStimFolderText.Text;
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog myOpenDialog = new FolderBrowserDialog();

            if (myOpenDialog.ShowDialog() == DialogResult.OK)
            {
                aStimFolderText.Text = myOpenDialog.SelectedPath;
                stimPathAudio = aStimFolderText.Text;
            }
        }

        private void camScanButton_Click(object sender, EventArgs e)
        {
            List<ICameraInfo> allDeviceInfos = CameraFinder.Enumerate(DeviceType.GigE);

            if (allDeviceInfos.Count == 0)
            {
                MessageBox.Show("No GigE cameras present.");
            }

            foreach (ICameraInfo cameraInfo in allDeviceInfos)
            {
                MessageBox.Show("Found camera: " + cameraInfo[CameraInfoKey.DeviceIpAddress]);
            }
        }
         
        private void swapCamButton_Click(object sender, EventArgs e)
        {
            string temp = leftIPTextBox.Text;
            leftIPTextBox.Text = rightIPTextBox.Text;
            rightIPTextBox.Text = temp;
        }

        private void camPreviewButton_Click(object sender, EventArgs e)
        {
            BaslerCam camera;
            camera = new BaslerCam(leftIPTextBox.Text);

            if (camera.found)
            {
                camPreviewPictureBox.Image =  camera.aquireSingleFrame();
            }
        }
    }
}
