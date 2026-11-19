using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Repositories;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserQueryRepository GetUserQueryRepository()
		{
			return new UserQueryRepository(serviceProvider.GetUserCollection());
		}

		public IUserQueryRepository GetCachedUserQueryRepository()
		{
			return serviceProvider.GetRequiredService<IUserQueryRepository>();
		}

		public IUserCommandRepository GetUserCommandRepository()
		{
			return new UserCommandRepository(
				serviceProvider.GetUserCollection(),
				serviceProvider.GetUserIncludeBuilderFactory());
		}

		public IUserCommandRepository GetCachedUserCommandRepository()
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

		public IUserQueryRepository GetCachedUserQueryRepository()
		{
			return serviceScope.ServiceProvider.GetCachedUserQueryRepository();
		}

		public IUserCommandRepository GetUserCommandRepository()
		{
			return serviceScope.ServiceProvider.GetUserCommandRepository();
		}

		public IUserCommandRepository GetCachedUserCommandRepository()
		{
			return serviceScope.ServiceProvider.GetCachedUserCommandRepository();
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
			var include = serviceScope.GetUserIncludeBuilderFactory().Create().WithPosts().WithPostLikes().WithPostComments().WithPostCommentLikes().Build();

			return (await serviceScope.GetUserCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetPosts().SetPostLikes().SetPostComments().SetPostCommentLikes();
		}

		public async Task AddAsync(
			User user,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetUserCacheHandler();
			var userRepository = serviceScope.GetUserCommandRepository();

			await userRepository.AddAsync(user, cancellationToken);
			await cacheHandler.AddAsync(user.ToFullResponse(), currentUserId, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<User> users,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetUserCacheHandler();
			var userRepository = serviceScope.GetUserCommandRepository();

			await userRepository.AddRangeAsync(users, cancellationToken);
			await cacheHandler.AddRangeAsync(users.ToFullResponse(), currentUserId, cancellationToken);
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
}
