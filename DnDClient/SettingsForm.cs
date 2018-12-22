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

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (textBoxServerURL.Text == "")
            {
                MessageBox.Show("Введите URL сервера");

                return;
            }

            SaveDefaultSettings();

            Hide();
        }
        public string GetURL()
        {
            return textBoxServerURL.Text;
        }

        internal void SetDefaultValues(string URL)
        {
            textBoxServerURL.Text = URL;
        }

        private void SaveDefaultSettings()
        {
            try
            {
                string currentPath = Directory.GetCurrentDirectory() + "\\settings.stgs";

                using (StreamWriter file = new StreamWriter(currentPath, false))
                {
                    file.Write(String.Format("URL {0}\r\n", textBoxServerURL.Text));
                }
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
        }

        private void buttonDecline_Click(object sender, EventArgs e)
        {
            if (!textBoxServerURL.Text.Equals(oldServerURL))
            {
                textBoxServerURL.Text = oldServerURL;
            }

            Hide();
        }
    }
}
