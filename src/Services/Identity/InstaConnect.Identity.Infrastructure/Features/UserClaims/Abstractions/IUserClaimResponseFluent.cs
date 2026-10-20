namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimResponseFluent : IMongoDbResponseFluent<UserClaimResponse>
{
	public IUserClaimResponseFluent ApplySorting(UserClaimsSortingQuery query);
	public IUserClaimResponseFluent ApplyPagination(UserClaimsPaginationQuery query);
}
