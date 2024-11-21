using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Services;

namespace Program;

/// <summary>
/// Un programa que implementa un bot de Discord.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Punto de entrada al programa.
    /// </summary>
    private static void Main()
    {
        //DemoFacade();
        DemoBot();
    }

    private static void DemoFacade()
    {
        Console.WriteLine(Facade.Instance.AddTrainerToWaitingList("player"));
        Console.WriteLine(Facade.Instance.AddTrainerToWaitingList("opponent"));
        Console.WriteLine(Facade.Instance.GetAllTrainersWaiting());
        Console.WriteLine(Facade.Instance.StartBattle("player", "opponent"));
        Console.WriteLine(Facade.Instance.GetAllTrainersWaiting());
    }

    private static void DemoBot()
    {
        BotLoader.LoadAsync().GetAwaiter().GetResult();
    }
}
