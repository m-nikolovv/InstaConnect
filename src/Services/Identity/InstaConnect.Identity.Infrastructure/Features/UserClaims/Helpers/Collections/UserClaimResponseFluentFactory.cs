namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimResponseFluentFactory : IUserClaimResponseFluentFactory
{
	public IUserClaimResponseFluent Create(IAggregateFluent<UserClaimResponse> fluent)
	{
		return new UserClaimResponseFluent(fluent);
	}
}
