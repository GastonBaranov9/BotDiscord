using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'join' del bot. Este comando une al jugador
/// que envía el mensaje a la lista de jugadores esperando para jugar.
/// </summary>
public class JoinCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'join'. Este comando une al jugador que envía el
    /// mensaje a la lista de jugadores esperando para jugar.
    /// </summary>
    [Command("join")]
    [Summary("Une el usuario que envía el mensaje a la lista de espera")]
    public async Task UserInfoAsync()
    {
        string username = Context.Message.Author.Username;
        if (TrainersWaitingList.Instance.AddTrainer(username))
        {
            await ReplyAsync($"{username} agregado a la lista de espera");
        }
        else
        {
            await ReplyAsync($"{username} ya está en la lista de espera");
        }
    }
}
