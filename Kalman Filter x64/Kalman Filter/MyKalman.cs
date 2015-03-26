using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Kalman_Filter
{
    class MyKalman
    {
        public Kalman kal;
        public List<PointF> kalmanPoints;
        public SyntheticData syntheticData;
        public MyKalman(int dynamParams, int measureParams, int controlParams)
        {
            kal = new Kalman(dynamParams, measureParams, controlParams);
            KalmanFilter();
        }
        /// <summary>
        /// 对kalman滤波器进行赋值初始化
        /// </summary>
        public void KalmanFilter()
        {
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
            return results;
        }
    }
}
