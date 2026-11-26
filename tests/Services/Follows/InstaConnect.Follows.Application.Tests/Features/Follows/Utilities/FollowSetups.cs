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
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(follow, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteFollowCommandRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(follow, request.FollowerId, cancellationToken);
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
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(follows, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllFollowsQueryRequest request,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(follows, cancellationToken);
		}


		public async Task SetupGetByIdAsync(
			GetFollowByIdQueryRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(follow, cancellationToken);
		}
	}
}
