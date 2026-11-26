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

		public async Task DisposeAddAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DeleteAsync(user, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			User user,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var posts = user.Posts;
			var postLikes = user.PostLikes;
			var postComments = user.PostComments;
			var postCommentLikes = user.PostCommentLikes;
			var postImages = posts.SelectMany(p => p.PostImages).ToList();
			var postCommentImages = postComments.SelectMany(p => p.PostCommentImages).ToList();

			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddRangeAsync(posts, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentImages, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentLikes, cancellationToken);
			await serviceScope.AddUserCacheAsync(user, currentUserId, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			User user,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(user, currentUserId.Id, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			User user,
			CancellationToken cancellationToken)
		{
			var posts = user.Posts;
			var postLikes = user.PostLikes;
			var postComments = user.PostComments;
			var postCommentLikes = user.PostCommentLikes;
			var postImages = posts.SelectMany(p => p.PostImages).ToList();
			var postCommentImages = postComments.SelectMany(p => p.PostCommentImages).ToList();

			await serviceScope.DeleteRangeAsync(postCommentLikes, cancellationToken);
			await serviceScope.DeleteRangeAsync(postCommentImages, cancellationToken);
			await serviceScope.DeleteRangeAsync(postComments, cancellationToken);
			await serviceScope.DeleteRangeAsync(postLikes, cancellationToken);
			await serviceScope.DeleteRangeAsync(postImages, cancellationToken);
			await serviceScope.DeleteRangeAsync(posts, cancellationToken);
			await serviceScope.DeleteAsync(user, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DeleteAsync(user, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			User user,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddUserCacheAsync(user, currentUserId, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			User user,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(user, currentUserId.Id, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DeleteAsync(user, cancellationToken);
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
