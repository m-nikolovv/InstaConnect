namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimResponseFluent :
	MongoDbResponseFluent<UserClaimResponse>, IUserClaimResponseFluent
{
	public UserClaimResponseFluent(IAggregateFluent<UserClaimResponse> fluent) : base(fluent)
	{
	}
}
