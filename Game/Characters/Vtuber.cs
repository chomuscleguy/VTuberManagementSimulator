namespace VTuberManagementSimulator
{
    public class Vtuber
    {
        public string Name { get; private set; }
        public int Game { get; private set; }
        public int Music { get; private set; }
        public int Cute { get; private set; }
        public int Mental { get; private set; }
        public int Physical { get; private set; }
        public int Subscribers { get; private set; }
        public int Fatigue { get; private set; }

        private const int MAX_STAT = 100;

        public Vtuber(string name, int game, int music, int cute, int mental, int physical)
        {
            Name = name;
            Game = game;
            Music = music;
            Cute = cute;
            Mental = mental;
            Physical = physical;
            Subscribers = 0;
            Fatigue = 0;
        }

        public void SetState(int game, int music, int cute, int mental, int physical, int subscribers, int fatigue)
        {
            Game = game;
            Music = music;
            Cute = cute;
            Mental = mental;
            Physical = physical;
            Subscribers = subscribers;
            Fatigue = fatigue;
        }

        public void GainSubscribers(int value)
        {
            Subscribers += value;
        }

        public void IncreaseGame(int value)
        {
            Game += value;
        }
        public void IncreaseMusic(int value)
        {
            Music += value;
        }
        public void IncreaseCute(int value)
        {
            Cute += value;
        }

        public void AddFatigue(int amount)
        {
            if (amount <= 0)
                return;

            Fatigue += amount;

            if (Fatigue > MAX_STAT)
                Fatigue = MAX_STAT;
        }

        public void ReduceFatigue(int amount)
        {
            if (amount <= 0)
                return;

            Fatigue -= amount;

            if (Fatigue < 0)
                Fatigue = 0;
        }

        public void IncreaseMental(int amount)
        {
            if (amount <= 0)
                return;

            Mental += amount;

            if (Mental > MAX_STAT)
                Mental = MAX_STAT;
        }

        public void ReduceMental(int amount)
        {
            if (amount <= 0)
                return;

            Mental -= amount;

            if (Mental < 0)
                Mental = 0;
        }

        public void ApplyDailyDecay()
        {
            ReduceMental(1);

            if (Fatigue >= 70)
                ReduceMental(1);
        }
    }
}