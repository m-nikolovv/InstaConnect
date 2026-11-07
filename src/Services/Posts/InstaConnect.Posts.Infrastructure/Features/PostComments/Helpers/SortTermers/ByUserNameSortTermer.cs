namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortTermers;

internal class ByUserNameSortTermer : IPostCommentsSortTermer
{
	public PostCommentsSortTerm SortTerm => PostCommentsSortTerm.ByUserName;

	public Expression<Func<PostComment, object>> Term => p => p.User!.Name;
}
