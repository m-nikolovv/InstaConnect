using InstaConnect.Chats.Application.Features.ChatMessages.Models;
using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Entities;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<ChatMessage?> GetByIdAsync(
		ChatMessageIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new ChatMessageId(
							   new(
								   new(id.ParticipantOneId),
								   new(id.ParticipantTwoId)),
							   id.MessageId),
				cancellationToken);
		}

		public async Task<ChatMessage?> GetByIdAsync(
			AddChatMessageCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<ChatMessage?> GetByIdAsync(
			UpdateChatMessageCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			UpdateChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatMessageCacheByIdAsync(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId, request.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			DeleteChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatMessageCacheByIdAsync(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId, request.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			GetChatMessageByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatMessageCacheByIdAsync(request.CurrentUserId, request.ParticipantTwoId, request.MessageId, request.CurrentUserId, cancellationToken);
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			AddChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(request.ParticipantOneId, request.ParticipantTwoId, request.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			DeleteChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(request.ParticipantOneId, request.ParticipantTwoId, request.ParticipantOneId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddChatMessageCommandRequest request,
			User participantOne,
			User participantTwo,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddChatMessageAsync(participantOne, participantTwo, chat, request.ParticipantOneId, cancellationToken);
		}

		public async Task AddChatCacheAsync(
			AddChatMessageCommandRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatCacheAsync(chat, request.ParticipantOneId, cancellationToken);
		}

		public async Task AddChatCacheAsync(
			DeleteChatMessageCommandRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatCacheAsync(chat, request.ParticipantOneId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteChatMessageCommandRequest request,
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteChatMessageAsync(participantOne, participantTwo, chat, chatMessage, chatMessageImages, request.ParticipantOneId, cancellationToken);
		}

		public async Task AddChatMessageCacheAsync(
			DeleteChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatMessageCacheAsync(chatMessage, request.ParticipantOneId, cancellationToken);
		}

		public async Task AddChatMessageCacheAsync(
			UpdateChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatMessageCacheAsync(chatMessage, request.ParticipantOneId, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllChatMessagesQueryRequest request,
			ICollection<User> participantOnes,
			ICollection<User> participantTwos,
			ICollection<Chat> chats,
			ICollection<ChatMessage> chatMessages,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllChatMessagesAsync(participantOnes, participantTwos, chats, chatMessages, chatMessageImages, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetChatMessageByIdQueryRequest request,
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetChatMessageByIdAsync(participantOne, participantTwo, chat, chatMessage, chatMessageImages, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			UpdateChatMessageCommandRequest request,
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateChatMessageAsync(participantOne, participantTwo, chat, chatMessage, chatMessageImages, request.ParticipantOneId, cancellationToken);
		}
	}
}
