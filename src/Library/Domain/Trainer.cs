namespace Ucu.Poo.DiscordBot.Domain;

/// <summary>
/// Esta clase representa un jugador en el juego Pokémon.
/// </summary>
public class Trainer
{
    /// <summary>
    /// El nombre de usuario de Discord del jugador.
    /// </summary>
    public string DiscordUsername { get; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Trainer"/> con el
    /// nombre de usuario de Discord que se recibe como argumento.
    /// </summary>
    /// <param name="username">El nombre de usuario de Discord.</param>
    public Trainer(string username)
    {
        this.DiscordUsername = username;
    }
}
