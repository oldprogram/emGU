using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kalman_Filter
{
    public partial class Form1 : Form
    {
        #region Variables
        float px, py, cx, cy, ix, iy;//预测+修正+真实
        float ax, ay;
        #endregion

        #region Kalman Filter and Poins Lists
        PointF[] oup = new PointF[2];
        private Kalman kal = null;
        private SyntheticData syntheticData;
        private List<PointF> mousePoints;
        private List<PointF> kalmanPoints;
        #endregion

        #region Timers
        Timer MousePositionTaker = new Timer();
        Timer KalmanOutputDisplay = new Timer();
        #endregion

        public Form1()
        {
            InitializeComponent();
            KalmanFilter(); //initialize kalman filter
        }

        //Record mouse position when over the specific tracking area
        private void MouseTrackingArea_MouseMove(object sender, MouseEventArgs e)
        {
            ax = e.X;// store mouse locations over picturebox in avriables
            ay = e.Y;
            MouseLive_LBL.Text = "Mose Position Live- X:" + ax.ToString() + " Y:" + ay.ToString();
        }

        /// <summary>
        /// kalman滤波器run函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KalmanFilterRunner(object sender, EventArgs e)
        {
            //Graphics G = Graphics.FromImage(pictureBox1.Image);
            //Image<Bgr, Byte> gridx = grid; //Not needed
            PointF inp = new PointF(ix, iy);//鼠标跟踪获得的实际位置

            oup = new PointF[2];

            oup = filterPoints(inp);

            PointF[] pts = oup;

            MouseCorrected_LBL.Text = "Mouse Position Corrected- X:" + cx.ToString() + " Y:" + cy.ToString();
            MousePredicted_LBL.Text = "Mouse Position Predicted- X:" + px.ToString() + " Y:" + py.ToString();


            Graphics G = MouseTrackingArea.CreateGraphics();
            G.FillEllipse(Brushes.Green, cx, cy, 5, 5);//Corrected
            G.FillEllipse(Brushes.Red, px, py, 5, 5);//Predicted
            G.FillEllipse(Brushes.Blue, ix, iy, 5, 5);//真正位置

            // Action<PointF, Bgr> drawCross =
            // delegate(PointF point, Bgr color)
            // {
            //     gridx.Draw(new Cross2DF(point, 15, 15), color, 1);
            //};

            //drawCross(inp, new Bgr(Color.Black)); //draw current state in White
            // drawCross(oup[1], new Bgr(Color.Red)); //draw the measurement in Red
            // drawCross(oup[0], new Bgr(Color.Blue)); //draw the prediction (the next state) in green
            //gridx.Draw(new LineSegment2DF(inp, oup[0]), new Bgr(Color.Magenta), 1); //Draw a line between the current position and prediction of next position

            //pictureBox1.Image = gridx.ToBitmap();


        }

        /// <summary>
        /// 鼠标跟踪位置定时器触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private double t=0.1;
        private void MousePositionRecord(object sender, EventArgs e)
        {
            Random rand = new Random();
            //ix = (int)ax;//跟踪鼠标
            //iy = (int)ay;
            ix = (float)(100.0 * Math.Sin(t) + 200 + 40*rand.NextDouble());
            iy = (float)(100.0 * Math.Cos(t) + 200 - 40 * rand.NextDouble());
            t += 0.1;
            //ix = (float)(600*rand.NextDouble());
            //iy = (float)(400*rand.NextDouble());
            MouseTimed_LBL.Text = "Mouse Position Timed- X:" + ix.ToString() + " Y:" + iy.ToString();
        }

        public PointF[] filterPoints(PointF pt)
        {                                                                  
            syntheticData.state[0, 0] = pt.X;//将鼠标位置赋值给状态向量=X(n-1)
            syntheticData.state[1, 0] = pt.Y;
            Matrix<float> prediction = kal.Predict();//用卡尔曼滤波器进行预测
            PointF predictPoint = new PointF(prediction[0, 0], prediction[1, 0]);//取预测的点
            PointF measurePoint = new PointF(syntheticData.GetMeasurement()[0, 0],
                syntheticData.GetMeasurement()[1, 0]);//取观测点
            Matrix<float> estimated = kal.Correct(syntheticData.GetMeasurement());//用测量值进行修正
            PointF estimatedPoint = new PointF(estimated[0, 0], estimated[1, 0]);//取出估计点
            syntheticData.GoToNextState();
            PointF[] results = new PointF[2];
            results[0] = predictPoint;
            results[1] = estimatedPoint;

            px = predictPoint.X;
            py = predictPoint.Y;
            cx = estimatedPoint.X;
            cy = estimatedPoint.Y;
            return results;
        }

        /// <summary>
        /// 对kalman滤波器进行赋值初始化
        /// </summary>
        public void KalmanFilter()
        {
            mousePoints = new List<PointF>();//鼠标点
            kalmanPoints = new List<PointF>();//kalman滤波点
            kal = new Kalman(4, 2, 0);//状态变量，观测变量 
            syntheticData = new SyntheticData();//实例化数据
            Matrix<float> state = new Matrix<float>(new float[]
                {
                    0.0f, 0.0f, 0.0f, 0.0f
                });
            kal.CorrectedState = state;//当前状态
            kal.TransitionMatrix = syntheticData.transitionMatrix;
            kal.MeasurementNoiseCovariance = syntheticData.measurementNoise;
            kal.ProcessNoiseCovariance = syntheticData.processNoise;
            kal.ErrorCovariancePost = syntheticData.errorCovariancePost;
            kal.MeasurementMatrix = syntheticData.measurementMatrix;
        }

        //Initialse Kalman Filter and Timers
        private void Start_BTN_Click(object sender, EventArgs e)
        {
            if (Start_BTN.Text == "Start")
            {
                MouseTrackingArea.Refresh();//刷新mouse跟踪区域，进行重绘
                InitialiseTimers(100);//初始化定时器
                Start_BTN.Text = "Stop";
            }
            else
            {
                StopTimers();
                Start_BTN.Text = "Start";
            }
        }
        private void InitialiseTimers(int Timer_Interval = 1000)
        {
            MousePositionTaker.Interval = Timer_Interval;//鼠标位置跟踪定时器周期设置
            MousePositionTaker.Tick += new EventHandler(MousePositionRecord);//触发事件
            MousePositionTaker.Start();//启东事件
            KalmanOutputDisplay.Interval = Timer_Interval;//kalman
            KalmanOutputDisplay.Tick += new EventHandler(KalmanFilterRunner);
            KalmanOutputDisplay.Start();
        }
        private void StopTimers()
        {
            MousePositionTaker.Tick -= new EventHandler(MousePositionRecord);
            MousePositionTaker.Stop();
            KalmanOutputDisplay.Tick -= new EventHandler(KalmanFilterRunner);
            KalmanOutputDisplay.Stop();
        }

    }
}
