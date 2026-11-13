namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortTermers;

internal class ByUserNameSortTermer : IPostLikesSortTermer
{
	public PostLikesSortTerm SortTerm => PostLikesSortTerm.ByUserName;

	public Expression<Func<PostLikeResponse, object>> Term => p => p.User!.Name;
}
