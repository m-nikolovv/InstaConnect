namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortTermers;

internal class ByCreatedAtSortTermer : IPostLikesSortTermer
{
	public PostLikesSortTerm SortTerm => PostLikesSortTerm.ByCreatedAt;

	public Expression<Func<PostLikeResponse, object>> Term => p => p.CreatedAtUtc;
}
