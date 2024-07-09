using OpenCvSharp.Dnn;
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
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace LincolnTest

{
    public partial class DataWindow : Form
    {
        // Data variables
        string scoredPath;
        string[] scoreFiles;
        string currBlock;

        int cutoff = 3000;
        int latency = 0;

        List<string> data = new List<string>();
        List<string> presData = new List<string>();

        List<LookData> lookData = new List<LookData>();
        List<LookData> partData = new List<LookData>();

        //Init XML interface
        CreateXML myXML = new CreateXML();
        XmlDocument doc = new XmlDocument();


        BlockInfo blockInfo = new BlockInfo();
        TrialInfo trialInfo = new TrialInfo();


        public DataWindow()
        {
            InitializeComponent();

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Include";
            checkColumn.HeaderText = "Include";

            // Add columns to the data grid view
            outputDGV.Columns.Add("Look", "Look");
            outputDGV.Columns.Add("Length", "Length");
            outputDGV.Columns.Add("isPre", "isPre");
            outputDGV.Columns.Add("LImage", "Left Image");
            outputDGV.Columns.Add("RImage", "Right Image");
            outputDGV.Columns.Add("Side", "Side");
            outputDGV.Columns.Add(checkColumn);

            outputDGV.Columns[0].Width = 50;
            outputDGV.Columns[2].Width = 50;
            outputDGV.Columns[3].Width = 150;
            outputDGV.Columns[4].Width = 150;
            outputDGV.Columns[5].Width = 50;
            outputDGV.Columns[6].Width = 50;


            scoredPath = Properties.Settings.Default.ExpPath + @"\output\scored\";
            scoreFiles = Directory.GetFiles(scoredPath);

            readFiles();
            loadData();
        }
        private void loadData()
        {
            DirectoryInfo dinfo = new DirectoryInfo(Properties.Settings.Default.ExpPath);
            FileInfo[] Files = dinfo.GetFiles("*.bex");
            expListBox.Items.Clear();
            foreach (FileInfo file in Files)
            {
                expListBox.Items.Add(file.Name);
            }
            if (expListBox.Items.Count > 0)
            {
                expListBox.SelectedIndex = 0;
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < trialListBox.Items.Count; i++)
            {
                trialListBox.SelectedIndex = i;
            }

            List<string> outputs = new List<string>();

            string prevPart = "";
            int index = -1;

            if (!perPartCheck.Checked)
            {
                outputs.Add("");
            }

            foreach (LookData look in lookData)
            {
                if(!look.isFinal) continue;
                look.processData();
                string line = "";
                line += look.partName + ",";
                line = line + look.trial + ",";
                line = line + look.leftImage + ",";
                line = line + look.rightImage + ",";
                line = line + look.side + ",";
                line = line + look.outputData.tottarpr.val + ",";
                line = line + look.outputData.totdispr.val + ",";
                line = line + look.outputData.totdifpr.val + ",";
                line = line + look.outputData.tottarpo.val + ",";
                line = line + look.outputData.totdispo.val + ",";
                line = line + look.outputData.totdifpo.val + ",";
                line = line + look.outputData.tottarch.val + ",";
                line = line + look.outputData.totdisch.val + ",";
                line = line + look.outputData.totdifch.val + ",";
                line = line + look.outputData.totLpr.val + ",";
                line = line + look.outputData.totRpr.val + ",";
                line = line + look.outputData.totLpo.val + ",";
                line = line + look.outputData.totRpo.val + ",";
                line = line + look.outputData.protarpr.val + ",";
                line = line + look.outputData.prodispr.val + ",";
                line = line + look.outputData.protarpo.val + ",";
                line = line + look.outputData.prodispo.val + ",";
                line = line + look.outputData.protarch.val + ",";
                line = line + look.outputData.prodisch.val + ",";
                line = line + look.outputData.llktarpr.val + ",";
                line = line + look.outputData.llkdispr.val + ",";
                line = line + look.outputData.llktarpo.val + ",";
                line = line + look.outputData.llkdispo.val + ",";
                line = line + look.outputData.llktarch.val + ",";
                line = line + look.outputData.llkdisch.val + ",";
                line = line + look.outputData.lldifch.val + ",";
                line = line + look.outputData.flktarpr.val + ",";
                line = line + look.outputData.flkdispr.val + ",";
                line = line + look.outputData.flktarpo.val + ",";
                line = line + look.outputData.flkdispo.val + ",";
                line = line + look.outputData.flktarch.val + ",";
                line = line + look.outputData.flkdisch.val + ",";
                line = line + look.outputData.fldifch.val + ",";
                line = line + look.outputData.latlkdir.val + ",";
                line = line + look.outputData.dir1sw.val + ",";
                line = line + look.outputData.dir2sw.val + ",";
                line = line + look.outputData.lat1sw.val + ",";
                line = line + look.outputData.lat2sw.val + ",";
                line = line + look.outputData.lattar.val + ",";
                line = line + look.outputData.latdis.val + ",";
                line = line + look.outputData.latmid.val + ",";
                line = line + look.outputData.numtarpr.val + ",";
                line = line + look.outputData.numdispr.val + ",";
                line = line + look.outputData.numdifpr.val + ",";
                line = line + look.outputData.numtarpo.val + ",";
                line = line + look.outputData.numdispo.val + ",";
                line = line + look.outputData.numdifpo.val;
                line += "\n";

                if (perPartCheck.Checked)
                {
                    if (look.partName == prevPart)
                    {
                        outputs[index] += line;
                    }
                    else
                    {
                        outputs.Add(line);
                        index++;
                    }
                }
                else
                {
                    outputs[0] += line; ;
                }

                prevPart = look.partName;
            }

            Directory.CreateDirectory(Properties.Settings.Default.LastProject + @"\output\Final\");
            string outPath = Properties.Settings.Default.LastProject + @"\output\Final\";

            if (!perPartCheck.Checked)
            {
                StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(outPath, expListBox.Text.Split('.')[0] + ".csv"));

                string colNames = "Participant,Trial,Left,Right,Side,tottarpr,totdispr,totdifpr,tottarpo,totdispo,totdifpo,tottarch,totdisch,totdifch,totLpr,totRpr,totLpo,totRpo,protarpr,prodispr,protarpo,prodispo,protarch,prodisch,llktarpr,llkdispr,llktarpo,llkdispo,llktarch,llkdisch,lldifch,flktarpr,flkdispr,flktarpo,flkdispo,flktarch,flkdisch,fldifch,latlkdir,dir1sw,dir2sw,lat1sw,lat2sw,lattar,latdis,latmid,numtarpr,numdispr,numdifpr,numtarpo,numdispo,numdifpo";
                outputFile.WriteLine(colNames);
                outputFile.WriteLine(outputs[0]);
                outputFile.Close();
            }
            else
            {
                foreach (string output in outputs)
                {
                    StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(outPath, output.Split(',')[0] + ".csv"));

                    string colNames = "Participant,Trial,Left,Right,Side,tottarpr,totdispr,totdifpr,tottarpo,totdispo,totdifpo,tottarch,totdisch,totdifch,totLpr,totRpr,totLpo,totRpo,protarpr,prodispr,protarpo,prodispo,protarch,prodisch,llktarpr,llkdispr,llktarpo,llkdispo,llktarch,llkdisch,lldifch,flktarpr,flkdispr,flktarpo,flkdispo,flktarch,flkdisch,fldifch,latlkdir,dir1sw,dir2sw,lat1sw,lat2sw,lattar,latdis,latmid,numtarpr,numdispr,numdifpr,numtarpo,numdispo,numdifpo";
                    outputFile.WriteLine(colNames);

                    Debug.WriteLine("Adding output: " + output);
                    outputFile.WriteLine(output);
                    outputFile.Close();
                }
            }
        }

        private void readFiles()
        {
            int index = 0;

            foreach (string file in scoreFiles)
            {
                // Get participant name from file name
                string partName = System.IO.Path.GetFileName(file).Split('_')[0];

                // Debug.WriteLine("Reading participant: " + partName);

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

                data.Remove("Event,Frame,ms");

                string eventString;
                string frameString;
                string msString;

                List<string[]> looks = new List<string[]>();

                int trialStart = 0;
                int postNamingWindow = 0;
                bool isPostNamingWindow = false;

                bool legitLook = false; // Ignores looks outside of trials

                foreach (string line in data)
                {
                    eventString = line.Split(',')[0];
                    frameString = line.Split(',')[1];
                    msString = line.Split(',')[2];

                    // Trials start, get start time and allow looks
                    if (eventString.StartsWith("showStims"))
                    {
                        Int32.TryParse(msString.Split('.')[0], out trialStart);
                        legitLook = true;
                        continue;
                    }

                    // Trial ends, add line, process the group and stop looks
                    if (eventString.StartsWith("hideStims") || isPostNamingWindow)
                    {
                        lookData.Add(new LookData());
                        lookData[index].partName = partName;
                        looks.Add(line.Split(','));
                        Int32.TryParse(msString.Split('.')[0], out int endTime);
                        int totalTime = endTime - trialStart;
                        lookData[index].trial = index.ToString();
                        processLooks(looks, trialStart, lookData[index]);
                        looks.Clear();
                        index++;
                        legitLook = false;
                        continue;
                    }

                    // If we're in a trial, add the looks
                    if (!legitLook) continue;
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

                            break;
                    }
                }
                data.Clear();
            }
        }

        private void printlooks(List<string[]> looks)
        {
            Debug.WriteLine("===================");
            foreach (string[] look in looks)
            {
                Debug.WriteLine("Look: " + look[0] + " : " + look[1] + " : " + look[2]);
            }
            Debug.WriteLine("===================");
        }

        private void processLooks(List<string[]> looks, int trialStart, LookData lookData)
        {
            string thisLook;
            string prevLook = "Start";

            bool isFirstPost = false;
            bool isPre = true;

            int prevLookTime = 0;
            int index = 0;

            cutoff = (int)cutPointBox.Value;

            // Find cutoff point and insert looks to split post and pre looks
            string[] tempLook = new string[3];

            foreach (string[] look in looks)
            {
                int lookTime = Int32.Parse(look[2].Split('.')[0]);

                // If we've found one higher than the cutoff, insert a looks  the same as the previous and then stop
                if (lookTime >= trialStart + cutoff)
                {
                    tempLook[0] = look[0];
                    tempLook[1] = ((trialStart + cutoff) / 60).ToString();
                    tempLook[2] = (trialStart + cutoff).ToString();
                    looks.Insert(index, tempLook);
                    break;
                }
                index++;

                // TODO Repeat above with latency
            }

            foreach (string[] look in looks)
            {

                Int32.TryParse(look[2].Split('.')[0], out int lookTime);
                thisLook = look[0];

                if (lookTime <= trialStart + cutoff)
                {
                    isPre = true;
                }
                else
                {
                    isPre = false;
                }

                switch (prevLook)
                {
                    case "Left":
                        lookData.length.Add(lookTime - prevLookTime);
                        lookData.looks.Add(prevLook);
                        lookData.isPre.Add(isPre);
                        prevLookTime = lookTime;
                        prevLook = thisLook;
                        break;
                    case "Right":
                        lookData.length.Add(lookTime - prevLookTime);
                        lookData.looks.Add(prevLook);
                        lookData.isPre.Add(isPre);
                        prevLookTime = lookTime;
                        prevLook = thisLook;
                        break;
                    case "Other":
                        lookData.length.Add(lookTime - prevLookTime);
                        lookData.looks.Add(prevLook);
                        lookData.isPre.Add(isPre);
                        prevLookTime = lookTime;
                        prevLook = thisLook;
                        break;
                    case "Start":
                        prevLookTime = lookTime;
                        prevLook = thisLook;
                        break;
                    default:
                        // Debug.WriteLine("Default Look: " + prevLook);
                        // code block
                        break;
                }

            }
        }

        private void dataFilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            trialInfo = myXML.getTrialInfo(trialListBox.Text);
            string[] stimsL = trialInfo.stimulusList.Split(',');
            string[] stimsR = trialInfo.stimulusListRight.Split(',');
            string[] stimsS = trialInfo.audioStimulusSide.Split(',');

            partData.Clear();

            int i = 0;

            foreach (LookData look in lookData)
            {
                if (look.partName == trialListBox.Text)
                {
                    partData.Add(look);
                    partData[i].leftImage = stimsL[i];
                    partData[i].rightImage = stimsR[i];
                    partData[i].side = stimsS[i];
                    i++;
                }
                else
                {
                    // Debug.WriteLine("No data for: " + trialListBox.Text);
                }
            }

            if (partData.Count != 0)
            {
                trialUpDown.Maximum = partData.Count - 1;
            }
            else
            {
                trialUpDown.Maximum = 0;
            }


            changeTrial();
        }

        private void trialUpDown_ValueChanged(object sender, EventArgs e)
        {
            changeTrial();
        }

        private void changeTrial()
        {
            int index = (int)trialUpDown.Value;
            string side = "";

            outputDGV.Rows.Clear();

            if (partData.Count == 0) return;
            
            includeCheckBox.Checked = partData[index].isFinal;

            for (int i = 0; i < partData[index].looks.Count; i++)
            {
                outputDGV.Rows.Add();

                outputDGV.Rows[i].Cells[0].Value = partData[index].looks[i];
                outputDGV.Rows[i].Cells[1].Value = partData[index].length[i];
                outputDGV.Rows[i].Cells[2].Value = partData[index].isPre[i].ToString();
                outputDGV.Rows[i].Cells[3].Value = partData[index].leftImage;
                outputDGV.Rows[i].Cells[4].Value = partData[index].rightImage;
                outputDGV.Rows[i].Cells[5].Value = partData[index].side;
                side = partData[index].side;
            }

            if (side == "Left")
            {
                outputDGV.Columns[3].DefaultCellStyle.BackColor = Color.LightGreen;
                outputDGV.Columns[4].DefaultCellStyle.BackColor = Color.White;
            }
            else if (side == "Right")
            {
                outputDGV.Columns[3].DefaultCellStyle.BackColor = Color.White;
                outputDGV.Columns[4].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            else
            {
                outputDGV.Columns[3].DefaultCellStyle.BackColor = Color.White;
                outputDGV.Columns[4].DefaultCellStyle.BackColor = Color.White;
            }

            updateTotalsDGV(index);

        }

        private void updateTotalsDGV(int index)
        {
            OutputData outputData = partData[index].processData();
            totalsDGV.Rows.Clear();
            int i = 0;
            foreach (result res in outputData.GetType().GetProperties().Select(p => p.GetValue(outputData)).OfType<result>())
            {
                // Debug.WriteLine(res.desc + ": " + res.val);
                totalsDGV.Rows.Add();
                totalsDGV.Rows[i].Cells[0].Value = res.desc;
                totalsDGV.Rows[i].Cells[1].Value = res.val;
                i++;
            }

        }

        public void getImageInfo()
        {
            //Debug.WriteLine("Getting trial info");
            trialInfo = myXML.getTrialInfo(partInfoLabel.Text);
            //Debug.WriteLine(trialInfo.stimulusList);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool fileSelected;
            string fileName = "";
            bool isLoading = true;

            if (expListBox.SelectedItem != null)
            {
                fileName = expListBox.SelectedItem.ToString();
                fileSelected = true;
            }
            else
            {
                //TODO: Add errorMessage("Error reading files", explistBox.SelectedItem.ToString());
                fileSelected = false;
            }

            if (fileSelected)
            {
                //TODO: Save changes
                doc = myXML.getBlocks(fileName);
                if (doc == null)
                {
                    Debug.WriteLine("File: " + fileName + " is corrupt.", "Error");
                    expListBox.Items.RemoveAt(expListBox.SelectedIndex);
                }
                else
                {
                    // Debug.WriteLine("Refreshing..." + fileName);
                    refreshBlockList();
                }
            }


            isLoading = false;
        }

        private void refreshBlockList()
        {
            // Clear current list
            blockListBox.Items.Clear();

            // Get reader to read the blocks
            List<string> blocks = myXML.getBlockList(expListBox.Text);

            // Debug.WriteLine("Read " + blocks.Count + " lines");
            if (blocks.Count == 0) return;

            foreach (string block in blocks)
            {
                blockListBox.Items.Add(block);
            }

            blockListBox.SelectedIndex = 0;
        }

        private void blockListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            populate_blockInfo();
            refresh_trialListBox();
        }
        private void populate_blockInfo()
        {
            blockInfo = myXML.getBlockInfo(blockListBox.SelectedIndex);
        }

        private void refresh_trialListBox()
        {
            // Clear current list
            trialListBox.Items.Clear();

            // Get reader to read the blocks
            List<string> trials = myXML.getTrialList(blockListBox.Text);

            if (trials.Count == 0) return;

            foreach (string trial in trials)
            {
                // Debug.WriteLine("Adding trial: " + trial);
                trialListBox.Items.Add(trial);
            }

            trialListBox.SelectedIndex = 0;
        }

        private void cutPointBox_ValueChanged(object sender, EventArgs e)
        {
            readFiles();
            loadData();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            latency = (int)numericUpDown5.Value;
            readFiles();
            loadData();
        }

        private void includeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lookData[(int)trialUpDown.Value].isFinal = includeCheckBox.Checked;
        }
    }



    public class LookData
    {
        public string partName { get; set; }
        public string trial { get; set; }
        public float ageDays { get; set; }
        public List<bool> isPre { get; set; }
        public List<string> looks { get; set; }
        public List<int> length { get; set; }
        public bool isFinal { get; set; } // Flags whether to include this in final output
        public string leftImage { get; set; }
        public string rightImage { get; set; }
        public string side { get; set; }
        public OutputData outputData { get; set; }


        public LookData()
        {
            trial = "";
            isPre = new List<bool>();
            looks = new List<string>();
            length = new List<int>();
            isFinal = true;
            leftImage = "";
            rightImage = "";
            side = "";
        }

        public OutputData processData()
        {
            outputData = new OutputData();
            int i = 0;

            List<int> lttPre = new List<int>();
            List<int> lttPost = new List<int>();
            List<int> ltdPre = new List<int>();
            List<int> ltdPost = new List<int>();
            List<int> rttPre = new List<int>();
            List<int> rttPost = new List<int>();
            List<int> rtdPre = new List<int>();
            List<int> rtdPost = new List<int>();

            foreach (string look in looks)
            {
                if (look == "Left")
                {
                    if (isPre[i])
                    {
                        outputData.totLpr.val += length[i];
                        if (look == side)
                        {
                            outputData.tottarpr.val += length[i];
                            lttPre.Add(length[i]);
                            outputData.numtarpr.val++;
                        }
                        else
                        {
                            outputData.totdispr.val += length[i];
                            ltdPre.Add(length[i]);
                            outputData.numdispr.val++;
                        }
                    }
                    else
                    {
                        outputData.totLpo.val += length[i];
                        if (look == side)
                        {
                            outputData.tottarpo.val += length[i];
                            lttPost.Add(length[i]);
                            outputData.numtarpo.val++;
                        }
                        else
                        {
                            outputData.totdispo.val += length[i];
                            ltdPost.Add(length[i]);
                            outputData.numdispo.val++;
                        }
                    }
                }
                else if (look == "Right")
                {
                    if (isPre[i])
                    {
                        outputData.totRpr.val += length[i];
                        if (look == side)
                        {
                            outputData.tottarpr.val += length[i];
                            rttPre.Add(length[i]);
                            outputData.numtarpr.val++;
                        }
                        else
                        {
                            outputData.totdispr.val += length[i];
                            rtdPre.Add(length[i]);
                            outputData.numdispr.val++;
                        }
                    }
                    else
                    {
                        outputData.totRpo.val += length[i];
                        if (look == side)
                        {
                            outputData.tottarpo.val += length[i];
                            rttPost.Add(length[i]);
                            outputData.numtarpo.val++;
                        }
                        else
                        {
                            outputData.totdispo.val += length[i];
                            rtdPost.Add(length[i]);
                            outputData.numdispo.val++;
                        }
                    }
                }
                else
                {
                    // Debug.WriteLine("Other look: " + look);
                }
                i++;
            }

            outputData.totdifpr.val = outputData.tottarpr.val - outputData.totdispr.val;
            outputData.totdifpo.val = outputData.tottarpo.val - outputData.totdispo.val;

            outputData.tottarch.val = outputData.tottarpo.val - outputData.tottarpr.val;
            outputData.totdisch.val = outputData.totdispo.val - outputData.totdispr.val;
            outputData.totdifch.val = outputData.totdifpo.val - outputData.totdifpr.val;

            if (outputData.tottarpr.val + outputData.totdispr.val == 0)
            {
                outputData.protarpr.val = 0;
                outputData.prodispr.val = 0;
            }
            else
            {
                outputData.protarpr.val = (outputData.tottarpr.val / (outputData.tottarpr.val + outputData.totdispr.val));
                outputData.prodispr.val = (outputData.totdispr.val / (outputData.tottarpr.val + outputData.totdispr.val));
            }
            outputData.protarpo.val = (outputData.tottarpo.val / (outputData.tottarpo.val + outputData.totdispo.val));
            outputData.prodispo.val = (outputData.totdispo.val / (outputData.tottarpo.val + outputData.totdispo.val));
            outputData.protarch.val = outputData.protarpo.val - outputData.protarpr.val;
            outputData.prodisch.val = outputData.prodispo.val - outputData.prodispr.val;

            if (lttPre.Count > 0) outputData.llktarpr.val = lttPre.Max();
            if (ltdPre.Count > 0) outputData.llkdispr.val = ltdPre.Max();
            if (lttPost.Count > 0) outputData.llktarpo.val = lttPost.Max();
            if (ltdPost.Count > 0) outputData.llkdispo.val = ltdPost.Max();
            outputData.llktarch.val = outputData.llktarpo.val - outputData.llktarpr.val;
            outputData.llkdisch.val = outputData.llkdispo.val - outputData.llkdispr.val;
            outputData.lldifch.val = outputData.llktarch.val - outputData.llkdisch.val;

            if (lttPre.Count > 0) outputData.flktarpr.val = lttPre[0];
            if (ltdPre.Count > 0) outputData.flkdispr.val = ltdPre[0];
            if (lttPost.Count > 0) outputData.flktarpo.val = lttPost[0];
            if (ltdPost.Count > 0) outputData.flkdispo.val = ltdPost[0];
            outputData.flktarch.val = outputData.flktarpo.val - outputData.flktarpr.val;
            outputData.flkdisch.val = outputData.flkdispo.val - outputData.flkdispr.val;
            outputData.fldifch.val = outputData.flktarch.val - outputData.flkdisch.val;

            // TODO: Latency calculations
            outputData.latlkdir.val = 0;



            outputData.numdifpr.val = outputData.numtarpr.val - outputData.numdispr.val;
            outputData.numdifpo.val = outputData.numtarpo.val - outputData.numdispo.val;

            return outputData;
        }


    }
}
public class OutputData
{
    // Pre-naming phase for targets and distracters
    public result tottarpr { get; set; } // Total time looking at target
    public result totdispr { get; set; } //  Total time looking at distractor
    public result totdifpr { get; set; } //  Total target minus total distractor

