﻿namespace DnDClient
{
    partial class CharactersForm
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
            this.hScrollBarCharacters = new System.Windows.Forms.HScrollBar();
            this.panelCharacters = new System.Windows.Forms.Panel();
            this.panelCharacters.SuspendLayout();
            this.SuspendLayout();
            // 
            // hScrollBarCharacters
            // 
            this.hScrollBarCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBarCharacters.Location = new System.Drawing.Point(0, 433);
            this.hScrollBarCharacters.Name = "hScrollBarCharacters";
            this.hScrollBarCharacters.Size = new System.Drawing.Size(800, 17);
            this.hScrollBarCharacters.TabIndex = 0;
            // 
            // panelCharacters
            // 
            this.panelCharacters.Controls.Add(this.hScrollBarCharacters);
            this.panelCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCharacters.Location = new System.Drawing.Point(0, 0);
            this.panelCharacters.Name = "panelCharacters";
            this.panelCharacters.Size = new System.Drawing.Size(800, 450);
            this.panelCharacters.TabIndex = 1;
            // 
            // CharactersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panelCharacters);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharactersForm";
            this.Text = "Персонажи";
            this.panelCharacters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar hScrollBarCharacters;
        private System.Windows.Forms.Panel panelCharacters;
    }
}