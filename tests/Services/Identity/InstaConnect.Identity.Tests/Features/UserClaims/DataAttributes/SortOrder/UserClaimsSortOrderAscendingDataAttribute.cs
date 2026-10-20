namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimsSortOrderAscendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
	public UserClaimsSortOrderAscendingDataAttribute()
		: base(CommonSortOrder.Ascending)
	{
	}
}
