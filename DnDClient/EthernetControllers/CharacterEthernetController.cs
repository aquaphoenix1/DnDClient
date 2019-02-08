namespace DnDClient.EthernetControllers
{
    class CharacterEthernetController : Ethernet.Controller
    {
        //private const int PORT = 61623;
        private const string CHARACTER_PATH = "api/Characters";

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

        private CharacterEthernetController(string url) : base(url, CHARACTER_PATH) { }
    }
}