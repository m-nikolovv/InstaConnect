using InstaConnect.Common.Infrastructure.Features.Caches.Models;

namespace InstaConnect.Common.Infrastructure.Features.Hubs.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddHubs(IConfiguration configuration)
		{
			var options = configuration.GetOptions<RedisOptions>(RedisOptions.SectionName);

			serviceCollection.AddSignalR()
				.AddStackExchangeRedis(options.ConnectionString);

			return serviceCollection;
		}
	}
}
