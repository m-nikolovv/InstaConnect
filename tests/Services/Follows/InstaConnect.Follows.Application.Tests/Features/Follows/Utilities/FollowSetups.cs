using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<Follow?> GetByIdAsync(
		FollowIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new FollowId(
							   new(id.FollowerId),
							   new(id.FollowingId)),
				cancellationToken);
		}

		public async Task<Follow?> GetByIdAsync(
		AddFollowCommandResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<FollowResponse?> GetFollowCacheByIdAsync(
			DeleteFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetFollowCacheByIdAsync(request.FollowerId, request.FollowingId, request.FollowerId, cancellationToken);
		}

		public async Task<FollowResponse?> GetFollowCacheByIdAsync(
			GetFollowByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetFollowCacheByIdAsync(request.FollowerId, request.FollowingId, request.CurrentUserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddFollowCommandRequest request,
			User follower,
			User following,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddFollowAsync(follower, following, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteFollowCommandRequest request,
			User follower,
			User following,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteFollowAsync(follower, following, follow, request.FollowerId, cancellationToken);
		}

		public async Task AddFollowCacheAsync(
			DeleteFollowCommandRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddFollowCacheAsync(follow, request.FollowerId, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllFollowsForFollowingQueryRequest request,
			ICollection<User> followers,
			ICollection<User> followings,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllFollowsAsync(followers, followings, follows, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllFollowsQueryRequest request,
			ICollection<User> followers,
			ICollection<User> followings,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllFollowsAsync(followers, followings, follows, cancellationToken);
		}


		public async Task SetupGetByIdAsync(
			GetFollowByIdQueryRequest request,
			User follower,
			User following,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetFollowByIdAsync(follower, following, follow, cancellationToken);
		}
	}
}
