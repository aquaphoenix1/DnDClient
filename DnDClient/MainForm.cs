using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace DnDClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ToChat(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => richTextBoxChat.AppendText(message + Environment.NewLine)));
            }
            else
            {
                richTextBoxChat.AppendText(message + Environment.NewLine);
            }
        }

        private int MAX_MESSAGES = 20;
        private Dictionary<int, string> chatMessages;

        internal void AddChatMessage(int id, string message)
        {
            if(chatMessages.Count > MAX_MESSAGES)
            {
                chatMessages.Remove(chatMessages.ElementAt(0).Key);
            }

            if (!chatMessages.ContainsKey(id))
            {
                chatMessages.Add(id, message);
                ToChat(message);
            }
        }

        private void ButtonSendChatMessage_Click(object sender, EventArgs e)
        {
            if (textBoxChatMessage.Text != "")
            {
                ChatEthernetController.GetController().SendChatMessage(Controller.Controller.UserName, textBoxChatMessage.Text);
                textBoxChatMessage.Text = "";
            }
        }

        private void CreateCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CreateCharacterForm(false, null).ShowDialog();
        }

        private void LoadCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите имя персонажа",
                       "Загрузка персонажа");

            if(input != "")
            {
                string path = Directory.GetCurrentDirectory() + "\\" + input;

                if (File.Exists(path))
                {
                    var text = File.ReadAllText(path);

                    dynamic element = JsonConvert.DeserializeObject(text);

                    var form = new CreateCharacterForm(true, element) {
                        AutoScroll = true,
                        TopLevel = false,
                        Name = "MyCharacter"
                    };

                    if(panelCharacter.Controls.Find("MyCharacter", true).Length > 0)
                    {
                        panelCharacter.Controls.RemoveAt(0);
                    }

                    panelCharacter.Controls.Add(form);
                    try
                    {
                        form.Show();
                    }
                    catch { }
                }
            }
        }

        private void сохранитьПерсонажаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var panel = panelCharacter.Controls.Find("MyCharacter", true);
            if(panel.Length > 0)
            {
                var form = panel[0] as CreateCharacterForm;
                form.SaveCharacter();
            }
        }

        private void редактироватьПерсонажаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите имя персонажа",
                       "Загрузка персонажа");

            if (input != "")
            {
                if (panelCharacter.Controls.Count > 0)
                {
                    panelCharacter.Controls.RemoveAt(0);
                }

                string path = Directory.GetCurrentDirectory() + "\\" + input;

                if (File.Exists(path))
                {
                    var text = File.ReadAllText(path);

                    dynamic element = JsonConvert.DeserializeObject(text);

                    try
                    {
                        new CreateCharacterForm(false, element).ShowDialog();
                    }
                    catch { }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chatMessages = new Dictionary<int, string>();
            try
            {
                var path = Directory.GetCurrentDirectory() + "\\rules.pdf";
                /*
                axAcroPDFRules.LoadFile(path);
                axAcroPDFRules.src = path;*/
            }
            catch { }

            radioButtonNormal.Checked = true;
            comboBoxDice.SelectedIndex = 0;
        }

        private void TabControlMain_Selected(object sender, TabControlEventArgs e)
        {/*
            axAcroPDFRules.Select();*/
        }

        private void ButtonThrowDice_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Controller.Controller.ShutDown();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ChatEthernetController.GetController().SendGoodBye(Controller.Controller.UserName);
            }
            catch { }
        }
    }
}
