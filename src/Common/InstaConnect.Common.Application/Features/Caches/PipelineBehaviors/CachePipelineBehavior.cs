using InstaConnect.Common.Application.Features.Caches.Abstractions;
using InstaConnect.Common.Application.Features.Requests.Abstractions;

using Microsoft.Extensions.Logging;

namespace InstaConnect.Common.Application.Features.Caches.PipelineBehaviors;

internal class CachePipelineBehavior<TRequest, TResponse>
	: IPipelineBehavior<TRequest, TResponse>
	where TRequest : IQueryRequest<TResponse>, ICachable
	where TResponse : class
{
	private readonly ICacheHandler _cacheHandler;
	private readonly ICacheRequestFactory _cacheRequestFactory;
	private readonly ILogger<CachePipelineBehavior<TRequest, TResponse>> _logger;

	public CachePipelineBehavior(
		ICacheHandler cacheHandler,
		ICacheRequestFactory cacheRequestFactory,
		ILogger<CachePipelineBehavior<TRequest, TResponse>> logger)
	{
		_cacheHandler = cacheHandler;
		_cacheRequestFactory = cacheRequestFactory;
		_logger = logger;
	}

	public async Task<TResponse> Handle(
		TRequest request,
		RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
		var requestKey = request.Key;
		var cachedResult = await _cacheHandler.GetAsync<TResponse>(requestKey, cancellationToken);

		if (cachedResult != null)
		{
			_logger.LogInformation("Cache hit for key {RequestKey}", requestKey);

			return cachedResult;
		}

		_logger.LogInformation("Cache miss for {RequestKey}", requestKey);

		var data = await next(cancellationToken);
		var cacheRequest = _cacheRequestFactory.Get(requestKey, request.ExpirationSeconds, data);
		await _cacheHandler.SetAsync(cacheRequest, cancellationToken);

		return data;
	}
}
