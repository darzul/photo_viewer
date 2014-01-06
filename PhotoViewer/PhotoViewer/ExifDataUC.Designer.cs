namespace PhotoViewer
{
    partial class ExifDataUC
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
            this.propertyLabel = new System.Windows.Forms.Label();
            this.propertyMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // propertyLabel
            // 
            this.propertyLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.propertyLabel.AutoEllipsis = true;
            this.propertyLabel.AutoSize = true;
            this.propertyLabel.Location = new System.Drawing.Point(3, 3);
            this.propertyLabel.Name = "propertyLabel";
            this.propertyLabel.Size = new System.Drawing.Size(35, 13);
            this.propertyLabel.TabIndex = 0;
            this.propertyLabel.Text = "label1";
            this.propertyLabel.Click += new System.EventHandler(this.propertyLabelFocus);
            // 
            // propertyMaskedTextBox
            // 
            this.propertyMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyMaskedTextBox.Location = new System.Drawing.Point(103, 0);
            this.propertyMaskedTextBox.Name = "propertyMaskedTextBox";
            this.propertyMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.propertyMaskedTextBox.TabIndex = 1;
            this.propertyMaskedTextBox.Click += new System.EventHandler(this.ExifDataUCFocus);
            // 
            // ExifDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propertyMaskedTextBox);
            this.Controls.Add(this.propertyLabel);
            this.Name = "ExifDataUC";
            this.Size = new System.Drawing.Size(250, 20);
            this.Click += new System.EventHandler(this.ExifDataUCFocus);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label propertyLabel;
        private System.Windows.Forms.MaskedTextBox propertyMaskedTextBox;
    }
}
