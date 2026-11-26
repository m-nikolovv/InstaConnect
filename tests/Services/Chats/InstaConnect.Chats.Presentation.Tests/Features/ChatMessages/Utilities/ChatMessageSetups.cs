using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Entities;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Controllers.v1;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public ChatMessageController GetChatMessageController()
		{
			return serviceProvider.GetRequiredService<ChatMessageController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public ChatMessageController GetChatMessageController()
		{
			return serviceScope.ServiceProvider.GetChatMessageController();
		}

		internal async Task<ChatMessage?> GetByIdAsync(
		ChatMessageIdApiResponse id,
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
			AddChatMessageApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<ChatMessage?> GetByIdAsync(
			UpdateChatMessageApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<ChatMessage?> GetByIdAsync(
			ActionResult<AddChatMessageApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task<ChatMessage?> GetByIdAsync(
			ActionResult<UpdateChatMessageApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatMessageCacheByIdAsync(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId, request.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatMessageCacheByIdAsync(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId, request.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatMessageCacheByIdAsync(request.CurrentUserId, request.ParticipantTwoId, request.MessageId, request.CurrentUserId, cancellationToken);
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(request.ParticipantOneId, request.ParticipantTwoId, request.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(request.ParticipantOneId, request.ParticipantTwoId, request.ParticipantOneId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddChatMessageApiRequest request,
			User participantOne,
			User participantTwo,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddChatMessageAsync(participantOne, participantTwo, chat, request.ParticipantOneId, cancellationToken);
		}

		public async Task AddChatCacheAsync(
			AddChatMessageApiRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatCacheAsync(chat, request.ParticipantOneId, cancellationToken);
		}

		public async Task AddChatCacheAsync(
			DeleteChatMessageApiRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatCacheAsync(chat, request.ParticipantOneId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteChatMessageApiRequest request,
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
			DeleteChatMessageApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatMessageCacheAsync(chatMessage, request.ParticipantOneId, cancellationToken);
		}

		public async Task AddChatMessageCacheAsync(
			UpdateChatMessageApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatMessageCacheAsync(chatMessage, request.ParticipantOneId, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllChatMessagesApiRequest request,
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
			GetChatMessageByIdApiRequest request,
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
			UpdateChatMessageApiRequest request,
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
