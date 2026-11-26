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

		public async Task InitializeAddAsync(
			AddFollowCommandRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(follow, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddFollowCommandRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(follow, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteFollowCommandRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(follow, request.FollowerId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteFollowCommandRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(follow, cancellationToken);
		}

		public async Task AddFollowCacheAsync(
			DeleteFollowCommandRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddFollowCacheAsync(follow, request.FollowerId, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllFollowsForFollowingQueryRequest request,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(follows, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllFollowsQueryRequest request,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(follows, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllFollowsForFollowingQueryRequest request,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(follows, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllFollowsQueryRequest request,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(follows, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetFollowByIdQueryRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(follow, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetFollowByIdQueryRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(follow, cancellationToken);
		}
	}
}
