using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Repositories;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatQueryRepository GetQueryRepository()
		{
			return new ChatQueryRepository(
				serviceProvider.GetCollection(),
				serviceProvider.GetIncludeBuilderFactory());
		}

		public IChatCommandRepository GetCommandRepository()
		{
			return new ChatCommandRepository(
				serviceProvider.GetCollection(),
				serviceProvider.GetIncludeBuilderFactory());
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
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();

			await cacheHandler.AddAsync(chat.ToFullResponse(), currentUserId, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<Chat> chats,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();

			await cacheHandler.AddRangeAsync(chats.ToFullResponse(), currentUserId, cancellationToken);
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
	}
}
