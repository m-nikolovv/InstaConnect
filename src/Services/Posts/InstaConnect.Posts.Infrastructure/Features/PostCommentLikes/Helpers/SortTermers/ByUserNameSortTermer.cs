namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortTermers;

internal class ByUserNameSortTermer : IPostCommentLikesSortTermer
{
	public PostCommentLikesSortTerm SortTerm => PostCommentLikesSortTerm.ByUserName;

	public Expression<Func<PostCommentLikeResponse, object>> Term => p => p.User!.Name.Value;
}
