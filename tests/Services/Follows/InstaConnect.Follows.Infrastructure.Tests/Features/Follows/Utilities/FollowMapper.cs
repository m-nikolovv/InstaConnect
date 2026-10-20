using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Infrastructure.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;

public static class FollowMapper
{
	extension(Follow follow)
	{
		internal FollowResponse ToFullResponse(CurrentUserQuery query)
		{
			return new(follow.Id,
					   follow.Follower?.ToFullResponse(),
					   follow.Following?.ToFullResponse(),
					   follow.Id.FollowerId.Matches(query.Id),
					   follow.CreatedAtUtc);
		}

		internal FollowResponse ToResponseWithoutFollower(CurrentUserQuery query)
		{
			return new(follow.Id,
					   null,
					   follow.Following?.ToFullResponse(),
					   follow.Id.FollowerId.Matches(query.Id),
					   follow.CreatedAtUtc);
		}

		internal FollowResponse ToResponseWithoutFollowing(CurrentUserQuery query)
		{
			return new(follow.Id,
					   follow.Follower?.ToFullResponse(),
					   null,
					   follow.Id.FollowerId.Matches(query.Id),
					   follow.CreatedAtUtc);
		}

		public FollowResponse ToResponse(
			FollowId id,
			CurrentUserQuery currentUserQuery)
		{
			return follow.ToFullResponse(currentUserQuery);
		}
	}

	extension(ICollection<Follow> follows)
	{
		public ICollection<FollowResponse> ToResponse(
			FollowsFilterQuery filterQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return follows.Filter(paginationQuery, follow => follow.MatchesFilter(filterQuery), follow => follow.ToResponseWithoutFollower(currentUserQuery));
		}

		public ICollection<FollowResponse> ToResponse(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return follows.Filter(paginationQuery, follow => follow.MatchesFilter(filterQuery), follow => follow.ToResponseWithoutFollowing(currentUserQuery));
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
