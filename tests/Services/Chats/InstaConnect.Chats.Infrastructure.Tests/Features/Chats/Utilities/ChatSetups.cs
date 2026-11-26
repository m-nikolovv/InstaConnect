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
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(chat.Id, chat.Id.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}

		public async Task SetupDeleteChatAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteChatAsync(participantOne, participantTwo, chat, chatMessages, chatMessageImages, chat.Id.ParticipantOneId, cancellationToken);
		}
	}

}
