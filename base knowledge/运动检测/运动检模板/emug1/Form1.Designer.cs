namespace emug1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.motionImageBox = new Emgu.CV.UI.ImageBox();
            this.forgroundImageBox = new Emgu.CV.UI.ImageBox();
            this.capturedImageBox = new Emgu.CV.UI.ImageBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forgroundImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 325F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.motionImageBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.forgroundImageBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.capturedImageBox, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(952, 369);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // motionImageBox
            // 
            this.motionImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.motionImageBox.Location = new System.Drawing.Point(641, 3);
            this.motionImageBox.Name = "motionImageBox";
            this.motionImageBox.Size = new System.Drawing.Size(308, 363);
            this.motionImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.motionImageBox.TabIndex = 5;
            this.motionImageBox.TabStop = false;
            // 
            // forgroundImageBox
            // 
            this.forgroundImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forgroundImageBox.Location = new System.Drawing.Point(316, 3);
            this.forgroundImageBox.Name = "forgroundImageBox";
            this.forgroundImageBox.Size = new System.Drawing.Size(319, 363);
            this.forgroundImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.forgroundImageBox.TabIndex = 4;
            this.forgroundImageBox.TabStop = false;
            // 
            // capturedImageBox
            // 
            this.capturedImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.capturedImageBox.Location = new System.Drawing.Point(3, 3);
            this.capturedImageBox.Name = "capturedImageBox";
            this.capturedImageBox.Size = new System.Drawing.Size(307, 363);
            this.capturedImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.capturedImageBox.TabIndex = 3;
            this.capturedImageBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 432);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forgroundImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Emgu.CV.UI.ImageBox motionImageBox;
        private Emgu.CV.UI.ImageBox forgroundImageBox;
        private Emgu.CV.UI.ImageBox capturedImageBox;


    }
}

