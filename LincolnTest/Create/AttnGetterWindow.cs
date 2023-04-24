using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LincolnTest
{
    public partial class AttnGetterWindow : Form
    {
        public string attnVisLocation;
        public string attnAudioLocation;
        public Create parentWindow;

        OpenFileDialog openImageFileDialog = new OpenFileDialog();
        OpenFileDialog openAudioFileDialog = new OpenFileDialog();

        public AttnGetterWindow()
        {
            InitializeComponent();            
        }

        private void AttnGetterWindow_Load(object sender, EventArgs e)
        {

        }

        private void AttnGetterWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentWindow.setAttn(attnAudioLocation, attnVisLocation);
        }

        private void browseVisButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Properties.Settings.Default.ExpPath + @".\stimuli");
            string[] filters = new[] { "*.jpg", "*.png", "*.gif", "*.bmp" };
            openImageFileDialog.RestoreDirectory = true;
            openImageFileDialog.InitialDirectory = Properties.Settings.Default.ExpPath + @".\stimuli";
            openImageFileDialog.Filter = "Images(*.BMP; *.JPG; *.GIF,*.PNG,*.TIFF)| *.BMP; *.JPG; *.GIF; *.PNG; *.TIFF ";
            DialogResult dr = openImageFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                attnVisLocation = openImageFileDialog.FileName;
            }
        }

        private void browseAudioButton_Click(object sender, EventArgs e)
        {
            openAudioFileDialog.RestoreDirectory = true;
            openAudioFileDialog.InitialDirectory = Properties.Settings.Default.ExpPath + @".\stimuli";
            openAudioFileDialog.Filter = "Sound files(*.wav; *.mp3)| *.wav; *.mp3";
            DialogResult dr = openAudioFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                attnAudioLocation = openAudioFileDialog.FileName;
            }
        }
    }
}
