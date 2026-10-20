namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowsSortOrderWithAscendingTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<CommonSortOrder, Follow, DateTimeOffset>
{
	public FollowsSortOrderWithAscendingTermDataAttribute()
		: base(CommonSortOrder.Ascending, p => p.CreatedAtUtc)
	{
	}
}
