namespace VTuberManagementSimulator
{
    class CreateScene : IScene
    {
        private readonly Managers managers;
        public CreateScene(Managers managers)
        {
            this.managers = managers;
        }

        private int totalPoints = 30;
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

            int game, music, cute, mental, physical;

            while (true)
            {
                AutoDistributeStats(
                    totalPoints,
                    out game,
                    out music,
                    out cute,
                    out mental,
                    out physical
                );

                DrawStatScreen(name, game, music, cute, mental, physical);

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Spacebar)
                {
                    continue;
                }
                else if (key == ConsoleKey.Enter)
                {
                    var vtuber = new Vtuber(name, game, music, cute, mental, physical);
                    var gameManager = new GameManager(vtuber);

                    managers.setGM(gameManager);
                    managers.Scene.ChangeScene(new MainScene(managers));
                    return;
                }
            }
        }
        private void AutoDistributeStats(int totalPoints, out int game, out int music, out int cute, out int mental, out int physical)
        {
            int statsCount = 5;

            game = music = cute = mental = physical = 1;
            int remain = totalPoints - statsCount;

            Random rand = new Random();

            while (remain > 0)
            {
                int r = rand.Next(5);
                switch (r)
                {
                    case 0:
                        game++;
                        break;
                    case 1:
                        music++;
                        break;
                    case 2:
                        cute++;
                        break;
                    case 3:
                        mental++;
                        break;
                    case 4:
                        physical++;
                        break;
                }
                remain--;
            }
        }

        private void DrawStatScreen(string name, int game, int music, int cute, int mental, int physical)
        {
            Console.Clear();
            Console.WriteLine($"이름: {name}");
            Console.WriteLine();
            Console.WriteLine($"Game      : {game}");
            Console.WriteLine($"Music     : {music}");
            Console.WriteLine($"Cute      : {cute}");
            Console.WriteLine($"Mental    : {mental}");
            Console.WriteLine($"Physical  : {physical}");
            Console.WriteLine();
            Console.WriteLine($"총 포인트: {totalPoints}");
            Console.WriteLine();
            Console.WriteLine("[Space] 다시 굴리기");
            Console.WriteLine("[Enter] 이 설정으로 시작");
        }
    }
}
