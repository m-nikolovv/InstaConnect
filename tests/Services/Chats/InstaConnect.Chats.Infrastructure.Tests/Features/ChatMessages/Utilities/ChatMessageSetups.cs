using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageSetups
{
	extension(IChatMessageCacheHandler cacheHandler)
	{
		public async Task<ChatMessageResponse?> GetByIdAsync(
			ChatMessage chatMessage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(chatMessage.Id, currentUserId, cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetByIdAsync(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}
	}

	extension(IChatCacheHandler cacheHandler)
	{
		public async Task<ChatResponse?> GetByIdAsync(
			ChatMessage chatMessage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(chatMessage.Id.Id, currentUserId, cancellationToken);
		}
	}
}
