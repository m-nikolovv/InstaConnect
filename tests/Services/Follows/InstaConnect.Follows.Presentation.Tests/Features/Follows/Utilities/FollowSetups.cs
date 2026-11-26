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
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(follow, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteFollowApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(follow, request.FollowerId, cancellationToken);
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
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(follows, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllFollowsForFollowingApiRequest request,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(follows, cancellationToken);
		}


		public async Task SetupGetByIdAsync(
			GetFollowByIdApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(follow, cancellationToken);
		}
	}
}
