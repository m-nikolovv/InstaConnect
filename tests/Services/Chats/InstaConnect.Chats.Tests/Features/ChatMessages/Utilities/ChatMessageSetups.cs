using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Repositories;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatMessageQueryRepository GetMessageQueryRepository()
		{
			return new ChatMessageQueryRepository(
				serviceProvider.GetMessageCollection(),
				serviceProvider.GetIncludeBuilderFactory(),
				serviceProvider.GetMessageIncludeBuilderFactory());
		}

		public IChatMessageCommandRepository GetMessageCommandRepository()
		{
			return new ChatMessageCommandRepository(
				serviceProvider.GetMessageCollection(),
				serviceProvider.GetMessageIncludeBuilderFactory());
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
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var messageCacheHandler = serviceScope.GetMessageCacheHandler();
			var messageRepository = serviceScope.GetMessageCommandRepository();

			await messageRepository.AddAsync(chatMessage, cancellationToken);
			await messageCacheHandler.AddAsync(chatMessage.ToFullResponse(), currentUserId, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<ChatMessage> chatMessages,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var messageCacheHandler = serviceScope.GetMessageCacheHandler();
			var messageRepository = serviceScope.GetMessageCommandRepository();

			await messageRepository.AddRangeAsync(chatMessages, cancellationToken);
			await messageCacheHandler.AddRangeAsync(chatMessages.ToFullResponse(), currentUserId, cancellationToken);
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
	}
}
