using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatQueryRepository GetQueryRepository()
		{
			return serviceProvider.GetRequiredService<IChatQueryRepository>();
		}

		public IChatCommandRepository GetCommandRepository()
		{
			return serviceProvider.GetRequiredService<IChatCommandRepository>();
		}

		public IChatIncludeBuilderFactory GetIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IChatIncludeBuilderFactory>();
		}

		public IChatCollection GetCollection()
		{
			return serviceProvider.GetRequiredService<IChatCollection>();
		}

		public IChatCacheHandler GetCacheHandler()
		{
			return serviceProvider.GetRequiredService<IChatCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IChatQueryRepository GetQueryRepository()
		{
			return serviceScope.ServiceProvider.GetQueryRepository();
		}

		public IChatCommandRepository GetCommandRepository()
		{
			return serviceScope.ServiceProvider.GetCommandRepository();
		}

		public IChatIncludeBuilderFactory GetIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetIncludeBuilderFactory();
		}

		public IChatCacheHandler GetCacheHandler()
		{
			return serviceScope.ServiceProvider.GetCacheHandler();
		}

		public async Task<Chat?> GetByIdAsync(
			ChatId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetIncludeBuilderFactory().Create().WithParticipantOne().WithParticipantTwo().Build();

			return (await serviceScope.GetCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetParticipantOne().SetParticipantTwo();
		}

		public async Task<ICollection<Chat>> GetByIdRangeAsync(
			IEnumerable<ChatId> ids,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetIncludeBuilderFactory().Create().WithParticipantOne().WithParticipantTwo().Build();

			return (await serviceScope.GetCommandRepository().GetByIdRangeAsync(ids, include, cancellationToken)).SetParticipantOne().SetParticipantTwo();
		}

		public async Task AddAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			var repository = serviceScope.GetCommandRepository();

			await repository.AddAsync(chat, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			var repository = serviceScope.GetCommandRepository();

			await repository.AddRangeAsync(chats, cancellationToken);
		}

		public async Task DeleteAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();
			var repository = serviceScope.GetCommandRepository();

			await repository.DeleteAsync(chat, cancellationToken);
			await cacheHandler.DeleteAsync(chat.Id, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<Chat> chats,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();
			var repository = serviceScope.GetCommandRepository();

			foreach (var chat in chats)
			{
				await repository.DeleteAsync(chat, cancellationToken);
				await cacheHandler.DeleteAsync(chat.Id, cancellationToken);
			}
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			string participantOneId,
			string participantTwoId,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();

			return await cacheHandler.GetByIdAsync(new(new(participantOneId), new(participantTwoId)), new(currentUserId), cancellationToken);
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			ChatId id,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();

			return await cacheHandler.GetByIdAsync(id, currentUserId, cancellationToken);
		}

		public async Task SetupAddChatAsync(
			User participantOne,
			User participantTwo,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(participantOne, cancellationToken);
			await serviceScope.AddAsync(participantTwo, cancellationToken);
		}

		public async Task SetupDeleteChatAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ICollection<ChatMessageImage> chatMessageImages,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(participantOne, cancellationToken);
			await serviceScope.AddAsync(participantTwo, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessages, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessageImages, cancellationToken);
			await serviceScope.AddChatCacheAsync(chat, currentUserId, cancellationToken);
		}

		public async Task SetupDeleteChatAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ICollection<ChatMessageImage> chatMessageImages,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteChatAsync(participantOne, participantTwo, chat, chatMessages, chatMessageImages, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetAllChatsAsync(
			ICollection<User> participantOnes,
			ICollection<User> participantTwos,
			ICollection<Chat> chats,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(participantOnes, cancellationToken);
			await serviceScope.AddRangeAsync(participantTwos, cancellationToken);
			await serviceScope.AddRangeAsync(chats, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessages, cancellationToken);
		}

		public async Task SetupGetChatByIdAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(participantOne, cancellationToken);
			await serviceScope.AddAsync(participantTwo, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
		}

		public async Task AddChatCacheAsync(
			Chat chat,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();

			await cacheHandler.AddAsync(chat.ToFullResponse(), new(currentUserId), cancellationToken);
		}

		public async Task AddChatCacheAsync(
			Chat chat,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddChatCacheAsync(chat, currentUserId.Id, cancellationToken);
		}
	}
}
