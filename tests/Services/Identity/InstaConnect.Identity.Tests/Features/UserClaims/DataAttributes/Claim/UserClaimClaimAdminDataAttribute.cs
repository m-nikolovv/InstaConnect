namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Claim;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimClaimAdminDataAttribute
	: SortEnumDataAttribute<ApplicationClaims>
{
	public UserClaimClaimAdminDataAttribute()
		: base(ApplicationClaims.Admin)
	{
	}
}
