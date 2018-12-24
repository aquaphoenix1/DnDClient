using Newtonsoft.Json;

namespace DnDClient.Controller
{
    class DiceController : Controller
    {
        public static void DiceGetValueController(dynamic value)
        {
            if(value != null)
            {
                var elem = JsonConvert.DeserializeObject(value);
                var el = JsonConvert.DeserializeObject(elem);
                var message = "";
                if (bool.Parse(el.IsCritical.ToString()))
                {
                    message = "Критический успех! ";
                }

                message += string.Format("Результат: {0}", el.Value.ToString());

                ChatEthernetController.GetController().SendChatMessage(Controller.UserName, message);
            }
        }
    }
}
