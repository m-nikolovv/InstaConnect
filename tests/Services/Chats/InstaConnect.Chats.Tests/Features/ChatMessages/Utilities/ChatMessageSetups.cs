using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatMessageQueryRepository GetMessageQueryRepository()
		{
			return serviceProvider.GetRequiredService<IChatMessageQueryRepository>();
		}

		public IChatMessageCommandRepository GetMessageCommandRepository()
		{
			return serviceProvider.GetRequiredService<IChatMessageCommandRepository>();
		}

		public IChatMessageIncludeBuilderFactory GetMessageIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IChatMessageIncludeBuilderFactory>();
		}

		public IChatMessageCollection GetMessageCollection()
		{
			return serviceProvider.GetRequiredService<IChatMessageCollection>();
		}

		public IChatMessageCacheHandler GetMessageCacheHandler()
		{
			return serviceProvider.GetRequiredService<IChatMessageCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IChatMessageQueryRepository GetMessageQueryRepository()
		{
			return serviceScope.ServiceProvider.GetMessageQueryRepository();
		}

		public IChatMessageCommandRepository GetMessageCommandRepository()
		{
			return serviceScope.ServiceProvider.GetMessageCommandRepository();
		}

		public IChatMessageIncludeBuilderFactory GetMessageIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetMessageIncludeBuilderFactory();
		}

		public IChatMessageCacheHandler GetMessageCacheHandler()
		{
			return serviceScope.ServiceProvider.GetMessageCacheHandler();
		}

		public async Task<ChatMessage?> GetByIdAsync(
			ChatMessageId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetIncludeBuilderFactory().Create().WithParticipantOne().WithParticipantTwo().Build();
			var messageInclude = serviceScope.GetMessageIncludeBuilderFactory().Create().WithSender().WithChat(include).WithChatMessageImages().Build();

			return (await serviceScope.GetMessageCommandRepository().GetByIdAsync(id, messageInclude, cancellationToken)).SetSender().SetChat().SetChatMessageImages();
		}

		public async Task<ICollection<ChatMessage>> GetByIdRangeAsync(
			IEnumerable<ChatMessageId> ids,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetIncludeBuilderFactory().Create().WithParticipantOne().WithParticipantTwo().Build();
			var messageInclude = serviceScope.GetMessageIncludeBuilderFactory().Create().WithSender().WithChat(include).WithChatMessageImages().Build();

			return (await serviceScope.GetMessageCommandRepository().GetByIdRangeAsync(ids, messageInclude, cancellationToken)).SetSender().SetChat().SetChatMessageImages();
		}

		public async Task AddAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			var messageRepository = serviceScope.GetMessageCommandRepository();

			await messageRepository.AddAsync(chatMessage, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			var messageRepository = serviceScope.GetMessageCommandRepository();

			await messageRepository.AddRangeAsync(chatMessages, cancellationToken);
		}

		public async Task UpdateAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			var messageCacheHandler = serviceScope.GetMessageCacheHandler();
			var messageRepository = serviceScope.GetMessageCommandRepository();

			await messageRepository.UpdateAsync(chatMessage, cancellationToken);
			await messageCacheHandler.DeleteAsync(chatMessage.Id, cancellationToken);
		}

		public async Task DeleteAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();
			var messageCacheHandler = serviceScope.GetMessageCacheHandler();
			var messageRepository = serviceScope.GetMessageCommandRepository();

			await messageRepository.DeleteAsync(chatMessage, cancellationToken);
			await cacheHandler.DeleteResponseAsync(chatMessage.Id.Id, cancellationToken);
			await messageCacheHandler.DeleteAsync(chatMessage.Id, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();
			var messageCacheHandler = serviceScope.GetMessageCacheHandler();
			var messageRepository = serviceScope.GetMessageCommandRepository();

			foreach (var chatMessage in chatMessages)
			{
				await messageRepository.DeleteAsync(chatMessage, cancellationToken);
				await cacheHandler.DeleteResponseAsync(chatMessage.Id.Id, cancellationToken);
				await messageCacheHandler.DeleteAsync(chatMessage.Id, cancellationToken);
			}
		}

		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			string participantOneId,
			string participantTwoId,
			string messageId,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetMessageCacheHandler();

			return await cacheHandler.GetByIdAsync(new(new(new(participantOneId), new(participantTwoId)), messageId), new(currentUserId), cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetChatMessageCacheByIdAsync(
			ChatMessageId id,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetMessageCacheHandler();

			return await cacheHandler.GetByIdAsync(id, currentUserId, cancellationToken);
		}

		public async Task SetupAddChatMessageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(participantOne, cancellationToken);
			await serviceScope.AddAsync(participantTwo, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddChatCacheAsync(chat, currentUserId, cancellationToken);
		}

		public async Task SetupAddChatMessageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddChatMessageAsync(participantOne, participantTwo, chat, currentUserId.Id, cancellationToken);
		}

		public async Task SetupDeleteChatMessageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ICollection<ChatMessageImage> chatMessageImages,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(participantOne, cancellationToken);
			await serviceScope.AddAsync(participantTwo, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddAsync(chatMessage, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessageImages, cancellationToken);
			await serviceScope.AddChatCacheAsync(chat, currentUserId, cancellationToken);
			await serviceScope.AddChatMessageCacheAsync(chatMessage, currentUserId, cancellationToken);
		}

		public async Task SetupDeleteChatMessageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ICollection<ChatMessageImage> chatMessageImages,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteChatMessageAsync(participantOne, participantTwo, chat, chatMessage, chatMessageImages, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetAllChatMessagesAsync(
			ICollection<User> participantOnes,
			ICollection<User> participantTwos,
			ICollection<Chat> chats,
			ICollection<ChatMessage> chatMessages,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(participantOnes, cancellationToken);
			await serviceScope.AddRangeAsync(participantTwos, cancellationToken);
			await serviceScope.AddRangeAsync(chats, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessages, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessageImages, cancellationToken);
		}

		public async Task SetupGetChatMessageByIdAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(participantOne, cancellationToken);
			await serviceScope.AddAsync(participantTwo, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddAsync(chatMessage, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessageImages, cancellationToken);
		}

		public async Task SetupUpdateChatMessageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ICollection<ChatMessageImage> chatMessageImages,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(participantOne, cancellationToken);
			await serviceScope.AddAsync(participantTwo, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddAsync(chatMessage, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessageImages, cancellationToken);
			await serviceScope.AddChatMessageCacheAsync(chatMessage, currentUserId, cancellationToken);
		}

		public async Task SetupUpdateChatMessageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ICollection<ChatMessageImage> chatMessageImages,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateChatMessageAsync(participantOne, participantTwo, chat, chatMessage, chatMessageImages, currentUserId.Id, cancellationToken);
		}

		public async Task AddChatMessageCacheAsync(
			ChatMessage chatMessage,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetMessageCacheHandler();

			await cacheHandler.AddAsync(chatMessage.ToFullResponse(), new(currentUserId), cancellationToken);
		}

		public async Task AddChatMessageCacheAsync(
			ChatMessage chatMessage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatMessageCacheAsync(chatMessage, currentUserId.Id, cancellationToken);
		}
	}
}
