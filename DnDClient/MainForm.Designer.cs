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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.textBoxChatMessage = new System.Windows.Forms.TextBox();
            this.buttonSendChatMessage = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.персонажToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьПерсонажаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьПерсонажаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCharacter = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPageMyCharacter = new System.Windows.Forms.TabPage();
            this.tabPageRules = new System.Windows.Forms.TabPage();
            this.axAcroPDFRules = new AxAcroPDFLib.AxAcroPDF();
            this.menuStripMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageMyCharacter.SuspendLayout();
            this.tabPageRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDFRules)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Location = new System.Drawing.Point(6, 6);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ReadOnly = true;
            this.richTextBoxChat.Size = new System.Drawing.Size(287, 307);
            this.richTextBoxChat.TabIndex = 0;
            this.richTextBoxChat.Text = "";
            // 
            // textBoxChatMessage
            // 
            this.textBoxChatMessage.Location = new System.Drawing.Point(6, 319);
            this.textBoxChatMessage.Name = "textBoxChatMessage";
            this.textBoxChatMessage.Size = new System.Drawing.Size(206, 20);
            this.textBoxChatMessage.TabIndex = 1;
            // 
            // buttonSendChatMessage
            // 
            this.buttonSendChatMessage.Location = new System.Drawing.Point(218, 318);
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
            this.createCharacterToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.createCharacterToolStripMenuItem.Text = "Создать персонажа";
            this.createCharacterToolStripMenuItem.Click += new System.EventHandler(this.CreateCharacterToolStripMenuItem_Click);
            // 
            // loadCharacterToolStripMenuItem
            // 
            this.loadCharacterToolStripMenuItem.Name = "loadCharacterToolStripMenuItem";
            this.loadCharacterToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.loadCharacterToolStripMenuItem.Text = "Загрузить персонажа";
            this.loadCharacterToolStripMenuItem.Click += new System.EventHandler(this.LoadCharacterToolStripMenuItem_Click);
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
            // panelCharacter
            // 
            this.panelCharacter.AutoScroll = true;
            this.panelCharacter.AutoSize = true;
            this.panelCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCharacter.Location = new System.Drawing.Point(3, 3);
            this.panelCharacter.Name = "panelCharacter";
            this.panelCharacter.Size = new System.Drawing.Size(1227, 632);
            this.panelCharacter.TabIndex = 4;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageMain);
            this.tabControlMain.Controls.Add(this.tabPageMyCharacter);
            this.tabControlMain.Controls.Add(this.tabPageRules);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 24);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1241, 664);
            this.tabControlMain.TabIndex = 5;
            this.tabControlMain.TabStop = false;
            this.tabControlMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlMain_Selected);
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.richTextBoxChat);
            this.tabPageMain.Controls.Add(this.textBoxChatMessage);
            this.tabPageMain.Controls.Add(this.buttonSendChatMessage);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(1233, 638);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Игровое окно";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // tabPageMyCharacter
            // 
            this.tabPageMyCharacter.Controls.Add(this.panelCharacter);
            this.tabPageMyCharacter.Location = new System.Drawing.Point(4, 22);
            this.tabPageMyCharacter.Name = "tabPageMyCharacter";
            this.tabPageMyCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMyCharacter.Size = new System.Drawing.Size(1233, 638);
            this.tabPageMyCharacter.TabIndex = 1;
            this.tabPageMyCharacter.Text = "Мой персонаж";
            this.tabPageMyCharacter.UseVisualStyleBackColor = true;
            // 
            // tabPageRules
            // 
            this.tabPageRules.Controls.Add(this.axAcroPDFRules);
            this.tabPageRules.Location = new System.Drawing.Point(4, 22);
            this.tabPageRules.Name = "tabPageRules";
            this.tabPageRules.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRules.Size = new System.Drawing.Size(1233, 638);
            this.tabPageRules.TabIndex = 2;
            this.tabPageRules.Text = "Правила";
            this.tabPageRules.UseVisualStyleBackColor = true;
            // 
            // axAcroPDFRules
            // 
            this.axAcroPDFRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDFRules.Enabled = true;
            this.axAcroPDFRules.Location = new System.Drawing.Point(3, 3);
            this.axAcroPDFRules.Name = "axAcroPDFRules";
            this.axAcroPDFRules.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDFRules.OcxState")));
            this.axAcroPDFRules.Size = new System.Drawing.Size(1227, 632);
            this.axAcroPDFRules.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 688);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "Dungeon and Dragons";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageMyCharacter.ResumeLayout(false);
            this.tabPageMyCharacter.PerformLayout();
            this.tabPageRules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDFRules)).EndInit();
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
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageMyCharacter;
        private System.Windows.Forms.TabPage tabPageRules;
        private AxAcroPDFLib.AxAcroPDF axAcroPDFRules;
    }
}

