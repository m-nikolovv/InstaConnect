using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;

using ZiggyCreatures.Caching.Fusion;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Helpers;

internal class CacheHandler : ICacheHandler
{
	private readonly IFusionCache _fusionCache;

	public CacheHandler(IFusionCache fusionCache)
	{
		_fusionCache = fusionCache;
	}

	public async Task<T?> GetAsync<T>(string key)
	{
		return await _fusionCache.GetOrDefaultAsync<T>(key);
	}

	public async Task SetAsync<T>(string key, T value, TimeSpan expiration, IEnumerable<string> tags)
	{
		await _fusionCache.SetAsync(key, value, expiration, tags);
	}

	public async Task RemoveByTagAsync(string tag)
	{
		await _fusionCache.RemoveByTagAsync(tag);
	}

	public async Task RemoveByTagRangeAsync(IEnumerable<string> tags)
	{
		await _fusionCache.RemoveByTagAsync(tags);
	}
}
