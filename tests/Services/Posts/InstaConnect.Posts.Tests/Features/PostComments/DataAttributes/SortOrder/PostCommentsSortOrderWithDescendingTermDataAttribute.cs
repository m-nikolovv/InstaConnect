namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentsSortOrderWithDescendingTermDataAttribute
	: SortEnumWithDescendingTermDataAttribute<CommonSortOrder, PostComment, DateTimeOffset>
{
	public PostCommentsSortOrderWithDescendingTermDataAttribute()
		: base(CommonSortOrder.Descending, p => p.CreatedAtUtc)
	{
	}
}
