namespace DnDClient
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.textBoxChatMessage = new System.Windows.Forms.TextBox();
            this.buttonSendChatMessage = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.персонажToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCharacter = new System.Windows.Forms.Panel();
            this.сохранитьПерсонажаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьПерсонажаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Location = new System.Drawing.Point(12, 287);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ReadOnly = true;
            this.richTextBoxChat.Size = new System.Drawing.Size(287, 307);
            this.richTextBoxChat.TabIndex = 0;
            this.richTextBoxChat.Text = "";
            // 
            // textBoxChatMessage
            // 
            this.textBoxChatMessage.Location = new System.Drawing.Point(12, 600);
            this.textBoxChatMessage.Name = "textBoxChatMessage";
            this.textBoxChatMessage.Size = new System.Drawing.Size(206, 20);
            this.textBoxChatMessage.TabIndex = 1;
            // 
            // buttonSendChatMessage
            // 
            this.buttonSendChatMessage.Location = new System.Drawing.Point(224, 598);
            this.buttonSendChatMessage.Name = "buttonSendChatMessage";
            this.buttonSendChatMessage.Size = new System.Drawing.Size(75, 23);
            this.buttonSendChatMessage.TabIndex = 2;
            this.buttonSendChatMessage.Text = "Отправить";
            this.buttonSendChatMessage.UseVisualStyleBackColor = true;
            this.buttonSendChatMessage.Click += new System.EventHandler(this.ButtonSendChatMessage_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.персонажToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1241, 24);
            this.menuStripMain.TabIndex = 3;
            // 
            // персонажToolStripMenuItem
            // 
            this.персонажToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createCharacterToolStripMenuItem,
            this.loadCharacterToolStripMenuItem,
            this.сохранитьПерсонажаToolStripMenuItem,
            this.редактироватьПерсонажаToolStripMenuItem});
            this.персонажToolStripMenuItem.Name = "персонажToolStripMenuItem";
            this.персонажToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.персонажToolStripMenuItem.Text = "Персонаж";
            // 
            // createCharacterToolStripMenuItem
            // 
            this.createCharacterToolStripMenuItem.Name = "createCharacterToolStripMenuItem";
            this.createCharacterToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.createCharacterToolStripMenuItem.Text = "Создать персонажа";
            this.createCharacterToolStripMenuItem.Click += new System.EventHandler(this.CreateCharacterToolStripMenuItem_Click);
            // 
            // loadCharacterToolStripMenuItem
            // 
            this.loadCharacterToolStripMenuItem.Name = "loadCharacterToolStripMenuItem";
            this.loadCharacterToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.loadCharacterToolStripMenuItem.Text = "Загрузить персонажа";
            this.loadCharacterToolStripMenuItem.Click += new System.EventHandler(this.LoadCharacterToolStripMenuItem_Click);
            // 
            // panelCharacter
            // 
            this.panelCharacter.Location = new System.Drawing.Point(490, 12);
            this.panelCharacter.Name = "panelCharacter";
            this.panelCharacter.Size = new System.Drawing.Size(739, 664);
            this.panelCharacter.TabIndex = 4;
            // 
            // сохранитьПерсонажаToolStripMenuItem
            // 
            this.сохранитьПерсонажаToolStripMenuItem.Name = "сохранитьПерсонажаToolStripMenuItem";
            this.сохранитьПерсонажаToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.сохранитьПерсонажаToolStripMenuItem.Text = "Сохранить персонажа";
            this.сохранитьПерсонажаToolStripMenuItem.Click += new System.EventHandler(this.сохранитьПерсонажаToolStripMenuItem_Click);
            // 
            // редактироватьПерсонажаToolStripMenuItem
            // 
            this.редактироватьПерсонажаToolStripMenuItem.Name = "редактироватьПерсонажаToolStripMenuItem";
            this.редактироватьПерсонажаToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.редактироватьПерсонажаToolStripMenuItem.Text = "Редактировать персонажа";
            this.редактироватьПерсонажаToolStripMenuItem.Click += new System.EventHandler(this.редактироватьПерсонажаToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 688);
            this.Controls.Add(this.panelCharacter);
            this.Controls.Add(this.buttonSendChatMessage);
            this.Controls.Add(this.textBoxChatMessage);
            this.Controls.Add(this.richTextBoxChat);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "Dungeon and Dragons";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.TextBox textBoxChatMessage;
        private System.Windows.Forms.Button buttonSendChatMessage;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem персонажToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCharacterToolStripMenuItem;
        private System.Windows.Forms.Panel panelCharacter;
        private System.Windows.Forms.ToolStripMenuItem сохранитьПерсонажаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьПерсонажаToolStripMenuItem;
    }
}

