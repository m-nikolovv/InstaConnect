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
			await serviceScope.GetCommandRepository().AddAsync(chat, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<Chat> chats,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetCommandRepository().AddRangeAsync(chats, cancellationToken);
		}

		public async Task DeleteAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetCommandRepository().DeleteAsync(chat, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<Chat> chats,
			CancellationToken cancellationToken)
		{
			foreach (var chat in chats)
			{
				await serviceScope.GetCommandRepository().DeleteAsync(chat, cancellationToken);
			}
		}
	}
}
