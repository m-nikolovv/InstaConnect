using InstaConnect.Common.Application.Features.Caches.Abstractions;
using InstaConnect.Common.Application.Features.Caches.Helpers;
using InstaConnect.Common.Infrastructure.Features.Caches.Helpers;
using InstaConnect.Common.Infrastructure.Features.Caches.Models;

using Microsoft.Extensions.Caching.StackExchangeRedis;

using StackExchange.Redis;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddCaches(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<RedisOptions>(RedisOptions.SectionName);
			var options = configuration.GetOptions<RedisOptions>(RedisOptions.SectionName);

			serviceCollection.AddScoped<ICacheHandler, CacheHandler>()
							 .AddScoped<ICacheRequestFactory, CacheRequestFactory>();

			serviceCollection.AddSingleton<IConnectionMultiplexer>(_ =>
				ConnectionMultiplexer.Connect(options.ConnectionString));

			serviceCollection.AddStackExchangeRedisCache(_ => { });
			serviceCollection.AddOptions<RedisCacheOptions>()
				.Configure<IConnectionMultiplexer>((redisOptions, connectionMultiplexer) =>
					redisOptions.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));

			serviceCollection.AddHealthChecks()
							 .AddRedis(options.ConnectionString);

			return serviceCollection;
		}
	}
}
