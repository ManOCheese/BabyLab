using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace LincolnTest
{


    public partial class Create : Form
    {
        // Init Settings
        Settings mySettings = new Settings();

        // Init other windows
        StimWind newForm = new StimWind();
        randOptions randWindow = new randOptions();

        //Init XML interface
        CreateXML myXML = new CreateXML();
        XmlDocument doc = new XmlDocument();

        

        // XML tracking variables
        XmlNode selectedBlock = null;
        XmlNode selectedTrial = null;
        XmlNodeList trialList = null;

        // Data tables
        List<BlockInfo> blockInfo = new List<BlockInfo>();
        List<TrialInfo> trialInfo = new List<TrialInfo>();

        int blockindex = 0;
        int trialIndex = -1;

        bool mousePrevDown = false;
        int snapSize = 10;

        string audioStimFile = "";

        string errorList = "";

        // Temp lists for counterbalance button
        List<string> tempStimPos = new List<string>();
        List<string> tempStimRPos = new List<string>();
        List<string> tempStimsL = new List<string>();
        List<string> tempStimsR = new List<string>();
        List<string> tempAudioStims = new List<string>();
        List<string> tempAudioStimSide = new List<string>();

        

        public Create()
        {
            InitializeComponent();
            PopulateListBox();
            populateStimList();

            // Set for transparent gifs
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            vertImage.BackColor = Color.Transparent;
            horizImage.BackColor = Color.Transparent;

            // Set default settings TODO: Move to settings file
            mySettings.showConfirm = false;
            mySettings.hasChanged = false;

            imageCollections.Visible = false;

        }

        

        // Converts the colour picker to something we can save/load in XML
        private String colourToString()
        {
            Color buttonColour = colourButton.BackColor;
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(buttonColour);
            String buttonColourString = converter.ConvertToString(buttonColour);
            buttonColourString = colourButton.BackColor.ToArgb().ToString();

            return buttonColourString;
        }

        public static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }


        // Custom error message dialog
        public void errorMessage(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // Closes the parent form.
                // this.Close();
            }
        }

        // Custom confirmation dialog
        public DialogResult sureMessage(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            return result;
        }

        // Preview Present
        private void previewButton_Click(object sender, EventArgs e)
        {
            // Set the experiment screen to fullscreen on the 2nd monitor
            Screen[] screens = Screen.AllScreens;
            Screen screen = screens[1];
            Rectangle bounds = screen.Bounds;
            newForm.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            newForm.Show();
        }

        // Manually save all changes
        private void updateBlockButton_Click(object sender, EventArgs e)
        {
            if (myXML.updateBlock(selectedBlock, blockInfo[blockindex]))
            {
                myXML.updateTrial(selectedTrial, trialInfo[trialIndex]);
                refreshBlockList();
                refresh_trialListBox();
            }
            else
            {
                errorMessage("Error updating block", "Error");
            }
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Read BEX files from folder and list them
        private void PopulateListBox()
        {
            DirectoryInfo dinfo = new DirectoryInfo(Properties.Settings.Default.ExpPath);
            FileInfo[] Files = dinfo.GetFiles("*.bex");
            explistBox.Items.Clear();
            foreach (FileInfo file in Files)
            {
                explistBox.Items.Add(file.Name);
            }
            if (explistBox.Items.Count > 0)
            {
                explistBox.SelectedIndex = 0;
            }
        }

        // Read the Stimulus folder and list images and sounds on form
        private void populateStimList()
        {
            List<FileInfo> Files = new List<FileInfo>();

            DirectoryInfo dinfo = new DirectoryInfo(Properties.Settings.Default.stimPath);
            string[] filters = new[] { "*.jpg", "*.png", "*.gif", "*.bmp" };

            foreach (String ext in filters)
            {
                FileInfo[] TempFiles = dinfo.GetFiles(ext);
                Files.AddRange(TempFiles);
            }
            if(Files.Count <= 0)
            {
                string message = "Please add image files to the Stimuli folder and try again";
                string caption = "No Stimuli found";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);

                Close();
                return;
            }
            // DataGridViewComboBoxColumn cboBoxLColumn = (DataGridViewComboBoxColumn)stimDataGrid.Columns[0];
            DataGridViewComboBoxColumn cboBoxLColumn = (DataGridViewComboBoxColumn)stimDataGrid.Columns[0];
            DataGridViewComboBoxColumn cboBoxRColumn = (DataGridViewComboBoxColumn)stimDataGrid.Columns[1];

            cboBoxLColumn.Items.Add("");
            cboBoxRColumn.Items.Add("");

            foreach (FileInfo file in Files)
            {
                cboBoxLColumn.Items.Add(file.Name);
                cboBoxRColumn.Items.Add(file.Name);
            }

            Files.Clear();
            string[] audiFilters = new[] { "*.wav", "*.mp3" };

            foreach (String ext in audiFilters)
            {
                FileInfo[] TempFiles = dinfo.GetFiles(ext);
                Files.AddRange(TempFiles);
            }

            foreach (FileInfo file in Files)
            {
                DataGridViewComboBoxColumn cboBoxALColumn = (DataGridViewComboBoxColumn)stimDataGrid.Columns[3];
                cboBoxALColumn.Items.Add(file.Name);
            }

            DataGridViewComboBoxColumn cboBoxARColumn = (DataGridViewComboBoxColumn)stimDataGrid.Columns[4];
            cboBoxARColumn.Items.Add("Left");
            cboBoxARColumn.Items.Add("Right");
        }

        // Save unsaved and then load new blocks when selected experiment changes
        private void expListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool fileSelected;
            string fileName = "";

            if (explistBox.SelectedItem != null)
            {
                fileName = explistBox.SelectedItem.ToString();
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
                if(doc == null)
                {
                    errorMessage("File: " + fileName + " is corrupt.", "Error");
                    explistBox.Items.RemoveAt(explistBox.SelectedIndex);
                }
                else
                {
                    refreshBlockList();
                }
            }

        }

        // Load blocks from BEX file
        private void refreshBlockList()
        {
            bool blocksFound = false;
            XmlNode root = doc.DocumentElement;

            if (root.HasChildNodes)
            {
                XmlNode first = root.NextSibling;

                blockListBox.Items.Clear();
                XmlNodeList blockList = root.SelectNodes("Block");

                for (int i = 0; i < blockList.Count; i++)
                {
                    // blockListBox.Items.Add(blockList[i].FirstChild.InnerXml);
                    XmlElement node = (XmlElement)blockList[i];

                    blockListBox.Items.Add(node["href"].InnerText);

                    blocksFound = true;
                    blockInfo.Add(new BlockInfo() { });
                    load_blockInfo(blockList[i], i);
                    blockindex = i;
                }

                if (blocksFound)
                {

                    blockListBox.SetSelected(0, true);
                }

            }
        }


        // Load trials from BEX file
        private void refresh_trialListBox()
        {
            trialListBox.Items.Clear();
            stimDataGrid.Rows.Clear();
            selectedTrial = null;

            XmlNode root = doc.DocumentElement;

            Console.WriteLine("Refresh trials");

            bool trialsFound = false;

            trialInfo.Clear();

            // Add Trials that match block title
            trialList = root.SelectNodes("descendant::Trial[Block='" + blockListBox.SelectedItem.ToString() + "']");
            for (int i = 0; i < trialList.Count; i++)
            {
                Console.WriteLine(trialList[i].FirstChild.InnerXml);
                trialsFound = true;
                trialListBox.Items.Add(trialList[i].FirstChild.InnerXml);
                trialInfo.Add(new TrialInfo() { });
                load_trialInfo(trialList[i], i);
            }

            if (trialsFound)
            {
                trialListBox.SetSelected(0, true);
            }
        }

        // Load all the trials and confirm that stimuli exist
        public TrialInfo load_trialInfo(XmlNode trial, int trialNum)
        {
            XmlElement trialElement = (XmlElement)trial;
            selectedTrial = trialElement;

            bool foundError = false;

            trialInfo[trialNum].title = trialElement["Title"].InnerText;

            tempStimsL.Clear();
            tempStimsR.Clear();
            tempStimPos.Clear();
            tempStimRPos.Clear();
            tempAudioStims.Clear();
            tempAudioStimSide.Clear();

            if (trialElement.InnerXml.Contains("VisualStimuli"))
            {
                XmlNodeList stims = trialElement.SelectNodes("VisualStimuli");
                for (int i = stims.Count - 1; i >= 0; i--)
                {
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
                    if (stims[i].Attributes["audioStimulusCB"].Value == "Left" || stims[i].Attributes["audioStimulusCB"].Value == "Right")
                    {
                        tempAudioStimSide.Add(stims[i].Attributes["audioStimulusCB"].Value);
                    }
                    else
                    {
                        tempAudioStimSide.Add("Left");
                    }
                    if (stims[i].SelectSingleNode("Pos") != null)
                    {
                        tempStimPos.Add(stims[i].Attributes["Pos"].Value);
                    }
                    else
                    {
                        // Console.WriteLine("Error 1 in " + trialInfo[trialNum].title);
                        foundError = true;
                        tempStimPos.Add("{X=0,Y=73}");
                    }
                    if (stims[i].SelectSingleNode("RPos") != null)
                    {
                        tempStimRPos.Add(stims[i].Attributes["RPos"].Value);
                    }
                    else
                    {
                        foundError = true;
                        // Console.WriteLine("Error 2 in " + trialInfo[trialNum].title);
                        tempStimRPos.Add("{X=100,Y=73}");
                    }
                    //tempStimPos.Add(stims[i].Attributes["Pos"].Value);
                    // tempStimPos.Add(stims[i].Attributes["RPos"].Value);

                    if(errorList != "")
                    {
                        errorMessage("Image(s) " + errorList + " not found", "");
                        errorList = "";
                    }
                    
                }

                // Reverse order, because .Add adds at the beginning
                tempStimsL.Reverse();
                tempStimsR.Reverse();
                tempStimPos.Reverse();
                tempStimRPos.Reverse();
                tempAudioStims.Reverse();
                tempAudioStimSide.Reverse();

                trialInfo[trialNum].stimulusList = string.Join(",", tempStimsL);
                trialInfo[trialNum].stimulusListRight = string.Join(",", tempStimsR);
                trialInfo[trialNum].stimulusPosList = string.Join(":", tempStimPos);
                trialInfo[trialNum].stimulusRPosList = string.Join(":", tempStimPos);
                trialInfo[trialNum].audioStimulus = string.Join(",", tempAudioStims);
                trialInfo[trialNum].audioStimulusSide = string.Join(",", tempAudioStimSide);

                trialIndex = trialListBox.SelectedIndex;
                if (foundError)
                {
                    myXML.updateTrial(selectedTrial, trialInfo[trialNum]);
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

                    }
                    else
                    {
                        myXML.addMissingNode(blockElement, fieldname, "0");

                        errorMessage("Unable to read " + fieldname + " from file", "File repaired and setting to default");
                        propertyinfo.SetValue(blockInfo[blockNum], "");
                        // blockInfo[blockindex].hcWindow = "0";
                    }
                }
            }
        }

        // Loads the values from the array in to the form
        // TODO: Add more error checking
        private void populate_blockInfo()
        {

            XmlNode root = doc.DocumentElement;
            XmlNodeList nodeList = root.SelectNodes("descendant::Block[title='" + blockListBox.SelectedItem.ToString() + "']");
            foreach (XmlNode block in nodeList)
            {
                XmlElement blockElement = (XmlElement)block;
                selectedBlock = blockElement;
                titleBox.Text = blockInfo[blockindex].title;
                commentBox.Text = blockInfo[blockindex].comment;
                visualOnsetBox.Value = int.Parse(blockInfo[blockindex].vOnset);
                audioOnsetBox.Value = int.Parse(blockInfo[blockindex].aOnset);
                showThumbsBox.Checked = bool.Parse(blockInfo[blockindex].showThumbs);
                showStimInfoBox.Checked = bool.Parse(blockInfo[blockindex].showStimInfo);
                showTrialCountBox.Checked = bool.Parse(blockInfo[blockindex].showTrialCount);
                showAllBox.Checked = bool.Parse(blockInfo[blockindex].showAll);
                hcLooksBox.Value = int.Parse(blockInfo[blockindex].hcLooks);
                lookTrialExceedBox.Value = int.Parse(blockInfo[blockindex].lookTrialExceed);
                habitNPercentBox.Value = int.Parse(blockInfo[blockindex].habitNPercent);


                Int32 argb = Convert.ToInt32(blockInfo[blockindex].bgColour);
                colourButton.BackColor = Color.FromArgb(argb);

                switch (int.Parse(blockInfo[blockindex].trialEndsWhen))
                {
                    case 1:
                        radioButton1.Select();
                        break;
                    case 2:
                        radioButton2.Select();
                        break;
                    case 3:
                        radioButton3.Select();
                        break;
                    default:
                        //Console.WriteLine("Failed");
                        errorMessage("Unable to read Max Trials value", "Setting to default");
                        break;
                }

                switch (int.Parse(blockInfo[blockindex].blocksEndWhen))
                {
                    case 1:
                        radioButton4.Select();
                        break;
                    case 2:
                        lookTrialExceedSelect.Select();
                        break;
                    case 3:
                        radioButton6.Select();
                        break;
                    default:
                        //Console.WriteLine("Failed");
                        errorMessage("Unable to read Block ends value", "Setting to default");
                        radioButton4.Select();
                        break;

                }

                switch (int.Parse(blockInfo[blockindex].hcBasis))
                {
                    case 1:
                        hcBasisOption1.Select();
                        break;
                    case 2:
                        hcBasisOption2.Select();
                        break;
                    default:
                        errorMessage("Unable to read Block ends value", "Setting to default");
                        hcBasisOption1.Select();
                        break;
                }

                switch (int.Parse(blockInfo[blockindex].hcWindow))
                {
                    case 1:
                        hcWindowOption1.Select();
                        break;
                    case 2:
                        hcWindowOption2.Select();
                        break;
                    default:
                        errorMessage("Unable to read Block ends value", "Setting to default");
                        hcBasisOption1.Select();
                        break;
                }

                int value = int.Parse(blockInfo[blockindex].maxTrialDuration);
                maxTrialDurBox.Value = Clamp(value, 500, 25000);
            }
        }

        // Load the trial info from the array to the form
        private void populate_TrialInfo()
        {
            trialTitleBox.Text = trialInfo[trialIndex].title;
            stimDataGrid.Rows.Clear();

            if (trialInfo[trialIndex].stimulusList.Length > 0)
            {
                string[] stims = trialInfo[trialIndex].stimulusList.Split(',');
                string[] stimsR = trialInfo[trialIndex].stimulusListRight.Split(',');
                string[] audioStims = trialInfo[trialIndex].audioStimulus.Split(',');
                string[] audioStimSide = trialInfo[trialIndex].audioStimulusSide.Split(',');

                for (int i = 0; i < stims.Length; i++)
                {
                    stimDataGrid.Rows.Add();

                    stimDataGrid.Rows[i].Cells[0].Value = i;
                    stimDataGrid.Rows[i].Cells[1].Value = stims[i];
                    stimDataGrid.Rows[i].Cells[2].Value = stimsR[i];
                    stimDataGrid.Rows[i].Cells[3].Value = audioStims[i];
                    stimDataGrid.Rows[i].Cells[4].Value = audioStimSide[i];
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
                errorList = errorList + " : " + stimulus;
                Console.WriteLine(errorList);
                return false;
            }
        }

        public void setSelectedBlockNode()
        {

        }

        private void blockListBox_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private bool isSaved()
        {
            if (mySettings.hasChanged)
            {

                if (sureMessage("Save changes?", "Changes") == DialogResult.Yes)
                {
                    myXML.updateBlock(selectedBlock, blockInfo[blockindex]);
                    mySettings.hasChanged = false;

                    refreshBlockList();
                    populate_blockInfo();
                    setSelectedBlockNode();
                    refresh_trialListBox();

                }
                else
                {
                    populate_blockInfo();
                    setSelectedBlockNode();
                    refresh_trialListBox();

                    mySettings.hasChanged = false;
                }
            }
            else
            {
                populate_blockInfo();
                setSelectedBlockNode();
                refresh_trialListBox();

                mySettings.hasChanged = false;
            }
            return true;
        }

        // New file dialog
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Properties.Settings.Default.ExpPath);
            FileInfo[] Files = dinfo.GetFiles("*.bex");

            SaveFileDialog mySaveDialog = new SaveFileDialog();
            mySaveDialog.Filter = "bex files (*.bex)|*.bex";
            mySaveDialog.FilterIndex = 1;
            mySaveDialog.RestoreDirectory = true;

            if (mySaveDialog.ShowDialog() == DialogResult.OK)
            {
                string filename_with_ext = Path.GetFileName(mySaveDialog.FileName);
                myXML.CreateXMLDoc(filename_with_ext);
                PopulateListBox();
            }
        }

        private void titleBox_TextChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].title = titleBox.Text;
            mySettings.hasChanged = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (true)
            {
                // 
            }
            else
            {
                //
            }
        }

        private void addBlock_Click(object sender, EventArgs e)
        {
            if (selectedBlock != null)
            {
                myXML.updateBlock(selectedBlock, blockInfo[blockindex]);
            }

            NewBlockTextInput textInput = new NewBlockTextInput();
            if (textInput.ShowDialog() == DialogResult.OK)
            {
                string[] subs = textInput.Text.Split('.');

                string blockName = subs[0];
                string blockType = subs[1];

                if (myXML.addDefaultBlock(blockName, blockType))
                {
                    refreshBlockList();
                    populate_blockInfo();

                    blockListBox.SelectedItem = blockName;
                }
            }
        }

        private void changeColourButton_Click(object sender, EventArgs e)
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = colourButton.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                colourButton.BackColor = MyDialog.Color;
                blockInfo[blockindex].bgColour = colourToString();
                mySettings.hasChanged = true;
            }
        }



        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void addTrialButton_Click(object sender, EventArgs e)
        {
            myXML.addTrial(blockInfo[blockindex], "Trial");
            refresh_trialListBox();
            mySettings.hasChanged = true;
        }

        private void ASBrowseButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog myOpenDialog = new OpenFileDialog();
            myOpenDialog.Filter = "wave files (*.wav)|*.wav";
            myOpenDialog.FilterIndex = 1;
            myOpenDialog.RestoreDirectory = true;

            if (myOpenDialog.ShowDialog() == DialogResult.OK)
            {
                audioStimFile = myOpenDialog.FileName;
                // AStimTextBox.Text = audioStimFile;
            }
        }

        private void ASPlaybutton_Click(object sender, EventArgs e)
        {
            if (File.Exists(audioStimFile))// Checking to see if the file exist
            {
                SoundPlayer simpleSound = new SoundPlayer(audioStimFile);
                simpleSound.Play();
            }
        }

        // 
        //
        // Collapsed section - Handle form changes: set changes in to array
        //

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].trialEndsWhen = "1";
            mySettings.hasChanged = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].trialEndsWhen = "2";
            mySettings.hasChanged = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].trialEndsWhen = "3";
            mySettings.hasChanged = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (showAllBox.Checked)
            {
                showThumbsBox.Checked = true;
                showStimInfoBox.Checked = true;
                showTrialCountBox.Checked = true;
            }
            else
            {
            }
            mySettings.hasChanged = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].showThumbs = showThumbsBox.Checked.ToString();
            if (!showThumbsBox.Checked)
            {
                showAllBox.Checked = false;
            }
            mySettings.hasChanged = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].showStimInfo = showStimInfoBox.Checked.ToString();
            if (!showThumbsBox.Checked)
            {
                showAllBox.Checked = false;
            }
            mySettings.hasChanged = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].showTrialCount = showTrialCountBox.Checked.ToString();
            if (!showThumbsBox.Checked)
            {
                showAllBox.Checked = false;
            }
            mySettings.hasChanged = true;
        }

        private void removeBlockButton_Click(object sender, EventArgs e)
        {
            myXML.deleteBlock(selectedBlock);
            refreshBlockList();
        }

        private void commentBox_TextChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].comment = commentBox.Text;
            mySettings.hasChanged = true;

        }

        private void visualOnsetBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].vOnset = visualOnsetBox.Value.ToString();
            mySettings.hasChanged = true;
        }

        private void audioOnsetBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].aOnset = audioOnsetBox.Value.ToString();
            mySettings.hasChanged = true;
        }

        private void maxTrialDurBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].maxTrialDuration = maxTrialDurBox.Value.ToString();
            mySettings.hasChanged = true;
        }

        private void lookExceedBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].lookTrialExceed = lookTrialExceedBox.Value.ToString();
            mySettings.hasChanged = true;
        }

        private void lookBlockExceedBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].lookBlockExceed = lookBlockExceedBox.Value.ToString();
            mySettings.hasChanged = true;
        }

        private void lookedMin_ValueChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].lookedMin = lookedMin.Value.ToString();
            mySettings.hasChanged = true;
        }

        private void lookResetBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].lookReset = lookResetBox.Value.ToString();
            mySettings.hasChanged = true;
        }
        private void hcLooksBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].hcLooks = hcLooksBox.Value.ToString();
            mySettings.hasChanged = true;
        }

        private void habitNPercent_ValueChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].habitNPercent = habitNPercentBox.Value.ToString();
            mySettings.hasChanged = true;
        }

        private void FirstNTrialOption_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].hcBasis = "1";
            mySettings.hasChanged = true;
        }

        private void longestNTrialOption_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].hcBasis = "2";
            mySettings.hasChanged = true;
        }
        private void hcWindowOption1_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].hcWindow = "1";
            mySettings.hasChanged = true;
        }

        private void hcWindowOption2_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo[blockindex].hcWindow = "2";
            mySettings.hasChanged = true;
        }

        private void trialListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Selected trial: " + trialListBox.SelectedIndex.ToString());
            updateStimList();
            if (trialIndex >= 0)
            {
                //Console.WriteLine("Updating trial: " + trialIndex.ToString());
                myXML.updateTrial(selectedTrial, trialInfo[trialIndex]);
            }

            trialIndex = trialListBox.SelectedIndex;
            selectedTrial = trialList[trialIndex];
            populate_TrialInfo();
            updateImagePreview(0);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateStimList()
        {
            tempStimsL.Clear();
            tempStimsR.Clear();
            tempStimPos.Clear();
            tempStimRPos.Clear();
            tempAudioStims.Clear();
            tempAudioStimSide.Clear();

            foreach (DataGridViewRow row in stimDataGrid.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    tempStimsL.Add(row.Cells[1].Value.ToString());

                    if (row.Cells[2].Value != null)
                    {
                        tempStimsR.Add(row.Cells[2].Value.ToString());
                    }
                    else
                    {
                        tempStimsR.Add("");
                    }
                    if (row.Cells[3].Value != null)
                    {
                        tempAudioStims.Add(row.Cells[3].Value.ToString());
                    }
                    else
                    {
                        tempAudioStims.Add("");
                    }
                    if (row.Cells[4].Value != null)
                    {
                        tempAudioStimSide.Add(row.Cells[4].Value.ToString());
                    }
                    else
                    {
                        tempAudioStimSide.Add("");
                    }

                    tempStimPos.Add(stimImageL.Location.ToString());
                    tempStimRPos.Add(stimImageR.Location.ToString());
                }
            }

            if (tempStimsL.Count > 0)
            {
                trialInfo[trialIndex].stimulusList = string.Join(",", tempStimsL);
                trialInfo[trialIndex].stimulusListRight = string.Join(",", tempStimsR);
                trialInfo[trialIndex].stimulusPosList = string.Join(":", tempStimPos);
                trialInfo[trialIndex].stimulusRPosList = string.Join(":", tempStimPos);
                trialInfo[trialIndex].audioStimulus = string.Join(",", tempAudioStims);
                trialInfo[trialIndex].audioStimulusSide = string.Join(",", tempAudioStimSide);
            }
        }

        // USe mouse to move images
        private void stimPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePrevDown)
            {
                //stimPosLabel.Text = e.X.ToString() + " : " + e.Y.ToString();

                int mouseX = e.X;
                int mouseY = e.Y;

                int maxX = stimPanel.Width - stimImageL.Width;
                int maxY = stimPanel.Height - stimImageL.Height;
                int midX = (stimPanel.Width / 2) - (stimImageL.Width / 2);
                int midY = (stimPanel.Height / 2) - (stimImageL.Height / 2);

                if (snapBox.Checked)
                {
                    snapSize = 15;
                }
                else
                {
                    snapSize = 0;
                }


                if (e.X < snapSize)
                {
                    mouseX = 0;
                }
                if (e.Y < snapSize)
                {
                    mouseY = 0;
                }
                if (e.X >= maxX - snapSize)
                {
                    mouseX = maxX;
                }
                if (e.Y >= maxY - snapSize)
                {
                    mouseY = maxY;
                }

                if (e.X >= midX - snapSize && e.X <= midX + snapSize)
                {
                    mouseX = midX;
                    //vertImage.Visible = true;
                }
                else
                {
                    //vertImage.Visible = false;
                }
                if (e.Y >= midY - snapSize && e.Y <= midY + snapSize)
                {
                    mouseY = midY;
                    // horizImage.Visible = true;
                }
                else
                {
                    //horizImage.Visible = false;
                }

                stimImageL.Location = new Point(mouseX, mouseY);
                updateStimPosList();
            }

        }

        private void updateStimPosList()
        {

        }

        private void stimPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mousePrevDown = true;
        }

        private void stimPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mousePrevDown = false;
        }



        private void stimPanel_MouseLeave(object sender, EventArgs e)
        {
            mousePrevDown = false;

        }

        private void stimPanel_DragLeave(object sender, EventArgs e)
        {
            mousePrevDown = false;
        }

        private void horizImage_Click(object sender, EventArgs e)
        {

        }

        private void vertImage_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void snapBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Create_Load(object sender, EventArgs e)
        {

        }

        private void Create_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mySettings.hasChanged == true)
            {
                myXML.updateBlock(selectedBlock, blockInfo[blockindex]);
            }
        }

        // Loads stimuli images in to preview window
        private void updateImagePreviewEvent(DataGridViewCellEventArgs e)
        {
            updateImagePreview(e.RowIndex);
        }

        private void updateImagePreview(int index)
        {
            if (index >= 0)
            {
                DataGridViewRow row = stimDataGrid.Rows[index];

                Console.WriteLine("Row " + index + " entered.");

                if (row.Cells[1].Value != null)
                {
                    string leftImage = row.Cells[1].Value.ToString();

                    if (leftImage != "")
                    {
                        //Console.WriteLine("Updating left  row " + index + "  with image: " + row.Cells[1].Value.ToString());
                        stimImageL.ImageLocation = Properties.Settings.Default.stimPath + "/" + leftImage;
                    }
                    else
                    {
                        Console.WriteLine("No left  image name");
                        stimImageL.ImageLocation = Properties.Settings.Default.ExpPath + @"\resources\" + "none.gif";
                    }
                }
                else
                {
                    stimImageL.ImageLocation = Properties.Settings.Default.ExpPath + @"\resources\" + "none.gif";
                    // Console.WriteLine("No left cell value");
                }
                if (row.Cells[2].Value != null)
                {
                    string rightImage = row.Cells[2].Value.ToString();

                    if (rightImage != "")
                    {
                        // Console.WriteLine("Updating right row " + e.RowIndex.ToString() + "  with image: " + row.Cells[1].Value.ToString());
                        stimImageR.ImageLocation = Properties.Settings.Default.stimPath + "/" + rightImage;
                    }
                    else
                    {
                        // Console.WriteLine("No right image name");
                        stimImageR.ImageLocation = Properties.Settings.Default.ExpPath + @"\resources\" + "none.gif";
                    }
                }
                else
                {
                    stimImageR.ImageLocation = Properties.Settings.Default.ExpPath + @"\resources\" + "none.gif";
                    // Console.WriteLine("No right cell value");
                }

            }
            else
            {

            }
        }

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (stimDataGrid.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                stimDataGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void stimDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateStimList();
            updateImagePreviewEvent(e);
        }

        private void stimDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            updateImagePreviewEvent(e);
        }

        private void randOptButton_Click(object sender, EventArgs e)
        {
            randWindow.randSeed = blockInfo[blockindex].randSeed;
            randWindow.randOption = blockInfo[blockindex].randSeed;
            randWindow.ShowDialog();

            blockInfo[blockindex].randSeed = randWindow.randSeed;
        }


        //  Counter balance the trial list. Creates 3 new lists with columns swapped

        private void cbButton_Click(object sender, EventArgs e)
        {
            // trialInfo[trialIndex].stimulusList;

            TrialInfo CBTrialInfo = new TrialInfo();


            // Balance 1

            CBTrialInfo.title = trialInfo[0].title + "CB1";
            CBTrialInfo.stimulusList = string.Join(",", tempStimsR);
            CBTrialInfo.stimulusListRight = string.Join(",", tempStimsL);
            CBTrialInfo.audioStimulus = string.Join(",", tempAudioStims);
            CBTrialInfo.audioStimulusSide = string.Join(",", tempAudioStimSide);

            for (int i = 0; i <= tempStimsL.Count; i++)
            {
                tempStimPos.Add("{X=0,Y=73}");
                tempStimRPos.Add("{X=100,Y=73}");
            }
            CBTrialInfo.stimulusPosList = string.Join(":", tempStimPos);
            CBTrialInfo.stimulusRPosList = string.Join(":", tempStimRPos);

            myXML.addTrial(blockInfo[blockindex], "CB1");
            refresh_trialListBox();
            myXML.updateTrial(trialList[trialList.Count - 1], CBTrialInfo);
            refresh_trialListBox();

            //Balance 2

            CBTrialInfo.title = trialInfo[0].title + "CB2";
            CBTrialInfo.stimulusList = string.Join(",", tempStimsL);
            CBTrialInfo.stimulusListRight = string.Join(",", tempStimsR);
            CBTrialInfo.audioStimulus = string.Join(",", tempAudioStimSide);
            CBTrialInfo.audioStimulusSide = string.Join(",", tempAudioStims);

            for (int i = 0; i <= tempStimsL.Count; i++)
            {
                tempStimPos.Add("{X=0,Y=73}");
                tempStimRPos.Add("{X=100,Y=73}");
            }
            CBTrialInfo.stimulusPosList = string.Join(":", tempStimPos);
            CBTrialInfo.stimulusRPosList = string.Join(":", tempStimRPos);

            myXML.addTrial(blockInfo[blockindex], "CB2");
            refresh_trialListBox();
            myXML.updateTrial(trialList[trialList.Count - 1], CBTrialInfo);
            refresh_trialListBox();

            // Balance 3

            CBTrialInfo.title = trialInfo[0].title + "CB3";
            CBTrialInfo.stimulusList = string.Join(",", tempStimsR);
            CBTrialInfo.stimulusListRight = string.Join(",", tempStimsL);
            CBTrialInfo.audioStimulus = string.Join(",", tempAudioStimSide);
            CBTrialInfo.audioStimulusSide = string.Join(",", tempAudioStims);

            for (int i = 0; i <= tempStimsL.Count; i++)
            {
                tempStimPos.Add("{X=0,Y=73}");
                tempStimRPos.Add("{X=100,Y=73}");
            }
            CBTrialInfo.stimulusPosList = string.Join(":", tempStimPos);
            CBTrialInfo.stimulusRPosList = string.Join(":", tempStimPos);

            myXML.addTrial(blockInfo[blockindex], "CB3");
            refresh_trialListBox();
            myXML.updateTrial(trialList[trialList.Count - 1], CBTrialInfo);
            refresh_trialListBox();

        }

        private void blockListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (true)
            {
                if (selectedTrial != null)
                {
                    myXML.updateTrial(selectedTrial, trialInfo[trialIndex]);
                }
                myXML.updateBlock(selectedBlock, blockInfo[blockindex]);
                blockindex = blockListBox.SelectedIndex;
            }
            populate_blockInfo();
            setSelectedBlockNode();
            refresh_trialListBox();
        }

        private void stimImageL_Click(object sender, EventArgs e)
        {

        }

        private void attnButton_Click(object sender, EventArgs e)
        {
            AttnGetterWindow attnWin = new AttnGetterWindow();
            attnWin.parentWindow = this;
            attnWin.Show();
        }

        public void setAttn(string audio, string image)
        {
            blockInfo[blockindex].attnImage = image;
            blockInfo[blockindex].attnAudio = audio;
        }

        private void stimImageR_Click(object sender, EventArgs e)
        {

        }

        private void stimDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void trialTitleBox_TextChanged(object sender, EventArgs e)
        {
            trialInfo[trialIndex].title = trialTitleBox.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void stimDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }

    public class Settings
    {
        public bool showConfirm { get; set; }
        public bool hasChanged { get; set; }
    }

}

