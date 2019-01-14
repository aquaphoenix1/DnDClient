namespace DnDClient.EthernetControllers
{
    class CharacterEthernetController : Ethernet.Controller
    {
        private const int PORT = 62354;
        private const string CHARACTER_PATH = "api/character";

        private static CharacterEthernetController controller;

        public static CharacterEthernetController GetController() => controller;

        public static CharacterEthernetController GetController(string url)
        {
            if (controller == null || controller.Url != url)
            {
                controller = new CharacterEthernetController(url);
            }

            return controller;
        }

        private CharacterEthernetController(string url) : base(url, PORT, CHARACTER_PATH) { }
    }
}