namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortTermers;

internal class ByCreatedAtSortTermer : IPostCommentsSortTermer
{
	public PostCommentsSortTerm SortTerm => PostCommentsSortTerm.ByCreatedAt;

	public Expression<Func<PostCommentResponse, object>> Term => p => p.CreatedAtUtc;
}
