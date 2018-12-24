using DnDClient.Controller;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace DnDClient
{
    public partial class ConnectorForm : Form
    {
        private SettingsForm settingsForm;

        public ConnectorForm()
        {
            InitializeComponent();

            settingsForm = new SettingsForm();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            ChatEthernetController.GetController(settingsForm.GetURL());

            bool isConnected = false;

            try
            {
                var response = ChatEthernetController.GetController().SendHello(settingsForm.GetName());
                isConnected = true;
            }
            catch { }

            if (isConnected)
            {
                var main = new MainForm();
                Controller.Controller.SetController(main);
                Controller.Controller.SetUserName(settingsForm.GetName());
                ChatEthernetController.GetController().AddUpdater(ChatController.ChatGetMessagesController);
                Hide();
                settingsForm.Close();
                main.ShowDialog();
            }
            else
            {
                MessageBox.Show("Не удалось соединиться с сервером!");
            }
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        private void ConnectorForm_Load(object sender, EventArgs e)
        {
            try
            {
                string currentPath = Directory.GetCurrentDirectory() + "\\settings.stgs";

                string URL = "";
                string name = "";

                if (File.Exists(currentPath))
                {
                    var text = File.ReadAllText(currentPath);

                    dynamic element = JsonConvert.DeserializeObject(text);
                    URL = element.Http;
                    name = element.Name;
                }

                settingsForm.SetDefaultValues(name, URL);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}