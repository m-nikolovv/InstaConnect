namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikesSortOrderAscendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
	public PostCommentLikesSortOrderAscendingDataAttribute()
		: base(CommonSortOrder.Ascending)
	{
	}
}
