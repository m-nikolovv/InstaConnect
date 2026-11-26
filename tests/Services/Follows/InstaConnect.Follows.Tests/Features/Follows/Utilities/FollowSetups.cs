using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IFollowQueryRepository GetFollowQueryRepository()
		{
			return serviceProvider.GetRequiredService<IFollowQueryRepository>();
		}

		public IFollowCommandRepository GetFollowCommandRepository()
		{
			return serviceProvider.GetRequiredService<IFollowCommandRepository>();
		}

		public IFollowIncludeBuilderFactory GetFollowIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IFollowIncludeBuilderFactory>();
		}

		public IFollowCollection GetFollowCollection()
		{
			return serviceProvider.GetRequiredService<IFollowCollection>();
		}

		public IFollowCacheHandler GetFollowCacheHandler()
		{
			return serviceProvider.GetRequiredService<IFollowCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IFollowQueryRepository GetFollowQueryRepository()
		{
			return serviceScope.ServiceProvider.GetFollowQueryRepository();
		}

		public IFollowCommandRepository GetFollowCommandRepository()
		{
			return serviceScope.ServiceProvider.GetFollowCommandRepository();
		}

		public IFollowIncludeBuilderFactory GetFollowIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetFollowIncludeBuilderFactory();
		}

		public IFollowCacheHandler GetFollowCacheHandler()
		{
			return serviceScope.ServiceProvider.GetFollowCacheHandler();
		}

		public async Task<Follow?> GetByIdAsync(
			FollowId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetFollowIncludeBuilderFactory().Create().WithFollower().WithFollowing().Build();

			return (await serviceScope.GetFollowCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetFollower().SetFollowing();
		}

		public async Task<ICollection<Follow>> GetByIdRangeAsync(
			IEnumerable<FollowId> ids,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetFollowCommandRepository().GetByIdRangeAsync(ids, cancellationToken);
		}

		public async Task AddAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			var followRepository = serviceScope.GetFollowCommandRepository();

			await followRepository.AddAsync(follow, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			var followRepository = serviceScope.GetFollowCommandRepository();

			await followRepository.AddRangeAsync(follows, cancellationToken);
		}

		public async Task DeleteAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetFollowCacheHandler();
			var followRepository = serviceScope.GetFollowCommandRepository();

			await followRepository.DeleteAsync(follow, cancellationToken);
			await cacheHandler.DeleteAsync(follow.Id, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<Follow> follows,
			CancellationToken cancellationToken)
		{
			foreach (var follow in follows)
			{
				await serviceScope.DeleteAsync(follow, cancellationToken);
			}
		}

		public async Task<FollowResponse?> GetFollowCacheByIdAsync(
			string followerId,
			string followingId,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetFollowCacheHandler();

			return await cacheHandler.GetByIdAsync(new(new(followerId), new(followingId)), new(currentUserId), cancellationToken);
		}

		public async Task<FollowResponse?> GetFollowCacheByIdAsync(
			FollowId id,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetFollowCacheHandler();

			return await cacheHandler.GetByIdAsync(id, currentUserId, cancellationToken);
		}

		public async Task SetupAddFollowAsync(
			User follower,
			User following,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(follower, cancellationToken);
			await serviceScope.AddAsync(following, cancellationToken);
		}

		public async Task SetupDeleteFollowAsync(
			User follower,
			User following,
			Follow follow,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(follower, cancellationToken);
			await serviceScope.AddAsync(following, cancellationToken);
			await serviceScope.AddAsync(follow, cancellationToken);
			await serviceScope.AddFollowCacheAsync(follow, currentUserId, cancellationToken);
		}

		public async Task SetupDeleteFollowAsync(
			User follower,
			User following,
			Follow follow,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteFollowAsync(follower, following, follow, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetAllFollowsAsync(
			ICollection<User> followers,
			ICollection<User> followings,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(followers, cancellationToken);
			await serviceScope.AddRangeAsync(followings, cancellationToken);
			await serviceScope.AddRangeAsync(follows, cancellationToken);
		}

		public async Task SetupGetFollowByIdAsync(
			User follower,
			User following,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(follower, cancellationToken);
			await serviceScope.AddAsync(following, cancellationToken);
			await serviceScope.AddAsync(follow, cancellationToken);
		}

		public async Task AddFollowCacheAsync(
			Follow follow,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetFollowCacheHandler();

			await cacheHandler.AddAsync(follow.ToFullResponse(currentUserId), new(currentUserId), cancellationToken);
		}

		public async Task AddFollowCacheAsync(
			Follow follow,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddFollowCacheAsync(follow, currentUserId.Id, cancellationToken);
		}
	}
}
