using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'waitinglist' del bot. Este comando muestra
/// la lista de jugadores esperando para jugar.
/// </summary>
public class WaitingCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'waitinglist'. Este comando muestra la lista de
    /// jugadores esperando para jugar.
    /// </summary>
    [Command("waitinglist")]
    [Summary("Muestra los usuarios en la lista de espera")]
    [Alias("waiting", "whoiswaiting")]
    public async Task UserInfoAsync()
    {
        string usersWaiting =
            string.Join(",", TrainersWaitingList.Instance.GetAllUsernames());
        if (string.IsNullOrEmpty(usersWaiting))
        {
            await ReplyAsync("No hay nadie esperando");
        }
        else
        {
            await ReplyAsync($"Esperan: {usersWaiting}");
        }
    }
}
