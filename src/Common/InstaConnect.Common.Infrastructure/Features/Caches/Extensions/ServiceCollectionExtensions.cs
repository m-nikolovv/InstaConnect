using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Caches.Helpers;
using InstaConnect.Common.Infrastructure.Features.Caches.Models;

using Microsoft.Extensions.Caching.StackExchangeRedis;

using StackExchange.Redis;

using ZiggyCreatures.Caching.Fusion;
using ZiggyCreatures.Caching.Fusion.Backplane.StackExchangeRedis;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddCaches(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<RedisOptions>(RedisOptions.SectionName);
			var options = configuration.GetOptions<RedisOptions>(RedisOptions.SectionName);

			serviceCollection.AddSingleton<IConnectionMultiplexer>(_ =>
				ConnectionMultiplexer.Connect(options.ConnectionString));

			serviceCollection.AddSingleton(sp =>
				sp.GetRequiredService<IConnectionMultiplexer>().GetDatabase());

			serviceCollection.AddFusionCache()
							 .WithDefaultEntryOptions(entryOptions => entryOptions.EnableAutoClone = true)
							 .WithSerializer(new BsonCacheSerializer())
							 .WithDistributedCache(sp => new RedisCache(new RedisCacheOptions
							 {
								 ConnectionMultiplexerFactory = () => Task.FromResult(sp.GetRequiredService<IConnectionMultiplexer>())
							 }))
							 .WithBackplane(sp => new RedisBackplane(new RedisBackplaneOptions
							 {
								 ConnectionMultiplexerFactory = () => Task.FromResult(sp.GetRequiredService<IConnectionMultiplexer>())
							 }));

			serviceCollection.AddScoped<ICacheHandler, CacheHandler>();

			serviceCollection.AddHealthChecks()
							 .AddRedis(sp => sp.GetRequiredService<IConnectionMultiplexer>());

			return serviceCollection;
		}
	}
}
