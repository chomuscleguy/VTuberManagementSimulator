using VTuberManagementSimulator;

public class MainScene : IScene
{
    private readonly Managers managers;

    public MainScene(Managers managers)
    {
        this.managers = managers;
    }

    public void Enter()
    {
        Console.Clear();
        ShowStatus();
        ShowMainMenu();
    }

    public void Update()
    {
        string input = Console.ReadLine()!;

        switch (input)
        {
            case "1":
                ShowStreamMenu();
                break;
            case "2":
                ShowTrainingMenu();
                break;
            case "3":
                managers.Game.PerformAction(DayAction.Rest);
                managers.Scene.ChangeScene(this);
                break;
            case "4":
                managers.Scene.ChangeScene(new SaveScene(managers));
                break;
            case "5":
                managers.Scene.ChangeScene(new TitleScene(managers));
                break;
        }
    }

    public void Exit() { }

    private void ShowStatus()
    {
        var v = managers.Game.Vtuber;
        Console.WriteLine($"Day {managers.Game.Day}");
        Console.WriteLine($"구독자: {v.Subscribers}");
        Console.WriteLine($"게임: {v.Game}");
        Console.WriteLine($"음악: {v.Music}");
        Console.WriteLine($"애교: {v.Cute}");
        Console.WriteLine($"피로: {v.Fatigue}");
        Console.WriteLine();
    }

    private void ShowMainMenu()
    {
        Console.WriteLine("1. 방송");
        Console.WriteLine("2. 연습");
        Console.WriteLine("3. 휴식");
        Console.WriteLine("4. 저장");
        Console.WriteLine("5. 종료");
        Console.Write("선택: ");
    }

    private void ShowStreamMenu()
    {
        Console.Clear();
        Console.WriteLine("방송 종류를 선택하세요");
        Console.WriteLine("1. 게임 방송");
        Console.WriteLine("2. 노래 방송");
        Console.WriteLine("3. 잡담 방송");
        Console.Write("선택: ");

        string input = Console.ReadLine()!;
        switch (input)
        {
            case "1": managers.Game.PerformAction(DayAction.StreamGame); break;
            case "2": managers.Game.PerformAction(DayAction.StreamMusic); break;
            case "3": managers.Game.PerformAction(DayAction.StreamChat); break;
        }

        managers.Scene.ChangeScene(this);
    }

    private void ShowTrainingMenu()
    {
        Console.Clear();
        Console.WriteLine("연습 종류를 선택하세요");
        Console.WriteLine("1. 게임 연습");
        Console.WriteLine("2. 노래 연습");
        Console.WriteLine("3. 애교 연습");
        Console.Write("선택: ");

        string input = Console.ReadLine()!;
        switch (input)
        {
            case "1": managers.Game.PerformAction(DayAction.TrainGame); break;
            case "2": managers.Game.PerformAction(DayAction.TrainMusic); break;
            case "3": managers.Game.PerformAction(DayAction.TrainCute); break;
        }

        managers.Scene.ChangeScene(this);
    }
}
