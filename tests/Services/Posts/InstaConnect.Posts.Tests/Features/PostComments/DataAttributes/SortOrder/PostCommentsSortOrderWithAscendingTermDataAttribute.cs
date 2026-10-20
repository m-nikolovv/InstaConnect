namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentsSortOrderWithAscendingTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<CommonSortOrder, PostComment, DateTimeOffset>
{
	public PostCommentsSortOrderWithAscendingTermDataAttribute()
		: base(CommonSortOrder.Ascending, p => p.CreatedAtUtc)
	{
	}
}
