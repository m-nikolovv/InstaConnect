namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortTermers.ForUser;

internal class ByUserNameSortTermer : IPostCommentLikesForUserSortTermer
{
	public PostCommentLikesForUserSortTerm SortTerm => PostCommentLikesForUserSortTerm.ByUserName;

	public Expression<Func<PostCommentLikeResponse, object>> Term => p => p.User!.Name.Value;
}
