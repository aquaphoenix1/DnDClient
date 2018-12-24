using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace DnDClient
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Введите имя");

                return;
            }

            if (textBoxServerURL.Text == "")
            {
                MessageBox.Show("Введите URL сервера");

                return;
            }

            SaveDefaultSettings();

            Hide();
        }

        public string GetName()
        {
            return textBoxName.Text;
        }

        public string GetURL()
        {
            return textBoxServerURL.Text;
        }

        internal void SetDefaultValues(string name, string URL)
        {
            textBoxServerURL.Text = URL;
            textBoxName.Text = name;
        }

        private class Settings
        {
            public string Name { get; set; }
            public string Http { get; set; }

            public Settings(string name, string http)
            {
                Name = name;
                Http = http;
            }
        }

        private void SaveDefaultSettings()
        {
            try
            {
                string currentPath = Directory.GetCurrentDirectory() + "\\settings.stgs";

                var json = JsonConvert.SerializeObject(new Settings(textBoxName.Text, textBoxServerURL.Text));

                File.WriteAllText(currentPath, json);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private string oldName;
        private string oldServerURL;

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            oldServerURL = textBoxServerURL.Text;
            oldName = textBoxName.Text;
        }

        private void ButtonDecline_Click(object sender, EventArgs e)
        {
            if (!textBoxName.Text.Equals(oldName))
            {
                textBoxName.Text = oldName;
            }

            if (!textBoxServerURL.Text.Equals(oldServerURL))
            {
                textBoxServerURL.Text = oldServerURL;
            }

            Hide();
        }
    }
}
