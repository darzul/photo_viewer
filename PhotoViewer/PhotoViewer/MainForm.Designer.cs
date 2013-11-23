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
            this.secondarySplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondarySplitContainer)).BeginInit();
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
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.secondarySplitContainer);
            this.mainSplitContainer.Size = new System.Drawing.Size(784, 562);
            this.mainSplitContainer.SplitterDistance = 261;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // secondarySplitContainer
            // 
            this.secondarySplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondarySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondarySplitContainer.Location = new System.Drawing.Point(0, 0);
            this.secondarySplitContainer.Name = "secondarySplitContainer";
            this.secondarySplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.secondarySplitContainer.Size = new System.Drawing.Size(519, 562);
            this.secondarySplitContainer.SplitterDistance = 483;
            this.secondarySplitContainer.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "MainForm";
            this.Text = "iViewer";
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secondarySplitContainer)).EndInit();
            this.secondarySplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.SplitContainer secondarySplitContainer;

    }
}

