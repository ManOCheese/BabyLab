using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LincolnTest
{
    public partial class Present : Form
    {
        //Init XML interface
        CreateXML myXML = new CreateXML();
        XmlDocument doc = new XmlDocument();

        List<BlockInfo> blockInfo = new List<BlockInfo>();
        List<TrialInfo> trialInfo = new List<TrialInfo>();

        XmlNodeList trialList = null;

        // XML tracking variables
        XmlNode selectedBlock = null;
        // XmlNode selectedTrial = null;

        // Create Child windows Window
        PresentKBOp presWindow = new PresentKBOp();
        StimWind stimWindow = new StimWind();
        viewSettings viewSettingsWindow = new viewSettings();

        private static System.Timers.Timer previewTimer;
        Bitmap preview = new Bitmap(1920, 1080);
        Rectangle rec = new Rectangle(0, 0, 1920, 1080);
        private delegate void SafeCallDelegate(Object source, ElapsedEventArgs e);

        // Temp lists for counterbalance button
        List<string> tempStimPos = new List<string>();
        List<string> tempStimRPos = new List<string>();
        List<string> tempStimsL = new List<string>();
        List<string> tempStimsR = new List<string>();
        List<string> tempAudioStims = new List<string>();
        List<string> tempAudioStimsCB = new List<string>();

        

    public Present()
        {
            InitializeComponent();
            PopulateExpListBox();
            UpdateKeysText();
        }

        private void PopulateExpListBox()
        {
            DirectoryInfo dinfo = new DirectoryInfo(Properties.Settings.Default.LastProject);
            FileInfo[] Files = dinfo.GetFiles("*.bex");
            expListBox.Items.Clear();

            Console.WriteLine("Dir: " + Properties.Settings.Default.LastProject);

            foreach (FileInfo file in Files)
            {
                expListBox.Items.Add(file.Name);
            }
            if (expListBox.Items.Count > 0)
            {
                expListBox.SelectedIndex = 0;
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

        private void refreshBlockList()
        {
            bool blocksFound = false;
            bool filesFound = false;
            string fileName = "";

            foreach (object file in expListBox.CheckedItems)
            {
                fileName = file.ToString();
                Console.WriteLine("File: " + fileName);
                doc = myXML.getBlocks(fileName);
                filesFound = true;
            }

            XmlNode root = doc.DocumentElement;

            if (filesFound)
            {
                if (root.HasChildNodes)
                {
                    XmlNode first = root.NextSibling;

                    blockListBox.Items.Clear();
                    XmlNodeList blockList = root.SelectNodes("Block");

                    for (int i = 0; i < blockList.Count; i++)
                    {
                        // blockListBox.Items.Add(blockList[i].FirstChild.InnerXml);
                        XmlElement node = (XmlElement)blockList[i];

                        blockListBox.Items.Add(node["title"].InnerText);

                        blocksFound = true;
                        blockInfo.Add(new BlockInfo() { });
                        load_blockInfo(node, i);
                    }

                    if (blocksFound)
                    {
                        blockListBox.SetSelected(0, true);
                    }
                }
            }
        }


        private void expListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => refreshBlockList()));

            //TODO: Save changes
        }

        private void refresh_trialListBox()
        {

            trialListBox.Items.Clear();
            XmlNode root = doc.DocumentElement;
            Console.WriteLine("Refresh trials");
            trialInfo.Clear();

            List<string> blocks = new List<string>();

            for (int x = 0; x < blockListBox.CheckedItems.Count; x++)
            {
                blocks.Add(blockListBox.CheckedItems[x].ToString());
            }

            foreach (string block in blocks)
            {
                block.ToString();// Add Trials that match block title
                trialList = root.SelectNodes("descendant::Trial[Block='" + block + "']");
                for (int i = 0; i < trialList.Count; i++)
                {
                    trialListBox.Items.Add(trialList[i].FirstChild.InnerXml);
                    trialInfo.Add(new TrialInfo() { });
                    trialInfo[i] = load_trialInfo(trialList[i], i);
                }
            }

            if(trialList.Count <= 0)
            {

            }
            else
            {
                trialListBox.SetSelected(0, true);
            }
            
        }

        private void readyToStart()
        {
            if (trialListBox.CheckedItems.Count > 0)
            {
                startButton.Enabled = true;
            }
            else
            {
                startButton.Enabled = false;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            previewTimer = new System.Timers.Timer(60);

            stimWindow.parentWindow = this;

            int trialIndex = 1;
            int blockIndex = 0;

            foreach (var item in trialListBox.CheckedIndices)
            {
                Console.WriteLine("Checked item:  " + item.ToString());
                trialIndex = int.Parse(item.ToString());
            }            

            stimWindow.trialInfo = trialInfo[trialIndex];
            stimWindow.blockInfo = blockInfo[blockIndex];
            stimWindow.Show();

            stimWindow.SetupExperiment();
            stimWindow.DrawToBitmap(preview, rec );
            StimWinPreview.Image = preview;

            previewTimer.Elapsed += refreshPreview;
            previewTimer.AutoReset = true;
            previewTimer.Enabled = true;

            startButton.Enabled = false;
        }

        private void refreshPreview(Object source, ElapsedEventArgs e)
        {
            // TODO: Stop crash on closing
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


        public void stimWindowClosed()
        {
            // this.startButton.Enabled = true;
            // TODO: Thread error
        }

        private void blockListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => refresh_trialListBox()));            
        }

        private void trialListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => readyToStart()));
        }

        public TrialInfo load_trialInfo(XmlNode trial, int trialNum)
        {
            XmlElement trialElement = (XmlElement)trial;
            bool foundError = false;
            trialInfo[trialNum].title = trialElement["Title"].InnerText;

            Console.WriteLine("Attempting to load " + trialElement["Title"].InnerText);

            tempStimsL.Clear();
            tempStimsR.Clear();
            tempStimPos.Clear();
            tempStimRPos.Clear();
            tempAudioStims.Clear();
            tempAudioStimsCB.Clear();

            if (trialElement.InnerXml.Contains("VisualStimuli"))
            {

                XmlNodeList stims = trialElement.SelectNodes("VisualStimuli");

                for (int i = stims.Count - 1; i >= 0; i--)
                {

                    Console.WriteLine("Attempting to load stims");

                    if (checkStimulusFile(stims[i].InnerText))
                    {
                        tempStimsL.Add(stims[i].InnerText);

                    }
                    else
                    {
                        tempStimsL.Add("");
                    }
                    if (checkStimulusFile(stims[i].Attributes["RightImage"].Value))
                    {
                        tempStimsR.Add(stims[i].Attributes["RightImage"].Value);
                        Console.WriteLine("Loaded Right image: " + stims[i].Attributes["RightImage"].Value);
                    }
                    else
                    {
                        tempStimsR.Add("");
                    }
                    if (checkStimulusFile(stims[i].Attributes["audioStimulus"].Value))
                    {
                        tempAudioStims.Add(stims[i].Attributes["audioStimulus"].Value);
                    }
                    else
                    {
                        tempAudioStims.Add("");
                    }
                    if (stims[i].Attributes["audioStimulusCB"].Value != "")
                    {
                        tempAudioStimsCB.Add(stims[i].Attributes["audioStimulusCB"].Value);
                    }
                    else
                    {
                        tempAudioStimsCB.Add("");
                    }
                    if (stims[i].Attributes.GetNamedItem("Pos") != null)
                    {
                        tempStimPos.Add(stims[i].Attributes["Pos"].Value);
                    }
                    else
                    {
                        Console.WriteLine("Error 1 in " + trialInfo[trialNum].title);
                        foundError = true;
                        tempStimPos.Add("{X=0,Y=73}");
                    }
                    if (stims[i].Attributes.GetNamedItem("Pos") != null)
                    {
                        tempStimRPos.Add(stims[i].Attributes["RPos"].Value);
                    }
                    else
                    {
                        foundError = true;
                        Console.WriteLine("Error 2 in " + trialInfo[trialNum].title);
                        tempStimRPos.Add("{X=100,Y=73}");
                    }

                    //tempStimPos.Add(stims[i].Attributes["Pos"].Value);
                    // tempStimPos.Add(stims[i].Attributes["RPos"].Value);
                }

                tempStimsL.Reverse();
                tempStimsR.Reverse();
                tempStimPos.Reverse();
                tempStimRPos.Reverse();
                tempAudioStims.Reverse();
                tempAudioStimsCB.Reverse();

                trialInfo[trialNum].stimulusList = string.Join(",", tempStimsL);
                trialInfo[trialNum].stimulusListRight = string.Join(",", tempStimsR);
                trialInfo[trialNum].stimulusPosList = string.Join(":", tempStimPos);
                trialInfo[trialNum].stimulusRPosList = string.Join(":", tempStimPos);
                trialInfo[trialNum].audioStimulus = string.Join(",", tempAudioStims);
                trialInfo[trialNum].audioStimulusSide = string.Join(",", tempAudioStimsCB);

                // trialIndex = trialListBox.SelectedIndex;

                if (foundError)
                {
                    myXML.updateTrial(trialElement, trialInfo[trialNum]);
                }
            }
            else
            {
                trialInfo[trialNum].stimulusList = "";
                trialInfo[trialNum].stimulusListRight = "";
            }

            return trialInfo[trialNum];
        }

        // Loads the each block from XML to the array List
        private void load_blockInfo(XmlNode block, int blockNum)
        {

            XmlElement blockElement = (XmlElement)block;
            selectedBlock = blockElement;
            blockInfo[blockNum].title = blockElement["title"].InnerText;

            foreach (PropertyInfo propertyinfo in typeof(BlockInfo).GetProperties())
            {
                if (propertyinfo != null)
                {
                    var valueOfField = propertyinfo.GetValue(blockInfo[blockNum]);
                    var fieldname = propertyinfo.Name;


                    if (blockElement.SelectNodes(fieldname).Count > 0)
                    {
                        propertyinfo.SetValue(blockInfo[blockNum], blockElement[fieldname].InnerText);
                        Console.WriteLine(fieldname + "  with value  " + valueOfField + "  loaded.");
                    }
                    else
                    {
                        myXML.addMissingNode(blockElement, fieldname, "0");
                        // errorMessage("Unable to read " + fieldname + " from file", "File repaired and setting to default");
                        propertyinfo.SetValue(blockInfo[blockNum], "0");
                        // blockInfo[blockindex].hcWindow = "0";
                    }
                }
            }
        }

        private bool checkStimulusFile(string stimulus)
        {
            if (stimulus == "") { return true; }

            if (File.Exists(Properties.Settings.Default.stimPath + "/" + stimulus))
            {
                return true;
            }
            else
            {
                // errorMessage("Image " + stimulus + " not found", "");
                return false;
            }
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

        }
    }
}
