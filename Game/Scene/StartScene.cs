namespace VTuberManagementSimulator
{
    class StartScene : IScene
    {
        private readonly Managers managers;

        public StartScene(Managers manager)
        {
            this.managers = manager;
        }

        public void Enter()
        {
            Console.Clear();
            Draw();
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            string input = Console.ReadLine()!;

            switch (input)
            {
                case "1":
                    managers.Scene.ChangeScene(new CreateScene(managers));
                    break;
                case "2":
                    managers.Scene.ChangeScene(new LoadScene(managers));
                    break;
                case "3":
                    managers.Scene.ChangeScene(new TitleScene(managers));
                    break;
            }
        }

        private void Draw()
        {
            Console.WriteLine("=== VTuber Management Simulator ===");
            Console.WriteLine("1. 새로시작");
            Console.WriteLine("2. 불러오기");
            Console.WriteLine("3. 뒤로가기");
            Console.Write("번호 입력: ");
        }
    }
}