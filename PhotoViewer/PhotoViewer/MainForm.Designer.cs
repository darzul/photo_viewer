namespace PhotoViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.albumsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.secondarySplitContainer = new System.Windows.Forms.SplitContainer();
            this.picturesvScrollBar = new System.Windows.Forms.VScrollBar();
            this.picturesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondarySplitContainer)).BeginInit();
            this.secondarySplitContainer.Panel1.SuspendLayout();
            this.secondarySplitContainer.Panel2.SuspendLayout();
            this.secondarySplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.AccessibleName = "albumsPanel";
            this.mainSplitContainer.Panel1.Controls.Add(this.albumsFlowLayoutPanel);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.secondarySplitContainer);
            this.mainSplitContainer.Size = new System.Drawing.Size(784, 562);
            this.mainSplitContainer.SplitterDistance = 261;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // albumsFlowLayoutPanel
            // 
            this.albumsFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.albumsFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.albumsFlowLayoutPanel.Name = "albumsFlowLayoutPanel";
            this.albumsFlowLayoutPanel.Size = new System.Drawing.Size(253, 554);
            this.albumsFlowLayoutPanel.TabIndex = 0;
            // 
            // secondarySplitContainer
            // 
            this.secondarySplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondarySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondarySplitContainer.Location = new System.Drawing.Point(0, 0);
            this.secondarySplitContainer.Name = "secondarySplitContainer";
            this.secondarySplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // secondarySplitContainer.Panel1
            // 
            this.secondarySplitContainer.Panel1.Controls.Add(this.picturesvScrollBar);
            this.secondarySplitContainer.Panel1.Controls.Add(this.picturesFlowLayoutPanel);
            // 
            // secondarySplitContainer.Panel2
            // 
            this.secondarySplitContainer.Panel2.Controls.Add(this.button1);
            this.secondarySplitContainer.Size = new System.Drawing.Size(519, 562);
            this.secondarySplitContainer.SplitterDistance = 483;
            this.secondarySplitContainer.TabIndex = 0;
            // 
            // picturesvScrollBar
            // 
            this.picturesvScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturesvScrollBar.Location = new System.Drawing.Point(501, 3);
            this.picturesvScrollBar.Name = "picturesvScrollBar";
            this.picturesvScrollBar.Size = new System.Drawing.Size(17, 475);
            this.picturesvScrollBar.TabIndex = 0;
            // 
            // picturesFlowLayoutPanel
            // 
            this.picturesFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturesFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.picturesFlowLayoutPanel.Name = "picturesFlowLayoutPanel";
            this.picturesFlowLayoutPanel.Size = new System.Drawing.Size(511, 475);
            this.picturesFlowLayoutPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Location = new System.Drawing.Point(198, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 67);
            this.button1.TabIndex = 0;
            this.button1.Text = "Diaporama";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.Paint += new System.Windows.Forms.PaintEventHandler(this.button1_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "MainForm";
            this.Text = "iViewer";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.secondarySplitContainer.Panel1.ResumeLayout(false);
            this.secondarySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secondarySplitContainer)).EndInit();
            this.secondarySplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.SplitContainer secondarySplitContainer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel albumsFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel picturesFlowLayoutPanel;
        private System.Windows.Forms.VScrollBar picturesvScrollBar;
    }
}

