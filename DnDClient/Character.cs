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

        internal class Save
        {
            public bool IsChecked { get; set; }
            public string Value { get; set; }
            public string Name { get; set; }

            public Save(bool isChecked, string value, string name)
            {
                IsChecked = isChecked;
                Value = value;
                Name = name;
            }
        }

        internal class DeadAlive
        {
            public bool[] Deathes { get; set; } = new bool[3];
            public bool[] Alives { get; set; } = new bool[3];

            public DeadAlive(bool[] deathes, bool[] alives)
            {
                Deathes = deathes;
                Alives = alives;
            }
        }

        internal class Skill
        {
            public bool IsChecked { get; set; }
            public int Value { get; set; }
            public string Name { get; set; }

            public Skill(bool isChecked, int value, string name)
            {
                IsChecked = isChecked;
                Value = value;
                Name = name;
            }
        }

        internal class Weapon
        {
            public string Name { get; set; }
            public string Accuracy { get; set; }
            public string Damage { get; set; }

            public Weapon(string name, string accuracy, string damage)
            {
                Name = name;
                Accuracy = accuracy;
                Damage = damage;
            }
        }

        internal class Abilitiy
        {
            public string Name { get; set; }
            public string About { get; set; }
            public string Text { get; set; }

            public Abilitiy(string name, string about, string text)
            {
                Name = name;
                About = about;
                Text = text;
            }
        }

        internal class Equipment
        {
            public string Name { get; set; }
            public string About { get; set; }

            public Equipment(string name, string about)
            {
                Name = name;
                About = about;
            }
        }

        public string Name { get; set; }
        public List<Characteristic> Characteristics { get; set; }
        public int Mastery { get; set; }
        public List<Save> Saves { get; set; }
        public List<Skill> Skills { get; set; }
        public DeadAlive DeadAndAlive { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Abilitiy> Abilities { get; set; }
        public List<Equipment> Equipments { get; set; }
        public string UserName { get; set; }
        public string ClassAndLevel { get; set; }
        public string History { get; set; }
        public string Race { get; set; }
        public string God { get; set; }
        public int Speed { get; set; }
        public string Traits { get; set; }
        public string Ideals { get; set; }
        public string Attachment { get; set; }
        public string Weaknesses { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int TimeHP { get; set; }
        public string BoneHP { get; set; }
        public bool IsCheckedBoneHP { get; set; }
        public string Languages { get; set; }
        public int Passive { get; set; }
        public int XP { get; set; }
        public bool Inspiration { get; set; }
        public int KD { get; set; }
        public int Initiative { get; set; }
        public int CopperMoney { get; set; }
        public int SilverMoney { get; set; }
        public int ElectroMoney { get; set; }
        public int GoldMoney { get; set; }
        public int PlatinumMoney { get; set; }
        
        public string Hist { get; set; }

        public Character(string name, List<Characteristic> characteristics, int mastery, List<Save> saves, List<Skill> skills, DeadAlive deadAndAlive, List<Weapon> weapons, List<Abilitiy> abilities, List<Equipment> equipments, string userName, string classAndLevel, string history, string race, string god, int speed, string traits, string ideals, string attachment, string weaknesses, int maxHP, int currentHP, int timeHP, string boneHP, bool isCheckedBoneHP, string languages, int passive, int xP, bool inspiration, int kD, int initiative, int copperMoney, int silverMoney, int electroMoney, int goldMoney, int platinumMoney, string hist)
        {
            Name = name;
            Characteristics = characteristics;
            Mastery = mastery;
            Saves = saves;
            Skills = skills;
            DeadAndAlive = deadAndAlive;
            Weapons = weapons;
            Abilities = abilities;
            Equipments = equipments;
            UserName = userName;
            ClassAndLevel = classAndLevel;
            History = history;
            Race = race;
            God = god;
            Speed = speed;
            Traits = traits;
            Ideals = ideals;
            Attachment = attachment;
            Weaknesses = weaknesses;
            MaxHP = maxHP;
            CurrentHP = currentHP;
            TimeHP = timeHP;
            BoneHP = boneHP;
            IsCheckedBoneHP = IsCheckedBoneHP;
            Languages = languages;
            Passive = passive;
            XP = xP;
            Inspiration = inspiration;
            KD = kD;
            Initiative = initiative;
            CopperMoney = copperMoney;
            SilverMoney = silverMoney;
            ElectroMoney = electroMoney;
            GoldMoney = goldMoney;
            PlatinumMoney = platinumMoney;
            Hist = hist;
        }
    }
}
