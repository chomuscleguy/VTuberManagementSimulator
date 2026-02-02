namespace VTuberManagementSimulator
{
    public readonly struct GameDayContext
    {
        public int Day { get; }
        public Vtuber Vtuber { get; }

        public GameDayContext(int day, Vtuber vtuber)
        {
            Day = day;
            Vtuber = vtuber;
        }
    }
}
