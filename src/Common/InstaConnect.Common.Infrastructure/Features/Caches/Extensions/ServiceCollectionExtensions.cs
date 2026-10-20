using InstaConnect.Common.Application.Features.Caches.Abstractions;
using InstaConnect.Common.Application.Features.Caches.Helpers;
using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Caches.Helpers;
using InstaConnect.Common.Infrastructure.Features.Caches.Models;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddCaches(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<RedisOptions>(RedisOptions.SectionName);
			var options = configuration.GetOptions<RedisOptions>(RedisOptions.SectionName);

			serviceCollection.AddScoped<IJsonConverter, JsonConverter>()
							 .AddScoped<ICacheHandler, CacheHandler>()
							 .AddScoped<ICacheRequestFactory, CacheRequestFactory>();

			serviceCollection.AddStackExchangeRedisCache(redisOptions =>
				redisOptions.Configuration = options.ConnectionString);

			serviceCollection.AddHealthChecks()
							 .AddRedis(options.ConnectionString);

			return serviceCollection;
		}
	}
}
