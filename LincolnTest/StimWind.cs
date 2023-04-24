

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Timers;
using System.Threading;
using System.Windows.Forms;

namespace LincolnTest
{
    public partial class StimWind : Form
    {
        babyUtils myUtils = new babyUtils();

        private static System.Timers.Timer vonsetTimer;
        private static System.Timers.Timer maxTrialDurTimer;
        private static System.Timers.Timer aonsetTimer;
        private static System.Timers.Timer autoPlayTimer;

        public BlockInfo blockInfo = new BlockInfo();
        public TrialInfo trialInfo = new TrialInfo();

        private delegate void SafeCallDelegate(Object source, ElapsedEventArgs e);

        public Present parentWindow;

        AxWMPLib.AxWindowsMediaPlayer wplayer = new AxWMPLib.AxWindowsMediaPlayer();

        List<timeStampInfo> stampInfo = new List<timeStampInfo>();
        timeStampInfo info = new timeStampInfo();
        Stopwatch stopwatch = new Stopwatch();

        string[] listLImage;
        string[] listRImage;
        string[] listAudioStims;
        string[] listAudioStimsSide;
        string audioStimFile = "";
        string attnImage = "";
        string attnAudio = "";
        bool trialRunning;
        bool trialStarted = false;
        bool isAutoPlay = true;

        string filename;

        int index = 0;

        // Instantiate new MicroTimer and add event handler
        MicroLibrary.MicroTimer microTimer = new MicroLibrary.MicroTimer();

        public StimWind()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            microTimer.MicroTimerElapsed +=
                    new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);

