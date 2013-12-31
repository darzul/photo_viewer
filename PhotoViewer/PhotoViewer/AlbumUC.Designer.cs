﻿using System.Collections.Generic;
using System.IO;


namespace PhotoViewer
{
    partial class AlbumUC
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.rightClickContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.rightClickContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.AlbumUC_DragDrop);
            this.pictureBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.AlbumUC_DragEnter);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AlbumUC_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AlbumUC_MouseMove);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox3.Location = new System.Drawing.Point(5, 60);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.DragDrop += new System.Windows.Forms.DragEventHandler(this.AlbumUC_DragDrop);
            this.pictureBox3.DragEnter += new System.Windows.Forms.DragEventHandler(this.AlbumUC_DragEnter);
            this.pictureBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AlbumUC_MouseClick);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AlbumUC_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox2.Location = new System.Drawing.Point(60, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.AlbumUC_DragDrop);
            this.pictureBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.AlbumUC_DragEnter);
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AlbumUC_MouseClick);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AlbumUC_MouseMove);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox4.Location = new System.Drawing.Point(60, 60);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.DragDrop += new System.Windows.Forms.DragEventHandler(this.AlbumUC_DragDrop);
            this.pictureBox4.DragEnter += new System.Windows.Forms.DragEventHandler(this.AlbumUC_DragEnter);
            this.pictureBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AlbumUC_MouseClick);
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AlbumUC_MouseMove);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.titleLabel.Location = new System.Drawing.Point(5, 115);
            this.titleLabel.MaximumSize = new System.Drawing.Size(105, 25);
            this.titleLabel.MinimumSize = new System.Drawing.Size(105, 25);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(105, 25);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.AlbumUC_DragDrop);
            this.titleLabel.DragEnter += new System.Windows.Forms.DragEventHandler(this.AlbumUC_DragEnter);
            this.titleLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AlbumUC_MouseClick);
            this.titleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AlbumUC_MouseMove);
            // 
            // rightClickContextMenuStrip
            // 
            this.rightClickContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.webViewToolStripMenuItem});
            this.rightClickContextMenuStrip.Name = "rightClickContextMenuStrip";
            this.rightClickContextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rightClickContextMenuStrip.Size = new System.Drawing.Size(126, 70);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.rename);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.delete);
            // 
            // webViewToolStripMenuItem
            // 
            this.webViewToolStripMenuItem.Name = "webViewToolStripMenuItem";
            this.webViewToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.webViewToolStripMenuItem.Text = "Web view";
            this.webViewToolStripMenuItem.Click += new System.EventHandler(this.webView);
            // 
            // AlbumUC
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AlbumUC";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(115, 145);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AlbumUC_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.AlbumUC_DragEnter);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AlbumUC_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AlbumUC_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.rightClickContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ContextMenuStrip rightClickContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webViewToolStripMenuItem;
    }
}
