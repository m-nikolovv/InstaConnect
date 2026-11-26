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

		public async Task SetupAddAsync(
			ChatMessage chatMessage,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var chat = chatMessage.Chat!;
			var users = new List<User> { chat.ParticipantOne!, chat.ParticipantTwo!, chatMessage.Sender! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddChatCacheAsync(chat, currentUserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			ChatMessage chatMessage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(chatMessage, currentUserId.Id, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			ChatMessage chatMessage,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var chat = chatMessage.Chat!;
			var chatMessageImages = chatMessage.ChatMessageImages;
			var users = new List<User> { chat.ParticipantOne!, chat.ParticipantTwo!, chatMessage.Sender! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddAsync(chatMessage, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessageImages, cancellationToken);
			await serviceScope.AddChatCacheAsync(chat, currentUserId, cancellationToken);
			await serviceScope.AddChatMessageCacheAsync(chatMessage, currentUserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			ChatMessage chatMessage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(chatMessage, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			var chats = chatMessages.Select(p => p.Chat!).DistinctBy(p => p.Id).ToList();
			var chatMessageImages = chatMessages.SelectMany(p => p.ChatMessageImages).ToList();
			var users = chats
				.Select(p => p.ParticipantOne!)
				.Concat(chats.Select(p => p.ParticipantTwo!))
				.Concat(chatMessages.Select(p => p.Sender!))
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(chats, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessages, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessageImages, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			var chat = chatMessage.Chat!;
			var chatMessageImages = chatMessage.ChatMessageImages;
			var users = new List<User> { chat.ParticipantOne!, chat.ParticipantTwo!, chatMessage.Sender! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddAsync(chatMessage, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessageImages, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			ChatMessage chatMessage,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var chat = chatMessage.Chat!;
			var chatMessageImages = chatMessage.ChatMessageImages;
			var users = new List<User> { chat.ParticipantOne!, chat.ParticipantTwo!, chatMessage.Sender! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddAsync(chatMessage, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessageImages, cancellationToken);
			await serviceScope.AddChatMessageCacheAsync(chatMessage, currentUserId, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			ChatMessage chatMessage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateAsync(chatMessage, currentUserId.Id, cancellationToken);
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
