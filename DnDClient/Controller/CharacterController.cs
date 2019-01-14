using System;

namespace DnDClient.Controller
{
    class CharacterController
    {
        private class CharacterPanel : CreateCharacterForm
        {
            public string UserName { get; set; }

            public CharacterPanel(bool isLoad, object element, string userName) : base(isLoad, element, true)
            {
                UserName = userName;
            }
        }

        internal static void CharacterGetMessage(dynamic value)
        {
            var panels = Controller.CharactersPanel.Controls;

            var name = value.UserName;

            foreach(var p in panels)
            {
                if((p as CharacterPanel).UserName.Equals(name))
                {
                    ChangeExistsUser(p as CharacterPanel, value);
                    return;
                }
            }

            AddNewUser(value);
        }

        private static void AddNewUser(dynamic value)
        {
            var panel = new CharacterPanel(true, value, value.UserName);

            Controller.CharactersPanel.Controls.Add(panel);
        }

        private static void ChangeExistsUser(CharacterPanel characterPanel, dynamic value)
        {
            throw new NotImplementedException();
        }
    }
}