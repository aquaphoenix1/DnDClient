using DnDClient.Controller;
using DnDClient.EthernetControllers;
using DnDClient.Graphics;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Task.Factory.StartNew(() =>
            {
                BeginInvoke(new MethodInvoker(() => richTextBoxChat.AppendText(message + Environment.NewLine)));
            });
            /*if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => richTextBoxChat.AppendText(message + Environment.NewLine)));
            }
            else
            {
                richTextBoxChat.AppendText(message + Environment.NewLine);
            }*/
        }

        internal void AddChatMessage(string message)
        {
            ToChat(message);
        }

        internal void ToggleCharactersVisible(bool isCharactersVisible)
        {
            показатьПерсонажейToolStripMenuItem.Text = (isCharactersVisible) ? "Скрыть персонажей" : "Показать персонажей";
        }

        private void ButtonSendChatMessage_Click(object sender, EventArgs e)
        {
            if (textBoxChatMessage.Text != "")
            {
                ChatEthernetController.GetController().SendChatMessage(Controller.Controller.UserName, textBoxChatMessage.Text);
                textBoxChatMessage.Text = "";
            }
        }

        public void DisableChat()
        {
            textBoxChatMessage.Enabled = false;
            buttonSendChatMessage.Enabled = false;
        }

        public void DisableDices()
        {
            groupBoxDices.Enabled = false;
        }

        private void CreateCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CreateCharacterForm(false, null, false).ShowDialog();
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

                    var form = new CreateCharacterForm(true, element, false) {
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

                        CharacterEthernetController.GetController().SendRequest("GET", JsonConvert.SerializeObject(new { UserName = Controller.Controller.UserName, Value = element }));
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
                        new CreateCharacterForm(false, element, false).ShowDialog();
                    }
                    catch {
                        MessageBox.Show("Ошибка");
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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

            BattleField.CreateBattleField(panelBattlefield);
        }

        private void TabControlMain_Selected(object sender, TabControlEventArgs e)
        {/*
            axAcroPDFRules.Select();*/
        }

        private void ButtonThrowDice_Click(object sender, EventArgs e)
        {
            var advantageAndInterferenceEnum = radioButtonAdvantage.Checked ? Entities.Dice.AdvantageAndInterferenceEnum.Advantage :
                radioButtonInterference.Checked ? Entities.Dice.AdvantageAndInterferenceEnum.Interference : 
                Entities.Dice.AdvantageAndInterferenceEnum.Normal;

            var json = JsonConvert.SerializeObject(new Entities.Dice((int)numericUpDownCountDices.Value, Entities.Dice.GetCountEdged(comboBoxDice.SelectedItem.ToString()),
                advantageAndInterferenceEnum, (int)numericUpDownPlusDices.Value));

            try
            {
                Task.Factory.StartNew(() =>
                {
                    var response = DiceEthernetController.GetController().SendRequest("POST", json);
                    DiceController.DiceGetValueController(response);
                });
            }
            catch { }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ChatEthernetController.GetController().SendGoodBye(Controller.Controller.UserName);
            }
            catch { }
        }

        private void показатьПерсонажейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.Controller.ToggleCharactersVisible();
        }
    }
}
