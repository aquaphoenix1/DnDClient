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
            this.panelChatAndDices = new System.Windows.Forms.Panel();
            this.panelChat = new System.Windows.Forms.Panel();
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.textBoxChatMessage = new System.Windows.Forms.TextBox();
            this.buttonSendChatMessage = new System.Windows.Forms.Button();
            this.groupBoxDices = new System.Windows.Forms.GroupBox();
            this.buttonThrowDice = new System.Windows.Forms.Button();
            this.groupBoxAdvantageAndInterference = new System.Windows.Forms.GroupBox();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.radioButtonInterference = new System.Windows.Forms.RadioButton();
            this.radioButtonAdvantage = new System.Windows.Forms.RadioButton();
            this.labelPlusDices = new System.Windows.Forms.Label();
            this.labelCountDices = new System.Windows.Forms.Label();
            this.numericUpDownPlusDices = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCountDices = new System.Windows.Forms.NumericUpDown();
            this.labelDice = new System.Windows.Forms.Label();
            this.comboBoxDice = new System.Windows.Forms.ComboBox();
            this.panelBattlefield = new System.Windows.Forms.Panel();
            this.показатьПерсонажейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageMyCharacter.SuspendLayout();
            this.panelChatAndDices.SuspendLayout();
            this.panelChat.SuspendLayout();
            this.groupBoxDices.SuspendLayout();
            this.groupBoxAdvantageAndInterference.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlusDices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountDices)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьПерсонажейToolStripMenuItem,
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
            this.panelCharacter.Size = new System.Drawing.Size(1227, 515);
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
            this.tabControlMain.Size = new System.Drawing.Size(1241, 547);
            this.tabControlMain.TabIndex = 5;
            this.tabControlMain.TabStop = false;
            this.tabControlMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlMain_Selected);
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.panelBattlefield);
            this.tabPageMain.Controls.Add(this.panelChatAndDices);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(1233, 521);
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
            this.tabPageMyCharacter.Size = new System.Drawing.Size(1233, 521);
            this.tabPageMyCharacter.TabIndex = 1;
            this.tabPageMyCharacter.Text = "Мой персонаж";
            this.tabPageMyCharacter.UseVisualStyleBackColor = true;
            // 
            // tabPageRules
            // 
            this.tabPageRules.Location = new System.Drawing.Point(4, 22);
            this.tabPageRules.Name = "tabPageRules";
            this.tabPageRules.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRules.Size = new System.Drawing.Size(1233, 521);
            this.tabPageRules.TabIndex = 2;
            this.tabPageRules.Text = "Правила";
            this.tabPageRules.UseVisualStyleBackColor = true;
            // 
            // panelChatAndDices
            // 
            this.panelChatAndDices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelChatAndDices.Controls.Add(this.panelChat);
            this.panelChatAndDices.Controls.Add(this.groupBoxDices);
            this.panelChatAndDices.Location = new System.Drawing.Point(0, 3);
            this.panelChatAndDices.Name = "panelChatAndDices";
            this.panelChatAndDices.Size = new System.Drawing.Size(303, 522);
            this.panelChatAndDices.TabIndex = 8;
            // 
            // panelChat
            // 
            this.panelChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panelChat.Controls.Add(this.richTextBoxChat);
            this.panelChat.Controls.Add(this.textBoxChatMessage);
            this.panelChat.Controls.Add(this.buttonSendChatMessage);
            this.panelChat.Location = new System.Drawing.Point(3, 3);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(297, 343);
            this.panelChat.TabIndex = 4;
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.richTextBoxChat.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ReadOnly = true;
            this.richTextBoxChat.Size = new System.Drawing.Size(291, 307);
            this.richTextBoxChat.TabIndex = 0;
            this.richTextBoxChat.Text = "";
            // 
            // textBoxChatMessage
            // 
            this.textBoxChatMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxChatMessage.Location = new System.Drawing.Point(3, 316);
            this.textBoxChatMessage.Name = "textBoxChatMessage";
            this.textBoxChatMessage.Size = new System.Drawing.Size(206, 20);
            this.textBoxChatMessage.TabIndex = 1;
            // 
            // buttonSendChatMessage
            // 
            this.buttonSendChatMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSendChatMessage.Location = new System.Drawing.Point(215, 315);
            this.buttonSendChatMessage.Name = "buttonSendChatMessage";
            this.buttonSendChatMessage.Size = new System.Drawing.Size(75, 23);
            this.buttonSendChatMessage.TabIndex = 2;
            this.buttonSendChatMessage.Text = "Отправить";
            this.buttonSendChatMessage.UseVisualStyleBackColor = true;
            // 
            // groupBoxDices
            // 
            this.groupBoxDices.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBoxDices.Controls.Add(this.buttonThrowDice);
            this.groupBoxDices.Controls.Add(this.groupBoxAdvantageAndInterference);
            this.groupBoxDices.Controls.Add(this.labelPlusDices);
            this.groupBoxDices.Controls.Add(this.labelCountDices);
            this.groupBoxDices.Controls.Add(this.numericUpDownPlusDices);
            this.groupBoxDices.Controls.Add(this.numericUpDownCountDices);
            this.groupBoxDices.Controls.Add(this.labelDice);
            this.groupBoxDices.Controls.Add(this.comboBoxDice);
            this.groupBoxDices.Location = new System.Drawing.Point(6, 349);
            this.groupBoxDices.Name = "groupBoxDices";
            this.groupBoxDices.Size = new System.Drawing.Size(287, 167);
            this.groupBoxDices.TabIndex = 3;
            this.groupBoxDices.TabStop = false;
            this.groupBoxDices.Text = "Кубики";
            // 
            // buttonThrowDice
            // 
            this.buttonThrowDice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonThrowDice.Location = new System.Drawing.Point(205, 107);
            this.buttonThrowDice.Name = "buttonThrowDice";
            this.buttonThrowDice.Size = new System.Drawing.Size(75, 23);
            this.buttonThrowDice.TabIndex = 4;
            this.buttonThrowDice.Text = "Бросить";
            this.buttonThrowDice.UseVisualStyleBackColor = true;
            // 
            // groupBoxAdvantageAndInterference
            // 
            this.groupBoxAdvantageAndInterference.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBoxAdvantageAndInterference.Controls.Add(this.radioButtonNormal);
            this.groupBoxAdvantageAndInterference.Controls.Add(this.radioButtonInterference);
            this.groupBoxAdvantageAndInterference.Controls.Add(this.radioButtonAdvantage);
            this.groupBoxAdvantageAndInterference.Location = new System.Drawing.Point(6, 75);
            this.groupBoxAdvantageAndInterference.Name = "groupBoxAdvantageAndInterference";
            this.groupBoxAdvantageAndInterference.Size = new System.Drawing.Size(193, 86);
            this.groupBoxAdvantageAndInterference.TabIndex = 7;
            this.groupBoxAdvantageAndInterference.TabStop = false;
            this.groupBoxAdvantageAndInterference.Text = "Преимущество и помеха";
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Location = new System.Drawing.Point(6, 19);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(111, 17);
            this.radioButtonNormal.TabIndex = 2;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "Обычный бросок";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            // 
            // radioButtonInterference
            // 
            this.radioButtonInterference.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonInterference.AutoSize = true;
            this.radioButtonInterference.Location = new System.Drawing.Point(6, 63);
            this.radioButtonInterference.Name = "radioButtonInterference";
            this.radioButtonInterference.Size = new System.Drawing.Size(64, 17);
            this.radioButtonInterference.TabIndex = 1;
            this.radioButtonInterference.TabStop = true;
            this.radioButtonInterference.Text = "Помеха";
            this.radioButtonInterference.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdvantage
            // 
            this.radioButtonAdvantage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonAdvantage.AutoSize = true;
            this.radioButtonAdvantage.Location = new System.Drawing.Point(6, 42);
            this.radioButtonAdvantage.Name = "radioButtonAdvantage";
            this.radioButtonAdvantage.Size = new System.Drawing.Size(102, 17);
            this.radioButtonAdvantage.TabIndex = 0;
            this.radioButtonAdvantage.TabStop = true;
            this.radioButtonAdvantage.Text = "Преимущество";
            this.radioButtonAdvantage.UseVisualStyleBackColor = true;
            // 
            // labelPlusDices
            // 
            this.labelPlusDices.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPlusDices.AutoSize = true;
            this.labelPlusDices.Location = new System.Drawing.Point(206, 27);
            this.labelPlusDices.Name = "labelPlusDices";
            this.labelPlusDices.Size = new System.Drawing.Size(77, 13);
            this.labelPlusDices.TabIndex = 6;
            this.labelPlusDices.Text = "Модификатор";
            // 
            // labelCountDices
            // 
            this.labelCountDices.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCountDices.AutoSize = true;
            this.labelCountDices.Location = new System.Drawing.Point(110, 27);
            this.labelCountDices.Name = "labelCountDices";
            this.labelCountDices.Size = new System.Drawing.Size(66, 13);
            this.labelCountDices.TabIndex = 5;
            this.labelCountDices.Text = "Количество";
            // 
            // numericUpDownPlusDices
            // 
            this.numericUpDownPlusDices.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownPlusDices.Location = new System.Drawing.Point(206, 46);
            this.numericUpDownPlusDices.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPlusDices.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownPlusDices.Name = "numericUpDownPlusDices";
            this.numericUpDownPlusDices.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownPlusDices.TabIndex = 4;
            // 
            // numericUpDownCountDices
            // 
            this.numericUpDownCountDices.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownCountDices.Location = new System.Drawing.Point(106, 46);
            this.numericUpDownCountDices.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownCountDices.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCountDices.Name = "numericUpDownCountDices";
            this.numericUpDownCountDices.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownCountDices.TabIndex = 3;
            this.numericUpDownCountDices.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelDice
            // 
            this.labelDice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDice.AutoSize = true;
            this.labelDice.Location = new System.Drawing.Point(25, 27);
            this.labelDice.Name = "labelDice";
            this.labelDice.Size = new System.Drawing.Size(37, 13);
            this.labelDice.TabIndex = 2;
            this.labelDice.Text = "Кубик";
            // 
            // comboBoxDice
            // 
            this.comboBoxDice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxDice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDice.FormattingEnabled = true;
            this.comboBoxDice.Items.AddRange(new object[] {
            "к20",
            "к10",
            "к8",
            "к6",
            "к4",
            "к2",
            "к100"});
            this.comboBoxDice.Location = new System.Drawing.Point(6, 46);
            this.comboBoxDice.Name = "comboBoxDice";
            this.comboBoxDice.Size = new System.Drawing.Size(74, 21);
            this.comboBoxDice.TabIndex = 1;
            // 
            // panelBattlefield
            // 
            this.panelBattlefield.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBattlefield.Location = new System.Drawing.Point(306, 3);
            this.panelBattlefield.Name = "panelBattlefield";
            this.panelBattlefield.Size = new System.Drawing.Size(924, 518);
            this.panelBattlefield.TabIndex = 9;
            // 
            // показатьПерсонажейToolStripMenuItem
            // 
            this.показатьПерсонажейToolStripMenuItem.Name = "показатьПерсонажейToolStripMenuItem";
            this.показатьПерсонажейToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.показатьПерсонажейToolStripMenuItem.Text = "Показать персонажей";
            this.показатьПерсонажейToolStripMenuItem.Click += new System.EventHandler(this.показатьПерсонажейToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 571);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "Dungeon and Dragons";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMyCharacter.ResumeLayout(false);
            this.tabPageMyCharacter.PerformLayout();
            this.panelChatAndDices.ResumeLayout(false);
            this.panelChat.ResumeLayout(false);
            this.panelChat.PerformLayout();
            this.groupBoxDices.ResumeLayout(false);
            this.groupBoxDices.PerformLayout();
            this.groupBoxAdvantageAndInterference.ResumeLayout(false);
            this.groupBoxAdvantageAndInterference.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlusDices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountDices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Panel panelBattlefield;
        private System.Windows.Forms.Panel panelChatAndDices;
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.TextBox textBoxChatMessage;
        private System.Windows.Forms.Button buttonSendChatMessage;
        private System.Windows.Forms.GroupBox groupBoxDices;
        private System.Windows.Forms.Button buttonThrowDice;
        private System.Windows.Forms.GroupBox groupBoxAdvantageAndInterference;
        private System.Windows.Forms.RadioButton radioButtonNormal;
        private System.Windows.Forms.RadioButton radioButtonInterference;
        private System.Windows.Forms.RadioButton radioButtonAdvantage;
        private System.Windows.Forms.Label labelPlusDices;
        private System.Windows.Forms.Label labelCountDices;
        private System.Windows.Forms.NumericUpDown numericUpDownPlusDices;
        private System.Windows.Forms.NumericUpDown numericUpDownCountDices;
        private System.Windows.Forms.Label labelDice;
        private System.Windows.Forms.ComboBox comboBoxDice;
        private System.Windows.Forms.ToolStripMenuItem показатьПерсонажейToolStripMenuItem;
        // private AxAcroPDFLib.AxAcroPDF axAcroPDFRules;
    }
}

