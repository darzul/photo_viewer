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
            this.picturesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.detailFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.albumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAlbumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAlbumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayOnWebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondarySplitContainer)).BeginInit();
            this.secondarySplitContainer.Panel1.SuspendLayout();
            this.secondarySplitContainer.Panel2.SuspendLayout();
            this.secondarySplitContainer.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 24);
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
            this.mainSplitContainer.Size = new System.Drawing.Size(784, 590);
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
            this.albumsFlowLayoutPanel.Size = new System.Drawing.Size(253, 582);
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
            this.secondarySplitContainer.Panel1.Controls.Add(this.picturesFlowLayoutPanel);
            // 
            // secondarySplitContainer.Panel2
            // 
            this.secondarySplitContainer.Panel2.Controls.Add(this.detailFlowLayoutPanel);
            this.secondarySplitContainer.Size = new System.Drawing.Size(519, 590);
            this.secondarySplitContainer.SplitterDistance = 443;
            this.secondarySplitContainer.TabIndex = 0;
            // 
            // picturesFlowLayoutPanel
            // 
            this.picturesFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturesFlowLayoutPanel.AutoScroll = true;
            this.picturesFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.picturesFlowLayoutPanel.Name = "picturesFlowLayoutPanel";
            this.picturesFlowLayoutPanel.Size = new System.Drawing.Size(511, 435);
            this.picturesFlowLayoutPanel.TabIndex = 0;
            this.picturesFlowLayoutPanel.Click += new System.EventHandler(this.picturesFlowLayoutPanel_Click);
            // 
            // detailFlowLayoutPanel
            // 
            this.detailFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.detailFlowLayoutPanel.Name = "detailFlowLayoutPanel";
            this.detailFlowLayoutPanel.Size = new System.Drawing.Size(511, 135);
            this.detailFlowLayoutPanel.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.albumsToolStripMenuItem,
            this.picturesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // albumsToolStripMenuItem
            // 
            this.albumsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createAlbumToolStripMenuItem,
            this.removeAlbumToolStripMenuItem,
            this.displayOnWebToolStripMenuItem});
            this.albumsToolStripMenuItem.Name = "albumsToolStripMenuItem";
            this.albumsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.albumsToolStripMenuItem.Text = "Albums";
            // 
            // createAlbumToolStripMenuItem
            // 
            this.createAlbumToolStripMenuItem.Name = "createAlbumToolStripMenuItem";
            this.createAlbumToolStripMenuItem.Size = new System.Drawing.Size(154, 22);

            this.createAlbumToolStripMenuItem.Text = "Create";
            this.createAlbumToolStripMenuItem.Click += new System.EventHandler(this.createAlbumToolStripMenuItem_Click);
            // 
            // removeAlbumToolStripMenuItem
            // 
            this.removeAlbumToolStripMenuItem.Name = "removeAlbumToolStripMenuItem";
            this.removeAlbumToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.removeAlbumToolStripMenuItem.Text = "Remove";
            // 
            // displayOnWebToolStripMenuItem
            // 
            this.displayOnWebToolStripMenuItem.Name = "displayOnWebToolStripMenuItem";
            this.displayOnWebToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.displayOnWebToolStripMenuItem.Text = "Display on web";
            this.displayOnWebToolStripMenuItem.Click += new System.EventHandler(this.displayOnWebToolStripMenuItem_Click);
            // 
            // picturesToolStripMenuItem
            // 
            this.picturesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.picturesToolStripMenuItem.Name = "picturesToolStripMenuItem";
            this.picturesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.picturesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.picturesToolStripMenuItem.Text = "Pictures";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 614);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "iViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.secondarySplitContainer.Panel1.ResumeLayout(false);
            this.secondarySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secondarySplitContainer)).EndInit();
            this.secondarySplitContainer.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.SplitContainer secondarySplitContainer;
        private System.Windows.Forms.FlowLayoutPanel albumsFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel picturesFlowLayoutPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem albumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createAlbumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAlbumToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel detailFlowLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem picturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayOnWebToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

