namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimFluentFactory
{
	public IUserClaimFluent Create(IAggregateFluent<UserClaim> fluent);
}
