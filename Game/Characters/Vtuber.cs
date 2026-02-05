namespace VTuberManagementSimulator
{
    public class Vtuber
    {
        public string Name { get; private set; }
        public float Game { get; private set; }
        public float Music { get; private set; }
        public float Cute { get; private set; }
        public float Mental { get; private set; }
        public float Physical { get; private set; }
        public float Subscribers { get; private set; }
        public float Fatigue { get; private set; }

        private const float MAX_STAT = 100.0f;

        public Vtuber(string name, float game, float music, float cute, float mental, float physical, float subscribers, float fatigue)
        {
            Name = name;
            Game = game;
            Music = music;
            Cute = cute;
            Mental = mental;
            Physical = physical;
            Subscribers = subscribers;
            Fatigue = fatigue;
        }

        public void SetState(float game, float music, float cute, float mental, float physical, float subscribers, float fatigue)
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