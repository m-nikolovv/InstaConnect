using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;

public static class FollowMockSetups
{
	extension(IFollowCollection collection)
	{
		public void SetupAggregateFluent(
			FollowId id,
			IFollowFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			IFollowFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ICollection<FollowId> ids,
			IFollowFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IFollowFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			FollowsFilterQuery filterQuery,
			IFollowFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IFollowFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			FollowsForFollowingFilterQuery filterQuery,
			IFollowFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IFollowFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IFollowFluent fluent)
	{
		public void SetupGetCountAsync(
			FollowsFilterQuery filterQuery,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(follows.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupGetCountAsync(
			FollowsForFollowingFilterQuery filterQuery,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(follows.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupAnyAsync(
			FollowId id,
			Follow? follow,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(follow != null, cancellationToken);
		}

		public void SetupInclude(
			FollowId id,
			FollowInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			FollowInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			ICollection<FollowId> ids,
			FollowInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			FollowsFilterQuery filterQuery,
			FollowInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			FollowsForFollowingFilterQuery filterQuery,
			FollowInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			FollowInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			FollowInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(FollowInclude include)
		{
			fluent.Include(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(FollowId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			FollowId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(id);
		}

		public void SetupMatch(ICollection<FollowId> ids)
		{
			fluent.Match(ids).ReturnsResponse(fluent);
		}

		public void SetupMatch(FollowsFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(FollowsForFollowingFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupMatch(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupProjectToFullResponse(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			IFollowResponseFluent responseFluent)
		{
			fluent.SetupProjectToFullResponse(currentUserQuery, responseFluent);
		}

		public void SetupProjectToFullResponse(
			CurrentUserQuery currentUserQuery,
			IFollowResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutFollower(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IFollowResponseFluent responseFluent)
		{
			fluent.SetupProjectToResponseWithoutFollower(currentUserQuery, responseFluent);
		}

		public void SetupProjectToResponseWithoutFollower(
			CurrentUserQuery currentUserQuery,
			IFollowResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutFollower(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutFollowing(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IFollowResponseFluent responseFluent)
		{
			fluent.SetupProjectToResponseWithoutFollowing(currentUserQuery, responseFluent);
		}

		public void SetupProjectToResponseWithoutFollowing(
			CurrentUserQuery currentUserQuery,
			IFollowResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutFollowing(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			FollowId id,
			Follow follow,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(follow, cancellationToken);
		}

		public void SetupToListAsync(
			ICollection<FollowId> ids,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(follows, cancellationToken);
		}
	}

	extension(IFollowResponseFluent fluent)
	{
		public void SetupSort(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupSort(sortingQuery);
		}

		public void SetupSort(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupSort(sortingQuery);
		}

		public void SetupSort(FollowsSortingQuery sortingQuery)
		{
			fluent.Sort(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupSort(FollowsForFollowingSortingQuery sortingQuery)
		{
			fluent.Sort(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupPaginate(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupPaginate(paginationQuery);
		}

		public void SetupPaginate(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupPaginate(paginationQuery);
		}

		public void SetupPaginate(FollowsPaginationQuery paginationQuery)
		{
			fluent.Paginate(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(follows.ToResponse(filterQuery, paginationQuery, currentUserQuery), cancellationToken);
		}

		public void SetupToListAsync(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(follows.ToResponse(filterQuery, paginationQuery, currentUserQuery), cancellationToken);
		}

		public void SetupFirstOrDefaultAsync(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			Follow follow,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(follow.ToResponse(id, currentUserQuery), cancellationToken);
		}
	}
}
