using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Data;
using System.Windows.Documents;
using System.Diagnostics;

namespace LincolnTest
{
    public class BlockInfo
    {
        public string type { get; set; }
        public string blockName { get; set; }
        public string comment { get; set; }
        public string vOnset { get; set; }
        public string aOnset { get; set; }
        public string maxTrialDuration { get; set; }
        public string bgColour { get; set; }
        public string trialEndsWhen { get; set; }
        public string lookTrialExceed { get; set; }
        public string lookBlockExceed { get; set; }
        public string lookedMin { get; set; }
        public string lookReset { get; set; }
        public string showThumbs { get; set; }
        public string showStimInfo { get; set; }
        public string showTrialCount { get; set; }
        public string showAll { get; set; }
        public string blocksEndWhen { get; set; }
        public string hcLooks { get; set; }
        public string hcBasis { get; set; }
        public string hcWindow { get; set; }
        public string habitNPercent { get; set; }
        public string randSeed { get; set; }
        public string randOption { get; set; }
        public string logFile { get; set; }
        public string attnImage { get; set; }
        public string attnAudio { get; set; }

    }



    public class TrialInfo
    {
        public string filePath { get; set; }
        public string partCode { get; set; }
        public string partDOB { get; set; }
        public string partGender { get; set; }
        public string audioStimulus { get; set; }
        public string audioStimulusSide { get; set; }
        public string stimulusList { get; set; }
        public string stimulusListRight { get; set; }
        public bool isPresented { get; set; }
        public bool isScored { get; set; }
    }


    
    class CreateXML
    {
        string currFileName;
        List<string> blockList;

        // Parts of the currently loaded file
        XmlDocument doc = new XmlDocument();
        XmlNode root;
        XmlNodeList trialsRead;
        XmlNodeList blocksRead;

