using System;

namespace VTuberManagementSimulator
{
    class LoadScene : IScene
    {
        private readonly Managers managers;
        public LoadScene(Managers managers)
        {
            this.managers = managers;
        }

        private const int MaxSlot = 3;
        private bool isRunning;

        public void Enter()
        {
            isRunning = true;
            Console.Clear();
            Draw();
        }

        public void Exit()
        {
            isRunning = false;
        }

        public void Update()
        {
            if (!isRunning)
                return;

            Console.Write("불러올 슬롯 번호 (0: 뒤로가기): ");
            string input = Console.ReadLine() ?? "";

            if (input == "0")
            {
                managers.Scene.ChangeScene(new TitleScene(managers));
                return;
            }

            if (!int.TryParse(input, out int slot) || slot < 1 || slot > MaxSlot)
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }

            var data = managers.Save.LoadGameData(slot);

            if (data == null)
            {
                Console.WriteLine("해당 슬롯에는 저장 데이터가 없습니다.");
                return;
            }

            managers.Game.ApplySave(data);

            Console.WriteLine("로드 성공!");
            managers.Scene.ChangeScene(new MainScene(managers));
        }

        private void Draw()
        {
            Console.WriteLine("=== 불러오기 ===");
            Console.WriteLine();

            for (int i = 1; i <= MaxSlot; i++)
            {
                var preview = managers.Save.GetPreview(i);

                if (!preview.Exists)
                {
                    Console.WriteLine($"{i}. [비어 있음]");
                }
                else
                {
                    Console.WriteLine(
                        $"{i}. Day {preview.Day} | 저장 시간: {preview.SavedAt:yyyy-MM-dd HH:mm}"
                    );
                }
            }

            Console.WriteLine();
            Console.WriteLine("0. 뒤로가기");
            Console.WriteLine();
        }
    }
}
