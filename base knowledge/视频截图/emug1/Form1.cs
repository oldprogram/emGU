using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Emgu.CV;//PS:调用的Emgu dll  
using Emgu.CV.Structure;

//打开视屏，鼠标双击视频区进行截图
namespace emug1
{
    public partial class Form1 : Form
    {
        private Capture capture;
        int cut_num = 0;        //减下来的图片数

        int VideoFps;
        
        string file_name;
        Image<Bgr, byte> image;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 播放进程函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void processfram(object sender, EventArgs arg)
        {
            image = capture.QueryFrame();   //获取当前帧的图片
            原图.Image = image;               //将图片显示在picBox中
        }

        /// <summary>
        /// 选择menuItem触发事件，代开文件并播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 播放视频ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FilterIndex = 5;
            openFileDialog.Filter = "AVI文件|*.avi|RMVB文件|*.rmvb|WMV文件|*.wmv|MKV文件|*.mkv|所有文件|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Application.Idle += new EventHandler(processfram);  //播放的函数句柄
                capture = new Capture(openFileDialog.FileName);     //
                VideoFps = (int)CvInvoke.cvGetCaptureProperty(capture, Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS);
            }

            file_name = openFileDialog.SafeFileName;
            //缩放图片
            //image = image.Resize(0.25, Emgu.CV.CvEnum.INTER.CV_INTER_NN);
        }

        /// <summary>
        /// 窗口关闭触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Idle -= new EventHandler(processfram);
        }

        /// <summary>
        /// 鼠标点击进行截一张图并保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 原图_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            image.Save(file_name + "截图" + cut_num + ".bmp");
            cut_num++;
            label1.Text = cut_num.ToString();
        }
    }
}
