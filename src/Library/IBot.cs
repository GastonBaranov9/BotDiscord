using Microsoft.Extensions.DependencyInjection;

namespace Library;

public interface IBot
{
    Task StartAsync(ServiceProvider services);

    Task StopAsync();
}