namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.SortTermers.ForUser;

internal class ByUserNameSortTermer : IPostsForUserSortTermer
{
	public PostsForUserSortTerm SortTerm => PostsForUserSortTerm.ByUserName;

	public Expression<Func<PostResponse, object>> Term => p => p.User!.Name.Value;
}
