using OpenCvSharp.Flann;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace LincolnTest

{
    public partial class DataWindow : Form
    {
        string scoredPath;
        string outPath;

        string[] scoreFiles;
        string[] presentFiles;

        int cutoff = 300 / 60;

        List<string> data = new List<string>();
        List<string> presData = new List<string>();

        List<LookData> lookData = new List<LookData>();

        public DataWindow()
        {
            InitializeComponent();

            loadOutputs();
        }
        private void loadOutputs()
        {
            scoredPath = Properties.Settings.Default.ExpPath + @"\output\scored\";
            scoreFiles = Directory.GetFiles(scoredPath);

            foreach (string file in scoreFiles)
            {
                dataFilesList.Items.Add(System.IO.Path.GetFileName(file));
            }

            outPath = Properties.Settings.Default.ExpPath + @"\output\";
            presentFiles = Directory.GetFiles(outPath);
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            int index = 0;

            foreach (string file in scoreFiles)
            {
                Debug.WriteLine(file);
                const Int32 BufferSize = 128;
                using (var scoreStream = File.OpenRead(file))
                using (var scoreReader = new StreamReader(scoreStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    while ((line = scoreReader.ReadLine()) != null)
                    {
                        data.Add(line);
                    }
                }

                
                string presentFile = System.IO.Path.GetFileName(file).Split('_')[0] + ".out";
                using (var fileStream = File.OpenRead(Properties.Settings.Default.ExpPath + @"\output\" + presentFile))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        presData.Add(line);
                    }
                }

                data.Remove("Event,Frame,ms");

                string eventString;
                string frameString;
                string msString;

                List<string[]> looks = new List<string[]>();

                int trialStart = 0;

                foreach (string line in data)
                {
                    eventString = line.Split(',')[0];
                    frameString = line.Split(',')[1];
                    msString = line.Split(',')[2];

                    if (eventString.StartsWith("showStims"))
                    {
                        Int32.TryParse(msString.Split('.')[0], out trialStart);
                        Debug.WriteLine("Task Start: " + trialStart);
                        return;
                    }

                    if (eventString.StartsWith("hideStims"))
                    {
                        lookData.Add(new LookData());
                        Int32.TryParse(msString.Split('.')[0], out int endTime);
                        int totalTime = endTime - trialStart;
                        Debug.WriteLine("Trial length: " + totalTime);
                        lookData[index].trial = index.ToString();
                        processLooks(looks, trialStart, lookData[index]);
                        looks.Clear();
                        index++;
                    }

                    switch (eventString)
                    {
                        case "Left":
                            looks.Add(line.Split(','));
                            break;
                        case "Right":
                            looks.Add(line.Split(','));
                            break;
                        case "Other":
                            looks.Add(line.Split(','));
                            break;
                        default:
                            // code block
                            break;
                    }
                }
                data.Clear();
            }

            outputDGV.Columns.Add("Look", "Look");
            outputDGV.Columns.Add("Length", "Length");
            outputDGV.Columns.Add("isPre", "isPre");
            outputDGV.Columns.Add("Trial", "Trial");

            trialUpDown.Maximum = lookData.Count;

        }

        private void processLooks(List<string[]> looks, int trialStart, LookData lookData)
        {
            string thisLook;
            string prevLook = "Start";

            bool isFirstPost = false;
            bool isPre = true;

            int prevLookTime = 0;

            foreach (string[] look in looks)
            {
                Int32.TryParse(look[2].Split('.')[0], out int lookTime);
                thisLook = look[0];

                if (lookTime == trialStart + cutoff)
                {
                    isFirstPost = true;
                }
                else
                {
                    isFirstPost = false;
                }

                if (lookTime <= trialStart + cutoff)
                {
                    isPre = true;
                }
                else
                {
                    isPre = false;
                }


                // if (look[0] != prevLook || isFirstPost)
                if (look[0] != prevLook)
                {
                    // Debug.WriteLine("This Look: " + look[0] + "  Last look: " + prevLook);
                    switch (prevLook)
                    {
                        case "Left":
                            lookData.length.Add(lookTime - prevLookTime);
                            lookData.look.Add(prevLook);
                            lookData.isPre.Add(isPre);
                            prevLookTime = lookTime;
                            prevLook = thisLook;
                            break;
                        case "Right":
                            lookData.length.Add(lookTime - prevLookTime);
                            lookData.look.Add(prevLook);
                            lookData.isPre.Add(isPre);
                            prevLookTime = lookTime;
                            prevLook = thisLook;
                            break;
                        case "Other":
                            lookData.length.Add(lookTime - prevLookTime);
                            lookData.look.Add(prevLook);
                            lookData.isPre.Add(isPre);
                            prevLookTime = lookTime;
                            prevLook = thisLook;
                            break;
                        case "Start":
                            prevLookTime = lookTime;
                            prevLook = thisLook;
                            break;
                        default:
                            // code block
                            break;
                    }
                }
            }
        }

        private void dataFilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void trialUpDown_ValueChanged(object sender, EventArgs e)
        {
            int index = (int)trialUpDown.Value;

            for (int i = 0; i < lookData[index].look.Count; i++)
            {
                outputDGV.Rows.Add();

                outputDGV.Rows[i].Cells[0].Value = lookData[index].look[i];
                outputDGV.Rows[i].Cells[1].Value = lookData[index].length[i];
                outputDGV.Rows[i].Cells[2].Value = lookData[index].isPre[i].ToString();
                outputDGV.Rows[i].Cells[3].Value = lookData[index].trial;
                //outputDGV.Rows[i].Cells[4].Value = audioStimSide[i];
            }
        }
    }

    public class LookData
    {
        public string trial { get; set; }
        public List<bool> isPre { get; set; }
        public List<string> look { get; set; }
        public List<int> length { get; set; }
        public string leftImage { get; set; }
        public string rightImage { get; set; }

        public LookData()
        {
            trial = "";
            isPre = new List<bool>();
            look = new List<string>();
            length = new List<int>();
            leftImage = "";
            rightImage = "";
        }

        public void DisplayData()
        {
            foreach (var item in look)
            {


            }
        }
    }
}

