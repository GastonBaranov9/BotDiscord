using System.Net;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Logging;
using Discord.Commands;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'name' del bot. Este comando retorna el
/// nombre de un Pokémon dado su identificador.
/// </summary>
// ReSharper disable once UnusedType.Global
public class PokemonNameCommand : ModuleBase<SocketCommandContext>
{
    private readonly ILogger<PokemonNameCommand> logger;
    private readonly HttpClient httpClient;

    /// <summary>
    /// Inicializa una nueva instancia de la clase
    /// <see cref="PokemonNameCommand"/> con los valores recibidos como
    /// argumento.
    /// </summary>
    /// <param name="logger">El servicio de logging a utilizar.</param>
    public PokemonNameCommand(ILogger<PokemonNameCommand> logger)
    {
        this.logger = logger;

        httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add("User-Agent", "DiscordBot");
    }

    /// <summary>
    /// Implementa el comando 'name'. Este comando retorna el nombre de un
    /// Pokémon dado su identificador.
    /// </summary>
    /// <param name="id">El identificador del Pokémon a buscar.</param>
    [Command("name")]
    [Summary("Busca el nombre de un Pokémon por identificador usando la PokéAPI")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Remainder][Summary("ID")] int id = 0)
    {
        if (id <= 0)
        {
            await ReplyAsync("Uso: !name <id>");
            return;
        }

        try
        {
            var response = await httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}");

            if (string.IsNullOrEmpty(response))
            {
                await ReplyAsync($"No encontré nada para {id}");
                return;
            }
            
            JsonNode? pokemonNode = JsonNode.Parse(response);
            JsonNode? nameNode = pokemonNode?["name"];

            if (pokemonNode == null || nameNode == null)
            {
                await ReplyAsync($"No encontré el nombre de {id}");
            }
            else
            {
                await ReplyAsync(nameNode.GetValue<string>());
            }
        }
        catch (HttpRequestException exception)
        {
            if (exception.StatusCode == HttpStatusCode.NotFound)
            {
                await ReplyAsync("No lo encontré");
            }
            else
            {
                logger.LogError("HTTP error: {Message}", exception.Message);
            }
           
        }
        catch (Exception exception)
        {
            logger.LogError("Exception: {Message}", exception.Message);    
        }
    }
}
