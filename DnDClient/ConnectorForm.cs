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

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ChatEthernetController.GetController(settingsForm.GetURL());
            ChatEthernetController.GetController().AddUpdater((o)=> { });
            this.Hide();
            new MainForm().ShowDialog();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        private void ConnectorForm_Load(object sender, EventArgs e)
        {
            try
            {/*
                string currentPath = Directory.GetCurrentDirectory() + "\\settings.stgs";

                string line;

                string URL = "";

                using (StreamReader file = new StreamReader(currentPath))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] array = line.Split(new char[] { ' ' });

                        if (array[0].Equals("URL"))
                        {
                            if (!array[1].Equals(""))
                            {
                                URL = array[1];
                            }
                        }
                        else
                        {
                            throw new Exception("Ошибка чтения файла настроек");
                        }
                    }
                }

                settingsForm.SetDefaultValues(URL);*/
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}