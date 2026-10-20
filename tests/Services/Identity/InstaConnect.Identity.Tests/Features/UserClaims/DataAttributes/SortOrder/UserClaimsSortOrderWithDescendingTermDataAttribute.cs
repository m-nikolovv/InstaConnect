namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimsSortOrderWithDescendingTermDataAttribute
	: SortEnumWithDescendingTermDataAttribute<CommonSortOrder, UserClaim, DateTimeOffset>
{
	public UserClaimsSortOrderWithDescendingTermDataAttribute()
		: base(CommonSortOrder.Descending, p => p.CreatedAtUtc)
	{
	}
}
