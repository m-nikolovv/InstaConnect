using InstaConnect.Chats.Domain.Features.Users.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Repositories;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Chats.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserQueryRepository GetUserQueryRepository()
		{
			return new UserQueryRepository(serviceProvider.GetUserCollection());
		}

		public IUserCommandRepository GetUserCommandRepository()
		{
			return new UserCommandRepository(
				serviceProvider.GetUserCollection(),
				serviceProvider.GetUserIncludeBuilderFactory());
		}

		public IUserIncludeBuilderFactory GetUserIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IUserIncludeBuilderFactory>();
		}

		public IUserCollection GetUserCollection()
		{
			return serviceProvider.GetRequiredService<IUserCollection>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserQueryRepository GetUserQueryRepository()
		{
			return serviceScope.ServiceProvider.GetUserQueryRepository();
		}

		public IUserCommandRepository GetUserCommandRepository()
		{
			return serviceScope.ServiceProvider.GetUserCommandRepository();
		}

		public IUserIncludeBuilderFactory GetUserIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetUserIncludeBuilderFactory();
		}

		public async Task<User?> GetByIdAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetUserIncludeBuilderFactory().Create().WithChats().WithChatMessages().Build();

			return (await serviceScope.GetUserCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetChats().SetChatMessages();
		}

		public async Task<User?> GetByNameAsync(
			Name name,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetUserIncludeBuilderFactory().Create().WithChats().WithChatMessages().Build();

			return (await serviceScope.GetUserCommandRepository().GetByNameAsync(name, include, cancellationToken)).SetChats().SetChatMessages();
		}

		public async Task<User?> GetByEmailAsync(
			Email email,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetUserIncludeBuilderFactory().Create().WithChats().WithChatMessages().Build();

			return (await serviceScope.GetUserCommandRepository().GetByEmailAsync(email, include, cancellationToken)).SetChats().SetChatMessages();
		}

		public async Task AddAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetUserCommandRepository().AddAsync(user, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetUserCommandRepository().AddRangeAsync(users, cancellationToken);
		}

		public async Task DeleteAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetUserCommandRepository().DeleteAsync(user, cancellationToken);
		}
	}
}
