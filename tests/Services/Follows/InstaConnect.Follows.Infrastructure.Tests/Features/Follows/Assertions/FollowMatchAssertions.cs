using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Assertions;

public static class FollowMatchAssertions
{
	extension(Follow response)
	{
		public void ShouldSatisfy(FollowId id, Follow follow)
		{
			response.ShouldSatisfy(f => f.Matches(id, follow));
		}
	}

	extension(FollowResponse response)
	{
		public void ShouldSatisfy(FollowId id, CurrentUserQuery currentUserQuery, Follow follow)
		{
			response.ShouldSatisfy(f => f.Matches(id, currentUserQuery, follow));
		}
	}

	extension(ICollection<FollowResponse> response)
	{
		public void ShouldSatisfy(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User follower,
			ICollection<Follow> follows)
		{
			response.ShouldSatisfy(f => f.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, follower, follows));
		}

		public void ShouldSatisfy(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			response.ShouldSatisfy(f => f.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, follower, follows, termTransformer));
		}

		public void ShouldSatisfy(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User following,
			ICollection<Follow> follows)
		{
			response.ShouldSatisfy(f => f.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, following, follows));
		}

		public void ShouldSatisfy(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			response.ShouldSatisfy(f => f.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, following, follows, termTransformer));
		}
	}

	extension(long response)
	{
		public void ShouldSatisfy(
			FollowsFilterQuery filterQuery,
			ICollection<Follow> follows)
		{
			response.ShouldSatisfy(f => f.Matches(filterQuery, follows));
		}

		public void ShouldSatisfy(
			FollowsForFollowingFilterQuery filterQuery,
			ICollection<Follow> follows)
		{
			response.ShouldSatisfy(f => f.Matches(filterQuery, follows));
		}
	}

	extension(bool response)
	{
		public void ShouldSatisfy(FollowId id, Follow? follow)
		{
			response.ShouldSatisfy(f => f.Matches(id, follow));
		}
	}
}
