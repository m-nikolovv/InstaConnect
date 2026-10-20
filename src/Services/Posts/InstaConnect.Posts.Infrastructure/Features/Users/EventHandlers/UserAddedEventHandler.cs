using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Application.Features.Users.Commands.Add;

using MassTransit;

namespace InstaConnect.Posts.Infrastructure.Features.Users.EventHandlers;

public class UserAddedEventHandler : IEventHandler<UserAddedEventRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public UserAddedEventHandler(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	public async Task Consume(ConsumeContext<UserAddedEventRequest> context)
	{
		var request = _mapper.Map<AddUserCommandRequest>(context.Message);
		await _sender.SendAsync(request, context.CancellationToken);
	}
}