        // Create a basic BEX File
        public bool CreateXMLDoc(string filename)
        {
            using (XmlWriter writer = XmlWriter.Create(Properties.Settings.Default.ExpPath + @"\" + filename))
            {
                writer.WriteStartElement("Blocks");
                writer.WriteEndElement();
                writer.Flush();
            }
            doc = new XmlDocument();
            getBlocks(filename);
            addDefaultBlock("Block1", "visual");
            return true;
        }
        // Read blocks from a file
        public XmlDocument getBlocks(string fileName)
        {
            currFileName = fileName;
            try
            {
                doc.Load(Properties.Settings.Default.ExpPath + @"\" + fileName);
            }
            catch
            {
                return null;
            }
            return doc;
        }

        // Add an empty block
        public bool addBlock(BlockInfo blockInfo)
        {

            XmlNode root = doc.DocumentElement;
            XmlNodeList nodeList = root.SelectNodes("descendant::Block[blockName='" + blockInfo.blockName + "']");

            while (nodeList.Count >= 1)
            {
                blockInfo.blockName = blockInfo.blockName + "_1";
                nodeList = root.SelectNodes("descendant::Block[blockName='" + blockInfo.blockName + "']");
            }

            XmlElement element1 = doc.CreateElement(string.Empty, "Block", string.Empty);

            foreach (PropertyInfo propertyinfo in typeof(BlockInfo).GetProperties())
            {
                if (propertyinfo != null)
                {
                    var valueOfField = propertyinfo.GetValue(blockInfo);
                    var fieldname = propertyinfo.Name;
                    XmlText text;

                    XmlElement element = doc.CreateElement(string.Empty, fieldname, string.Empty);
                    
                    if(valueOfField != null)
                    {
                        text = doc.CreateTextNode(valueOfField.ToString());
                    }
                    else
                    {
                        text = doc.CreateTextNode("");
                    }
                    
                    element.AppendChild(text);
                    element1.AppendChild(element);
                }
            }

            doc.DocumentElement.AppendChild(element1);
            doc.Save(Properties.Settings.Default.ExpPath + @"\" + currFileName);

            return true;
        }

       

        //Update existing block

        public bool updateBlock(int blockNum, BlockInfo blockInfo)
        {
            XmlElement blockElement = (XmlElement)blocksRead[blockNum];



            Console.WriteLine("Saving: " + blockElement["blockName"].InnerText + " with block: " + blockInfo.blockName);

            if (blockElement["blockName"].InnerText != blockInfo.blockName)
            {
                // If we updated the block name, update the trials
                XmlNodeList trialList = root.SelectNodes("descendant::Trial[Block='" + blockElement["partCode"].InnerText + "']");
                for (int i = 0; i < trialList.Count; i++)
                {
                    XmlElement trialElement = (XmlElement)trialList[i];
                    XmlNodeList titleList = trialElement.SelectNodes("Block");
                    for (int x = 0; x < titleList.Count; x++)
                    {
                        titleList[x].InnerText = blockInfo.blockName;
                    }
                }

            }

            foreach (PropertyInfo propertyinfo in typeof(BlockInfo).GetProperties())
            {
                if (propertyinfo != null)
                {
                    var valueOfField = propertyinfo.GetValue(blockInfo);
                    if (valueOfField == null)
                    {
                        MessageBox.Show("Some text", "Some partCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    var fieldname = propertyinfo.Name;

                    blockElement[fieldname].InnerText = valueOfField.ToString();

                }
            }

            doc.Save(Properties.Settings.Default.ExpPath + @"\" + currFileName);

            return true;
        }

        


        // For fixing bad files and updating existing ones if we add more options
        public void addMissingNode(XmlNode block, string name, string value)
        {
            XmlElement element = doc.CreateElement(string.Empty, name, string.Empty);
            XmlText text = doc.CreateTextNode(name);
            element.AppendChild(text);
            block.AppendChild(element);


            doc.Save(Properties.Settings.Default.ExpPath + @"\" + currFileName);
        }
        // Update existing trial
        public bool updateTrial(int trialNum, TrialInfo trialInfo)
        {
            XmlElement trialElement = (XmlElement)trialsRead[trialNum];

            Console.WriteLine("Saving: " + trialElement["partCode"].InnerText + " with trial: " + trialInfo.partCode + " with Stims: " + trialInfo.stimulusList.ToString()) ;
            bool noNodes = false;

            trialElement["partCode"].InnerText = trialInfo.partCode;
            trialElement["isScored"].InnerText = trialInfo.isScored.ToString().ToLower();
            trialElement["isPresented"].InnerText = trialInfo.isPresented.ToString().ToLower();

            if (trialInfo.stimulusList != "")
            {
                string[] stims = trialInfo.stimulusList.ToString().Split(',');
                string[] stimsR = trialInfo.stimulusListRight.ToString().Split(',');
                string[] audioStims = trialInfo.audioStimulus.ToString().Split(',');
                string[] audioStimsSide = trialInfo.audioStimulusSide.ToString().Split(',');

                int index = 0;

                try {
                    trialsRead[trialNum].SelectNodes("VisualStimuli");
                }
                catch
                {
                    noNodes = true;                        
                }

                if (!noNodes)
                {
                    XmlNodeList nodes = trialsRead[trialNum].SelectNodes("VisualStimuli");
                    for (int i = nodes.Count - 1; i >= 0; i--)
                    {
                        nodes[i].ParentNode.RemoveChild(nodes[i]);
                    }
                }

                foreach (string stim in stims)
                {
                    XmlElement stimNode = doc.CreateElement(string.Empty, "VisualStimuli", string.Empty);
                    XmlText text1 = doc.CreateTextNode(stim);
                    stimNode.AppendChild(text1);
                    trialElement.AppendChild(stimNode);
                    stimNode.SetAttribute("RightImage", stimsR[index]);
                    stimNode.SetAttribute("audioStimulus", audioStims[index]);
                    stimNode.SetAttribute("audioStimulusCB", audioStimsSide[index]);
                    stimNode.SetAttribute("partDOB", trialInfo.partDOB);
                    index++;
                }

            }
            else
            {

                Console.WriteLine("No stimulus to save");
            }

            doc.Save(Properties.Settings.Default.ExpPath + @"\" + currFileName);

            return true;
        }

        // Add empty trial node
        public bool addTrial(BlockInfo blockInfo, string trialName)
        {
            XmlNode root = doc.DocumentElement;
            XmlNodeList nodeList = root.SelectNodes("descendant::Trial[Block='" + blockInfo.blockName + "']");

            XmlElement element1 = doc.CreateElement(string.Empty, "Trial", string.Empty);

            XmlElement element2 = doc.CreateElement(string.Empty, "partCode", string.Empty);
            XmlText text2 = doc.CreateTextNode(trialName);
            element2.AppendChild(text2);
            element1.AppendChild(element2);

            XmlElement element3 = doc.CreateElement(string.Empty, "Block", string.Empty);
            XmlText text3 = doc.CreateTextNode(blockInfo.blockName);
            element3.AppendChild(text3);
            element1.AppendChild(element3);

            XmlElement element4 = doc.CreateElement(string.Empty, "TrialsEnd", string.Empty);
            XmlText text4 = doc.CreateTextNode("max");
            element4.AppendChild(text4);
            element1.AppendChild(element4);

            XmlElement element5 = doc.CreateElement(string.Empty, "isScored", string.Empty);
            XmlText text5 = doc.CreateTextNode("false");
            element5.AppendChild(text5);
            element1.AppendChild(element5);

            XmlElement element6 = doc.CreateElement(string.Empty, "isPresented", string.Empty);
            XmlText text6 = doc.CreateTextNode("false");
            element6.AppendChild(text6);
            element1.AppendChild(element6);

            doc.DocumentElement.AppendChild(element1);
            doc.Save(Properties.Settings.Default.ExpPath + @"\" + currFileName);
            return true;
        }

        public bool removeTrial(int selectedTrial)
        {

            trialsRead[selectedTrial].RemoveAll();

            
            return true;
        }

        // Add a default block
        public bool addDefaultBlock(string title, string type)
        {
            BlockInfo blockInfo = new BlockInfo();
            blockInfo.blockName = title;
            blockInfo.type = type;
            blockInfo.comment = "Default block";
            blockInfo.vOnset = "0";
            blockInfo.aOnset = "0";
            blockInfo.maxTrialDuration = "6000";
            blockInfo.bgColour = "-8355712";
            blockInfo.trialEndsWhen = "1";
            blockInfo.showThumbs = "False";
            blockInfo.showStimInfo = "False";
            blockInfo.showTrialCount = "False";
            blockInfo.showAll = "False";
            blockInfo.blocksEndWhen = "1";
            blockInfo.hcLooks = "1";
            blockInfo.hcBasis = "1";
            blockInfo.hcWindow = "1";
            blockInfo.logFile = "";
            blockInfo.lookTrialExceed = "1";
            blockInfo.lookBlockExceed = "0";
            blockInfo.lookedMin = "0";
            blockInfo.lookReset = "0";
            blockInfo.habitNPercent = "0";
            blockInfo.randSeed = "0";
            blockInfo.randOption = "0";
            blockInfo.attnImage = "";


            return addBlock(blockInfo);
        }


        // Delete a block
        public void deleteBlock(XmlNode block)
        {
            XmlNode prevNode = block.PreviousSibling;

            block.OwnerDocument.DocumentElement.RemoveChild(block);

            try
            {
                if (prevNode != null)
                {
                    if (prevNode.NodeType == XmlNodeType.Whitespace ||
                prevNode.NodeType == XmlNodeType.SignificantWhitespace)
                    {
                        prevNode.OwnerDocument.DocumentElement.RemoveChild(prevNode);
                    }
                }
            }
            catch
            {

            }

            doc.Save(Properties.Settings.Default.ExpPath + @"\" + currFileName);

        }

        // Load a file and return a list of blocks: Used to update lists in various windows
        public List<string> getBlockList(string fileName)
        {
            List<string> blockList = new List<string>();

            try
            {
                doc.Load(Properties.Settings.Default.ExpPath + @"\" + fileName);
            }
            catch
            {
                return blockList;
            }

            root = doc.DocumentElement;

            if (root.HasChildNodes)
            {
                XmlNode first = root.NextSibling;

                blocksRead = root.SelectNodes("Block");

                for (int i = 0; i < blocksRead.Count; i++)
                {
                    // blockListBox.Items.Add(blockList[i].FirstChild.InnerXml);
                    XmlElement node = (XmlElement)blocksRead[i];
                    blockList.Add(node["blockName"].InnerText);
                }
            }
            return blockList;
        }
        // Return a list of trials for a block from the loaded file
        public List<string> getTrialList(string fileName, string blockName)
        {
            currFileName = fileName;

            List<string> trialList = new List<string>();

            trialsRead = root.SelectNodes("descendant::Trial[Block='" + blockName + "']");
            for (int i = 0; i < trialsRead.Count; i++)
            {
                trialList.Add(trialsRead[i].FirstChild.InnerXml);
            }

            return trialList;

        }
        // Returns the info for a trial
        public TrialInfo getTrialInfo(int trialNum) { 
        
            TrialInfo trialInfo = new TrialInfo();

            Debug.WriteLine(trialsRead[trialNum].InnerText);
            
            XmlElement selectedTrial = (XmlElement)trialsRead[trialNum];

            trialInfo.partCode = selectedTrial["partCode"].InnerText;

            List<string> tempStimsL = new List<string>();
            List<string> tempStimsR = new List<string>();
            List<string> tempAudioStims = new List<string>();
            List<string> tempAudioStimSide = new List<string>();

            XmlNodeList stims = selectedTrial.SelectNodes("VisualStimuli");
            for (int i = stims.Count - 1; i >= 0; i--)
            {
                    tempStimsL.Add(stims[i].InnerText);
                    tempStimsR.Add(stims[i].Attributes["RightImage"].Value);
                    tempAudioStims.Add(stims[i].Attributes["audioStimulus"].Value);
                    tempAudioStimSide.Add(stims[i].Attributes["audioStimulusCB"].Value);
            }

            // Reverse order, because .Add adds at the beginning
            tempStimsL.Reverse();
            tempStimsR.Reverse();
            tempAudioStims.Reverse();
            tempAudioStimSide.Reverse();

            trialInfo.stimulusList = string.Join(",", tempStimsL);
            trialInfo.stimulusListRight = string.Join(",", tempStimsR);
            trialInfo.audioStimulus = string.Join(",", tempAudioStims);
            trialInfo.audioStimulusSide = string.Join(",", tempAudioStimSide);

            trialInfo.isPresented = selectedTrial["isPresented"].InnerText == "true";
            trialInfo.isScored = selectedTrial["isScored"].InnerText == "true";

            return trialInfo;
            
        }
        // Returns the info for a block
        public BlockInfo getBlockInfo(int blockNum)
        {
            BlockInfo blockInfo = new BlockInfo();

            XmlElement blockElement = (XmlElement)blocksRead[blockNum];
            blockInfo.blockName = blockElement["blockName"].InnerText;

            foreach (PropertyInfo propertyinfo in typeof(BlockInfo).GetProperties())
            {
                if (propertyinfo != null)
                {
                    var valueOfField = propertyinfo.GetValue(blockInfo);
                    var fieldname = propertyinfo.Name;


                    if (blockElement.SelectNodes(fieldname).Count > 0)
                    {
                        propertyinfo.SetValue(blockInfo, blockElement[fieldname].InnerText);
                        Console.WriteLine(fieldname + "  with value  " + valueOfField + "  loaded.");
                    }
                    else
                    {
                        addMissingNode(blockElement, fieldname, "0");
                        // errorMessage("Unable to read " + fieldname + " from file", "File repaired and setting to default");
                        propertyinfo.SetValue(blockInfo, "0");
                        // blockInfo[blockindex].hcWindow = "0";
                    }
                }
            }



            return blockInfo;
        }

    }
}