using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Utilities;

public static class ChatSetups
{
	extension(IChatCacheHandler cacheHandler)
	{
		public async Task<ChatResponse?> GetByIdAsync(
			Chat chat,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(chat.Id, currentUserId, cancellationToken);
		}

		public async Task<ChatResponse?> GetByIdAsync(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}
	}
}
