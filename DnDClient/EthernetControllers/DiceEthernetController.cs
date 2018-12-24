﻿namespace DnDClient.EthernetControllers
{
    class DiceEthernetController : Ethernet.Controller
    {
        private const int PORT = 61623;
        private const string DICE_PATH = "api/dice";

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

        private DiceEthernetController(string url) : base(url, PORT, DICE_PATH) { }
    }
}