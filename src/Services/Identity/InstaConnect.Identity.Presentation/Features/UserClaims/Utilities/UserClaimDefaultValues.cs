using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Utilities;

public static class UserClaimDefaultValues
{
	public const ApplicationClaims Claim = ApplicationClaims.None;

	public const UserClaimsSortTerm SortTerm = UserClaimsSortTerm.ByCreatedAt;

	public const int Page = 1;

	public const int PageSize = 20;
}
