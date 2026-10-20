namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Builders;

public class UserClaimsFilterQueryBuilderFactory
{
	public UserClaimsFilterQueryBuilder Create(UserClaim userClaim)
	{
		return new(userClaim);
	}
}
