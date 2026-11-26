using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Models.Responses;
using InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Follows.Tests.Features.Users.Utilities;

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

		public IFollowFollowerIncludeBuilderFactory GetFollowFollowerIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IFollowFollowerIncludeBuilderFactory>();
		}

		public IFollowFollowingIncludeBuilderFactory GetFollowFollowingIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IFollowFollowingIncludeBuilderFactory>();
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

		public IFollowFollowerIncludeBuilderFactory GetFollowFollowerIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetFollowFollowerIncludeBuilderFactory();
		}

		public IFollowFollowingIncludeBuilderFactory GetFollowFollowingIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetFollowFollowingIncludeBuilderFactory();
		}

		public IUserCacheHandler GetUserCacheHandler()
		{
			return serviceScope.ServiceProvider.GetUserCacheHandler();
		}

		public async Task<User?> GetByIdAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetUserIncludeBuilderFactory().Create().WithFollowers().WithFollowings().Build();

			return (await serviceScope.GetUserCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetFollowFollowers().SetFollowFollowings();
		}

		public async Task<User?> GetByNameAsync(
			Name name,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetUserIncludeBuilderFactory().Create().WithFollowers().WithFollowings().Build();

			return (await serviceScope.GetUserCommandRepository().GetByNameAsync(name, include, cancellationToken)).SetFollowFollowers().SetFollowFollowings();
		}

		public async Task<User?> GetByEmailAsync(
			Email email,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetUserIncludeBuilderFactory().Create().WithFollowers().WithFollowings().Build();

			return (await serviceScope.GetUserCommandRepository().GetByEmailAsync(email, include, cancellationToken)).SetFollowFollowers().SetFollowFollowings();
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

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			string id,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetUserCacheHandler();

			return await cacheHandler.GetByIdAsync(new(id), new(currentUserId), cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			UserId id,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetUserCacheHandler();

			return await cacheHandler.GetByIdAsync(id, currentUserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			User user,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var follows = user.FollowFollowers.Concat(user.FollowFollowings).DistinctBy(p => p.Id).ToList();
			var users = follows
				.Select(p => p.Follower!)
				.Concat(follows.Select(p => p.Following!))
				.Where(p => p.Id != user.Id)
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(follows, cancellationToken);
			await serviceScope.AddUserCacheAsync(user, currentUserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			User user,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(user, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			User user,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddUserCacheAsync(user, currentUserId, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			User user,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateAsync(user, currentUserId.Id, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			User user,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetUserCacheHandler();

			await cacheHandler.AddAsync(user.ToFullResponse(), new(currentUserId), cancellationToken);
		}

		public async Task AddUserCacheAsync(
			User user,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, currentUserId.Id, cancellationToken);
		}
	}
}
