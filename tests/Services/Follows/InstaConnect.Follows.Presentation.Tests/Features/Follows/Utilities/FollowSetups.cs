using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;
using InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public FollowController GetFollowController()
		{
			return serviceProvider.GetRequiredService<FollowController>();
		}

		public FollowingFollowController GetFollowingFollowController()
		{
			return serviceProvider.GetRequiredService<FollowingFollowController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public FollowController GetFollowController()
		{
			return serviceScope.ServiceProvider.GetFollowController();
		}

		public FollowingFollowController GetFollowingFollowController()
		{
			return serviceScope.ServiceProvider.GetFollowingFollowController();
		}

		internal async Task<Follow?> GetByIdAsync(
		FollowIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new FollowId(
							   new(id.FollowerId),
							   new(id.FollowingId)),
				cancellationToken);
		}

		public async Task<Follow?> GetByIdAsync(
		AddFollowApiResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<Follow?> GetByIdAsync(
		ActionResult<AddFollowApiResponse> response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task<FollowResponse?> GetFollowCacheByIdAsync(
			DeleteFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetFollowCacheByIdAsync(request.FollowerId, request.FollowingId, request.FollowerId, cancellationToken);
		}

		public async Task<FollowResponse?> GetFollowCacheByIdAsync(
			GetFollowByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetFollowCacheByIdAsync(request.FollowerId, request.FollowingId, request.CurrentUserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddFollowApiRequest request,
			User follower,
			User following,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddFollowAsync(follower, following, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteFollowApiRequest request,
			User follower,
			User following,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteFollowAsync(follower, following, follow, request.FollowerId, cancellationToken);
		}

		public async Task AddFollowCacheAsync(
			DeleteFollowApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddFollowCacheAsync(follow, request.FollowerId, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllFollowsApiRequest request,
			ICollection<User> followers,
			ICollection<User> followings,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllFollowsAsync(followers, followings, follows, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllFollowsForFollowingApiRequest request,
			ICollection<User> followers,
			ICollection<User> followings,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllFollowsAsync(followers, followings, follows, cancellationToken);
		}


		public async Task SetupGetByIdAsync(
			GetFollowByIdApiRequest request,
			User follower,
			User following,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetFollowByIdAsync(follower, following, follow, cancellationToken);
		}
	}
}
