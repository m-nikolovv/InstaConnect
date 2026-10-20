namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikesSortOrderAscendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
	public PostLikesSortOrderAscendingDataAttribute()
		: base(CommonSortOrder.Ascending)
	{
	}
}
