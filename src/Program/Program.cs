using Library;

namespace Program;

class Program
{
    private static void Main(string[] args)
    {
        BotLoader.LoadAsync(args).GetAwaiter().GetResult();
    }
}
