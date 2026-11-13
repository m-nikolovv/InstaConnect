namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortTermers.ForUser;

internal class ByCreatedAtSortTermer : IPostLikesForUserSortTermer
{
	public PostLikesForUserSortTerm SortTerm => PostLikesForUserSortTerm.ByCreatedAt;

	public Expression<Func<PostLikeResponse, object>> Term => p => p.CreatedAtUtc;
}
