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

		public async Task SetupAddChatMessageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddChatMessageAsync(participantOne, participantTwo, chat, chat.Id.ParticipantOneId, cancellationToken);
		}

		public async Task SetupUpdateChatMessageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateChatMessageAsync(participantOne, participantTwo, chat, chatMessage, chatMessageImages, chatMessage.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task SetupDeleteChatMessageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteChatMessageAsync(participantOne, participantTwo, chat, chatMessage, chatMessageImages, chatMessage.Id.Id.ParticipantOneId, cancellationToken);
		}
	}

}
