namespace VTuberManagementSimulator
{
    class CreateScene : IScene
    {
        private readonly Managers managers;
        public CreateScene(Managers managers)
        {
            this.managers = managers;
        }

        public void Enter()
        {
            Console.Clear();
            CreateVtuber();
        }

        public void Exit() { }

        public void Update() { }

        private void CreateVtuber()
        {
            Console.Write("버튜버 이름을 입력하세요: ");
            string name = Console.ReadLine() ?? "";
            IVtuberFactory factory = new VtuberFactory();

            while (true)
            {
                var data = new VtuberCreateData { Name = name };
                var vtuber = factory.Create(data);

                DrawStatScreen(vtuber);

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Spacebar)
                {
                    continue;
                }
                else if (key == ConsoleKey.Enter)
                {
                    managers.setGM(new GameManager(vtuber));
                    managers.Scene.ChangeScene(new MainScene(managers));
                    return;
                }
            }
        }

        private void DrawStatScreen(Vtuber vtuber)
        {
            Console.Clear();
            Console.WriteLine($"이름: {vtuber.Name}");
            Console.WriteLine();
            Console.WriteLine($"Game      : {vtuber.Game}");
            Console.WriteLine($"Music     : {vtuber.Music}");
            Console.WriteLine($"Cute      : {vtuber.Cute}");
            Console.WriteLine($"Mental    : {vtuber.Mental}");
            Console.WriteLine($"Physical  : {vtuber.Physical}");
            Console.WriteLine();
            Console.WriteLine("[Space] 다시 굴리기");
            Console.WriteLine("[Enter] 이 설정으로 시작");
        }


    }
}
