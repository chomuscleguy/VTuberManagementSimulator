namespace VTuberManagementSimulator
{
    public class VtuberSaveData
    {
        public string Name { get; set; } = "";
        public float Game { get; set; }
        public float Music { get; set; }
        public float Cute { get; set; }
        public float Mental { get; set; }
        public float Physical { get; set; }
        public float Subscribers { get; set; }
        public float Fatigue { get; set; }
    }

    public class GameSaveData
    {
        public int Version { get; set; } = 1;
        public DateTime SavedAt { get; set; }

        public int Day { get; set; }
        public VtuberSaveData Vtuber { get; set; } = new();
    }

    public class Monster
    {
        public int ID;
        public string Name;
        public int Hp;
        public int Attack;

        public Monster(int id, string name, int hp, int attack)
        {
            ID = id;
            Name = name;
            Hp = hp;
            Attack = attack;
        }
    }
    public class Item
    {
        public enum EquipSlot
        {
            None = 0,
            Weapon = 1,
            Shield = 2,
            Helmet = 3,
            Armor = 4,
            Gloves = 5,
            Boots = 6,
            Accessory = 7
        }

        public int ID;
        public string Name;
        public EquipSlot Slot;
        public int Attack;
        public int Defense;
        public string Option;

        public Item(int id, string name, EquipSlot slot, int atk, int def, string option)
        {
            ID = id;
            Name = name;
            Slot = slot;
            Attack = atk;
            Defense = def;
            Option = option;
        }
    }
    public class Job
    {
        public int ID;
        public string Name;
        public int BaseHP;
        public int BaseAtk;

        public Job(int id, string name, int baseHP, int baseAtk)
        {
            ID = id;
            Name = name;
            BaseHP = baseHP;
            BaseAtk = baseAtk;
        }
    }
}
