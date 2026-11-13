namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.SortTermers.ForUser;

internal class ByTitleSortTermer : IPostsForUserSortTermer
{
	public PostsForUserSortTerm SortTerm => PostsForUserSortTerm.ByTitle;

	public Expression<Func<PostResponse, object>> Term => p => p.Title;
}
