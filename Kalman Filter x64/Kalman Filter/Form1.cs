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
        MyKalman myKalman;
        //输入的数据（也是实际观测值，这里我用一个随机函数生成）
        public float ix, iy;
        #region Timers
        Timer PositionTaker = new Timer();
        Timer KalmanOutputDisplay = new Timer();
        #endregion

        public Form1()
        {
            InitializeComponent();
            myKalman=new MyKalman(4,2,0); 
        }

        /// <summary>
        /// kalman滤波器run函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>            
        PointF[] oup = new PointF[2];
        private void KalmanFilterRunner(object sender, EventArgs e)
        {
            //Graphics G = Graphics.FromImage(pictureBox1.Image);
            //Image<Bgr, Byte> gridx = grid; //Not needed
            PointF inp = new PointF(ix, iy);//输入实际位置
            oup = myKalman.filterPoints(inp);

            Corrected_LBL.Text = "Position Corrected[Green]- X:" + oup[1].X.ToString() + " Y:" + oup[1].Y.ToString();
            Predicted_LBL.Text = "Position Predicted[Red]- X:" + oup[0].X.ToString() + " Y:" + oup[0].Y.ToString();


            Graphics G = MouseTrackingArea.CreateGraphics();
            G.FillEllipse(Brushes.Green, oup[1].X, oup[1].Y, 5, 5);//Corrected
            G.FillEllipse(Brushes.Red, oup[0].X, oup[0].Y, 5, 5);//Predicted
            G.FillEllipse(Brushes.Blue, ix, iy, 5, 5);//真正位置
        }

        /// <summary>
        /// 用来模拟传感器观测到的数值(ix,iy)坐标
        /// 实际应用中该数据是你想用kalman预测的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private double t=0.1;
        private void PositionRecord(object sender, EventArgs e)
        {
            Random rand = new Random();
            ix = (float)(100.0 * Math.Sin(t) + 200 + 40 * rand.NextDouble());
            iy = (float)(100.0 * Math.Cos(t) + 200 - 40 * rand.NextDouble());
            t += 0.1;
            Timed_LBL.Text = "Position Timed[Blue]- X:" + ix.ToString() + " Y:" + iy.ToString();
        }
        //Initialse Kalman Filter and Timers
        //the next three function are about timer
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
            PositionTaker.Interval = Timer_Interval;//位置跟踪定时器周期设置
            PositionTaker.Tick += new EventHandler(PositionRecord);//触发事件
            PositionTaker.Start();//启东事件
            KalmanOutputDisplay.Interval = Timer_Interval;//kalman
            KalmanOutputDisplay.Tick += new EventHandler(KalmanFilterRunner);
            KalmanOutputDisplay.Start();
        }
        private void StopTimers()
        {
            PositionTaker.Tick -= new EventHandler(PositionRecord);
            PositionTaker.Stop();
            KalmanOutputDisplay.Tick -= new EventHandler(KalmanFilterRunner);
            KalmanOutputDisplay.Stop();
        }
    }
}
