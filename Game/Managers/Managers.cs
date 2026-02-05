namespace VTuberManagementSimulator
{
    public sealed class Managers
    {
        public IDataManager Data { get; }
        public IGameManager Game { get; private set; }
        public ISceneManager Scene { get; }
        public ISaveManager Save { get; }
        public IEventManager Event { get; }

        public Managers()
        {
            if (Data == null)
                Data = new DataManager();
            if (Scene == null)
                Scene = new SceneManager();
            if (Save == null)
                Save = new SaveManager();
            if (Event == null)
                Event = new EventManager();
            if (Game == null)
            {
                Vtuber vtuber = new Vtuber("",0.0f,0.0f,0.0f,0.0f,0.0f,0,0);
                Game = new GameManager(vtuber);
            }
        }
        public void setGM(IGameManager gm)
        {
            Game = gm;
        }
    }
}
