namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.SortTermers;

internal class ByCreatedAtSortTermer : IPostsSortTermer
{
	public PostsSortTerm SortTerm => PostsSortTerm.ByCreatedAt;

	public Expression<Func<Post, object>> Term => p => p.CreatedAtUtc;
}
