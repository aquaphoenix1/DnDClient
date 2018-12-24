using Newtonsoft.Json;

namespace DnDClient.Controller
{
    class ChatController : Controller
    {
        private static int lastMessageId = 0;

        public static void ChatGetMessagesController(dynamic value)
        {
            foreach (var e in value)
            {
                var a = int.Parse(e.Name);
                var b = e.Value.ToString();

                int id = int.Parse(e.Name);

                if(id > lastMessageId)
                {
                    lastMessageId = id;
                    MainForm.AddChatMessage(e.Value.ToString());
                }
            }
        }
    }
}