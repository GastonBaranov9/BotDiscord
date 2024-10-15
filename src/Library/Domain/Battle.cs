namespace Ucu.Poo.DiscordBot.Domain;

/// <summary>
/// Esta clase representa una batalla entre dos jugadores.
/// </summary>
public class Battle
{
    /// <summary>
    /// Obtiene un valor que representa el primer jugador.
    /// </summary>
    public string Player1 { get; }
    
    /// <summary>
    /// Obtiene un valor que representa al oponente.
    /// </summary>
    public string Player2 { get; }

    /// <summary>
    /// Inicializa una instancia de la clase <see cref="Battle"/> con los
    /// valores recibidos como argumento.
    /// </summary>
    /// <param name="player1">El primer jugador.</param>
    /// <param name="player2">El oponente.</param>
    public Battle(string player1, string player2)
    {
        this.Player1 = player1;
        this.Player2 = player2;
    }
}
