namespace DnDClient.EthernetControllers
{
    class DiceEthernetController : Ethernet.Controller
    {
        private const string DICE_PATH = "api/Dice";

        private static DiceEthernetController controller;

        public static DiceEthernetController GetController() => controller;

        public static DiceEthernetController GetController(string url)
        {
            if (controller == null || controller.Url != url)
            {
                controller = new DiceEthernetController(url);
            }

            return controller;
        }

        private DiceEthernetController(string url) : base(url, DICE_PATH) { }
    }
}