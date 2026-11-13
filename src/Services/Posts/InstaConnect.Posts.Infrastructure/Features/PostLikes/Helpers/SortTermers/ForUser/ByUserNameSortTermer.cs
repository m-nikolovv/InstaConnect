namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortTermers.ForUser;

internal class ByUserNameSortTermer : IPostLikesForUserSortTermer
{
	public PostLikesForUserSortTerm SortTerm => PostLikesForUserSortTerm.ByUserName;

	public Expression<Func<PostLikeResponse, object>> Term => p => p.User!.Name;
}
