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

		public async Task InitializeAddAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			var users = new List<User> { chat.ParticipantOne!, chat.ParticipantTwo! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
		}

		public async Task DisposeAddAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			var users = new List<User> { chat.ParticipantOne!, chat.ParticipantTwo! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.DeleteAsync(chat, cancellationToken);

			foreach (var linkedUser in users)
			{
				await serviceScope.DeleteAsync(linkedUser, cancellationToken);
			}
		}

		public async Task InitializeDeleteAsync(
			Chat chat,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var users = new List<User> { chat.ParticipantOne!, chat.ParticipantTwo! }.DistinctBy(p => p.Id).ToList();
			var chatMessages = chat.ChatMessages;
			var chatMessageImages = chatMessages.SelectMany(p => p.ChatMessageImages).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessages, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessageImages, cancellationToken);
			await serviceScope.AddChatCacheAsync(chat, currentUserId, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			Chat chat,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(chat, currentUserId.Id, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			var users = new List<User> { chat.ParticipantOne!, chat.ParticipantTwo! }.DistinctBy(p => p.Id).ToList();
			var chatMessages = chat.ChatMessages;
			var chatMessageImages = chatMessages.SelectMany(p => p.ChatMessageImages).ToList();

			await serviceScope.DeleteRangeAsync(chatMessageImages, cancellationToken);
			await serviceScope.DeleteRangeAsync(chatMessages, cancellationToken);
			await serviceScope.DeleteAsync(chat, cancellationToken);

			foreach (var linkedUser in users)
			{
				await serviceScope.DeleteAsync(linkedUser, cancellationToken);
			}
		}

		public async Task InitializeGetAllAsync(
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			var chatMessages = chats.SelectMany(p => p.ChatMessages).ToList();
			var users = chats
				.Select(p => p.ParticipantOne!)
				.Concat(chats.Select(p => p.ParticipantTwo!))
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(chats, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessages, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			var chatMessages = chats.SelectMany(p => p.ChatMessages).ToList();
			var users = chats
				.Select(p => p.ParticipantOne!)
				.Concat(chats.Select(p => p.ParticipantTwo!))
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.DeleteRangeAsync(chatMessages, cancellationToken);
			await serviceScope.DeleteRangeAsync(chats, cancellationToken);

			foreach (var linkedUser in users)
			{
				await serviceScope.DeleteAsync(linkedUser, cancellationToken);
			}
		}

		public async Task InitializeGetByIdAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			var users = new List<User> { chat.ParticipantOne!, chat.ParticipantTwo! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			var users = new List<User> { chat.ParticipantOne!, chat.ParticipantTwo! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.DeleteAsync(chat, cancellationToken);

			foreach (var linkedUser in users)
			{
				await serviceScope.DeleteAsync(linkedUser, cancellationToken);
			}
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
