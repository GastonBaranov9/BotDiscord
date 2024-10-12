namespace Library;

using Discord;
using Discord.WebSocket;
using Discord.Commands;

public class LoggingService
{
    public LoggingService(DiscordSocketClient client, CommandService command)
    {
        if (client != null)
            client.Log += LogAsync;
        if (command != null)
            command.Log += LogAsync;
    }
    private Task LogAsync(LogMessage message)
    {
        if (message.Exception is CommandException cmdException)
        {
            Console.WriteLine($"[Command/{message.Severity}] {cmdException.Command.Aliases.First()}"
                + $" failed to execute in {cmdException.Context.Channel}.");
            Console.WriteLine(cmdException);
        }
        else
            Console.WriteLine($"[General/{message.Severity}] {message}");

        return Task.CompletedTask;
    }
}
