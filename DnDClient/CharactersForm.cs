using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace DnDClient
{
    public partial class CharactersForm : Form
    {
        public class CharacterPanel : CreateCharacterForm
        {
            public string UserName { get; set; }

            public CharacterPanel(bool isLoad, object element, string userName) : base(isLoad, element, true)
            {
                UserName = userName;
            }
        }

        public CharactersForm()
        {
            InitializeComponent();
        }

        public static void AddNewUser(dynamic value)
        {
            foreach (var item in value)
            {
                /*var a = item.Value;
                var elem = JsonConvert.DeserializeObject(item);*/

                Controller.Controller.MainForm.Invoke((MethodInvoker) delegate()
                {
                    var panel = new CharacterPanel(true, item, value.Name)
                    {
                        AutoScroll = true,
                        TopLevel = false
                    };

                    Controller.Controller.CharactersPanel.Controls.Add(panel);

                    panel.Show();
                });

               
            }
        }
    }
}