using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Utilities;

public static class ChatSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			Chat chat,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(chat.Id, currentUserId, cancellationToken);
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}
	}

}
