using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

public static class FollowMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			GetAllFollowsQuery query)
		{
			return user.ToFullResponse();
		}

		public UserResponse ToResponse(
			GetAllFollowsForFollowingQuery query)
		{
			return user.ToFullResponse();
		}
	}

	extension(Follow follow)
	{
		public Follow To(AddFollowCommand command)
		{
			return new(
				new(command.FollowerId, command.FollowingId),
				follow.CreatedAtUtc);
		}

		public FollowId ToResponse(
			AddFollowCommand command)
		{
			return follow.ToId();
		}

		public FollowResponse ToResponse(
			GetFollowByIdQuery query)
		{
			return follow.ToFullResponse(query.CurrentUser.Id);
		}
	}

	extension(ICollection<Follow> follows)
	{
		public ICollection<FollowResponse> ToResponse(
			GetAllFollowsQuery query)
		{
			return follows.Filter(query.Pagination, follow => follow.MatchesFilter(query.Filter), follow => follow.ToResponseWithoutFollower(query.CurrentUser.Id));
		}

		public ICollection<FollowResponse> ToResponse(
			GetAllFollowsForFollowingQuery query)
		{
			return follows.Filter(query.Pagination, follow => follow.MatchesFilter(query.Filter), follow => follow.ToResponseWithoutFollowing(query.CurrentUser.Id));
		}

		public long ToTotalCountResponse(
			GetAllFollowsQuery query)
		{
			return follows.Count(follow => follow.MatchesFilter(query.Filter));
		}

		public long ToTotalCountResponse(
			GetAllFollowsForFollowingQuery query)
		{
			return follows.Count(follow => follow.MatchesFilter(query.Filter));
		}
	}
}
