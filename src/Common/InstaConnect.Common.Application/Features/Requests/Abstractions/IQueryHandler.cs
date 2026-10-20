namespace InstaConnect.Common.Application.Features.Requests.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
	where TQuery : IQueryRequest<TResponse>;
