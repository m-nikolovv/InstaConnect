namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.SortTermers;

internal class ByUserNameSortTermer : IPostsSortTermer
{
	public PostsSortTerm SortTerm => PostsSortTerm.ByUserName;

	public Expression<Func<Post, object>> Term => p => p.User!.Name.Value;
}
