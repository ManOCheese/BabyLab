using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LincolnTest
{
    public partial class MainPrefs : Form
    {
        String monInfo = "";
        public string stimPath = Properties.Settings.Default.stimPath;

        public MainPrefs()
        {
            InitializeComponent();

            stimFolderText.Text = Properties.Settings.Default.stimPath;
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
                    monInfo += "Width: " + aScreen.Bounds.Width + "\r\n" + "Height: " + aScreen.Bounds.Height +"\r\n";
                    monitorInfo.Text = monInfo;
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
                stimFolderText.Text = myOpenDialog.SelectedPath;
                stimPath = stimFolderText.Text;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {            
            DialogResult = DialogResult.OK;
        }
    }
}
