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
            this.pictureListView = new System.Windows.Forms.ListView();
            this.detailFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.albumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAlbumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAlbumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayOnWebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondarySplitContainer)).BeginInit();
            this.secondarySplitContainer.Panel1.SuspendLayout();
            this.secondarySplitContainer.Panel2.SuspendLayout();
            this.secondarySplitContainer.SuspendLayout();
            this.picturesFlowLayoutPanel.SuspendLayout();
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
            this.albumsFlowLayoutPanel.AllowDrop = true;
            this.albumsFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.albumsFlowLayoutPanel.AutoScroll = true;
            this.albumsFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.albumsFlowLayoutPanel.Name = "albumsFlowLayoutPanel";
            this.albumsFlowLayoutPanel.Size = new System.Drawing.Size(253, 582);
            this.albumsFlowLayoutPanel.TabIndex = 0;
            this.albumsFlowLayoutPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.albumsFlowLayoutPanel_DragDrop);
            this.albumsFlowLayoutPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel_DragEnter);
            this.albumsFlowLayoutPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.albumsFlowLayoutPanel_MouseClick);
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
            this.picturesFlowLayoutPanel.AllowDrop = true;
            this.picturesFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturesFlowLayoutPanel.AutoScroll = true;
            this.picturesFlowLayoutPanel.Controls.Add(this.pictureListView);
            this.picturesFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.picturesFlowLayoutPanel.Name = "picturesFlowLayoutPanel";
            this.picturesFlowLayoutPanel.Size = new System.Drawing.Size(511, 435);
            this.picturesFlowLayoutPanel.TabIndex = 0;
            this.picturesFlowLayoutPanel.Click += new System.EventHandler(this.picturesFlowLayoutPanel_Click);
            this.picturesFlowLayoutPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.picturesFlowLayoutPanel_DragDrop);
            this.picturesFlowLayoutPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel_DragEnter);
            this.picturesFlowLayoutPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picturesFlowLayoutPanel_MouseClick);
            // 
            // pictureListView
            // 
            this.pictureListView.Location = new System.Drawing.Point(3, 3);
            this.pictureListView.Name = "pictureListView";
            this.pictureListView.Scrollable = false;
            this.pictureListView.Size = new System.Drawing.Size(490, 432);
            this.pictureListView.TabIndex = 0;
            this.pictureListView.UseCompatibleStateImageBehavior = false;
            this.pictureListView.Visible = false;
            // 
            // detailFlowLayoutPanel
            // 
            this.detailFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailFlowLayoutPanel.AutoScroll = true;
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
            this.createAlbumToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emptyToolStripMenuItem,
            this.fromFolderToolStripMenuItem});
            this.createAlbumToolStripMenuItem.Name = "createAlbumToolStripMenuItem";
            this.createAlbumToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.createAlbumToolStripMenuItem.Text = "New album";
            // 
            // emptyToolStripMenuItem
            // 
            this.emptyToolStripMenuItem.Name = "emptyToolStripMenuItem";
            this.emptyToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.emptyToolStripMenuItem.Text = "Empty";
            this.emptyToolStripMenuItem.Click += new System.EventHandler(this.createEmptyAlbum);
            // 
            // fromFolderToolStripMenuItem
            // 
            this.fromFolderToolStripMenuItem.Name = "fromFolderToolStripMenuItem";
            this.fromFolderToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.fromFolderToolStripMenuItem.Text = "From folder";
            this.fromFolderToolStripMenuItem.Click += new System.EventHandler(this.createAlbumFromFolder);
            // 
            // removeAlbumToolStripMenuItem
            // 
            this.removeAlbumToolStripMenuItem.Name = "removeAlbumToolStripMenuItem";
            this.removeAlbumToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.removeAlbumToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.removeAlbumToolStripMenuItem.Text = "Remove";
            this.removeAlbumToolStripMenuItem.Click += new System.EventHandler(this.removeAlbum);
            // 
            // displayOnWebToolStripMenuItem
            // 
            this.displayOnWebToolStripMenuItem.Name = "displayOnWebToolStripMenuItem";
            this.displayOnWebToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.displayOnWebToolStripMenuItem.Text = "Display on web";
            this.displayOnWebToolStripMenuItem.Click += new System.EventHandler(this.displayOnWeb);
            // 
            // picturesToolStripMenuItem
            // 
            this.picturesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.sortByToolStripMenuItem,
            this.displayInToolStripMenuItem});
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
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllPictures);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addPictures);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.removePicture);
            // 
            // sortByToolStripMenuItem
            // 
            this.sortByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.rateToolStripMenuItem,
            this.dateToolStripMenuItem});
            this.sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
            this.sortByToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.sortByToolStripMenuItem.Text = "Sort by";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.nameToolStripMenuItem.Text = "Name";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.sortByTitle);
            // 
            // rateToolStripMenuItem
            // 
            this.rateToolStripMenuItem.Name = "rateToolStripMenuItem";
            this.rateToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.rateToolStripMenuItem.Text = "Rate";
            // 
            // dateToolStripMenuItem
            // 
            this.dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.dateToolStripMenuItem.Text = "Date";
            // 
            // displayInToolStripMenuItem
            // 
            this.displayInToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listViewToolStripMenuItem,
            this.listViewToolStripMenuItem1});
            this.displayInToolStripMenuItem.Name = "displayInToolStripMenuItem";
            this.displayInToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.displayInToolStripMenuItem.Text = "Display in";
            // 
            // listViewToolStripMenuItem
            // 
            this.listViewToolStripMenuItem.Name = "listViewToolStripMenuItem";
            this.listViewToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.listViewToolStripMenuItem.Text = "Normal";
            this.listViewToolStripMenuItem.Click += new System.EventHandler(this.NormalDisplay);
            // 
            // listViewToolStripMenuItem1
            // 
            this.listViewToolStripMenuItem1.Name = "listViewToolStripMenuItem1";
            this.listViewToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.listViewToolStripMenuItem1.Text = "List view";
            this.listViewToolStripMenuItem1.Click += new System.EventHandler(this.listViewDisplay);
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
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.secondarySplitContainer.Panel1.ResumeLayout(false);
            this.secondarySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secondarySplitContainer)).EndInit();
            this.secondarySplitContainer.ResumeLayout(false);
            this.picturesFlowLayoutPanel.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emptyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateToolStripMenuItem;
        private System.Windows.Forms.ListView pictureListView;
        private System.Windows.Forms.ToolStripMenuItem displayInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listViewToolStripMenuItem1;
    }
}

