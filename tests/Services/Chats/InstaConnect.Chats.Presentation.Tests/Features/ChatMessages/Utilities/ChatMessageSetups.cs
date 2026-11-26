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

		public async Task InitializeAddAsync(
			AddChatMessageApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(chatMessage, request.ParticipantOneId, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddChatMessageApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(chatMessage, cancellationToken);
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

		public async Task InitializeDeleteAsync(
			DeleteChatMessageApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(chatMessage, request.ParticipantOneId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteChatMessageApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(chatMessage, cancellationToken);
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

		public async Task InitializeGetAllAsync(
			GetAllChatMessagesApiRequest request,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(chatMessages, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllChatMessagesApiRequest request,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(chatMessages, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetChatMessageByIdApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(chatMessage, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetChatMessageByIdApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(chatMessage, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			UpdateChatMessageApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(chatMessage, request.ParticipantOneId, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			UpdateChatMessageApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(chatMessage, cancellationToken);
		}
	}
}
