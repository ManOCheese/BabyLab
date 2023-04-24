using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Data;

namespace LincolnTest
{
    public class BlockInfo
    {
        public string type { get; set; }
        public string title { get; set; }
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
        public string title { get; set; }
        public string Code { get; set; }
        public string audioStimulus { get; set; }
        public string audioStimulusSide { get; set; }
        public string stimulusList { get; set; }
        public string stimulusListRight { get; set; }
        public string stimulusPosList { get; set; }
        public string stimulusRPosList { get; set; }
    }


    
    class CreateXML
    {
        XmlDocument doc = new XmlDocument();

        string currFileName;
        List<string> blockList;


        // Create an basic BEX File
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
            XmlNodeList nodeList = root.SelectNodes("descendant::Block[title='" + blockInfo.title + "']");

            while (nodeList.Count >= 1)
            {
                blockInfo.title = blockInfo.title + "_1";
                nodeList = root.SelectNodes("descendant::Block[title='" + blockInfo.title + "']");
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

        public bool updateBlock(XmlNode block, BlockInfo blockInfo)
        {

            XmlNode root = doc.DocumentElement;
            XmlElement blockElement = (XmlElement)block;

            Console.WriteLine("Saving: " + blockElement["title"].InnerText + " with block: " + blockInfo.title);

            if (blockElement["title"].InnerText != blockInfo.title)
            {
                // If we updated the block name, update the trials
                XmlNodeList trialList = root.SelectNodes("descendant::Trial[Block='" + blockElement["title"].InnerText + "']");
                for (int i = 0; i < trialList.Count; i++)
                {
                    XmlElement trialElement = (XmlElement)trialList[i];
                    XmlNodeList titleList = trialElement.SelectNodes("Block");
                    for (int x = 0; x < titleList.Count; x++)
                    {
                        titleList[x].InnerText = blockInfo.title;
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
                        MessageBox.Show("Some text", "Some title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    var fieldname = propertyinfo.Name;

                    blockElement[fieldname].InnerText = valueOfField.ToString();

                }
            }

            doc.Save(Properties.Settings.Default.ExpPath + @"\" + currFileName);

            return true;
        }

        public List<string> getBlockList()
        {

            return blockList;
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

        public bool updateTrial(XmlNode trial, TrialInfo trialInfo)
        {
            XmlElement trialElement = (XmlElement)trial;

            Console.WriteLine("Saving: " + trialElement["Title"].InnerText + " with trial: " + trialInfo.title + " with Stims: " + trialInfo.stimulusList.ToString()) ;
            bool noNodes = false;

            trialElement["Title"].InnerText = trialInfo.title;
            
            if (trialInfo.stimulusList != "")
            {
                string[] stims = trialInfo.stimulusList.ToString().Split(',');
                string[] stimsR = trialInfo.stimulusListRight.ToString().Split(',');
                string[] audioStims = trialInfo.audioStimulus.ToString().Split(',');
                string[] audioStimsCB = trialInfo.audioStimulusSide.ToString().Split(',');
                string[] positions = trialInfo.stimulusPosList.Split(':');
                string[] positionsR = trialInfo.stimulusRPosList.Split(':');

                int index = 0;

                try {
                    trial.SelectNodes("VisualStimuli");
                }
                catch
                {
                    noNodes = true;                        
                }

                if (!noNodes)
                {
                    XmlNodeList nodes = trial.SelectNodes("VisualStimuli");
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
                    stimNode.SetAttribute("Pos", positions[index]);
                    stimNode.SetAttribute("RPos", positionsR[index]);
                    stimNode.SetAttribute("RightImage", stimsR[index]);
                    stimNode.SetAttribute("audioStimulus", audioStims[index]);
                    stimNode.SetAttribute("audioStimulusCB", audioStimsCB[index]);
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
            XmlNodeList nodeList = root.SelectNodes("descendant::Trial[Block='" + blockInfo.title + "']");

            


            XmlElement element1 = doc.CreateElement(string.Empty, "Trial", string.Empty);

            XmlElement element2 = doc.CreateElement(string.Empty, "Title", string.Empty);
            XmlText text1 = doc.CreateTextNode(trialName);
            element2.AppendChild(text1);
            element1.AppendChild(element2);

            XmlElement element3 = doc.CreateElement(string.Empty, "Block", string.Empty);
            XmlText text2 = doc.CreateTextNode(blockInfo.title);
            element3.AppendChild(text2);
            element1.AppendChild(element3);

            XmlElement element7 = doc.CreateElement(string.Empty, "TrialsEnd", string.Empty);
            XmlText text6 = doc.CreateTextNode("max");
            element7.AppendChild(text6);
            element1.AppendChild(element7);

            doc.DocumentElement.AppendChild(element1);
            doc.Save(Properties.Settings.Default.ExpPath + @"\" + currFileName);
            return true;
        }


        public bool addDefaultBlock(string title, string type)
        {
            BlockInfo blockInfo = new BlockInfo();
            blockInfo.title = title;
            blockInfo.type = type;
            blockInfo.comment = "Default block";
            blockInfo.vOnset = "0";
            blockInfo.aOnset = "0";
            blockInfo.maxTrialDuration = "400";
            blockInfo.bgColour = "-16777216";
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
    }
}