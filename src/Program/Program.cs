using Ucu.Poo.DiscordBot.Services;

namespace Ucu.Poo.DiscordBot.Program;

/// <summary>
/// Un programa que implementa un bot de Discord.
/// </summary>
class Program
{
    /// <summary>
    /// Punto de entrada al programa.
    /// </summary>
    private static void Main(string[] args)
    {
        BotLoader.LoadAsync(args).GetAwaiter().GetResult();
    }
}
