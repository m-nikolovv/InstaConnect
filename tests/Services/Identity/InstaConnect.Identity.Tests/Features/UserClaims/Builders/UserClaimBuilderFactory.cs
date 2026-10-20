namespace InstaConnect.Identity.Tests.Features.UserClaims.Builders;

public class UserClaimBuilderFactory
{
	public UserClaimBuilder Create(User user)
	{
		return new(user);
	}

	public UserClaimBuilder Create(UserClaim userClaim)
	{
		return new(userClaim);
	}
}
