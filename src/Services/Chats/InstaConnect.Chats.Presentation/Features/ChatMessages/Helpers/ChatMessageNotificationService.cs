using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Abstractions;

using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Helpers;

internal class ChatMessageNotificationService : IChatMessageNotificationService
{
	private readonly IHubContext<ChatMessageHub, IChatMessageHubClient> _hubContext;

	public ChatMessageNotificationService(IHubContext<ChatMessageHub, IChatMessageHubClient> hubContext)
	{
		_hubContext = hubContext;
	}

	public async Task AddedAsync(ChatMessageAddedNotificationRequest request, CancellationToken cancellationToken)
	{
		await _hubContext.Clients.Users([request.ChatMessage.ParticipantOneId, request.ChatMessage.ParticipantTwoId]).Added(request);
	}

	public async Task UpdatedAsync(ChatMessageUpdatedNotificationRequest request, CancellationToken cancellationToken)
	{
		await _hubContext.Clients.Users([request.ChatMessage.ParticipantOneId, request.ChatMessage.ParticipantTwoId]).Updated(request);
	}

	public async Task DeletedAsync(ChatMessageDeletedNotificationRequest request, CancellationToken cancellationToken)
	{
		await _hubContext.Clients.Users([request.ChatMessage.ParticipantOneId, request.ChatMessage.ParticipantTwoId]).Deleted(request);
	}
}
