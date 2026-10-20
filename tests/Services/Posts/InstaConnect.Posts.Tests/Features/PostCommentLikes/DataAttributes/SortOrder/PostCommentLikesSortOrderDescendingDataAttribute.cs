namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikesSortOrderDescendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
	public PostCommentLikesSortOrderDescendingDataAttribute()
		: base(CommonSortOrder.Descending)
	{
	}
}
