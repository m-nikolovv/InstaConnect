namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentsSortOrderDescendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
	public PostCommentsSortOrderDescendingDataAttribute()
		: base(CommonSortOrder.Descending)
	{
	}
}
