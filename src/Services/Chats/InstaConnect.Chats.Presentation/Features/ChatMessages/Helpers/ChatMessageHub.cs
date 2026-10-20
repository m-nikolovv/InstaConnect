using InstaConnect.Chats.Presentation.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Helpers;

[Authorize]
public class ChatMessageHub : Hub<IChatMessageHubClient>
{
	private readonly IApplicationMapper _mapper;

	public ChatMessageHub(IApplicationMapper mapper)
	{
		_mapper = mapper;
	}

	public async Task TypingStarted(TypingStartedHubRequest request)
	{
		await Clients.User(request.ParticipantTwoId).TypingStarted(_mapper.Map<TypingStartedNotificationRequest>(Context));
	}
}
