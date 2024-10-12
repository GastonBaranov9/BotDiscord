namespace Ucu.Poo.DiscordBot.Domain;

/// <summary>
/// Esta clase representa la lista de jugadores esperando para jugar. Esta clase
/// es un singleton.
/// </summary>

public class TrainersWaitingList
{
    private static TrainersWaitingList? _instance;
    
    private List<Trainer> trainers = new List<Trainer>();

    /// <summary>
    /// Obtiene la única instancia de la clase <see cref="TrainersWaitingList"/>.
    /// </summary>
    public static TrainersWaitingList Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TrainersWaitingList();
            }

            return _instance;
        }
    }
    
    /// <summary>
    /// Agrega un jugador a la lista de espera.
    /// </summary>
    /// <param name="discordUsername">El nombre de usuario de Discord a agregar.
    /// </param>
    /// <returns><c>true</c> si se agrega el usuario; <c>false</c> en caso
    /// contrario.</returns>
    public bool AddTrainer(string discordUsername)
    {
        if (this.FindTrainerByDiscordUsername(discordUsername) == null)
        {
            trainers.Add(new Trainer(discordUsername));
            return true;
        }
        
        return false;
    }

    /// <summary>
    /// Remueve un jugador de la lista de espera.
    /// </summary>
    /// <param name="discordUsername">El nombre de usuario de Discord a remover.
    /// </param>
    /// <returns><c>true</c> si se remueve el usuario; <c>false</c> en caso
    /// contrario.</returns>
    public bool RemoveTrainer(string discordUsername)
    {
        Trainer? trainer = this.FindTrainerByDiscordUsername(discordUsername);
        if (trainer != null)
        {
            trainers.Remove(trainer);
            return true;
        }
        
        return false;
    }

    /// <summary>
    /// Busca un jugador por el nombre de usuario de Discord.
    /// </summary>
    /// <param name="discordUserName">El nombre de usuario de Discord a buscar.
    /// </param>
    /// <returns>El jugador encontrado o <c>null</c> en caso contrario.
    /// </returns>
    public Trainer? FindTrainerByDiscordUsername(string discordUserName)
    {
        foreach (Trainer trainer in this.trainers)
        {
            if (trainer.DiscordUsername == discordUserName)
            {
                return trainer;
            }
        }

        return null;
    }
}
