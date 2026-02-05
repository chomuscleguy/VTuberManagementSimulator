using static VTuberManagementSimulator.SaveManager;

namespace VTuberManagementSimulator
{
    public interface IGameManager
    {
        int Day { get; }
        Vtuber Vtuber { get; }

        void SetDay(int day);
        void NextDay();
        void PerformAction(DayAction action);

        event Action<IGameManager>? OnDayEnded;

        Vtuber ApplySave(GameSaveData data);
        GameSaveData ExtractSave();
    }

    public enum DayAction
    {
        // 방송
        StreamGame,
        StreamMusic,
        StreamChat,

        // 연습
        TrainGame,
        TrainMusic,
        TrainCute,

        // 기타
        Rest
    }

    class GameManager : IGameManager
    {
        public Vtuber Vtuber { get; }
        public event Action<IGameManager>? OnDayEnded;

        public int Day { get; private set; } = 1;

        public GameManager(Vtuber vtuber)
        {
            this.Vtuber = vtuber;
        }

        public void SetDay(int day)
        {
            Day = day;
        }

        public void PerformAction(DayAction action)
        {
            switch (action)
            {
                // 방송
                case DayAction.StreamGame:
                    DoStreamGame();
                    break;

                case DayAction.StreamMusic:
                    DoStreamMusic();
                    break;

                case DayAction.StreamChat:
                    DoStreamChat();
                    break;

                // 연습
                case DayAction.TrainGame:
                    DoTrainGame();
                    break;

                case DayAction.TrainMusic:
                    DoTrainMusic();
                    break;

                case DayAction.TrainCute:
                    DoTrainCute();
                    break;

                // 휴식
                case DayAction.Rest:
                    DoRest();
                    break;
            }

            NextDay();
        }

        public void NextDay()
        {
            Day++;
            Vtuber.ApplyDailyDecay();

            OnDayEnded?.Invoke(this);
        }

        // ================= 방송 =================

        private void DoStreamGame()
        {
            int subs = (int)Vtuber.Game * 15;
            Vtuber.GainSubscribers(subs);
            Vtuber.AddFatigue(25);
        }

        private void DoStreamMusic()
        {
            int subs = (int)Vtuber.Music * 15;
            Vtuber.GainSubscribers(subs);
            Vtuber.AddFatigue(25);
        }

        private void DoStreamChat()
        {
            int subs = (int)Vtuber.Cute * 12;
            Vtuber.GainSubscribers(subs);
            Vtuber.AddFatigue(20);
        }

        // ================= 연습 =================

        private void DoTrainGame()
        {
            Vtuber.IncreaseGame(1);
            Vtuber.AddFatigue(10);
        }

        private void DoTrainMusic()
        {
            Vtuber.IncreaseMusic(1);
            Vtuber.AddFatigue(10);
        }

        private void DoTrainCute()
        {
            Vtuber.IncreaseCute(1);
            Vtuber.AddFatigue(10);
        }

        // ================= 휴식 =================

        private void DoRest()
        {
            Vtuber.ReduceFatigue(30);
        }

        public GameSaveData ExtractSave()
        {
            return new GameSaveData
            {
                Day = Day,
                Vtuber = new VtuberSaveData
                {
                    Name = Vtuber.Name,
                    Game = Vtuber.Game,
                    Music = Vtuber.Music,
                    Cute = Vtuber.Cute,
                    Mental = Vtuber.Mental,
                    Physical = Vtuber.Physical,
                    Subscribers = Vtuber.Subscribers,
                    Fatigue = Vtuber.Fatigue
                }
            };
        }

        public Vtuber ApplySave(GameSaveData data)
        {
            Day = data.Day;
            Vtuber.SetState(
                data.Vtuber.Game,
                data.Vtuber.Music,
                data.Vtuber.Cute,
                data.Vtuber.Mental,
                data.Vtuber.Physical,
                data.Vtuber.Subscribers,
                data.Vtuber.Fatigue
            );

            return Vtuber;
        }
    }
}
