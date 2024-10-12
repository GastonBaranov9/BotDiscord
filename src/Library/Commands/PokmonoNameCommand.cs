using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Logging;
using Discord.Commands;

namespace Library.Commands;

public class PokemonNameCommand : ModuleBase<SocketCommandContext>
{
    private readonly ILogger<PokemonNameCommand> _logger;
    private readonly HttpClient _httpClient;

    public PokemonNameCommand(ILogger<PokemonNameCommand> logger)
    {
        _logger = logger;

        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "DiscordBot");
    }

    [Command("name")]
    [Summary("Busca el nombre de un Pokémon por ID usando la PokéAPI")]
    public async Task ExecuteAsync([Remainder][Summary("ID")] string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            await ReplyAsync("Uso: !name <id>");
            return;
        }

        try
        {
            id = Uri.EscapeDataString(id);

            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}");

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
                _logger.LogError(exception.Message);
            }
           
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);    
        }
    }
}

public class PokemonNameResponse
{
    public List<PokemonNameItem>? List { get; set; }
}

public class PokemonNameItem
{
    public string? Definition { get; set; }
}
