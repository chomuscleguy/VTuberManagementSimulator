namespace VTuberManagementSimulator
{
    partial class TitleScene : IScene
    {
        private readonly Managers managers;

        public TitleScene(Managers managers)
        {
            this.managers = managers;
        }

        public void Enter()
        {
            Console.Clear();
            Draw();
        }

        public void Update()
        {
            string input = Console.ReadLine()!;

            switch (input)
            {
                case "1":
                    managers.Scene.ChangeScene(new StartScene(managers));
                    break;
                case "2":
                    managers.Scene.ChangeScene(new OptionScene());
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
            }
        }

        public void Exit() { }

        private void Draw()
        {
            Console.WriteLine("=== VTuber Management Simulator ===");
            Console.WriteLine("1. 시작");
            Console.WriteLine("2. 옵션");
            Console.WriteLine("3. 종료");
            Console.Write("번호 입력: ");
        }
    }
}