namespace VTuberManagementSimulator
{
    sealed class GameContext
    {
        public IDataManager Data { get; }
        public IEventManager Events { get; }
        public IGameManager Game { get; set; }

        public GameContext( IDataManager data, IEventManager events)
        {
            Data = data;
            Events = events;
        }
    }
}