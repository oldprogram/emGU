namespace Kalman_Filter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MouseTrackingArea = new System.Windows.Forms.PictureBox();
            this.Start_BTN = new System.Windows.Forms.Button();
            this.Timed_LBL = new System.Windows.Forms.Label();
            this.Predicted_LBL = new System.Windows.Forms.Label();
            this.Corrected_LBL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MouseTrackingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // MouseTrackingArea
            // 
            this.MouseTrackingArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MouseTrackingArea.BackColor = System.Drawing.Color.White;
            this.MouseTrackingArea.Location = new System.Drawing.Point(12, 45);
            this.MouseTrackingArea.Name = "MouseTrackingArea";
            this.MouseTrackingArea.Size = new System.Drawing.Size(611, 379);
            this.MouseTrackingArea.TabIndex = 0;
            this.MouseTrackingArea.TabStop = false;
            // 
            // Start_BTN
            // 
            this.Start_BTN.Location = new System.Drawing.Point(12, 3);
            this.Start_BTN.Name = "Start_BTN";
            this.Start_BTN.Size = new System.Drawing.Size(75, 21);
            this.Start_BTN.TabIndex = 2;
            this.Start_BTN.Text = "Start";
            this.Start_BTN.UseVisualStyleBackColor = true;
            this.Start_BTN.Click += new System.EventHandler(this.Start_BTN_Click);
            // 
            // Timed_LBL
            // 
            this.Timed_LBL.AutoSize = true;
            this.Timed_LBL.Location = new System.Drawing.Point(15, 28);
            this.Timed_LBL.Name = "Timed_LBL";
            this.Timed_LBL.Size = new System.Drawing.Size(59, 12);
            this.Timed_LBL.TabIndex = 3;
            this.Timed_LBL.Text = "Position:";
            // 
            // Predicted_LBL
            // 
            this.Predicted_LBL.AutoSize = true;
            this.Predicted_LBL.Location = new System.Drawing.Point(324, 27);
            this.Predicted_LBL.Name = "Predicted_LBL";
            this.Predicted_LBL.Size = new System.Drawing.Size(59, 12);
            this.Predicted_LBL.TabIndex = 4;
            this.Predicted_LBL.Text = "Position:";
            // 
            // Corrected_LBL
            // 
            this.Corrected_LBL.AutoSize = true;
            this.Corrected_LBL.Location = new System.Drawing.Point(324, 9);
            this.Corrected_LBL.Name = "Corrected_LBL";
            this.Corrected_LBL.Size = new System.Drawing.Size(59, 12);
            this.Corrected_LBL.TabIndex = 5;
            this.Corrected_LBL.Text = "Position:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 436);
            this.Controls.Add(this.Corrected_LBL);
            this.Controls.Add(this.Predicted_LBL);
            this.Controls.Add(this.Timed_LBL);
            this.Controls.Add(this.Start_BTN);
            this.Controls.Add(this.MouseTrackingArea);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MouseTrackingArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MouseTrackingArea;
        private System.Windows.Forms.Button Start_BTN;
        private System.Windows.Forms.Label Timed_LBL;
        private System.Windows.Forms.Label Predicted_LBL;
        private System.Windows.Forms.Label Corrected_LBL;
    }
}

