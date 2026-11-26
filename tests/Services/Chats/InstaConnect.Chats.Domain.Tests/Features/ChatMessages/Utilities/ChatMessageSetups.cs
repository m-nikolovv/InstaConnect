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

		public async Task SetupAddAsync(
			AddChatMessageCommand command,
			User participantOne,
			User participantTwo,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddChatMessageAsync(participantOne, participantTwo, chat, command.Id.ParticipantOneId, cancellationToken);
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

		public async Task SetupDeleteAsync(
			DeleteChatMessageCommand command,
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteChatMessageAsync(participantOne, participantTwo, chat, chatMessage, chatMessageImages, command.Id.Id.ParticipantOneId, cancellationToken);
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

		public async Task SetupGetAllAsync(
			GetAllChatMessagesQuery query,
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
			GetChatMessageByIdQuery query,
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
			UpdateChatMessageCommand command,
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateChatMessageAsync(participantOne, participantTwo, chat, chatMessage, chatMessageImages, command.Id.Id.ParticipantOneId, cancellationToken);
		}
	}
}
