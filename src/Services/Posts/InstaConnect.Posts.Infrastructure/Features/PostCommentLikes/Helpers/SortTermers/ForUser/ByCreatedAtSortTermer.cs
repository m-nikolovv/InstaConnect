namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortTermers.ForUser;

internal class ByCreatedAtSortTermer : IPostCommentLikesForUserSortTermer
{
	public PostCommentLikesForUserSortTerm SortTerm => PostCommentLikesForUserSortTerm.ByCreatedAt;

	public Expression<Func<PostCommentLike, object>> Term => p => p.CreatedAtUtc;
}
