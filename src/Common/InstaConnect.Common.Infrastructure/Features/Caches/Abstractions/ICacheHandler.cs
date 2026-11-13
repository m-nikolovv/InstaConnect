namespace InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;

public interface ICacheHandler
{
	public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken);

	public Task SetAsync<T>(string key, T value, TimeSpan expiration, IEnumerable<string> tags, CancellationToken cancellationToken);

	public Task SetAsync<T>(string key, T value, TimeSpan expiration, IEnumerable<string> tags, IEnumerable<string> parentTags, CancellationToken cancellationToken);

	public Task RemoveByTagAsync(string tag, CancellationToken cancellationToken);

	public Task RemoveByTagRangeAsync(IEnumerable<string> tags, CancellationToken cancellationToken);
}
