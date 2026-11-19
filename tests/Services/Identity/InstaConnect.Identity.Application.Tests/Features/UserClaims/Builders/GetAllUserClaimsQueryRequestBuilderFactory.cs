namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Builders;

public class GetAllUserClaimsQueryRequestBuilderFactory
{
	public GetAllUserClaimsQueryRequestBuilder Create(UserClaim userClaim, UserId currentId)
	{
		return new(userClaim, currentId);
	}
}
