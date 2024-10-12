using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'leave' del bot. Este comando remueve el
/// jugador que envía el mensaje de la lista de jugadores esperando para jugar.
/// </summary>
public class LeaveCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'leave' del bot. Este comando remueve el jugador
    /// que envía el mensaje de la lista de jugadores esperando para jugar.
    /// </summary>
    [Command("leave")]
    [Summary("Remueve el usuario que envía el mensaje a la lista de espera")]
    public async Task UserInfoAsync()
    {
        string username = Context.Message.Author.Username;
        if (TrainersWaitingList.Instance.RemoveTrainer(username))
        {
            await ReplyAsync($"{username} removido de la lista de espera");
        }
        else
        {
            await ReplyAsync($"{username} no está en la lista de espera");
        }
    }
}
