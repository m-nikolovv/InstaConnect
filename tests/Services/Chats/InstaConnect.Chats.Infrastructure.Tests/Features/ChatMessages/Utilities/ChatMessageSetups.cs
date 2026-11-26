using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			ChatMessage chatMessage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatMessageCacheByIdAsync(chatMessage.Id, currentUserId, cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatMessageCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			ChatMessage chatMessage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(chatMessage.Id.Id, currentUserId, cancellationToken);
		}
	}

}
