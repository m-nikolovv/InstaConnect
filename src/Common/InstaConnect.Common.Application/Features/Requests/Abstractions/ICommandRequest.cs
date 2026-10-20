namespace InstaConnect.Common.Application.Features.Requests.Abstractions;

public interface ICommand : IBaseRequest;

public interface ICommandRequest : IRequest, ICommand;

public interface ICommandRequest<out TResponse> : IRequest<TResponse>, ICommand;
