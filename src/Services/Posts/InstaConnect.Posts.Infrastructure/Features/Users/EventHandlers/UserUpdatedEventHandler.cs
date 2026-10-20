using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Application.Features.Users.Commands.Update;

using MassTransit;

namespace InstaConnect.Posts.Infrastructure.Features.Users.EventHandlers;

public class UserUpdatedEventHandler : IEventHandler<UserUpdatedEventRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public UserUpdatedEventHandler(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	public async Task Consume(ConsumeContext<UserUpdatedEventRequest> context)
	{
		var request = _mapper.Map<UpdateUserCommandRequest>(context.Message);
		await _sender.SendAsync(request, context.CancellationToken);
	}
}