    // Post naming phase for targets and distracters
    public result tottarpo { get; set; } //  Total time looking at target
    public result totdispo { get; set; } //  Total time looking at distractor
    public result totdifpo { get; set; } //  Total target minus distractor

    // Post-naming minus Pre-naming for targets and distracters
    public result tottarch { get; set; } //  Change in total target looking
    public result totdisch { get; set; } //  Change in total distractor looking
    public result totdifch { get; set; } //  Change in total difference

    // Pre-naming for left and right looks
    public result totLpr { get; set; } //  Total time looking Left
    public result totRpr { get; set; } //  Total time looking Right

    // Post-naming for left and right looks
    public result totLpo { get; set; }  //  Total time looking Left
    public result totRpo { get; set; }  //  Total time looking Right

    public result protarpr { get; set; } // Proportion of time looking at target Pre
    public result prodispr { get; set; } // Proportion of time looking at distractor Pre
    public result protarpo { get; set; } // Proportion of time looking at target Post
    public result prodispo { get; set; } // Proportion of time looking at distractor Post
    public result protarch { get; set; } // Change in proportion of time looking at target
    public result prodisch { get; set; } // Change in proportion of time looking at distractor

    public result llktarpr { get; set; } // Longest looking at target Pre
    public result llkdispr { get; set; } // Longest looking at distractor Pre
    public result llktarpo { get; set; } // Longest looking at target Post
    public result llkdispo { get; set; } // Longest looking at distractor Post
    public result llktarch { get; set; } // Change in longest looking at target
    public result llkdisch { get; set; } // Change in longest looking at distractor
    public result lldifch { get; set; } // Change in longest difference
    public result flktarpr { get; set; } // First looking at target Pre
    public result flkdispr { get; set; } // First looking at distractor Pre
    public result flktarpo { get; set; } // First looking at target Post
    public result flkdispo { get; set; } // First looking at distractor Post
    public result flktarch { get; set; } // Change in first looking at target
    public result flkdisch { get; set; } // Change in first looking at distractor
    public result fldifch { get; set; } // Change in first difference
    public result latlkdir { get; set; } // Looking at target direction at cut-off
    public result dir1sw { get; set; } // Direction of first look started after cut-point
    public result dir2sw { get; set; } // Direction of second look started after cut-point
    public result lat1sw { get; set; } // Latency of first look started after cut-point
    public result lat2sw { get; set; } // Latency of second look started after cut-point
    public result lattar { get; set; } // Latency of first look to target started after cut-point
    public result latdis { get; set; } // Latency of first look to distractor started after cut-point
    public result latmid { get; set; } // Latency of first look to mid started after cutpoint

