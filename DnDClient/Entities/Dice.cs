using System;

namespace DnDClient.Entities
{
    class Dice
    {
        public enum AdvantageAndInterferenceEnum
        {
            Normal = 0,
            Advantage = 1,
            Interference = -1
        }

        public int CountDices { get; private set; }
        public int Edges { get; private set; }
        public int Bonus { get; private set; }
        public AdvantageAndInterferenceEnum AdvantageAndInterference { get; set; }

        public Dice(int countDices, int edges, AdvantageAndInterferenceEnum advantageAndInterferenceEnum, int bonus = 0)
        {
            CountDices = countDices;
            Edges = edges;
            Bonus = bonus;
            AdvantageAndInterference = advantageAndInterferenceEnum;
        }

        public static int GetCountEdged(string selectedValue)
        {
            return int.Parse(selectedValue.Substring(1));
        }
    }
}
