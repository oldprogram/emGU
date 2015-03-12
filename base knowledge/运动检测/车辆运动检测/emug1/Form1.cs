using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Emgu.CV;//PS:调用的Emgu dll  
using Emgu.CV.Structure;
using Emgu.CV.VideoSurveillance;

namespace emug1
{
    public partial class Form1 : Form
    {
        private Capture _capture2 = null;
        private MotionHistory _motionHistory;

        public Form1()
        {
            InitializeComponent();
        }

        Image<Bgr, Byte> image1 = null;
        Image<Gray, Byte> image2 = null;
        int count = 0;
        int rate = 10;
        private IBGFGDetector<Bgr> _forgroundDetector;

        private void ProcessFrame(object sender, EventArgs e)
        {
            count++;
            
            using (image1 = _capture2.QueryFrame())
            using (image2 = _capture2.QueryGrayFrame())
            using (MemStorage storage = new MemStorage()) //create storage for motion components
            {
                image1 = image1.Resize(0.5, 0);
                image2 = image2.Resize(0.5, 0);
                capturedImageBox.Image = image1;
                //update the motion history
                _motionHistory.Update(image2); 
                forgroundImageBox.Image = image2;
                
                //if (count > int.MaxValue - 2) count = 0;
                //if (count % rate != 0) return;
                #region get a copy of the motion mask and enhance its color
                double[] minValues, maxValues;
                Point[] minLoc, maxLoc;
                _motionHistory.Mask.MinMax(out minValues, out maxValues, out minLoc, out maxLoc);
                Image<Gray, Byte> motionMask = _motionHistory.Mask.Mul(255.0 / maxValues[0]);
                #endregion

                //create the motion image 
                Image<Bgr, Byte> motionImage = new Image<Bgr, byte>(motionMask.Size);
                //display the motion pixels in blue (first channel)
                motionImage[0] = motionMask;

                //Threshold to define a motion area, reduce the value to detect smaller motion
                double minArea = 1;

                storage.Clear(); //clear the storage
                Seq<MCvConnectedComp> motionComponents = _motionHistory.GetMotionComponents(storage);

                //iterate through each of the motion component
                foreach (MCvConnectedComp comp in motionComponents)
                {
                    //reject the components that have small area;
                    if (comp.area < minArea) continue;

                    // find the angle and motion pixel count of the specific area
                    double angle, motionPixelCount;
                    _motionHistory.MotionInfo(comp.rect, out angle, out motionPixelCount);

                    //reject the area that contains too few motion
                    if (motionPixelCount < comp.area * 0.05) continue;

                    //Draw each individual motion in red
                    DrawMotion(motionImage, comp.rect, angle, new Bgr(Color.Red));
                }

                // find and draw the overall motion angle
                double overallAngle, overallMotionPixelCount;
                _motionHistory.MotionInfo(motionMask.ROI, out overallAngle, out overallMotionPixelCount);
                DrawMotion(motionImage, motionMask.ROI, overallAngle, new Bgr(Color.Green));

                //Display the amount of motions found on the current image
                //UpdateText(String.Format("Total Motions found: {0}; Motion Pixel count: {1}", motionComponents.Total, overallMotionPixelCount));

                //Display the image of the motion
                motionImageBox.Image = motionImage;
            }
        }

        private static void DrawMotion(Image<Bgr, Byte> image, Rectangle motionRegion, double angle, Bgr color)
        {
            float circleRadius = (motionRegion.Width + motionRegion.Height) >> 2;
            Point center = new Point(motionRegion.X + motionRegion.Width >> 1, motionRegion.Y + motionRegion.Height >> 1);

            CircleF circle = new CircleF(
               center,
               circleRadius);

            int xDirection = (int)(Math.Cos(angle * (Math.PI / 180.0)) * circleRadius);
            int yDirection = (int)(Math.Sin(angle * (Math.PI / 180.0)) * circleRadius);
            Point pointOnCircle = new Point(
                center.X + xDirection,
                center.Y - yDirection);
            LineSegment2D line = new LineSegment2D(center, pointOnCircle);

            image.Draw(circle, color, 1);
            image.Draw(line, color, 2);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Idle -= new EventHandler(ProcessFrame);
        }

        private void 播放视频ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FilterIndex = 5;
            openFileDialog.Filter = "AVI文件|*.avi|RMVB文件|*.rmvb|WMV文件|*.wmv|MKV文件|*.mkv|所有文件|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Application.Idle += new EventHandler(ProcessFrame);  //播放的函数句柄
                _capture2 = new Capture(openFileDialog.FileName);
                _motionHistory = new MotionHistory(
                    1.0, //in second, the duration of motion history you wants to keep
                    0.05, //in second, maxDelta for cvCalcMotionGradient
                    0.5); //in second, minDelta for cvCalcMotionGradient
            }
        }
    }
}
