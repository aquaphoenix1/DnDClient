using Newtonsoft.Json;

namespace DnDClient.Controller
{
    class ChatController : Controller
    {
        public static void ChatGetMessagesController(dynamic value)
        {
            foreach (var e in value)
            {
                var a = int.Parse(e.Name);
                var b = e.Value.ToString();
                MainForm.AddChatMessage(int.Parse(e.Name), e.Value.ToString());
            }
        }
    }
}