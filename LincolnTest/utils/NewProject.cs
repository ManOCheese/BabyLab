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

namespace LincolnTest.utils
{
    public partial class NewProject : Form
    {
        string projFolder;
        string projectName;
        bool hasName = false;
        bool hasFolder = false;
        public MainMenu menuRef;

        public NewProject()
        {
            InitializeComponent();

            // ...

        }
        private void createButton_Click(object sender, EventArgs e)
        {
            // Create folders and project info file
            Properties.Settings.Default.ExpPath = Path.GetDirectoryName(projFolder);
            Properties.Settings.Default.LastProject = Properties.Settings.Default.ExpPath;
            Directory.CreateDirectory(Properties.Settings.Default.ExpPath + @"\Output");
            string path = Path.GetDirectoryName(projFolder) + @"\" + projectName + ".blp";

            if (!File.Exists(path))
            {
                // Create a file to write to
                utils.IniFile MyIni = new utils.IniFile(path);
                MyIni.Write("Project Name", projectName);
            }

            menuRef.projFolder = projFolder;
            menuRef = null;

            Close();
        }

       
        private void browseButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                int fCount = Directory.GetFiles(Path.GetDirectoryName(folderBrowser.FileName), "*.blp", SearchOption.TopDirectoryOnly).Length;
                if (fCount > 0)
                {
                    string message = "Please select a different folder or use Open to access this project";
                    string caption = "This folder already contains a project";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    return;
                }
                else
                {
                    hasFolder = true;
                    projFolder = Path.GetDirectoryName(folderBrowser.FileName);
                    projectFolderTextBox.Text = projFolder;
                }
                EnableCreateButton();
            }
        }

        private void projNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (projNameTextBox.Text.Length > 0)
            {
                hasName = true;
            }
            else
            {
                hasName = false;
                createButton.Enabled = false;
            }
            EnableCreateButton();
        }

        private void EnableCreateButton()
        {
            if(hasName == true && hasName == true)
            {
                createButton.Enabled = true;
            }
        }
    }
}
