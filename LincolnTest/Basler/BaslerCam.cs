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

namespace LincolnTest
{
    internal class BaslerCam
    {
        private Camera camera;
        private PixelDataConverter converter = new PixelDataConverter();
        OpenCvSharp.VideoWriter videoWriter = new OpenCvSharp.VideoWriter();

        public IGrabResult grabResult;

        private float currFrame = 0;

        public bool grabbing;
        public bool writing = false;
        public int axis_x;
        public int axis_y;
        public int axis_scale;

        public string camip;
        public string cam_name;
        public string camPath = Properties.Settings.Default.ExpPath + "\\CamOutput" + "\\";

        public int valueGain;
        public int valueExpTime;

        public bool found = false;

        public Bitmap bitmap;

        int count = 0;

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

        public void conShot()
        {
            if (!grabbing)
            {
                grabbing = true;

                try
                {
                    Thread thread = new Thread(() => th_grab(1280, 1024, 0));
                    thread.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void th_grab(int height = 0, int width = 0, int snap_wait = 500)
        {
            try
            {
                // Set the acquisition mode to free running continuous acquisition when the camera is opened.
                camera.CameraOpened += Configuration.AcquireContinuous;

                // Open the connection to the camera device and set parameters
                camera.Open();
                camera.Parameters[PLCamera.AcquisitionFrameRateEnable].SetValue(true);
                camera.Parameters[PLCamera.CenterX].SetValue(true);
                camera.Parameters[PLCamera.CenterY].SetValue(true);
                camera.Parameters[PLCamera.ExposureTimeAbs].SetValue(22200);

                camera.StreamGrabber.Start();

                var expected = new OpenCvSharp.Size(1280, 1024);
                string filename = camPath + cam_name + ".mkv";
                videoWriter.Open(filename, FourCC.H264, camera.Parameters[PLCamera.ResultingFrameRateAbs].GetValue(), expected, false);

                videoWriter.Set(VideoWriterProperties.Quality, 95);
                Debug.WriteLine("Video: " + videoWriter.FileName);

                while (grabbing)
                {
                    try
                    {
                        grabResult = camera.StreamGrabber.RetrieveResult(250, TimeoutHandling.ThrowException);
                    }
                    catch
                    {
                        grabResult = null;
                    }

                    using (grabResult)
                    {
                        if (grabResult.GrabSucceeded)
                        {
                            // convert image from basler IImage to OpenCV Mat
                            Mat img = convertIImage2Mat(grabResult);
                            // convert image from BayerBG to RGB
                            Cv2.CvtColor(img, img, ColorConversionCodes.BayerBG2GRAY);

                            // If 
                            if (writing)
                            {
                                currFrame++;
                                videoWriter.Write(img);
                            }
                            bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img);
                            img.Dispose();
                        }
                    }
                }
                
                // Finish the grab stream: write the video file and close the camera
                videoWriter.Release();
                camera.Close();
                Debug.WriteLine("Camera Shut");

                if(currFrame < 10)
                {
                    Debug.WriteLine("Video < 10 frames");
                    File.Delete(filename);
                }
            }
            catch (Exception exception)
            {
                if (camera.IsOpen)
                    camera.Close();

                MessageBox.Show("Exception: {0}" + exception.Message);
            }
        }

        private Mat convertIImage2Mat(IGrabResult grabResult)
        {
            converter.OutputPixelFormat = PixelType.BGR8packed;
            byte[] buffer = grabResult.PixelData as byte[];
            return new Mat(grabResult.Height, grabResult.Width, MatType.CV_8U, buffer);
        }

        public void Stop()
        {
            grabbing = false;
        }

        

        public float getKeyFrame()
        {
            return currFrame;
        }

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
