namespace DnDClient
{
    partial class SettingsForm
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
            this.textBoxServerURL = new System.Windows.Forms.TextBox();
            this.labelServerURL = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonDecline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxServerURL
            // 
            this.textBoxServerURL.Location = new System.Drawing.Point(16, 25);
            this.textBoxServerURL.Name = "textBoxServerURL";
            this.textBoxServerURL.Size = new System.Drawing.Size(220, 20);
            this.textBoxServerURL.TabIndex = 2;
            // 
            // labelServerURL
            // 
            this.labelServerURL.AutoSize = true;
            this.labelServerURL.Location = new System.Drawing.Point(77, 9);
            this.labelServerURL.Name = "labelServerURL";
            this.labelServerURL.Size = new System.Drawing.Size(74, 13);
            this.labelServerURL.TabIndex = 7;
            this.labelServerURL.Text = "URL сервера";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(15, 64);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(110, 23);
            this.buttonAccept.TabIndex = 4;
            this.buttonAccept.Text = "Применить";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonDecline
            // 
            this.buttonDecline.Location = new System.Drawing.Point(126, 64);
            this.buttonDecline.Name = "buttonDecline";
            this.buttonDecline.Size = new System.Drawing.Size(110, 23);
            this.buttonDecline.TabIndex = 5;
            this.buttonDecline.Text = "Отменить";
            this.buttonDecline.UseVisualStyleBackColor = true;
            this.buttonDecline.Click += new System.EventHandler(this.buttonDecline_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 91);
            this.ControlBox = false;
            this.Controls.Add(this.buttonDecline);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.textBoxServerURL);
            this.Controls.Add(this.labelServerURL);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Название игры";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxServerURL;
        private System.Windows.Forms.Label labelServerURL;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonDecline;
    }
}

