using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using static System.Net.WebRequestMethods;

namespace LincolnTest
{
    public partial class MainMenu : Form
    {
        MainPrefs PrefsWindow = new MainPrefs();
        string projPath;

        bool hasStimuliV = false;
        bool hasStimuliA = false;

        public MainMenu()
        {
            InitializeComponent();
            PrefsWindow.FormClosed += settingsChanged;

            checkFolders();
            checkProject();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create CreateWindow = new Create();
            CreateWindow.FormClosed += settingsChanged;
            CreateWindow.Show();
        }

        private void PresentButton_Click(object sender, EventArgs e)
        {
            Present PresentWindow = new Present();
            PresentWindow.FormClosed += settingsChanged;
            PresentWindow.ShowDialog();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PrefsWindow.ShowDialog() == DialogResult.OK)
            {

            };
        }


        // Update stimuli counts so we know if we can proceed

        private void settingsChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.stimPathVisual = PrefsWindow.stimPathVisual;
            Properties.Settings.Default.stimPathAudio = PrefsWindow.stimPathAudio;
            Properties.Settings.Default.Save();
            checkFolders();
            checkProject();
        }

        private void checkFolders()
        {
            string[] filters = new[] { "*.jpg", "*.png", "*.gif", "*.bmp" };

            // Check default paths exist
            if (Directory.Exists(Properties.Settings.Default.stimPathVisual))
            {
                int stimCount = countFilesinFolder(Properties.Settings.Default.stimPathVisual, filters);
                
                if (stimCount > 0)
                {
                    stimCountV.Text = stimCount.ToString();
                    hasStimuliV = true;
                }
                else
                {
                    stimCountV.Text = "Stim folder empty";
                }
            }
            else
            {
                stimCountV.Text = "Stim folder empty";
            }

            if (Directory.Exists(Properties.Settings.Default.stimPathAudio))
            {
                int audioCount = countFilesinFolder(Properties.Settings.Default.stimPathAudio, filters);

                if (audioCount > 0)
                {
                    hasStimuliA = true;
                    stimCountA.Text = audioCount.ToString();
                }
                else
                {
                    stimCountA.Text = "Stim folder empty";
                }
            }
            else
            {
                stimCountA.Text = "Stim folder missing";
            }

            // TODO: Add error message
        }
        // Count files in any folder
        private int countFilesinFolder(string path, string[] types)
        {
            List<FileInfo> Files = new List<FileInfo>();
            DirectoryInfo dvstiminfo = new DirectoryInfo(path);

            // Check stim folder and count files
            foreach (String ext in types)
            {
                FileInfo[] TempFiles = dvstiminfo.GetFiles(ext);
                Files.AddRange(TempFiles);
            }

            return Files.Count;
        }
        // See if we already have a project set
        private void checkProject()
        {
            if (Properties.Settings.Default.LastProject != "")
            {
                if (!System.IO.File.Exists(Properties.Settings.Default.LastProject + "/project.ini"))
                {
                    // error;
                    projectName.Text = "No project set";
                }
                else
                {
                    string path = Properties.Settings.Default.LastProject.TrimEnd(Path.DirectorySeparatorChar);
                    Properties.Settings.Default.ExpPath = path;
                    Properties.Settings.Default.Save();

                    var MyIni = new IniFile(Properties.Settings.Default.ExpPath + "/project.ini");
                    var ProjectName = MyIni.Read("ProjectName");

                    directoryLabel.Text = Properties.Settings.Default.ExpPath;
                    projectName.Text = ProjectName;

                    countFiles(path);
                }
            }
            else
            {
                projectName.Text = "";
            }
        }
        // Check to see if we can enable each button by looking for previously completed outputs
        private void countFiles(string path)
        {
            if (hasStimuliA && hasStimuliV)
            {
                createButton.Enabled = true;
            }
            else
            {
                stimCountText.Visible = true;
            }

            int fCount = Directory.GetFiles(path, "*.bex", SearchOption.AllDirectories).Length;
            experimentCount.Text = fCount.ToString();

            if (fCount > 0 && hasStimuliA && hasStimuliV == true)
            {
                presentButton.Enabled = true;
            }

            fCount = Directory.GetFiles(path + @"\output", "*.out", SearchOption.AllDirectories).Length;
            presentCount.Text = fCount.ToString();

            if (fCount > 0 && hasStimuliA && hasStimuliV)
            {
                scoreButton.Enabled = true;
            }

            Directory.CreateDirectory(path + @"\output\scored");
            fCount = Directory.GetFiles(path + @"\output\scored", "*.csv", SearchOption.AllDirectories).Length;
            scoredCountText.Text = fCount.ToString();

            if (fCount > 0)
            {
                analyseButton.Enabled = true;
            }


        }
        private void button3_Click(object sender, EventArgs e)
        {
            ScoreOCV scoreWindow = new ScoreOCV();
            scoreWindow.FormClosed -= settingsChanged;
            scoreWindow.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataWindow analyseWindow = new DataWindow();
            analyseWindow.FormClosed -= settingsChanged;
            analyseWindow.Show();
        }
        // Drop down menu
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog myOpenDialog = new CommonOpenFileDialog();
            PlainTextInput nameDialog = new PlainTextInput();

            myOpenDialog.IsFolderPicker = true;

            // myOpenDialog.RootFolder = Environment.SpecialFolder.MyDocuments;

            if (myOpenDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                projectName.Text = myOpenDialog.FileName;
                Properties.Settings.Default.ExpPath = myOpenDialog.FileName;
                Properties.Settings.Default.LastProject = myOpenDialog.FileName;
                Properties.Settings.Default.Save();
            }
            else
            {
                return;
            }

            nameDialog.setText("Set Project Name", "Project Name:");
            directoryLabel.Text = myOpenDialog.FileName;

            if (nameDialog.ShowDialog() == DialogResult.OK)
            {
                var MyIni = new IniFile(Properties.Settings.Default.ExpPath + "/project.ini");
                MyIni.Write("ProjectName", nameDialog.pname);
                Directory.CreateDirectory(Properties.Settings.Default.ExpPath + "/Output");
                checkProject();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog myOpenDialog = new CommonOpenFileDialog();
            myOpenDialog.IsFolderPicker = true;
            // myOpenDialog.RootFolder = Environment.SpecialFolder.MyDocuments;

            if (myOpenDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                projectName.Text = myOpenDialog.FileName;
                Properties.Settings.Default.ExpPath = myOpenDialog.FileName;
                Properties.Settings.Default.LastProject = myOpenDialog.FileName;
                checkProject();
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
