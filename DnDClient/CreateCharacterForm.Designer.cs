namespace DnDClient
{
    partial class CreateCharacterForm
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
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonDecline = new System.Windows.Forms.Button();
            this.panelCharacteristic = new System.Windows.Forms.Panel();
            this.labelMastery = new System.Windows.Forms.Label();
            this.numericUpDownMastery = new System.Windows.Forms.NumericUpDown();
            this.panelSave = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMastery)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(576, 415);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 0;
            this.buttonAccept.Text = "Применить";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // buttonDecline
            // 
            this.buttonDecline.Location = new System.Drawing.Point(713, 415);
            this.buttonDecline.Name = "buttonDecline";
            this.buttonDecline.Size = new System.Drawing.Size(75, 23);
            this.buttonDecline.TabIndex = 1;
            this.buttonDecline.Text = "Отменить";
            this.buttonDecline.UseVisualStyleBackColor = true;
            this.buttonDecline.Click += new System.EventHandler(this.ButtonDecline_Click);
            // 
            // panelCharacteristic
            // 
            this.panelCharacteristic.Location = new System.Drawing.Point(12, 12);
            this.panelCharacteristic.Name = "panelCharacteristic";
            this.panelCharacteristic.Size = new System.Drawing.Size(100, 426);
            this.panelCharacteristic.TabIndex = 2;
            // 
            // labelMastery
            // 
            this.labelMastery.AutoSize = true;
            this.labelMastery.Location = new System.Drawing.Point(118, 12);
            this.labelMastery.Name = "labelMastery";
            this.labelMastery.Size = new System.Drawing.Size(68, 13);
            this.labelMastery.TabIndex = 4;
            this.labelMastery.Text = "Мастерство";
            // 
            // numericUpDownMastery
            // 
            this.numericUpDownMastery.Location = new System.Drawing.Point(118, 28);
            this.numericUpDownMastery.Name = "numericUpDownMastery";
            this.numericUpDownMastery.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownMastery.TabIndex = 5;
            this.numericUpDownMastery.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // panelSave
            // 
            this.panelSave.Location = new System.Drawing.Point(118, 54);
            this.panelSave.Name = "panelSave";
            this.panelSave.Size = new System.Drawing.Size(124, 100);
            this.panelSave.TabIndex = 6;
            // 
            // CreateCharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panelSave);
            this.Controls.Add(this.numericUpDownMastery);
            this.Controls.Add(this.labelMastery);
            this.Controls.Add(this.panelCharacteristic);
            this.Controls.Add(this.buttonDecline);
            this.Controls.Add(this.buttonAccept);
            this.Name = "CreateCharacterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "/";
            this.Load += new System.EventHandler(this.CreateCharacterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMastery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonDecline;
        private System.Windows.Forms.Panel panelCharacteristic;
        private System.Windows.Forms.Label labelMastery;
        private System.Windows.Forms.NumericUpDown numericUpDownMastery;
        private System.Windows.Forms.Panel panelSave;
    }
}