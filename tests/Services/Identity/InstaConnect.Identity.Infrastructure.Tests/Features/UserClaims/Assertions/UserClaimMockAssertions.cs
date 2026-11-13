using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Assertions;

public static class UserClaimMockAssertions
{
	extension(IUserClaimCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(UserClaimId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ICollection<UserClaimId> ids)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			UserClaimId id,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(UserClaimsFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddAsync(userClaim, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddRangeAsync(
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddRangeAsync(userClaims, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(userClaim, cancellationToken);
		}
	}

	extension(IUserClaimFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(UserClaimsFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(UserClaimId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(ICollection<UserClaimId> ids)
		{
			fluent.ShouldHaveReceivedOne().Match(ids);
		}

		public void ShouldHaveReceivedOneMatch(
			UserClaimId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(id);
		}

		public void ShouldHaveReceivedOneInclude(
			UserClaimId id,
			UserClaimInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			UserClaimId id,
			CurrentUserQuery currentUserQuery,
			UserClaimInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(UserClaimInclude include)
		{
			fluent.ShouldHaveReceivedOne().Include(include);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(
			UserClaimId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutUser(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToResponseWithoutUser(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutUser(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutUser(currentUserQuery);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			UserClaimId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneAnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			UserClaimsFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneGetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			UserClaimId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ICollection<UserClaimId> ids,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}

	extension(IUserClaimResponseFluent fluent)
	{
		public void ShouldHaveReceivedOneSort(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneSort(sortingQuery);
		}

		public void ShouldHaveReceivedOneSort(UserClaimsSortingQuery sortingQuery)
		{
			fluent.ShouldHaveReceivedOne().Sort(sortingQuery);
		}

		public void ShouldHaveReceivedOnePaginate(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOnePaginate(paginationQuery);
		}

		public void ShouldHaveReceivedOnePaginate(UserClaimsPaginationQuery paginationQuery)
		{
			fluent.ShouldHaveReceivedOne().Paginate(paginationQuery);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			UserClaimId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}
}
