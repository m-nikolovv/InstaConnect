using InstaConnect.Common.Application.Tests.Features.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllFollowsApiRequest request,
		User follower,
		ICollection<Follow> follows,
		CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllFollowsQueryRequest(), follows.ToResponse(request, follower), cancellationToken);
		}

		public void SetupSendAsync(
			GetAllFollowsForFollowingApiRequest request,
			User following,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllFollowsForFollowingQueryRequest(), follows.ToResponse(request, following), cancellationToken);
		}

		public void SetupSendAsync(
			GetFollowByIdApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetFollowByIdQueryRequest(), follow.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			AddFollowApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsAddFollowCommandRequest(), follow.ToResponse(request), cancellationToken);
		}
	}
}
