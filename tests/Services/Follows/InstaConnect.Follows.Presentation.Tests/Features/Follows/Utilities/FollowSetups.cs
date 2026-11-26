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

		public async Task InitializeAddAsync(
			AddFollowApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(follow, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddFollowApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(follow, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteFollowApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(follow, request.FollowerId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteFollowApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(follow, cancellationToken);
		}

		public async Task AddFollowCacheAsync(
			DeleteFollowApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddFollowCacheAsync(follow, request.FollowerId, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllFollowsApiRequest request,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(follows, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllFollowsForFollowingApiRequest request,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(follows, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllFollowsApiRequest request,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(follows, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllFollowsForFollowingApiRequest request,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(follows, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetFollowByIdApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(follow, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetFollowByIdApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(follow, cancellationToken);
		}
	}
}
