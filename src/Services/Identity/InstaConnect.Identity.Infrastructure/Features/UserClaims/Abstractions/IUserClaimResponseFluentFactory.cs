namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimResponseFluentFactory
{
	public IUserClaimResponseFluent Create(IAggregateFluent<UserClaimResponse> fluent);
}
