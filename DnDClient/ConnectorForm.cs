using DnDClient.Controller;
using DnDClient.EthernetControllers;
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
            var main = new MainForm();
            Controller.Controller.SetController(main);
            Controller.Controller.SetUserName(settingsForm.GetName());

            ChatEthernetController.GetController(settingsForm.GetURL());
            DiceEthernetController.GetController(settingsForm.GetURL());

            try
            {
                ChatEthernetController.GetController().SendHello(settingsForm.GetName());
                ChatEthernetController.GetController().AddUpdater(ChatController.ChatGetMessagesController);
            }
            catch {
                Controller.Controller.MainForm.DisableChat();
            }

            try
            {
                DiceEthernetController.GetController().SendHello();
                DiceEthernetController.GetController().AddUpdater(DiceController.DiceGetValueController);
            }
            catch
            {
                Controller.Controller.MainForm.DisableDices();
            }

            Hide();
            settingsForm.Close();
            main.ShowDialog();
            Close();
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