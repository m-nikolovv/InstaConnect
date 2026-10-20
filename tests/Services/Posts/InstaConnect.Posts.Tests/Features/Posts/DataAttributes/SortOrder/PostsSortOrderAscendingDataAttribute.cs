namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsSortOrderAscendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
	public PostsSortOrderAscendingDataAttribute()
		: base(CommonSortOrder.Ascending)
	{
	}
}
