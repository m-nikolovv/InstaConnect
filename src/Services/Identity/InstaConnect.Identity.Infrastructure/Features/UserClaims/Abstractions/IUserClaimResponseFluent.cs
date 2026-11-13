namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimResponseFluent : IMongoDbResponseFluent<UserClaimResponse>
{
	public IUserClaimResponseFluent Sort(UserClaimsSortingQuery query);
	public IUserClaimResponseFluent Paginate(UserClaimsPaginationQuery query);
}
