using System;

namespace VTuberManagementSimulator
{
    public class VtuberCreateData
    {
        public string Name { get; init; }
        public int Game { get; set; }
        public int Music { get; set; }
        public int Cute { get; set; }
        public int Mental { get; set; }
        public int Physical { get; set; }
    }

    public interface IVtuberFactory
    {
        Vtuber Create(VtuberCreateData data);
    }

    public class VtuberFactory : IVtuberFactory
    {
        private readonly Random _random = new();
        public Vtuber Create(VtuberCreateData input)
        {
            var stats = GenerateStats(30);

            return new Vtuber(
                input.Name,
                stats.Game,
                stats.Music,
                stats.Cute,
                stats.Mental,
                stats.Physical,
                0,
                0
            );
        }

        private VtuberCreateData GenerateStats(int total)
        {
            var data = new VtuberCreateData { Name = "" };

            data.Game = data.Music = data.Cute = data.Mental = data.Physical = 4;
            int remain = total - 20;

            while (remain-- > 0)
            {
                switch (_random.Next(5))
                {
                    case 0: data.Game++; break;
                    case 1: data.Music++; break;
                    case 2: data.Cute++; break;
                    case 3: data.Mental++; break;
                    case 4: data.Physical++; break;
                }
            }

            return data;
        }
    }
}
