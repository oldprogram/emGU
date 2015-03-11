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
            this.原图 = new Emgu.CV.UI.ImageBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.二值图 = new Emgu.CV.UI.ImageBox();
            this.边缘 = new Emgu.CV.UI.ImageBox();
            this.增差 = new Emgu.CV.UI.ImageBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.播放视频ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.原图)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.二值图)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.边缘)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.增差)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 原图
            // 
            this.原图.Dock = System.Windows.Forms.DockStyle.Fill;
            this.原图.Location = new System.Drawing.Point(3, 3);
            this.原图.Name = "原图";
            this.原图.Size = new System.Drawing.Size(484, 291);
            this.原图.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.原图.TabIndex = 2;
            this.原图.TabStop = false;
            this.原图.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.原图_MouseDoubleClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 620);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(981, 122);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 742);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.二值图, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.边缘, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.增差, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.原图, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(981, 595);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // 二值图
            // 
            this.二值图.Dock = System.Windows.Forms.DockStyle.Fill;
            this.二值图.Location = new System.Drawing.Point(493, 300);
            this.二值图.Name = "二值图";
            this.二值图.Size = new System.Drawing.Size(485, 292);
            this.二值图.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.二值图.TabIndex = 4;
            this.二值图.TabStop = false;
            // 
            // 边缘
            // 
            this.边缘.Dock = System.Windows.Forms.DockStyle.Fill;
            this.边缘.Location = new System.Drawing.Point(3, 300);
            this.边缘.Name = "边缘";
            this.边缘.Size = new System.Drawing.Size(484, 292);
            this.边缘.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.边缘.TabIndex = 3;
            this.边缘.TabStop = false;
            // 
            // 增差
            // 
            this.增差.Dock = System.Windows.Forms.DockStyle.Fill;
            this.增差.Location = new System.Drawing.Point(493, 3);
            this.增差.Name = "增差";
            this.增差.Size = new System.Drawing.Size(485, 291);
            this.增差.TabIndex = 2;
            this.增差.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.播放视频ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(981, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 播放视频ToolStripMenuItem
            // 
            this.播放视频ToolStripMenuItem.Name = "播放视频ToolStripMenuItem";
            this.播放视频ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.播放视频ToolStripMenuItem.Text = "播放视频";
            this.播放视频ToolStripMenuItem.Click += new System.EventHandler(this.播放视频ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 742);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.原图)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.二值图)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.边缘)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.增差)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox 原图;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem 播放视频ToolStripMenuItem;
        private Emgu.CV.UI.ImageBox 二值图;
        private Emgu.CV.UI.ImageBox 边缘;
        private Emgu.CV.UI.ImageBox 增差;
        private System.Windows.Forms.Label label1;
    }
}

