using VTuberManagementSimulator;

class SaveScene : IScene
{
    private readonly Managers managers;

    public SaveScene(Managers managers)
    {
        this.managers = managers;
    }

    private const int MaxSlot = 3;

    public void Enter()
    {
        Console.Clear();
        Draw();
    }

    public void Update()
    {
        Console.Write("저장할 슬롯 번호 (0: 취소): ");
        string input = Console.ReadLine() ?? "";

        if (input == "0")
        {
            managers.Scene.ChangeScene(new MainScene(managers));
            return;
        }

        if (!int.TryParse(input, out int slot) || slot < 1 || slot > MaxSlot)
        {
            Console.WriteLine("잘못된 입력입니다.");
            return;
        }

        managers.Save.SaveGame(slot, managers.Game);
        Console.WriteLine("저장 완료!");

        managers.Scene.ChangeScene(new MainScene(managers));
    }

    public void Exit() { }

    private void Draw()
    {
        Console.WriteLine("=== 게임 저장 ===");
        Console.WriteLine();

        for (int i = 1; i <= MaxSlot; i++)
        {
            var preview = managers.Save.GetPreview(i);

            if (!preview.Exists)
                Console.WriteLine($"{i}. [비어 있음]");
            else
                Console.WriteLine($"{i}. Day {preview.Day} | {preview.SavedAt:yyyy-MM-dd HH:mm}");
        }

        Console.WriteLine();
        Console.WriteLine("0. 취소");
        Console.WriteLine();
    }
}
