using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Infrastructure.Tests.Features.Users.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;

public static class FollowEquals
{
	extension(Follow f)
	{
		public bool Matches(
			FollowId id,
			Follow follow)
		{
			return f.Matches(follow);
		}

		public bool MatchesFilter(FollowsFilterQuery query)
		{
			return f.Id.FollowerId.Matches(query.FollowerId) &&
				   f.Following.MatchesFilter(query);
		}

		public bool MatchesFilter(FollowsForFollowingFilterQuery query)
		{
			return f.Id.FollowingId.Matches(query.FollowingId) &&
				   f.Follower.MatchesFilter(query);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(FollowsFilterQuery query)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(query.FollowingName.Value);
		}

		public bool MatchesFilter(FollowsForFollowingFilterQuery query)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(query.FollowerName.Value);
		}
	}

	extension(FollowResponse? response)
	{
		public bool MatchesFull(
			CurrentUserQuery currentUserQuery,
			Follow? follow)
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(currentUserQuery.Id) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following.MatchesFull(follow.Following) &&
				   response.Follower.MatchesFull(follow.Follower);
		}

		public bool MatchesWithoutFollowing(
			CurrentUserQuery currentUserQuery,
			Follow? follow)
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(currentUserQuery.Id) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follow.Follower);
		}

		public bool MatchesWithoutFollower(
			CurrentUserQuery currentUserQuery,
			Follow? follow)
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(currentUserQuery.Id) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following.MatchesFull(follow.Following) &&
				   response.Follower == null;
		}

		public bool Matches(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			Follow follow)
		{
			return response.MatchesFull(currentUserQuery, follow);
		}
	}

	extension(ICollection<FollowResponse> response)
	{
		public bool MatchesWithoutFollowing(
			FollowsPaginationQuery paginationQuery,
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User follower,
			ICollection<Follow> follows)
		{
			return response.MatchesCollectionAndNotEmpty(paginationQuery,
											  follows,
											  response => response.Id,
											  follow => follow.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutFollowing(
			FollowsPaginationQuery paginationQuery,
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													follows,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool MatchesWithoutFollower(
			FollowsPaginationQuery paginationQuery,
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User following,
			ICollection<Follow> follows)
		{
			return response.MatchesCollectionAndNotEmpty(paginationQuery,
											  follows,
											  response => response.Id,
											  follow => follow.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutFollower(
			FollowsPaginationQuery paginationQuery,
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													follows,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool Matches(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User follower,
			ICollection<Follow> follows)
		{
			return response.MatchesWithoutFollowing(
					   paginationQuery,
					   (response, follow) => response.MatchesWithoutFollower(currentUserQuery, follow),
					   follow => follow.MatchesFilter(filterQuery),
					   follower,
					   follows);
		}

		public bool Matches(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			return response.MatchesWithoutFollowing(
					   paginationQuery,
					   (response, follow) => response.MatchesWithoutFollower(currentUserQuery, follow),
					   follow => follow.MatchesFilter(filterQuery),
					   follower,
					   follows,
					   termTransformer);
		}

		public bool Matches(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User following,
			ICollection<Follow> follows)
		{
			return response.MatchesWithoutFollower(
					   paginationQuery,
					   (response, follow) => response.MatchesWithoutFollowing(currentUserQuery, follow),
					   follow => follow.MatchesFilter(filterQuery),
					   following,
					   follows);
		}

		public bool Matches(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			return response.MatchesWithoutFollower(
					   paginationQuery,
					   (response, follow) => response.MatchesWithoutFollowing(currentUserQuery, follow),
					   follow => follow.MatchesFilter(filterQuery),
					   following,
					   follows,
					   termTransformer);
		}
	}

	extension(long response)
	{
		public bool Matches(
			FollowsFilterQuery filterQuery,
			ICollection<Follow> follows)
		{
			return response == follows.Count(follow => follow.MatchesFilter(filterQuery));
		}

		public bool Matches(
			FollowsForFollowingFilterQuery filterQuery,
			ICollection<Follow> follows)
		{
			return response == follows.Count(follow => follow.MatchesFilter(filterQuery));
		}
	}

	extension(bool response)
	{
		public bool Matches(FollowId id, Follow? follow)
		{
			return response == (follow != null);
		}
	}
}
