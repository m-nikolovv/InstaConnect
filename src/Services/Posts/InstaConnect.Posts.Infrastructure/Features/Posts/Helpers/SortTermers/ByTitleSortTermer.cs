namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.SortTermers;

internal class ByTitleSortTermer : IPostsSortTermer
{
	public PostsSortTerm SortTerm => PostsSortTerm.ByTitle;

	public Expression<Func<PostResponse, object>> Term => p => p.Title;
}
