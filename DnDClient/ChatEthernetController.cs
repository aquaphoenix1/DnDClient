using System;

namespace DnDClient
{
    class ChatEthernetController : Ethernet.Controller
    {
        private const string CHAT_PATH = "";//"account/";
        private const int PORT = 9999;

        private static ChatEthernetController controller;

        public static ChatEthernetController GetController() => controller;

        public static ChatEthernetController GetController(string url)
                => controller ?? (controller = new ChatEthernetController(url));

        private ChatEthernetController(string url) : base(url, PORT, CHAT_PATH) {}

        public void SendChatMessage(string message)
        {
            SendRequest(message, "POST");
        }
    }
}
