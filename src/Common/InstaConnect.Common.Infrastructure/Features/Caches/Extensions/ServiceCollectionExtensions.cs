using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Caches.Helpers;
using InstaConnect.Common.Infrastructure.Features.Caches.Models;

using Microsoft.Extensions.Caching.StackExchangeRedis;

using ZiggyCreatures.Caching.Fusion;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddCaches(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<RedisOptions>(RedisOptions.SectionName);
			var options = configuration.GetOptions<RedisOptions>(RedisOptions.SectionName);

			serviceCollection.AddFusionCache()
							 .WithDefaultEntryOptions(entryOptions => entryOptions.EnableAutoClone = true)
							 .WithSerializer(new BsonCacheSerializer())
							 .WithDistributedCache(new RedisCache(new RedisCacheOptions { Configuration = options.ConnectionString }))
							 .WithStackExchangeRedisBackplane(backplaneOptions => backplaneOptions.Configuration = options.ConnectionString);

			serviceCollection.AddScoped<ICacheHandler, CacheHandler>();

			serviceCollection.AddHealthChecks()
							 .AddRedis(options.ConnectionString);

			return serviceCollection;
		}
	}
}
