using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        BlockInfo blockInfo = new BlockInfo();
        TrialInfo trialInfo = new TrialInfo();

        int blockindex = 0;
        int trialIndex = -1;

        bool isLoading = false;
        bool mousePrevDown = false;
        int snapSize = 10;

        string audioStimFile = "";

        string errorList = "";

        // Temp lists for counterbalance button
        List<string> tempStimsL = new List<string>();
        List<string> tempStimsR = new List<string>();
        List<string> tempAudioStims = new List<string>();
        List<string> tempAudioStimSide = new List<string>();



        public Create()
        {
            isLoading = true;
            InitializeComponent();
            PopulateListBox();
            populateStimList();

            // Set for transparent gifs
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            vertImage.BackColor = Color.Transparent;
            horizImage.BackColor = Color.Transparent;

            // Set default settings TODO: Move to settings file
            mySettings.showConfirm = false;
            isLoading = false;
            imageCollections.Visible = false;
        }



        // Converts the colour picker to something we can save/load in XML
        private String colourToString()
        {
            String buttonColourString = colourButton.BackColor.ToArgb().ToString();
            return buttonColourString;
        }
        // Custom clamp function
        public static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }


        // Custom error message dialog box
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
            SaveChanges();
        }
        // Save changes to XML
        private void SaveChanges()
        {
            if (isLoading) return;
            Debug.WriteLine("Saving...");
            if (myXML.updateBlock(blockListBox.SelectedIndex, blockInfo))
            {
                myXML.updateTrial(trialListBox.SelectedIndex, trialInfo);
            }
            else
            {
                errorMessage("Error updating block", "Error");
            }
        }


        // Read BEX files from folder and list them
        private void PopulateListBox()
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

        // Read the Stimulus folder and list images and sounds on form
        private void populateStimList()
        {
            List<FileInfo> Files = new List<FileInfo>();

            DirectoryInfo dvstiminfo = new DirectoryInfo(Properties.Settings.Default.stimPathVisual);
            string[] filters = new[] { "*.jpg", "*.png", "*.gif", "*.bmp" };

            foreach (String ext in filters)
            {
                FileInfo[] TempFiles = dvstiminfo.GetFiles(ext);
                Files.AddRange(TempFiles);
            }
            if (Files.Count <= 0)
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
            DataGridViewComboBoxColumn cboBoxLColumn = (DataGridViewComboBoxColumn)stimDataGrid.Columns[1];
            DataGridViewComboBoxColumn cboBoxRColumn = (DataGridViewComboBoxColumn)stimDataGrid.Columns[2];

            cboBoxLColumn.Items.Add("");
            cboBoxRColumn.Items.Add("");

            foreach (FileInfo file in Files)
            {
                cboBoxLColumn.Items.Add(file.Name);
                cboBoxRColumn.Items.Add(file.Name);
            }

            Files.Clear();

            DirectoryInfo dastiminfo = new DirectoryInfo(Properties.Settings.Default.stimPathAudio);

            string[] audiFilters = new[] { "*.wav", "*.mp3" };

            foreach (String ext in audiFilters)
            {
                FileInfo[] TempFiles = dastiminfo.GetFiles(ext);
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
            cboBoxARColumn.Items.Add("None");
        }

        // Save unsaved and then load new blocks when selected experiment changes
        private void expListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool fileSelected;
            string fileName = "";
            isLoading = true;

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
                    errorMessage("File: " + fileName + " is corrupt.", "Error");
                    expListBox.Items.RemoveAt(expListBox.SelectedIndex);
                }
                else
                {
                    Debug.WriteLine("Refreshing..." + fileName);
                    refreshBlockList();
                }
            }

            isLoading = false;
        }

        // Load blocks from BEX file
        private void refreshBlockList()
        {
            // Clear current list
            blockListBox.Items.Clear();

            // Get reader to read the blocks
            List<string> blocks = myXML.getBlockList(expListBox.Text);

            Debug.WriteLine("Read " + blocks.Count + " lines");
            if (blocks.Count == 0) return;

            foreach (string block in blocks)
            {
                blockListBox.Items.Add(block);
            }

            blockListBox.SelectedIndex = 0;
        }


        // Load trials from BEX file
        private void refresh_trialListBox()
        {
            // Clear current list
            trialListBox.Items.Clear();

            // Get reader to read the blocks
            List<string> trials = myXML.getTrialList(blockListBox.Text);

            if (trials.Count == 0) return;

            foreach (string trial in trials)
            {
                trialListBox.Items.Add(trial);
            }

            trialListBox.SelectedIndex = 0;
            stimDataGrid.Enabled = true;
        }

        // Loads the values from the array in to the form
        // TODO: Add more error checking
        private void populate_blockInfo()
        {
            blockInfo = myXML.getBlockInfo(blockListBox.SelectedIndex);

            titleBox.Text = blockInfo.blockName;
            commentBox.Text = blockInfo.comment;
            visualOnsetBox.Value = int.Parse(blockInfo.vOnset);
            audioOnsetBox.Value = int.Parse(blockInfo.aOnset);
            showThumbsBox.Checked = bool.Parse(blockInfo.showThumbs);
            showStimInfoBox.Checked = bool.Parse(blockInfo.showStimInfo);
            showTrialCountBox.Checked = bool.Parse(blockInfo.showTrialCount);
            showAllBox.Checked = bool.Parse(blockInfo.showAll);
            hcLooksBox.Value = int.Parse(blockInfo.hcLooks);
            lookTrialExceedBox.Value = int.Parse(blockInfo.lookTrialExceed);
            habitNPercentBox.Value = int.Parse(blockInfo.habitNPercent);


            Int32 argb = Convert.ToInt32(blockInfo.bgColour);
            colourButton.BackColor = Color.FromArgb(argb);

            switch (int.Parse(blockInfo.trialEndsWhen))
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

            switch (int.Parse(blockInfo.blocksEndWhen))
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

            switch (int.Parse(blockInfo.hcBasis))
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

            switch (int.Parse(blockInfo.hcWindow))
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

            int value = int.Parse(blockInfo.maxTrialDuration);
            maxTrialDurBox.Value = Clamp(value, 500, 25000);
        }

        // Load the trial info from the array to the form
        private void populate_TrialInfo()
        {
            trialInfo = myXML.getTrialInfo(trialListBox.Text);


            trialTitleBox.Text = trialInfo.partCode;

            if (trialInfo.isPresented)
            {
                shownTextLabel.ForeColor = Color.Red;
                shownTextLabel.Text = "Already presented";
            }
            else
            {
                shownTextLabel.ForeColor = Color.Green;
                shownTextLabel.Text = "Not presented";
            }

            stimDataGrid.Rows.Clear();

            if (trialInfo.stimulusList.Length > 0)
            {
                string[] stims = trialInfo.stimulusList.Split(',');
                string[] stimsR = trialInfo.stimulusListRight.Split(',');
                string[] audioStims = trialInfo.audioStimulus.Split(',');
                string[] audioStimSide = trialInfo.audioStimulusSide.Split(',');

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

            mySettings.hasChanged = false;
        }
        // TODO: Add this for more error checking - could be moved to XML class?
        private bool checkStimulusFile(string stimulus)
        {
            if (stimulus == "") { return false; }

            if (File.Exists(Properties.Settings.Default.stimPathVisual + "/" + stimulus) || File.Exists(Properties.Settings.Default.stimPathAudio + "/" + stimulus))
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

        // TODO: Could add this back in, but it's not really needed as we save on every change
        private bool isSaved()
        {
            if (mySettings.hasChanged)
            {

                if (sureMessage("Save changes?", "Changes") == DialogResult.Yes)
                {
                    SaveChanges();
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
        // Save new title when the text box is edited
        private void titleBox_TextChanged(object sender, EventArgs e)
        {
            blockInfo.blockName = titleBox.Text;
            SaveChanges();
        }

        // TODO: Can remove the save button as long as the autosave works
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
        // Gets XML class to add a new block
        private void addBlock_Click(object sender, EventArgs e)
        {
            if (selectedBlock != null)
            {
                myXML.updateBlock(blockListBox.SelectedIndex, blockInfo);
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

            stimDataGrid.Enabled = false;
        }
        // Opens colour picker dialog
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
                blockInfo.bgColour = colourToString();
                SaveChanges();
            }
        }



        // Gets XML class to add a new trial
        private void addTrialButton_Click(object sender, EventArgs e)
        {
            if (trialTitleBox.Text != "")
            {
                myXML.addTrial(blockInfo, trialTitleBox.Text);
            }
            else
            {
                myXML.addTrial(blockInfo, "Child" + blockindex);
            }
            refresh_trialListBox();
            SaveChanges();
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
        // Many below: Handle form changes: set changes in to array
        //

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo.trialEndsWhen = "1";
            SaveChanges();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo.trialEndsWhen = "2";
            SaveChanges();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo.trialEndsWhen = "3";
            SaveChanges();
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
            SaveChanges();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo.showThumbs = showThumbsBox.Checked.ToString();
            if (!showThumbsBox.Checked)
            {
                showAllBox.Checked = false;
            }
            SaveChanges();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo.showStimInfo = showStimInfoBox.Checked.ToString();
            if (!showThumbsBox.Checked)
            {
                showAllBox.Checked = false;
            }
            SaveChanges();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo.showTrialCount = showTrialCountBox.Checked.ToString();
            if (!showThumbsBox.Checked)
            {
                showAllBox.Checked = false;
            }
            SaveChanges();
        }

        private void removeBlockButton_Click(object sender, EventArgs e)
        {
            myXML.deleteBlock(selectedBlock);
            refreshBlockList();
        }

        private void commentBox_TextChanged(object sender, EventArgs e)
        {
            blockInfo.comment = commentBox.Text;
            SaveChanges();
        }

        private void visualOnsetBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo.vOnset = visualOnsetBox.Value.ToString();
            SaveChanges();
        }

        private void audioOnsetBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo.aOnset = audioOnsetBox.Value.ToString();
            SaveChanges();
        }

        private void maxTrialDurBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo.maxTrialDuration = maxTrialDurBox.Value.ToString();
            SaveChanges();
        }

        private void lookExceedBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo.lookTrialExceed = lookTrialExceedBox.Value.ToString();
            SaveChanges();
        }

        private void lookBlockExceedBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo.lookBlockExceed = lookBlockExceedBox.Value.ToString();
            SaveChanges();
        }

        private void lookedMin_ValueChanged(object sender, EventArgs e)
        {
            blockInfo.lookedMin = lookedMin.Value.ToString();
            SaveChanges();
        }

        private void lookResetBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo.lookReset = lookResetBox.Value.ToString();
            SaveChanges();
        }
        private void hcLooksBox_ValueChanged(object sender, EventArgs e)
        {
            blockInfo.hcLooks = hcLooksBox.Value.ToString();
            SaveChanges();
        }

        private void habitNPercent_ValueChanged(object sender, EventArgs e)
        {
            blockInfo.habitNPercent = habitNPercentBox.Value.ToString();
            SaveChanges();
        }

        private void FirstNTrialOption_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo.hcBasis = "1";
            SaveChanges();
        }

        private void longestNTrialOption_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo.hcBasis = "2";
            SaveChanges();
        }
        private void hcWindowOption1_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo.hcWindow = "1";
            SaveChanges();
        }

        private void hcWindowOption2_CheckedChanged(object sender, EventArgs e)
        {
            blockInfo.hcWindow = "2";
            SaveChanges();
        }

        private void trialListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            isLoading = true;
            updateStimList();
            populate_TrialInfo();
            updateImagePreview(0);
            isLoading = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // Updates the stimulus list from the data grid
        private void updateStimList()
        {
            tempStimsL.Clear();
            tempStimsR.Clear();
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
                }
            }

            if (tempStimsL.Count > 0)
            {
                trialInfo.stimulusList = string.Join(",", tempStimsL);
                trialInfo.stimulusListRight = string.Join(",", tempStimsR);
                trialInfo.audioStimulus = string.Join(",", tempAudioStims);
                trialInfo.audioStimulusSide = string.Join(",", tempAudioStimSide);
            }
        }

        // Use mouse to move images TODO: remove this
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
        // Save on close
        private void Create_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (trialListBox.Items.Count == 0) { return; }

            //   myXML.updateBlock(selectedBlock, blockInfo);
            if (myXML.updateBlock(blockListBox.SelectedIndex, blockInfo))
            {
                myXML.updateTrial(trialListBox.SelectedIndex, trialInfo);
                refreshBlockList();
                refresh_trialListBox();
            }
            else
            {
                errorMessage("Error updating block", "Error");
            }
        }

        // Loads stimuli images in to preview window
        private void updateImagePreviewEvent(DataGridViewCellEventArgs e)
        {
            updateImagePreview(e.RowIndex);
        }
        // Show the images in the preview window based on the row index of the data table
        private void updateImagePreview(int index)
        {
            if (index >= 0)
            {
                DataGridViewRow row = stimDataGrid.Rows[index];

                if (row.Cells[1].Value != null)
                {
                    string leftImage = row.Cells[1].Value.ToString();

                    if (leftImage != "")
                    {
                        //Console.WriteLine("Updating left  row " + index + "  with image: " + row.Cells[1].Value.ToString());
                        stimImageL.ImageLocation = Properties.Settings.Default.stimPathVisual + "/" + leftImage;
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
                        stimImageR.ImageLocation = Properties.Settings.Default.stimPathVisual + "/" + rightImage;
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
            Debug.WriteLine("Changed");
           
            updateStimList();
            SaveChanges();
            updateImagePreviewEvent(e);
        }

        private void stimDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            updateImagePreviewEvent(e);

            mySettings.hasChanged = false;
        }

        private void randOptButton_Click(object sender, EventArgs e)
        {
            randWindow.randSeed = blockInfo.randSeed;
            randWindow.randOption = blockInfo.randSeed;
            randWindow.ShowDialog();

            blockInfo.randSeed = randWindow.randSeed;
        }


        //  Counter balance the trial list. Creates 3 new lists with columns swapped
        // TODO: Move to XML class, maybe
        private void cbButton_Click(object sender, EventArgs e)
        {
            TrialInfo CBTrialInfo = new TrialInfo();
            List<string> tempAudioStimSideSwapped = new List<string>();

            // Balance 1 - Swap Stims and Side

            CBTrialInfo.partCode = trialInfo.partCode + "_StimSide";
            CBTrialInfo.stimulusList = string.Join(",", tempStimsR);
            CBTrialInfo.stimulusListRight = string.Join(",", tempStimsL);
            CBTrialInfo.audioStimulus = string.Join(",", tempAudioStims);
            foreach (string side in tempAudioStimSide)
            {
                Console.WriteLine("Changing side: " + side);
                if (side == "Left")
                {
                    tempAudioStimSideSwapped.Add("Right");
                }
                else
                {
                    tempAudioStimSideSwapped.Add("Left");
                }
            }
            CBTrialInfo.audioStimulusSide = string.Join(",", tempAudioStimSideSwapped);


            myXML.addTrial(blockInfo, "CB1");
            refresh_trialListBox();
            myXML.updateTrial(trialListBox.Items.Count-1, CBTrialInfo);
            refresh_trialListBox();

            //Balance 2 - Swap Side
            CBTrialInfo.audioStimulusSide = "";
            CBTrialInfo.partCode = trialInfo.partCode + "CB2";
            CBTrialInfo.stimulusList = string.Join(",", tempStimsL);
            CBTrialInfo.stimulusListRight = string.Join(",", tempStimsR);
            CBTrialInfo.audioStimulus = string.Join(",", tempAudioStims);
            CBTrialInfo.audioStimulusSide = string.Join(",", tempAudioStimSideSwapped);

            myXML.addTrial(blockInfo, "CB2");
            refresh_trialListBox();
            myXML.updateTrial(trialListBox.Items.Count - 1, CBTrialInfo);
            refresh_trialListBox();

            // Balance 3 Swap stims

            CBTrialInfo.partCode = trialInfo.partCode + "CB3";
            CBTrialInfo.stimulusList = string.Join(",", tempStimsR);
            CBTrialInfo.stimulusListRight = string.Join(",", tempStimsL);
            CBTrialInfo.audioStimulus = string.Join(",", tempAudioStims);
            CBTrialInfo.audioStimulusSide = string.Join(",", tempAudioStimSide);


            myXML.addTrial(blockInfo, "CB3");
            refresh_trialListBox();
            myXML.updateTrial(trialListBox.Items.Count - 1, CBTrialInfo);
            refresh_trialListBox();

        }

        private void blockListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mySettings.hasChanged)
            {
                if (selectedTrial != null)
                {
                    SaveChanges();
                }
                blockindex = blockListBox.SelectedIndex;
            }
            populate_blockInfo();
            setSelectedBlockNode();
            refresh_trialListBox();
        }

        private void stimImageL_Click(object sender, EventArgs e)
        {

        }

        private void stimImageR_Click(object sender, EventArgs e)
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
            blockInfo.attnImage = image;
            blockInfo.attnAudio = audio;
        }

        public Tuple<string, string> getAttn()
        {
            string image = blockInfo.attnImage;
            string audio = blockInfo.attnAudio;

            Tuple<string, string> t = new Tuple<string, string>(image, audio);

            return t;
        }




        private void stimDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void trialTitleBox_TextChanged(object sender, EventArgs e)
        {

            //trialInfo.partCode = trialTitleBox.Text;

            //refresh_trialListBox();
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

        private void delTrialButton_Click(object sender, EventArgs e)
        {
            // TODO: Remove selected Trial
            myXML.removeTrial(trialListBox.SelectedIndex);
            refresh_trialListBox();
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            trialInfo.partCode = trialTitleBox.Text;
            myXML.updateTrial(trialListBox.SelectedIndex, trialInfo);
            refresh_trialListBox();
        }
    }

    public class Settings
    {
        public bool showConfirm { get; set; }
        public bool hasChanged { get; set; }
    }

}