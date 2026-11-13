namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.SortTermers.ForUser;

internal class ByCreatedAtSortTermer : IPostsForUserSortTermer
{
	public PostsForUserSortTerm SortTerm => PostsForUserSortTerm.ByCreatedAt;

	public Expression<Func<PostResponse, object>> Term => p => p.CreatedAtUtc;
}
