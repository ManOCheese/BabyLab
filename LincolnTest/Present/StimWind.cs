
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
using OpenCvSharp;
using MS.WindowsAPICodePack.Internal;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace LincolnTest
{
    public static class IListExtensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

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

        private SoundPlayer audioPlayer;

        Screen screen;

        List<TimeStampInfo> stampInfo = new List<TimeStampInfo>();
        TimeStampInfo info = new TimeStampInfo();
        Stopwatch stopwatch = new Stopwatch();

        // Local variables used to store stimuli, audio and attention image 
        string[] listLImage;
        string[] listRImage;
        string[] listAudioStims;
        string[] listAudioStimsSide;
        string audioStimFile = "";
        string attnImage = "";
        string attnAudio = "";
        bool trialRunning;
        bool trialStarted = false;
        public bool isShuffled = false;
        public bool isAutoPlay = true;

        string filename;

        int index = 0;
        List<int> indexShuffler = new List<int>();

        // Instantiate new MicroTimer and add event handler
        MicroLibrary.MicroTimer microTimer = new MicroLibrary.MicroTimer();

        public StimWind()
        {
            InitializeComponent();
            setupScreen();

            // this.MaximumSize = this.Size;
            microTimer.MicroTimerElapsed +=
                    new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);

            attentionPicBox.Visible = false;

            audioPlayer = new SoundPlayer();

        }

        private void setupScreen()
        {
            // Create stimuli window on 2nd screen and calculate sizes and positions for stimuli
            // Resizes images to scale with screen resolution
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;

            foreach (Screen scrn in Screen.AllScreens)
            {
                if (scrn.DeviceName == Properties.Settings.Default.stimulusDisplay)
                {
                    screen = scrn;
                }
                else
                {
                    screen = Screen.AllScreens[0];
                }
            }
            Rectangle bounds = screen.Bounds;

            this.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);

            int imageHeight = bounds.Height / 5;
            int imageWidth = (int)((double)imageHeight * 1.6);

            rightStimPic.Size = new System.Drawing.Size(imageWidth, imageHeight);
            rightStimPic.Location = new System.Drawing.Point(((bounds.Width / 2) / 2) - (rightStimPic.Size.Width / 2), (bounds.Height / 2) - (imageHeight / 2));
            leftStimPic.Size = new System.Drawing.Size(imageWidth, imageHeight);
            leftStimPic.Location = new System.Drawing.Point((int)((bounds.Width / 2) * 1.5) - (leftStimPic.Size.Width / 2), (bounds.Height / 2) - (imageHeight / 2));
            attentionPicBox.Location = new System.Drawing.Point(bounds.Width / 2 - (attentionPicBox.Size.Width / 2), bounds.Height / 2 - (attentionPicBox.Size.Height / 2));
        }

        private Color stringToColour(string colour)
        {
            Color windowColour = Color.FromArgb(Int32.Parse(colour));

            return windowColour;
        }

        // Checks that stimuli exist and sets up the experiment
        public void SetupExperiment()
        {
            index = 0;

            if (leftStimPic.ImageLocation != null) leftStimPic.Visible = false;
            if (rightStimPic.ImageLocation != null) rightStimPic.Visible = false;

            attnImage = blockInfo.attnImage;
            attnAudio = blockInfo.attnAudio;

            attentionPicBox.ImageLocation = attnImage;

            this.BackColor = stringToColour(blockInfo.bgColour);

            if (File.Exists(attnAudio))
            {
                Console.WriteLine("Audio file found");
            }
            else
            {
                Console.WriteLine("Attention audio file: " + blockInfo.attnAudio + " not found");
            }
        }

        public bool StartExperiment()
        {
            label1.Text = "";
            attentionPicBox.ImageLocation = blockInfo.attnImage;

            if (blockInfo.blockName == null)
            {
                Console.WriteLine("Block failed");
                return false;
            }
            // Parse images from strings to file list
            listLImage = trialInfo.stimulusList.ToString().Split(',');
            Console.WriteLine("Images loaded: " + trialInfo.stimulusList.ToString());
            listRImage = trialInfo.stimulusListRight.ToString().Split(',');
            listAudioStims = trialInfo.audioStimulus.ToString().Split(',');
            listAudioStimsSide = trialInfo.audioStimulusSide.ToString().Split(',');
            Console.WriteLine(trialInfo.audioStimulusSide.ToString());

            int i = 0;
            foreach (var item in listLImage) {
                indexShuffler.Add(i);
                i++;
            }

            if(isShuffled) indexShuffler.Shuffle();

            // Create timers for simuli
            vonsetTimer = new System.Timers.Timer(int.Parse(blockInfo.vOnset) + 1); // Delay before showing stimulus
            aonsetTimer = new System.Timers.Timer(int.Parse(blockInfo.aOnset) + 1); // Delay before playing audio
            maxTrialDurTimer = new System.Timers.Timer(int.Parse(blockInfo.maxTrialDuration)); // Delay before ending trial
            autoPlayTimer = new System.Timers.Timer(1500);

            // Hook up the Elapsed events for the timers
            vonsetTimer.Elapsed += showStims;
            vonsetTimer.AutoReset = false;
            vonsetTimer.Stop();

            aonsetTimer.Elapsed += playAudio;
            aonsetTimer.AutoReset = false;
            aonsetTimer.Stop();

            maxTrialDurTimer.Elapsed += endTrial;
            maxTrialDurTimer.AutoReset = false;
            maxTrialDurTimer.Stop();

            autoPlayTimer.Elapsed += autoNextTrial;
            autoPlayTimer.AutoReset = false;
            autoPlayTimer.Stop();

            stopwatch.Start();
            startTrial();

            return true;
        }

        private void startTrial()
        {
            // Get shuffled index
            int tempIndex = indexShuffler[index];

            // Set stimuli to current trial entries
            setStims(listLImage[tempIndex], listRImage[tempIndex], listAudioStims[tempIndex]);
            trialRunning = true;

            long timeMS = stopwatch.ElapsedMilliseconds;
            
            // Record timestamp           

            stampInfo.Add(new TimeStampInfo { timeStamp = parentWindow.getCameraFrames().ToString(), eventCode = "Trial " + (index + 1), frame = timeMS });
            
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

            if (index < listLImage.Length - 1)
            {
                index++;
                startTrial();
            }
            else
            {
                endSession();
            }
        }

        private async void endSession()
        {
            string txt = "";
            
            
            foreach (var stamp in stampInfo)
            {
                txt += stamp.eventCode + "-" + stamp.timeStamp + "-"+ stamp.frame + "\r\n";
            }

            //Console.WriteLine("File: " + txt); 

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

            filename = trialInfo.partCode + ".out";

            IniFile MyIni = new IniFile(Properties.Settings.Default.ExpPath + "/project.ini");
            MyIni.Write("ScoreFile", filename);

            System.Threading.Tasks.Task writefile = myUtils.SaveTimingsAsync(txt, filename);
            await writefile;

            DialogResult result;

            result = MessageBox.Show("Trials Complete", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                trialStarted = false;
                blockInfo = new BlockInfo();
                trialInfo = new TrialInfo();
                parentWindow.stimWindowClosed();
            }


        }

        private void setStims(string imageL, string imageR, string audio)
        {
            if (imageL != "")
            {
                leftStimPic.ImageLocation = Properties.Settings.Default.stimPathVisual + "/" + imageL;
            }
            else
            {
                leftStimPic.ImageLocation = null;
            }

            if (imageR != "")
            {
                rightStimPic.ImageLocation = Properties.Settings.Default.stimPathVisual + "/" + imageR;
            }
            else
            {
                rightStimPic.ImageLocation = null;
            }
            audioStimFile = Properties.Settings.Default.stimPathAudio + "/" + audio;
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

                // Record timestamp
                stampInfo.Add(new TimeStampInfo { timeStamp = parentWindow.getCameraFrames().ToString(), eventCode = "showStims", frame = stopwatch.ElapsedMilliseconds });

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
                stampInfo.Add(new TimeStampInfo { timeStamp = parentWindow.getCameraFrames().ToString(), eventCode = "hideStims", frame = stopwatch.ElapsedMilliseconds });

                trialRunning = false;
                maxTrialDurTimer.Stop();

                if (index >= listLImage.Length - 1)
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

            if (File.Exists(audioStimFile))// Checking to see if the file exist
            {
                audioPlayer.SoundLocation = audioStimFile;

                var tries = 3;
                while (true)
                {
                    try
                    {
                        audioPlayer.Play();
                        stampInfo.Add(new TimeStampInfo { timeStamp = parentWindow.getCameraFrames().ToString(), eventCode = "AudioStimPlayed", frame = stopwatch.ElapsedMilliseconds });
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
        private void showAttention()
        {
            if (attentionPicBox.Visible == true)
            {
                attentionPicBox.Visible = false;
                stampInfo.Add(new TimeStampInfo { timeStamp = parentWindow.getCameraFrames().ToString(), eventCode = "V Attn Off", frame = stopwatch.ElapsedMilliseconds });
            }
            else
            {
                if (attentionPicBox.Visible == false)
                {
                    attentionPicBox.Visible = true;
                    stampInfo.Add(new TimeStampInfo { timeStamp = parentWindow.getCameraFrames().ToString(), eventCode = "V Attn On", frame = stopwatch.ElapsedMilliseconds });
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
                case "TrialStart":
                    if (trialStarted) break;
                    trialStarted = true;
                    StartExperiment();
                    break;
                case "ShowAttendPic":
                    showAttention();
                    break;
                case "AttentionImage":
                    showAttention();
                    break;
                case "AttentionSound":
                    showAttention();
                    break;
                case "AutoPlay":
                    autoPlay();
                    break;
                case "NextTrial":
                    nextTrialKey();
                    break;
                case "EndTrial":
                    endSession();
                    break;
                case "none":
                    // Do nowt
                    break;
            }
        }
    }
    public class TimeStampInfo
    {
        public string timeStamp { get; set; }
        public string eventCode { get; set; }
        public long frame { get; set; }
    }


    

}
