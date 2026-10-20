namespace InstaConnect.Identity.Tests.Features.UserClaims.Builders;

public class UserClaimIdBuilderFactory
{
	public UserClaimIdBuilder Create(UserClaimId id)
	{
		return new(id);
	}
}
