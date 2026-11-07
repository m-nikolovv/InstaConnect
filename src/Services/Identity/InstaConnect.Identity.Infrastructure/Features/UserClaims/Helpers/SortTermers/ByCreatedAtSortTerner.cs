namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.SortTermers;

internal class ByCreatedAtSortTerner : IUserClaimsSortTermer
{
	public UserClaimsSortTerm SortTerm => UserClaimsSortTerm.ByCreatedAt;

	public Expression<Func<UserClaim, object>> Term => p => p.CreatedAtUtc;
}
