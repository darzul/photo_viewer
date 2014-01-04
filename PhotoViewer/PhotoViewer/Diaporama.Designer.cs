namespace PhotoViewer
{
    partial class Diaporama
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
            this.components = new System.ComponentModel.Container();
            this.diapoPictureBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.diapoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // diapoPictureBox
            // 
            this.diapoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diapoPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.diapoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.diapoPictureBox.Name = "diapoPictureBox";
            this.diapoPictureBox.Size = new System.Drawing.Size(0, 0);
            this.diapoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.diapoPictureBox.TabIndex = 0;
            this.diapoPictureBox.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Diaporama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.diapoPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Diaporama";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Diaporama_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Diaporama_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Diaporama_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.diapoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox diapoPictureBox;
        private System.Windows.Forms.Timer timer;
    }
}