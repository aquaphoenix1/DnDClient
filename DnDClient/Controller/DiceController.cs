namespace DnDClient.Controller
{
    class DiceController : Controller
    {
        public static void DiceGetValueController(dynamic value)
        {
            if(value != null)
            {
                var message = "";
                if (value.IsCritical)
                {
                    message = "Критический успех! ";
                }

                message += string.Format("Результат: {0}", value.Value);

                ChatEthernetController.GetController().SendChatMessage(Controller.UserName, message);
            }
        }
    }
}
