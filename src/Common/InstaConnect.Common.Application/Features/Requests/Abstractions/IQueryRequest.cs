namespace InstaConnect.Common.Application.Features.Requests.Abstractions;

public interface IQuery : IBaseRequest;

public interface IQueryRequest<out TResponse> : IRequest<TResponse>, IQuery;
