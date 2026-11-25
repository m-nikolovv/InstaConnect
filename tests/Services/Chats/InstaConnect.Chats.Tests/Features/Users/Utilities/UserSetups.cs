using InstaConnect.Chats.Domain.Features.Users.Abstractions;
using InstaConnect.Chats.Domain.Features.Users.Models.Responses;
using InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Chats.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserQueryRepository GetUserQueryRepository()
		{
			return serviceProvider.GetRequiredService<IUserQueryRepository>();
		}

		public IUserCommandRepository GetUserCommandRepository()
		{
			return serviceProvider.GetRequiredService<IUserCommandRepository>();
		}

		public IUserIncludeBuilderFactory GetUserIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IUserIncludeBuilderFactory>();
		}

		public IUserCollection GetUserCollection()
		{
			return serviceProvider.GetRequiredService<IUserCollection>();
		}

		public IUserCacheHandler GetUserCacheHandler()
		{
			return serviceProvider.GetRequiredService<IUserCacheHandler>();
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

		public IUserCacheHandler GetUserCacheHandler()
		{
			return serviceScope.ServiceProvider.GetUserCacheHandler();
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
			var userRepository = serviceScope.GetUserCommandRepository();

			await userRepository.AddAsync(user, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			var userRepository = serviceScope.GetUserCommandRepository();

			await userRepository.AddRangeAsync(users, cancellationToken);
		}

		public async Task DeleteAsync(
			User user,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetUserCacheHandler();
			var userRepository = serviceScope.GetUserCommandRepository();

			await userRepository.DeleteAsync(user, cancellationToken);
			await cacheHandler.DeleteAsync(user.Id, cancellationToken);
		}
	}

	extension(IUserCacheHandler cacheHandler)
	{
		public async Task<UserResponse?> GetByIdAsync(
			string id,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(new(id), new(currentUserId), cancellationToken);
		}
	}
}
