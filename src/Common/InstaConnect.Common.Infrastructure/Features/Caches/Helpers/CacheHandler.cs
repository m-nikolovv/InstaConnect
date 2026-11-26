using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Caches.Extensions;

using StackExchange.Redis;

using ZiggyCreatures.Caching.Fusion;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Helpers;

internal class CacheHandler : ICacheHandler
{
	private readonly IDatabase _database;
	private readonly IFusionCache _fusionCache;

	public CacheHandler(
		IDatabase database,
		IFusionCache fusionCache)
	{
		_database = database;
		_fusionCache = fusionCache;
	}

	public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
	{
		return await _fusionCache.GetOrDefaultAsync<T>(key, token: cancellationToken);
	}

	public async Task SetAsync<T>(string key, T value, TimeSpan expiration, IEnumerable<string> tags, CancellationToken cancellationToken)
	{
		await _fusionCache.SetAsync(key, value, expiration, tags, cancellationToken);
	}

	public async Task SetAsync<T>(string key, T value, TimeSpan expiration, IEnumerable<string> tags, IEnumerable<string> parentTags, CancellationToken cancellationToken)
	{
		await _fusionCache.SetAsync(key, value, expiration, [.. tags, .. parentTags], cancellationToken);
		await _database.AddChildTagsAsync(parentTags, tags, cancellationToken);
	}

	public async Task RemoveByTagAsync(string tag, CancellationToken cancellationToken)
	{
		var descendantTags = await _database.GetDescendantTagsAsync(tag, cancellationToken);

		await _fusionCache.RemoveByTagAsync(descendantTags, token: cancellationToken);
	}

	public async Task RemoveByTagRangeAsync(IEnumerable<string> tags, CancellationToken cancellationToken)
	{
		var descendantTags = await _database.GetDescendantTagsAsync(tags, cancellationToken);

		await _fusionCache.RemoveByTagAsync(descendantTags, token: cancellationToken);
	}
}
