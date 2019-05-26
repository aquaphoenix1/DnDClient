using Newtonsoft.Json;
using static DnDClient.CharactersForm;

namespace DnDClient.Controller
{
    public class CharacterController
    {
        internal static void CharacterGetMessage(dynamic value)
        {
            bool isFlag = false;
            foreach (var element in value)
            {
                var userName = element.Name;

                if (userName.Equals(Controller.UserName))
                {
                    //continue; TODO remove comment
                }

                var panels = Controller.CharactersPanel.Controls;

                foreach (var p in panels)
                {
                    if ((p as CharacterPanel).UserName.Equals(userName))
                    {
                        //ChangeExistsUser(p as CharacterPanel, element);//TODO remove comment
                        isFlag = true;
                        break;
                    }
                }

                if (!isFlag)
                {
                    CharactersForm.AddNewUser(element);
                    var result = EthernetControllers.CharacterEthernetController.GetController().SendRequest("GET", JsonConvert.SerializeObject(new { Name = userName }));

                    foreach (var p in panels)
                    {
                        if ((p as CharacterPanel).UserName.Equals(userName))
                        {
                            ChangeExistsUser(p as CharacterPanel, JsonConvert.DeserializeObject(result));//TODO Check
                            break;
                        }
                    }
                }

                isFlag = false;
            }
        }

      

        private static void ChangeExistsUser(CharacterPanel characterPanel, dynamic value)
        {
            characterPanel.ChangeValues(value);
        }
    }
}