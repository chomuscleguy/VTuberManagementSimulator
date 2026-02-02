using System.Threading;

namespace VTuberManagementSimulator
{
    public interface IDataManager
    {
        IReadOnlyDictionary<int, Monster> Monsters { get; }
        IReadOnlyDictionary<int, Item> Items { get; }
        IReadOnlyDictionary<int, Job> Jobs { get; }
    }

    class DataManager : IDataManager
    {
        private readonly Dictionary<int, Monster> monsters = new();
        private readonly Dictionary<int, Item> items = new();
        private readonly Dictionary<int, Job> jobs = new();

        public DataManager()
        {
            LoadMonsters();
            LoadItems();
            LoadJobs();
        }

        public Monster GetMonster(int id)
        {
            return monsters[id];
        }

        public Item GetItem(int id)
        {
            return items[id];
        }
        public Job GetJob(int id)
        {
            return jobs[id];
        }


        public IReadOnlyDictionary<int, Monster> Monsters => monsters;
        public IReadOnlyDictionary<int, Item> Items => items;
        public IReadOnlyDictionary<int, Job> Jobs => jobs;

        private const string DataPath = "Data";

        private string MonsterPath => Path.Combine(DataPath, "monsters.csv");
        private string ItemPath => Path.Combine(DataPath, "items.csv");
        private string JobPath => Path.Combine(DataPath, "jobs.csv");

        public void LoadMonsters()
        {
            var lines = File.ReadAllLines(MonsterPath);

            for (int i = 1; i < lines.Length; i++)
            {
                var c = lines[i].Split(',');

                int id = int.Parse(c[0]);
                string name = c[1];
                int hp = int.Parse(c[2]);
                int atk = int.Parse(c[3]);

                var monster = new Monster(id, name, hp, atk);
                monsters.Add(id, monster);
            }

            Console.WriteLine("몬스터 데이터 로드 완료!");
        }

        public void LoadItems()
        {
            var lines = File.ReadAllLines(ItemPath);

            for (int i = 1; i < lines.Length; i++)
            {
                var c = lines[i].Split(',');

                int id = int.Parse(c[0]);
                string name = c[1];
                Item.EquipSlot slot = Enum.TryParse(c[2], out Item.EquipSlot s) ? s : Item.EquipSlot.None;
                int atk = int.Parse(c[3]);
                int def = int.Parse(c[4]);
                string option = c[5];

                var item = new Item(id, name, slot, atk, def, option);
                items.Add(id, item);
            }

            Console.WriteLine("아이템 데이터 로드 완료!");
        }

        public void LoadJobs()
        {
            var lines = File.ReadAllLines(JobPath);

            for (int i = 1; i < lines.Length; i++)
            {
                var c = lines[i].Split(',');

                int id = int.Parse(c[0]);
                string name = c[1];
                int baseHP = int.Parse(c[2]);
                int baseAtk = int.Parse(c[3]);

                var job = new Job(id, name, baseHP, baseAtk);
                jobs.Add(id, job);
            }

            Console.WriteLine("직업 데이터 로드 완료!");
        }
    }
}
