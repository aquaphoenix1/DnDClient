using System;
using System.Windows.Forms;

namespace DnDClient
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var main = new MainForm();
            Controller.Controller.SetController(main);

            Application.Run(main);
            //Application.Run(new ConnectorForm());
        }
    }
}
