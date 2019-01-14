using Newtonsoft.Json;

namespace DnDClient.EthernetControllers
{
    class ChatEthernetController : Ethernet.Controller
    {
        private const string CHAT_PATH = "api/chat";
        private const int PORT = 58830;

        private static ChatEthernetController controller;

        public static ChatEthernetController GetController() => controller;

        public static ChatEthernetController GetController(string url)
        {
            if (controller == null || controller.Url != url)
            {
                controller = new ChatEthernetController(url);
            }

            return controller;
        }

        private ChatEthernetController(string url) : base(url, PORT, CHAT_PATH) { }

        private class MessageToServer
        {
            public string Name { get; set; }
            public string Message { get; set; }

            public MessageToServer(string name, string message)
            {
                Name = name;
                Message = message;
            }
        }

        public void SendChatMessage(string name, string message)
        {
            var json = JsonConvert.SerializeObject(new MessageToServer(name, message));
            SendRequest("POST", json);
        }
    }
}