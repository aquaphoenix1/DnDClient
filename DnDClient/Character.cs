using System.Collections.Generic;

namespace DnDClient
{
    class Character
    {
        internal class Characteristic
        {
            public string Name { get; set; }
            public int Value { get; set; }
            public int Bonus { get; set; }

            public Characteristic(string name, int value, int bonus)
            {
                this.Name = name;
                this.Value = value;
                this.Bonus = bonus;
            }
        }

        public string Name { get; set; }
        public List<Characteristic> Characteristics { get; set; }
        public int Mastery { get; set; }

        public Character(string name, List<Characteristic> characteristics, int mastery)
        {
            this.Name = name;
            this.Characteristics = characteristics;
            this.Mastery = mastery;
        }
    }
}
