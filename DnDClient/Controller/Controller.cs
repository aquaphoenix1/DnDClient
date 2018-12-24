using System;

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

        internal static void SetUserName(string name)
        {
            UserName = name;
        }
    }
}