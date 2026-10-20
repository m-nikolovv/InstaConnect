using InstaConnect.Common.Application.Features.Caches.Models;

using Microsoft.Extensions.Caching.Distributed;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Mappings;

public class CacheInfrastructureMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<CacheRequest, DistributedCacheEntryOptions>()
			.ConstructUsing(src => new()
			{
				AbsoluteExpiration = src.Expiration,
			});
	}
}
