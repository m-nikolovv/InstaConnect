namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortTermers;

internal class ByCreatedAtSortTermer : IPostCommentLikesSortTermer
{
	public PostCommentLikesSortTerm SortTerm => PostCommentLikesSortTerm.ByCreatedAt;

	public Expression<Func<PostCommentLikeResponse, object>> Term => p => p.CreatedAtUtc;
}
