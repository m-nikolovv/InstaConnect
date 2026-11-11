namespace InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;

public interface ICacheHandler
{
	public Task<T?> GetAsync<T>(string key);

	public Task SetAsync<T>(string key, T value, TimeSpan expiration, IEnumerable<string> tags);

	public Task RemoveByTagAsync(string tag);

	public Task RemoveByTagRangeAsync(IEnumerable<string> tags);
}
