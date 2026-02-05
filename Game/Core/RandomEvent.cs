namespace VTuberManagementSimulator
{
    public interface IRandomEvent
    {
        string Name { get; }
        bool CanTrigger(IGameManager game);
        void Execute(IGameManager game);
    }
    public class RandomEvent
    {

    }

    public class ViralClipEvent : IRandomEvent
    {
        public string Name => "클립 영상이 떡상했다!";

        public bool CanTrigger(IGameManager game)
        {
            return game.Vtuber.Game >= 5;
        }

        public void Execute(IGameManager game)
        {
            int bonus = (int)game.Vtuber.Game * 50;
            game.Vtuber.GainSubscribers(bonus);

            Console.WriteLine($"[이벤트] {Name}");
            Console.WriteLine($"구독자 +{bonus}");
            Console.ReadKey();
        }
    }

    public class BurnoutEvent : IRandomEvent
    {
        public string Name => "번아웃이 왔다…";

        public bool CanTrigger(IGameManager game)
        {
            return game.Vtuber.Fatigue >= 80;
        }

        public void Execute(IGameManager game)
        {
            game.Vtuber.ReduceFatigue(20);
            game.Vtuber.ReduceMental(2);

            Console.WriteLine($"[이벤트] {Name}");
            Console.WriteLine("멘탈 -2, 피로 일부 감소");
            Console.ReadKey();
        }
    }

    public sealed class HatredCommentEvent : IRandomEvent
    {
        public string Name => "악플이 쏟아졌다…";

        public bool CanTrigger(IGameManager game)
        {
            // 애교가 낮거나 멘탈이 약하면 잘 터짐
            return game.Vtuber.Cute <= 4 || game.Vtuber.Mental <= 5;
        }

        public void Execute(IGameManager game)
        {
            var v = game.Vtuber;

            int mentalDamage = 2;
            int fatigueIncrease = 10;

            // 멘탈이 약하면 피해 증가
            if (v.Mental <= 3)
                mentalDamage += 2;

            // 애교가 낮으면 더 상처받음
            if (v.Cute <= 2)
                mentalDamage += 1;

            v.ReduceMental(mentalDamage);
            v.AddFatigue(fatigueIncrease);

            Console.WriteLine($"[이벤트] {Name}");
            Console.WriteLine($"악플에 멘탈이 흔들렸다.");
            Console.WriteLine($"멘탈 -{mentalDamage}, 피로 +{fatigueIncrease}");
            Console.ReadKey();
        }
    }
}
