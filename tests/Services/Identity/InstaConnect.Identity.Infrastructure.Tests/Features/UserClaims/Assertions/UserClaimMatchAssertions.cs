using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;
using InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Assertions;

public static class UserClaimMatchAssertions
{
	extension(UserClaim response)
	{
		public void ShouldSatisfy(UserClaimId id, UserClaim userClaim)
		{
			response.ShouldSatisfy(p => p.Matches(id, userClaim));
		}
	}

	extension(UserClaimResponse response)
	{
		public void ShouldSatisfy(UserClaimId id, CurrentUserQuery currentUserQuery, UserClaim userClaim)
		{
			response.ShouldSatisfy(p => p.Matches(id, currentUserQuery, userClaim));
		}
	}

	extension(ICollection<UserClaimResponse> response)
	{
		public void ShouldSatisfy(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<UserClaim> userClaims)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, userClaims));
		}

		public void ShouldSatisfy(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, userClaims, termTransformer));
		}
	}

	extension(long response)
	{
		public void ShouldSatisfy(
			UserClaimsFilterQuery filterQuery,
			ICollection<UserClaim> userClaims)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, userClaims));
		}
	}

	extension(bool response)
	{
		public void ShouldSatisfy(UserClaimId id, UserClaim? userClaim)
		{
			response.ShouldSatisfy(p => p.Matches(id, userClaim));
		}
	}
}
