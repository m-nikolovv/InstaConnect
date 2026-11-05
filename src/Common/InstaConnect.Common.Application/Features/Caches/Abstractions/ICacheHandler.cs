using InstaConnect.Common.Application.Features.Caches.Models;

namespace InstaConnect.Common.Application.Features.Caches.Abstractions;

public interface ICacheHandler
{
	public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken);

	public Task SetAsync(CacheRequest request, CancellationToken cancellationToken);
}
