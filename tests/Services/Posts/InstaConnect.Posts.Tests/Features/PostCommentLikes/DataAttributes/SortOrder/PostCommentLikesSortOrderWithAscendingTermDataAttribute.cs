namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikesSortOrderWithAscendingTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<CommonSortOrder, PostCommentLike, DateTimeOffset>
{
	public PostCommentLikesSortOrderWithAscendingTermDataAttribute()
		: base(CommonSortOrder.Ascending, p => p.CreatedAtUtc)
	{
	}
}
