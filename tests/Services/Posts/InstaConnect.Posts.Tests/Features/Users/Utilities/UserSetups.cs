using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

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
			var include = serviceScope.GetUserIncludeBuilderFactory().Create().WithPosts().WithPostLikes().WithPostComments().WithPostCommentLikes().Build();

			return (await serviceScope.GetUserCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetPosts().SetPostLikes().SetPostComments().SetPostCommentLikes();
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
