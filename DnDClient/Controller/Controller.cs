using System;
using System.Windows.Forms;

namespace DnDClient.Controller
{
    class Controller
    {
        public static MainForm MainForm { get; private set; }
        public static string UserName { get; private set; }
        public static ConnectorForm ConnectorForm { get; private set; }

        public static void SetController(MainForm main)
        {
            MainForm = main;
        }

        public static void SetController(ConnectorForm connectorForm)
        {
            ConnectorForm = connectorForm;
        }

        public static void SetUserName(string name)
        {
            UserName = name;
        }

        private static CharactersForm charactersForm = new CharactersForm();
        public static Panel CharactersPanel { get; private set; } = charactersForm.Controls.Find("panelCharacters", true)[0] as Panel;
        public static bool IsCharactersVisible { private set; get; } = false;

        public static void ToggleCharactersVisible()
        {
            if (IsCharactersVisible)
            {
                IsCharactersVisible = false;
                charactersForm.Hide();
                MainForm.ToggleCharactersVisible(IsCharactersVisible);
            }
            else
            {
                IsCharactersVisible = true;
                charactersForm.Show();
            }
        }
    }
}