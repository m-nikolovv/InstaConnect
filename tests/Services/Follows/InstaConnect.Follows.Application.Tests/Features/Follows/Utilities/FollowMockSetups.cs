using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowMockSetups
{
	extension(IFollowQueryService likeService)
	{
		public void SetupGetAllAsync(
		GetAllFollowsQueryRequest request,
		User follower,
		ICollection<Follow> follows,
		CancellationToken cancellationToken)
		{
			likeService.SetupGetAllAsync(request.IsGetAllFollowsQuery(), follows.ToResponse(request, follower), cancellationToken);
		}

		public void SetupGetAllForFollowingAsync(
			GetAllFollowsForFollowingQueryRequest request,
			User following,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			likeService.SetupGetAllForFollowingAsync(request.IsGetAllFollowsForFollowingQuery(), follows.ToResponse(request, following), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetFollowByIdQueryRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			likeService.SetupGetByIdAsync(request.IsGetFollowByIdQuery(), follow.ToResponse(request), cancellationToken);
		}
	}

	extension(IFollowCommandService likeService)
	{
		public void SetupAddAsync(
		AddFollowCommandRequest request,
		Follow follow,
		CancellationToken cancellationToken)
		{
			likeService.SetupAddAsync(request.IsAddFollowCommand(), follow.ToResponse(request), cancellationToken);
		}
	}
}
