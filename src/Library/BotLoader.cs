using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Library;

public class BotLoader
{
    public static async Task LoadAsync(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();

        var serviceProvider = new ServiceCollection()
            .AddLogging(options =>
            {
                options.ClearProviders();
                options.AddConsole();
            })
            .AddSingleton<IConfiguration>(configuration)
            .AddScoped<IBot, Bot>()
            .BuildServiceProvider();

        try
        {
            IBot bot = serviceProvider.GetRequiredService<IBot>();

            await bot.StartAsync(serviceProvider);

            Console.WriteLine("Conectado a Discord. Presione 'q' para salir...");

            do
            {
                var keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Q)
                {
                    Console.WriteLine("\nShutting down!");

                    await bot.StopAsync();
                    return;
                }
            } while (true);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            Environment.Exit(-1);
        }
    }
}
