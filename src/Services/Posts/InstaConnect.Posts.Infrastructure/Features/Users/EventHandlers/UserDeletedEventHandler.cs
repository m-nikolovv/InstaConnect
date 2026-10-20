using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Application.Features.Users.Commands.Delete;

using MassTransit;

namespace InstaConnect.Posts.Infrastructure.Features.Users.EventHandlers;

public class UserDeletedEventHandler : IEventHandler<UserDeletedEventRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public UserDeletedEventHandler(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	public async Task Consume(ConsumeContext<UserDeletedEventRequest> context)
	{
		var request = _mapper.Map<DeleteUserCommandRequest>(context.Message);
		await _sender.SendAsync(request, context.CancellationToken);
	}
}
