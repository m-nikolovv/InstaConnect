namespace InstaConnect.Common.Application.Features.Caches.Abstractions;

public interface ICacheInvalidating
{
	public ICollection<string> InvalidatedKeys { get; }
}
