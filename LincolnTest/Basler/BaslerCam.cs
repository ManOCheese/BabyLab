using System;
using Basler.Pylon;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using OpenCvSharp;
using static System.Resources.ResXFileRef;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;

namespace LincolnTest
{
    /// <summary>
    /// Represents a Basler camera.
    /// </summary>
    internal class BaslerCam
    {
        private Camera camera;
        private PixelDataConverter converter = new PixelDataConverter();
        OpenCvSharp.VideoWriter videoWriter = new OpenCvSharp.VideoWriter();
        private BackgroundWorker camWorker;

        public IGrabResult grabResult;

        // Keep track of the current frame
        private float currFrame = 0;

        // Know if the camera is grabbing
        public bool grabbing;

        // Know if the camera is supposed to be writing the images to a file
        public bool writing = false;

        // Camera parameters

        public string camip;
        public string cam_name;
        public string camPath = Properties.Settings.Default.ExpPath + "\\CamOutput" + "\\";

        public int valueGain;
        public int valueExpTime;

        public bool found = false;

        // Bitmap to display the image, camera images need to be converted to bitmap
        public Bitmap bitmap;

        int count = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaslerCam"/> class.
        /// </summary>
        /// <param name="ip">The IP address of the camera.</param>
        public BaslerCam(string ip)
        {
            camip = ip;

            if (CameraFinder.Enumerate().Count == 0)
            {
                return;
            }

            foreach (ICameraInfo INFO in CameraFinder.Enumerate())
            {
                if (INFO.GetValueOrDefault("IpAddress", "0") == ip)
                {
                    camera = new Camera(INFO);
                    found = true;
                    break;
                }
            }

            grabbing = false;
        }


        // Use a new thread for each camera

        /// <summary>
        /// Starts continuous shot.
        /// </summary>
        public void conShot()
        {
            camWorker = new BackgroundWorker();
            camWorker.WorkerReportsProgress = true;
            camWorker.DoWork += new DoWorkEventHandler(th_grab);
            camWorker.ProgressChanged += new ProgressChangedEventHandler(updateFrame);

            if (!grabbing)
            {
                grabbing = true;

                try
                {
                    //Thread thread = new Thread(() => th_grab(1280, 1024, 0));
                    //thread.Start();
                    camWorker.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                camWorker.CancelAsync();
            }
        }

        public Bitmap aquireSingleFrame()
        {
            camera.Open();
            camera.Parameters[PLCamera.AcquisitionFrameRateEnable].SetValue(true);
            camera.Parameters[PLCamera.CenterX].SetValue(true);
            camera.Parameters[PLCamera.CenterY].SetValue(true);
            camera.Parameters[PLCamera.ExposureTimeAbs].SetValue(16000);

            camera.StreamGrabber.Start();

            grabResult = camera.StreamGrabber.RetrieveResult(5000, TimeoutHandling.ThrowException);

            using (grabResult)
            {
                if (grabResult.GrabSucceeded)
                {
                    // convert image from basler IImage to OpenCV Mat
                    Mat img = convertIImage2Mat(grabResult);
                    // convert image from BayerBG to RGB
                    Cv2.CvtColor(img, img, ColorConversionCodes.BayerBG2GRAY);

                    bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img);
                    img.Dispose();
                }
            }

            return bitmap;
        }

        private void th_grab(object sender, DoWorkEventArgs e)
        // private void th_grab(int height = 0, int width = 0, int snap_wait = 500)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            try
            {
                // Set the acquisition mode to free running continuous acquisition when the camera is opened.
                camera.CameraOpened += Configuration.AcquireContinuous;

                // Open the connection to the camera device and set parameters
                camera.Open();

            }
            catch (Exception exception)
            {
                camera.Close();
                // TODO: Custom error message
                Debug.WriteLine("Exception: {0}" + exception.Message);
                MessageBox.Show("Exception: {0}" + exception.Message);
            }

            camera.Parameters[PLCamera.GainRaw].SetValue(1);