    // Pre
    public result numtarpr { get; set; } // Number of looks to target
    public result numdispr { get; set; } // Number of looks to distractor
    public result numdifpr { get; set; } // Difference between number of looks to target and distractor(T - D)

    //Post
    public result numtarpo { get; set; } // Number of looks to target
    public result numdispo { get; set; } // Number of looks to distractor
    public result numdifpo { get; set; } // Difference between number of looks to target and distractor(T - D)




    public OutputData()
    {
        tottarpr = new result();
        totdispr = new result();
        totdifpr = new result();
        tottarpo = new result();
        totdispo = new result();
        totdifpo = new result();
        tottarch = new result();
        totdisch = new result();
        totdifch = new result();
        totLpr = new result();
        totRpr = new result();
        totLpo = new result();
        totRpo = new result();
        protarpr = new result();
        prodispr = new result();
        protarpo = new result();
        prodispo = new result();
        protarch = new result();
        prodisch = new result();
        llktarpr = new result();
        llkdispr = new result();
        llktarpo = new result();
        llkdispo = new result();
        llktarch = new result();
        llkdisch = new result();
        lldifch = new result();
        flktarpr = new result();
        flkdispr = new result();
        flktarpo = new result();
        flkdispo = new result();
        flktarch = new result();
        flkdisch = new result();
        fldifch = new result();
        latlkdir = new result();
        dir1sw = new result();
        dir2sw = new result();
        lat1sw = new result();
        lat2sw = new result();
        lattar = new result();
        latdis = new result();
        latmid = new result();
        numtarpr = new result();
        numdispr = new result();
        numdifpr = new result();
        numtarpo = new result();
        numdispo = new result();
        numdifpo = new result();

        tottarpr.desc = "Total time looking at target Pre";
        tottarpr.val = 0;
        totdispr.desc = "Total time looking at distractor Pre";
        totdispr.val = 0;
        totdifpr.desc = "Total target minus total distractor Pre";
        totdifpr.val = 0;
        tottarpo.desc = "Total time looking at target Post";
        tottarpo.val = 0;
        totdispo.desc = "Total time looking at distractor Post";
        totdispo.val = 0;
        totdifpo.desc = "Total target minus total distractor Post";
        totdifpo.val = 0;
        tottarch.desc = "Change in total target looking";
        tottarch.val = 0;
        totdisch.desc = "Change in total distractor looking";
        totdisch.val = 0;
        totdifch.desc = "Change in total difference";
        totdifch.val = 0;
        totLpr.desc = "Total time looking Left Pre";
        totLpr.val = 0;
        totLpo.desc = "Total time looking Left Post";
        totLpo.val = 0;
        totRpr.desc = "Total time looking Right Pre";
        totRpr.val = 0;
        totRpo.desc = "Total time looking Right Post";
        totRpo.val = 0;
        protarpr.desc = "Proportion of time looking at target Pre";
        protarpr.val = 0;
        prodispr.desc = "Proportion of time looking at distractor Pre";
        prodispr.val = 0;
        protarpo.desc = "Proportion of time looking at target Post";
        protarpo.val = 0;
        prodispo.desc = "Proportion of time looking at distractor Post";
        prodispo.val = 0;
        protarch.desc = "Change in proportion of time looking at target";
        protarch.val = 0;
        prodisch.desc = "Change in proportion of time looking at distractor";
        prodisch.val = 0;
        llktarpr.desc = "Longest looking at target Pre";
        llktarpr.val = 0;
        llkdispr.desc = "Longest looking at distractor Pre";
        llkdispr.val = 0;
        llktarpo.desc = "Longest looking at target Post";
        llktarpo.val = 0;
        llkdispo.desc = "Longest looking at distractor Post";
        llkdispo.val = 0;
        llktarch.desc = "Change in longest looking at target";
        llktarch.val = 0;
        llkdisch.desc = "Change in longest looking at distractor";
        llkdisch.val = 0;
        lldifch.desc = "Change in longest difference";
        lldifch.val = 0;
        flktarpr.desc = "First looking at target Pre";
        flktarpr.val = 0;
        flkdispr.desc = "First looking at distractor Pre";
        flkdispr.val = 0;
        flktarpo.desc = "First looking at target Post";
        flktarpo.val = 0;
        flkdispo.desc = "First looking at distractor Post";
        flkdispo.val = 0;
        flktarch.desc = "Change in first looking at target";
        flktarch.val = 0;
        flkdisch.desc = "Change in first looking at distractor";
        flkdisch.val = 0;
        fldifch.desc = "Change in first difference";
        fldifch.val = 0;
        latlkdir.desc = "Looking at target direction at cut-off";
        latlkdir.val = 0;
        dir1sw.desc = "Direction of first look started after cut-point";
        dir1sw.val = 0;
        dir2sw.desc = "Direction of second look started after cut-point";
        dir2sw.val = 0;
        lat1sw.desc = "Latency of first look started after cut-point";
        lat1sw.val = 0;
        lat2sw.desc = "Latency of second look started after cut-point";
        lat2sw.val = 0;
        lattar.desc = "Latency of first look to target started after cut-point";
        lattar.val = 0;
        latdis.desc = "Latency of first look to distractor started after cut-point";
        latdis.val = 0;
        latmid.desc = "Latency of first look to mid started after cutpoint";
        latmid.val = 0;
        numtarpr.desc = "Number of looks to target Pre";
        numtarpr.val = 0;
        numdispr.desc = "Number of looks to distractor Pre";
        numdispr.val = 0;
        numdifpr.desc = "Difference between number of looks to target and distractor Pre";
        numdifpr.val = 0;
        numtarpo.desc = "Number of looks to target Post";
        numtarpo.val = 0;
        numdispo.desc = "Number of looks to distractor Post";
        numdispo.val = 0;
        numdifpo.desc = "Difference between number of looks to target and distractor Post";
        numdifpo.val = 0;

    }
}

public class result
{
    public float val { get; set; }
    public string desc { get; set; }

    public result()
    {
        val = 0;
        desc = "";
    }
}



