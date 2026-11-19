using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Utilities;

public static class UserClaimMapper
{
	extension(UserClaim userClaim)
	{
		public UserClaimResponse ToResponse(
			UserClaimId id,
			CurrentUserQuery currentUserQuery)
		{
			return userClaim.ToFullResponse();
		}
	}

	extension(ICollection<UserClaim> userClaims)
	{
		public ICollection<UserClaimResponse> ToResponse(
			UserClaimsFilterQuery filterQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return userClaims.Filter(paginationQuery, userClaim => userClaim.MatchesFilter(filterQuery), userClaim => userClaim.ToResponseWithoutUser());
		}

		public long ToTotalCountResponse(
			UserClaimsFilterQuery filterQuery)
		{
			return userClaims.Count(userClaim => userClaim.MatchesFilter(filterQuery));
		}
	}
}
