using InstaConnect.Common.Application.Features.Caches.Abstractions;
using InstaConnect.Common.Application.Features.Caches.Models;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Jsons.Abstractions;

using Microsoft.Extensions.Caching.Distributed;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Helpers;


internal class CacheHandler : ICacheHandler
{
	private readonly IApplicationMapper _mapper;
	private readonly IJsonConverter _jsonConverter;
	private readonly IDistributedCache _distributedCache;

	public CacheHandler(
		IApplicationMapper mapper,
		IJsonConverter jsonConverter,
		IDistributedCache distributedCache)
	{
		_mapper = mapper;
		_jsonConverter = jsonConverter;
		_distributedCache = distributedCache;
	}

	public async Task SetAsync(CacheRequest request, CancellationToken cancellationToken)
	{
		var value = _jsonConverter.Serialize(request.Data);
		var options = _mapper.Map<DistributedCacheEntryOptions>(request);
		await _distributedCache.SetStringAsync(
			request.Key,
			value,
			options,
			cancellationToken);
	}

	public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
	{
		var value = await _distributedCache.GetStringAsync(key, cancellationToken) ?? string.Empty;

		var obj = _jsonConverter.Deserialize<T>(value);

		return obj;

	}
}

