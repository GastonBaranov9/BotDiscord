using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'userinfo', alias 'who' o 'whois' del bot.
/// Este comando retorna información sobre el usuario que envía el mensaje o sobre
/// otro usuario si se incluye como parámetro..
/// </summary>
public class UserInfoCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'userinfo', alias 'who' o 'whois' del bot.
    /// </summary>
    /// <param name="user">El nombre de usuario de Discord a buscar.</param>
    [Command("userinfo")]
    [Summary(@"""Devuelve información sobre el usuario que envía el mensaje o
        sobre otro usuario si se provee.""")]
    [Alias("who", "whois")]
    public async Task UserInfoAsync(
        [Summary("El usuario (opcional) del que tener información.")]
        SocketUser? user = null)
    {
        var userInfo = user ?? Context.Message.Author;
        
        Trainer? trainer = TrainersWaitingList.Instance
            .FindTrainerByDiscordUsername(userInfo.Username);
        string isTrainer = trainer == null ? "no está esperando" : "esperando";
        
        await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}; {isTrainer}");
    }
}
