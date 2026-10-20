namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowsSortOrderDescendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
	public FollowsSortOrderDescendingDataAttribute()
		: base(CommonSortOrder.Descending)
	{
	}
}
