namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UsersSortOrderDescendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
	public UsersSortOrderDescendingDataAttribute()
		: base(CommonSortOrder.Descending)
	{
	}
}
