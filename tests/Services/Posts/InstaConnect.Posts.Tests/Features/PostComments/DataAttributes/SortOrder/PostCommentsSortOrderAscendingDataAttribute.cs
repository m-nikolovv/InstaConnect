namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentsSortOrderAscendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
	public PostCommentsSortOrderAscendingDataAttribute()
		: base(CommonSortOrder.Ascending)
	{
	}
}
