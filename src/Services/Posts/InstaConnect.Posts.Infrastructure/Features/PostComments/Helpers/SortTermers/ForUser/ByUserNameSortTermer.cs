namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortTermers.ForUser;

internal class ByUserNameSortTermer : IPostCommentsForUserSortTermer
{
	public PostCommentsForUserSortTerm SortTerm => PostCommentsForUserSortTerm.ByUserName;

	public Expression<Func<PostCommentResponse, object>> Term => p => p.User!.Name;
}
