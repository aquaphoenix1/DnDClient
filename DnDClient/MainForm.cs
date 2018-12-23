using Newtonsoft.Json;
using PdfiumViewer;
using System;
using System.Drawing;
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

        private void Console(string message)
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

        private void ButtonSendChatMessage_Click(object sender, EventArgs e)
        {
            ChatEthernetController.GetController().SendChatMessage("Dsd");
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

            if(panel != null)
            {
                Type t = typeof(CreateCharacterForm);

                System.Reflection.MethodInfo m = t.GetMethod("SaveCharacter");
                m.Invoke(panel[0], null);
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

        private void buttonThrowDice_Click(object sender, EventArgs e)
        {

        }
    }
}
