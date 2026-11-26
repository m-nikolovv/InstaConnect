using InstaConnect.Chats.Application.Features.ChatMessages.Models;
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

		public async Task InitializeAddAsync(
			AddChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(chatMessage, request.ParticipantOneId, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(chatMessage, cancellationToken);
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

		public async Task InitializeDeleteAsync(
			DeleteChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(chatMessage, request.ParticipantOneId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(chatMessage, cancellationToken);
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

		public async Task InitializeGetAllAsync(
			GetAllChatMessagesQueryRequest request,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(chatMessages, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllChatMessagesQueryRequest request,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(chatMessages, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetChatMessageByIdQueryRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(chatMessage, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetChatMessageByIdQueryRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(chatMessage, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			UpdateChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(chatMessage, request.ParticipantOneId, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			UpdateChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(chatMessage, cancellationToken);
		}
	}
}