                camera.Parameters[PLCamera.AcquisitionFrameRateEnable].SetValue(true);
                camera.Parameters[PLCamera.CenterX].SetValue(true);
                camera.Parameters[PLCamera.CenterY].SetValue(true);
                camera.Parameters[PLCamera.ExposureTimeAbs].SetValue(16000);
                camera.Parameters[PLCamera.AcquisitionFrameRateAbs].SetValue(25);

                camera.StreamGrabber.Start();

                // Make sure the video is the correct size
                var expected = new OpenCvSharp.Size(1280, 1024);
                string filename = camPath + cam_name + ".mkv";
                videoWriter.Open(filename, FourCC.H264, camera.Parameters[PLCamera.ResultingFrameRateAbs].GetValue(), expected, false);

                videoWriter.Set(VideoWriterProperties.Quality, 95);

                // Grab images from the camera
                while (grabbing)
                { 
                    try
                    {
                        grabResult = camera.StreamGrabber.RetrieveResult(200, TimeoutHandling.ThrowException);
                    }
                    catch(Exception exception)
                    {
                        Debug.WriteLine("Grab exception: {0}" + exception.Message);
                        grabResult = null;
                        return;
                    }

                    using (grabResult)
                    {
                        if (grabResult.GrabSucceeded)
                        {
                            
                            if (grabResult.PixelData != null)
                            {
                                converter.OutputPixelFormat = PixelType.BGR8packed;
                                byte[] buffer = grabResult.PixelData as byte[];
                                Mat img = new Mat(grabResult.Height, grabResult.Width, MatType.CV_8U, buffer);

                                bw.ReportProgress(0, img);
                            }
                            else 
                            {  
                                Debug.WriteLine("No pixel data");
                            }
                        }
                    }
                }

                // Finish the grab stream: write the video file and close the camera
                videoWriter.Release();
                camera.Close();
                Debug.WriteLine("Camera Shut");

                if (currFrame < 10)
                {
                    Debug.WriteLine("Video < 10 frames");
                    File.Delete(filename);
                }
        }

        private void updateFrame(object sender, ProgressChangedEventArgs e)
        {
            // IGrabResult grabResult = (IGrabResult)e.UserState;
            // convert image from basler IImage to OpenCV Mat
            //
            Mat img = (Mat)e.UserState;           

            // convert image from BayerBG to RGB
            Cv2.CvtColor(img, img, ColorConversionCodes.BayerBG2GRAY);

            // Only write the image if the camera is supposed to be writing
            if (writing)
            {
                currFrame++;
                videoWriter.Write(img);
            }
            bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img);
            img.Dispose();
        }
        /// <summary>
        /// Converts an IImage to a Mat.
        /// </summary>
        /// <param name="grabResult"></param>
        /// <returns></returns>
        private Mat convertIImage2Mat(IGrabResult grabResult)
        {
            converter.OutputPixelFormat = PixelType.BGR8packed;
            byte[] buffer = grabResult.PixelData as byte[];
            return new Mat(grabResult.Height, grabResult.Width, MatType.CV_8U, buffer);
        }

        /// <summary>
        /// Stops continuous shot.
        /// </summary>
        public void Stop()
        {
            grabbing = false;
        }

        /// <summary>
        /// Gets the current key frame.
        /// </summary>
        /// <returns>The current key frame.</returns>
        public float getKeyFrame()
        {
            return currFrame;
        }

        /// <summary>
        /// Gets the frame rate of the camera.
        /// </summary>
        /// <returns>The frame rate of the camera.</returns>
        public string GetFrameRate()
        {
            string frameRate = "Waiting...";

            if (camera.IsOpen)
            {
                try
                {
                    frameRate = camera.Parameters[PLCamera.ResultingFrameRateAbs].GetValue().ToString();
                }
                catch (Exception ex)
                {
                    frameRate = "No reply from camera";
                }
            }

            return frameRate;
        }

    }
}