            attentionPicBox.Visible = false;
        }

        public void SetupExperiment()
        {
            index = 0;

            if (leftStimPic.ImageLocation != null) leftStimPic.Visible = false;
            if (rightStimPic.ImageLocation != null) rightStimPic.Visible = false;


            attnImage = blockInfo.attnImage;
            attnAudio = blockInfo.attnAudio;

            attentionPicBox.ImageLocation = attnImage;

            if (File.Exists(attnAudio))
            {
                Console.WriteLine("File found");
            }
            else
            {
                Console.WriteLine("Attention audio file: " + blockInfo.attnAudio + " not found");
            }
        }

        public bool StartExperiment()
        {
            // Only do this once
            // if (!trialStarted) return false;

            label1.Text = "Boop";

            wplayer.CreateControl();

            attentionPicBox.ImageLocation = blockInfo.attnImage;

            if (blockInfo.title == null)
            {
                Console.WriteLine("Block failed");
            }

            listLImage = trialInfo.stimulusList.ToString().Split(',');
            Console.WriteLine("Images loaded: " + trialInfo.stimulusList.ToString());
            listRImage = trialInfo.stimulusListRight.ToString().Split(',');
            listAudioStims = trialInfo.audioStimulus.ToString().Split(',');
            listAudioStimsSide = trialInfo.audioStimulusSide.ToString().Split(',');
            Console.WriteLine(trialInfo.audioStimulusSide.ToString());

            // Create a timer with a millisecond interval
            vonsetTimer = new System.Timers.Timer(int.Parse(blockInfo.vOnset + 1)); // Delay before showing stimulus
            aonsetTimer = new System.Timers.Timer(int.Parse(blockInfo.aOnset + 1)); // Delay before playing audio
            maxTrialDurTimer = new System.Timers.Timer(int.Parse(blockInfo.maxTrialDuration)); // Delay before ending trial
            autoPlayTimer = new System.Timers.Timer(1500);

            // Hook up the Elapsed event for the timer
            vonsetTimer.Elapsed += showStims;
            vonsetTimer.AutoReset = false;
            vonsetTimer.Stop();
            // vonsetTimer.Enabled = true;

            aonsetTimer.Elapsed += playAudio;
            aonsetTimer.AutoReset = false;
            aonsetTimer.Stop();
            // aonsetTimer.Enabled = true;

            maxTrialDurTimer.Elapsed += endTrial;
            maxTrialDurTimer.AutoReset = false;
            maxTrialDurTimer.Stop();
            // maxTrialDurTimer.Enabled = true;

            autoPlayTimer.Elapsed += autoNextTrial;
            autoPlayTimer.AutoReset = false;
            autoPlayTimer.Stop();
            

            trialStarted = true;
            stopwatch.Start();
            startTrial();

            return true;
        }

        private void startTrial()
        {
            
            setStims(listLImage[index], listRImage[index], listAudioStims[index]);
            Console.WriteLine("Setting stims");
            Console.WriteLine("Right Image: " + listRImage[index]);
            trialRunning = true;

            // Record timestamp
            if (index == 0)
            {
                stampInfo.Add(new timeStampInfo { timeStamp = stopwatch.ElapsedMilliseconds.ToString(), eventCode = "Start" });
            }
            else
            {
                stampInfo.Add(new timeStampInfo { timeStamp = stopwatch.ElapsedMilliseconds.ToString(), eventCode = "Trial: " + index });
            }            

            Console.WriteLine("Starting trial");
            // Console.WriteLine("Vonset: " + int.Parse(blockInfo.vOnset) + "   Aonset: " + int.Parse(blockInfo.aOnset) + "    max: " + int.Parse(blockInfo.maxTrialDuration));


            aonsetTimer.Start();
            vonsetTimer.Start();
            maxTrialDurTimer.Start();
        }

        private void autoNextTrial(Object source, ElapsedEventArgs e)
        {
            nextTrialKey();
        }

        private void nextTrialKey()
        {
            // Only move if we've pressed start and we're not currently showing a trial
            if (trialRunning || !trialStarted) return;

            if(index < listLImage.Length - 1)
            {
                index++;
                startTrial();
            }
            else
            {
                endSession();
            }
        }

        private void endSession()
        {
            string txt = "";

            foreach (var stamp in stampInfo){
                txt += stamp.eventCode + "-" + stamp.timeStamp + "\r\n";
            }

            //Console.WriteLine("File: " + txt); 

            Console.WriteLine("Ending session");

            if (aonsetTimer != null)
            {
                aonsetTimer.Stop();
            }

            if (vonsetTimer != null)
            {
                vonsetTimer.Stop();
            }

            if (maxTrialDurTimer != null)
            {
                maxTrialDurTimer.Stop();
            }

            filename = trialInfo.title + ".out";

            IniFile MyIni = new IniFile(Properties.Settings.Default.ExpPath + "/project.ini");
            MyIni.Write("ScoreFile", filename);

            myUtils.ExampleAsync(txt, filename);

            DialogResult result; 

            result = MessageBox.Show("Trials Complete", "Finished", MessageBoxButtons.OK);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //Hide();
                parentWindow.stimWindowClosed();
            }
        }

        private void setStims(string imageL, string imageR, string audio)
        {
            if (imageL != "")
            {
                leftStimPic.ImageLocation = Properties.Settings.Default.stimPath + "/" + imageL;
                // Console.WriteLine("ImageL:  " + imageL);
            }
            else
            {
                leftStimPic.ImageLocation = null;
                // Console.WriteLine("Empty?  " + imageL);
            }

            if (imageR != "")
            {
                rightStimPic.ImageLocation = Properties.Settings.Default.stimPath + "/" + imageR;
                 // Console.WriteLine("ImageR:  " + imageR);
            }
            else
            {
                rightStimPic.ImageLocation = null;
                // Console.WriteLine("Empty?  " + imageR);
            }
            audioStimFile = Properties.Settings.Default.stimPath + "/" + audio;
        }

        private void showStims(Object source, ElapsedEventArgs e)
        {
            

            if (leftStimPic.InvokeRequired)
            {
                var d = new SafeCallDelegate(showStims);
                try
                {
                    leftStimPic.Invoke(d, new object[] { source, e });
                }
                catch
                {
                    Console.WriteLine("Failed show");
                }
            }
            else
            {
                if (leftStimPic.ImageLocation != null) leftStimPic.Visible = true;
                if (rightStimPic.ImageLocation != null) rightStimPic.Visible = true;

                Console.WriteLine("Showing Stims: " + index);

                // Record timestamp
                stampInfo.Add(new timeStampInfo { timeStamp = stopwatch.ElapsedMilliseconds.ToString(), eventCode = "showStims" });

                
                vonsetTimer.Stop();
            }
            
        }


        private void endTrial(Object source, ElapsedEventArgs e)
        {
            if (leftStimPic.InvokeRequired)
            {
                var d = new SafeCallDelegate(endTrial);
                try
                {
                    leftStimPic.Invoke(d, new object[] { source, e });
                }
                catch
                {
                    Console.WriteLine("Failed hide");
                }

            }
            else
            {
                leftStimPic.Visible = false;
                rightStimPic.Visible = false;
                stampInfo.Add(new timeStampInfo { timeStamp = stopwatch.ElapsedMilliseconds.ToString(), eventCode = "hideStims" });

                trialRunning = false;
                maxTrialDurTimer.Stop();

                if (index >= listLImage.Length)
                {
                    endSession();
                }
                else
                {
                    if (isAutoPlay)
                    {
                        // Thread.Sleep(2000);
                        Console.WriteLine("Autoplay triggered");
                        // nextTrialKey();
                        autoPlayTimer.Start();
                    }
                }
            }
        }

        private void aEvent(Object source, ElapsedEventArgs e)
        {

            maxTrialDurTimer.Stop();
            maxTrialDurTimer.Dispose();
        }

        private void OnTimedEvent(object sender,
                                  MicroLibrary.MicroTimerEventArgs timerEventArgs)
        {
            microTimer.Enabled = false;

            /* Console.WriteLine(string.Format(
                "Count = {0:#,0}  Timer = {1:#,0} µs, " +
                "LateBy = {2:#,0} µs, ExecutionTime = {3:#,0} µs",
                timerEventArgs.TimerCount, timerEventArgs.ElapsedMicroseconds,
                timerEventArgs.TimerLateBy, timerEventArgs.CallbackFunctionExecutionTime));
            */
        }

        private void playAudio(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Audio triggered");

            if (wplayer.InvokeRequired)
            {
                var d = new SafeCallDelegate(playAudio);
                try
                {
                    wplayer.Invoke(d, new object[] { source, e });
                }
                catch
                {
                    Console.WriteLine("Failed hide");
                }

            }
            else
            {
                if (File.Exists(audioStimFile))// Checking to see if the file exist
                {
                    wplayer.URL = audioStimFile;

                    var tries = 3;
                    while (true)
                    {
                        try
                        {
                            wplayer.Ctlcontrols.play();
                            stampInfo.Add(new timeStampInfo { timeStamp = stopwatch.ElapsedMilliseconds.ToString(), eventCode = "AudioStimPlayed" });
                            Console.WriteLine("Audio");
                            break; // success!
                        }
                        catch
                        {
                            if (--tries == 0)
                                throw;
                            Console.WriteLine("Failed");
                            Thread.Sleep(10);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Audio file not found");
                }
                aonsetTimer.Stop();
            }
        }
        private void showAttention()
        {
            if (attentionPicBox.Visible == true)
            {
                attentionPicBox.Visible = false;
                stampInfo.Add(new timeStampInfo { timeStamp = stopwatch.ElapsedMilliseconds.ToString(), eventCode = "V Attn Off" });
            }
            else
            {
                if (attentionPicBox.Visible == false)
                {
                    attentionPicBox.Visible = true;
                    stampInfo.Add(new timeStampInfo { timeStamp = stopwatch.ElapsedMilliseconds.ToString(), eventCode = "V Attn On" });
                }
            }
        }

        private void autoPlay()
        {
            isAutoPlay = true;
            StartExperiment();
        }


        private void StimWind_KeyDown(object sender, KeyEventArgs e)
        {
            string inputKey = myUtils.getPresInput(e);

            switch (inputKey)
            {
                case "Start":
                    StartExperiment();
                    break;
                case "ShowAttendPic":
                    showAttention();
                    break;
                case "ShowAttend":
                    showAttention();
                    break;
                case "AutoPlay":
                    autoPlay();
                    break;
                case "Next":
                    nextTrialKey();
                    break;
                case "End":
                    endSession();
                    break;
                case "none":
                    // Do nowt
                    break;
            }
        }
    }
    public class timeStampInfo
    {
        public string timeStamp { get; set; }
        public string eventCode { get; set; }
    }

}
