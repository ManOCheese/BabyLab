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

namespace LincolnTest
{
    public partial class MainMenu : Form
    {
        MainPrefs PrefsWindow = new MainPrefs();
        string projPath;

        bool hasStimuli = false;

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
            CreateWindow.Show();
        }

        private void PresentButton_Click(object sender, EventArgs e)
        {
            Present PresentWindow = new Present();
            PresentWindow.ShowDialog();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PrefsWindow.ShowDialog() == DialogResult.OK)
            {
                
            };
        }

        private void settingsChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.stimPath = PrefsWindow.stimPath;
            checkFolders();
            checkProject();
        }

        private void checkFolders()
        {
            if (!Properties.Settings.Default.createPaths)
            {
                return;
            }

            // Check default paths exist, create if not
            if (!Directory.Exists(Properties.Settings.Default.stimPath))
            {
                return;
            }

            if (Properties.Settings.Default.stimPath != "" && Properties.Settings.Default.stimPath != null)
            {
                // Check default paths exist, create if not
                if (!Directory.Exists(Properties.Settings.Default.stimPath))
                {
                    return;
                }

                if (Directory.GetFiles(Properties.Settings.Default.stimPath, "*.jpg").Length > 0)
                {
                    hasStimuli = true;
                    errorMessage.Visible = false;
                }
            }
        }

        private void checkProject()
        {
            if(Properties.Settings.Default.LastProject != "")
            {
                if (!File.Exists(Properties.Settings.Default.LastProject + "/project.ini"))
                {
                    // error;
                    projectName.Text = "No project set";
                }
                else
                {
                    string path = Properties.Settings.Default.LastProject.TrimEnd(Path.DirectorySeparatorChar);
                    Properties.Settings.Default.ExpPath = path;

                    var MyIni = new IniFile(Properties.Settings.Default.ExpPath + "/project.ini");
                    var ProjectName = MyIni.Read("ProjectName");
                    projectName.Text = ProjectName;
                                 
                    countFiles(path);
                }
            }
            else
            {
                projectName.Text = "";
            }
        }

        private void countFiles(string path)
        {
            if (hasStimuli)
            {
                createButton.Enabled = true;
            }
            else
            {
                errorMessage.Visible = true;
            }

            int fCount = Directory.GetFiles(path, "*.bex", SearchOption.TopDirectoryOnly).Length;
            experimentCount.Text = fCount.ToString();

            if(fCount > 0 && hasStimuli == true)
            {
                presentButton.Enabled = true;
            }

            fCount = Directory.GetFiles(path + @"\output" , "*.out", SearchOption.TopDirectoryOnly).Length;
            presentCount.Text = fCount.ToString();

            if (fCount > 0 && hasStimuli)
            {
                scoreButton.Enabled = true;
            }


        }
        private void button3_Click(object sender, EventArgs e)
        {
            Score scoreWindow = new Score();
            scoreWindow.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Analyse analyseWindow = new Analyse();
            analyseWindow.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog myOpenDialog = new FolderBrowserDialog();
            PlainTextInput nameDialog = new PlainTextInput();

            // myOpenDialog.RootFolder = Environment.SpecialFolder.MyDocuments;

            if (myOpenDialog.ShowDialog() == DialogResult.OK)
            {
                projectName.Text = myOpenDialog.SelectedPath;
                Properties.Settings.Default.ExpPath = myOpenDialog.SelectedPath;
                Properties.Settings.Default.LastProject = myOpenDialog.SelectedPath;
            }

            nameDialog.setText("Set Project Name", "Project Name:");
            
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
            FolderBrowserDialog myOpenDialog = new FolderBrowserDialog();

            // myOpenDialog.RootFolder = Environment.SpecialFolder.MyDocuments;

            if (myOpenDialog.ShowDialog() == DialogResult.OK)
            {
                projectName.Text = myOpenDialog.SelectedPath;
                Properties.Settings.Default.ExpPath = myOpenDialog.SelectedPath;
                Properties.Settings.Default.LastProject = myOpenDialog.SelectedPath;
                checkProject();
            }
        }
    }
}
