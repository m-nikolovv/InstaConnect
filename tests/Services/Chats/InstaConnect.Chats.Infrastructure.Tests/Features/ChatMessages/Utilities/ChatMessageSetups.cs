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
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatMessageCacheByIdAsync(chatMessage.Id, chatMessage.Id.Id.ParticipantOneId, cancellationToken);
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
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(chatMessage.Id.Id, chatMessage.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task SetupAddAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(chatMessage, chatMessage.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateAsync(chatMessage, chatMessage.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(chatMessage, chatMessage.Id.Id.ParticipantOneId, cancellationToken);
		}
	}

}
