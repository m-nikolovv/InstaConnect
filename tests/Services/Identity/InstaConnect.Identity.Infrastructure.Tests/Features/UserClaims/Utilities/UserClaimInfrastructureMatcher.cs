using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Utilities;

public static class UserClaimInfrastructureMatcher
{
	extension(UserClaim userClaim)
	{
		public UserClaimResponse IsUserClaimResponse(CurrentUserQuery currentUserQuery)
		{
			return Matcher.Is<UserClaimResponse>(p => p.Matches(userClaim.Id, currentUserQuery, userClaim));
		}
	}
}
