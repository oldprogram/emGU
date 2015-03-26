using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
//http://blog.csdn.net/xiahouzuoxin/article/details/39582483
namespace Kalman_Filter
{
    public class SyntheticData
    {
        public Matrix<float> state;//状态矩阵
        public Matrix<float> transitionMatrix;//状态转换矩阵
        public Matrix<float> measurementMatrix;//测量矩阵
        public Matrix<float> processNoise;//过程噪声
        public Matrix<float> measurementNoise;//测量噪声
        public Matrix<float> errorCovariancePost;//误差协方差矩阵

        public SyntheticData()
        {
            state = new Matrix<float>(4, 1);
            state[0, 0] = 0f; // x-pos
            state[1, 0] = 0f; // y-pos
            state[2, 0] = 0f; // x-velocity
            state[3, 0] = 0f; // y-velocity
            transitionMatrix = new Matrix<float>(new float[,]
                    {
                        {1, 0, 1, 0},  // x-pos, y-pos, x-velocity, y-velocity
                        {0, 1, 0, 1},
                        {0, 0, 1, 0},
                        {0, 0, 0, 1}
                    }); 
            measurementMatrix = new Matrix<float>(new float[,]
                    {
                        { 1, 0, 0, 0 },
                        { 0, 1, 0, 0 }
                    });
            measurementMatrix.SetIdentity();
            processNoise = new Matrix<float>(4, 4); //Linked to the size of the transition matrix
            processNoise.SetIdentity(new MCvScalar(1.0e-4)); //The smaller the value the more resistance to noise 
            measurementNoise = new Matrix<float>(2, 2); //Fixed accordiong to input data 
            measurementNoise.SetIdentity(new MCvScalar(1.0e-1));
            errorCovariancePost = new Matrix<float>(4, 4); //Linked to the size of the transition matrix
            errorCovariancePost.SetIdentity();
        }

        /// <summary>
        /// 观测结果矩阵Z(n)=H(n)X(n)+V(n)
        /// H(n)为观测传递矩阵
        /// X(n)为状态变量
        /// V(n)为测量噪声
        /// </summary>
        /// <returns></returns>
        public Matrix<float> GetMeasurement()
        {
            Matrix<float> measurementNoise = new Matrix<float>(2, 1);
            measurementNoise.SetRandNormal(new MCvScalar(), new MCvScalar(Math.Sqrt(measurementNoise[0, 0])));
            return measurementMatrix * state + measurementNoise;
        }

        /// <summary>
        /// 预测结果矩阵X(n)=AX(n-1)+Bu(n)+w(n)
        /// X(n)为状态向量
        /// A状态转移矩阵
        /// B控制输入矩阵
        /// u(n)驱动输入向量
        /// w(n)过程噪声
        /// </summary>
        public void GoToNextState()
        {
            Matrix<float> processNoise = new Matrix<float>(4, 1);
            processNoise.SetRandNormal(new MCvScalar(), new MCvScalar(processNoise[0, 0]));
            state = transitionMatrix * state + processNoise;
        }
    
    
    }
}
