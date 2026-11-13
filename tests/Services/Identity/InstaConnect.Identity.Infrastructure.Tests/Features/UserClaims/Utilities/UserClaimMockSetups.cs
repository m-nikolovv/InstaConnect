using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockSetups
{
	extension(IUserClaimCollection collection)
	{
		public void SetupAggregateFluent(
			UserClaimId id,
			IUserClaimFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ICollection<UserClaimId> ids,
			IUserClaimFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			UserClaimId id,
			CurrentUserQuery currentUserQuery,
			IUserClaimFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IUserClaimFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			UserClaimsFilterQuery filterQuery,
			IUserClaimFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IUserClaimFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IUserClaimFluent fluent)
	{
		public void SetupGetCountAsync(
			UserClaimsFilterQuery filterQuery,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(userClaims.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupAnyAsync(
			UserClaimId id,
			UserClaim? userClaim,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(userClaim != null, cancellationToken);
		}

		public void SetupInclude(
			UserClaimId id,
			UserClaimInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			UserClaimId id,
			CurrentUserQuery currentUserQuery,
			UserClaimInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(UserClaimInclude include)
		{
			fluent.Include(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(UserClaimId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(ICollection<UserClaimId> ids)
		{
			fluent.Match(ids).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			UserClaimId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(id);
		}

		public void SetupMatch(UserClaimsFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupProjectToFullResponse(
			UserClaimId id,
			CurrentUserQuery currentUserQuery,
			IUserClaimResponseFluent responseFluent)
		{
			fluent.SetupProjectToFullResponse(currentUserQuery, responseFluent);
		}

		public void SetupProjectToFullResponse(
			CurrentUserQuery currentUserQuery,
			IUserClaimResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IUserClaimResponseFluent responseFluent)
		{
			fluent.SetupProjectToResponseWithoutUser(currentUserQuery, responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			CurrentUserQuery currentUserQuery,
			IUserClaimResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutUser(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			UserClaimId id,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(userClaim, cancellationToken);
		}

		public void SetupToListAsync(
			ICollection<UserClaimId> ids,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(userClaims, cancellationToken);
		}
	}

	extension(IUserClaimResponseFluent fluent)
	{
		public void SetupSort(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupSort(sortingQuery);
		}

		public void SetupSort(UserClaimsSortingQuery sortingQuery)
		{
			fluent.Sort(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupPaginate(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupPaginate(paginationQuery);
		}

		public void SetupPaginate(UserClaimsPaginationQuery paginationQuery)
		{
			fluent.Paginate(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(userClaims.ToResponse(filterQuery, paginationQuery, currentUserQuery), cancellationToken);
		}

		public void SetupFirstOrDefaultAsync(
			UserClaimId id,
			CurrentUserQuery currentUserQuery,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(userClaim.ToResponse(id, currentUserQuery), cancellationToken);
		}
	}
}
