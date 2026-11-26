using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;

public static class FollowMapper
{
	extension(Follow follow)
	{
		public FollowResponse ToResponse(
			FollowId id,
			CurrentUserQuery currentUserQuery)
		{
			return follow.ToFullResponse(currentUserQuery.Id);
		}
	}

	extension(ICollection<Follow> follows)
	{
		public ICollection<FollowResponse> ToResponse(
			FollowsFilterQuery filterQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return follows.Filter(paginationQuery, follow => follow.MatchesFilter(filterQuery), follow => follow.ToResponseWithoutFollower(currentUserQuery.Id));
		}

		public ICollection<FollowResponse> ToResponse(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return follows.Filter(paginationQuery, follow => follow.MatchesFilter(filterQuery), follow => follow.ToResponseWithoutFollowing(currentUserQuery.Id));
		}

		public long ToTotalCountResponse(
			FollowsFilterQuery filterQuery)
		{
			return follows.Count(follow => follow.MatchesFilter(filterQuery));
		}

		public long ToTotalCountResponse(
			FollowsForFollowingFilterQuery filterQuery)
		{
			return follows.Count(follow => follow.MatchesFilter(filterQuery));
		}
	}
}
