using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatMessageCommandService GetChatMessageCommandService()
		{
			return serviceProvider.GetRequiredService<IChatMessageCommandService>();
		}

		public IChatMessageQueryService GetChatMessageQueryService()
		{
			return serviceProvider.GetRequiredService<IChatMessageQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IChatMessageCommandService GetChatMessageCommandService()
		{
			return serviceScope.ServiceProvider.GetChatMessageCommandService();
		}

		public IChatMessageQueryService GetChatMessageQueryService()
		{
			return serviceScope.ServiceProvider.GetChatMessageQueryService();
		}

		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatMessageCacheByIdAsync(command.Id, command.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatMessageCacheByIdAsync(command.Id, command.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatMessageCacheByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			AddChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(command.Id, command.Id.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(command.Id.Id, command.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task InitializeAddAsync(
			AddChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(chatMessage, command.Id.ParticipantOneId, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(chatMessage, cancellationToken);
		}

		public async Task AddChatCacheAsync(
			AddChatMessageCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatCacheAsync(chat, command.Id.ParticipantOneId, cancellationToken);
		}

		public async Task AddChatCacheAsync(
			DeleteChatMessageCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatCacheAsync(chat, command.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(chatMessage, command.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(chatMessage, cancellationToken);
		}

		public async Task AddChatMessageCacheAsync(
			DeleteChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatMessageCacheAsync(chatMessage, command.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task AddChatMessageCacheAsync(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatMessageCacheAsync(chatMessage, command.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllChatMessagesQuery query,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(chatMessages, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllChatMessagesQuery query,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(chatMessages, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetChatMessageByIdQuery query,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(chatMessage, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetChatMessageByIdQuery query,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(chatMessage, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(chatMessage, command.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(chatMessage, cancellationToken);
		}
	}
}
