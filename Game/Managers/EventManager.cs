namespace VTuberManagementSimulator
{
    public interface IEventManager
    {
        void TryTriggerEvent(IGameManager game);
    }

    public class EventManager : IEventManager
    {
        private readonly List<IRandomEvent> events = new();
        private readonly Random random = new();

        public EventManager()
        {
            events.Add(new ViralClipEvent());
            events.Add(new BurnoutEvent());
            events.Add(new HatredCommentEvent());
        }

        public void Bind(IGameManager game)
        {
            game.OnDayEnded += TryTriggerEvent;
        }

        public void TryTriggerEvent(IGameManager game)
        {
            if (random.NextDouble() > 0.3)
                return;

            var candidates = events
                .Where(e => e.CanTrigger(game))
                .ToList();

            if (candidates.Count == 0)
                return;

            var ev = candidates[random.Next(candidates.Count)];
            ev.Execute(game);
        }
    }
}
