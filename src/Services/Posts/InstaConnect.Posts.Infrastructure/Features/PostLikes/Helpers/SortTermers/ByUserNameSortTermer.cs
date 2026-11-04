namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortTermers;

internal class ByUserNameSortTermer : IPostLikesSortTermer
{
	public PostLikesSortTerm SortTerm => PostLikesSortTerm.ByUserName;

	public Expression<Func<PostLike, object>> Term => p => p.User!.Name;
}
