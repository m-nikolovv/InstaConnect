using InstaConnect.Common.Application.Features.Caches.Abstractions;
using InstaConnect.Common.Application.Features.Requests.Abstractions;

namespace InstaConnect.Common.Application.Features.Caches.PipelineBehaviors;

internal class CacheInvalidationPipelineBehavior<TRequest, TResponse>
	: IPipelineBehavior<TRequest, TResponse>
	where TRequest : ICommand, ICacheInvalidating
{
	private readonly ICacheHandler _cacheHandler;

	public CacheInvalidationPipelineBehavior(ICacheHandler cacheHandler)
	{
		_cacheHandler = cacheHandler;
	}

	public async Task<TResponse> Handle(
		TRequest request,
		RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
		var response = await next(cancellationToken);

		foreach (var key in request.InvalidatedKeys)
		{
			await _cacheHandler.RemoveAsync(key, cancellationToken);
		}

		return response;
	}
}
