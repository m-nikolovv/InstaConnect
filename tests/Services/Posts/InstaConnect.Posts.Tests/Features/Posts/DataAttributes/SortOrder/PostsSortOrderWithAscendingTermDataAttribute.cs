namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsSortOrderWithAscendingTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<CommonSortOrder, Post, DateTimeOffset>
{
	public PostsSortOrderWithAscendingTermDataAttribute()
		: base(CommonSortOrder.Ascending, p => p.CreatedAtUtc)
	{
	}
}
