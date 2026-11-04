namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortTermers.ForUser;

internal class ByCreatedAtSortTermer : IPostCommentsForUserSortTermer
{
	public PostCommentsForUserSortTerm SortTerm => PostCommentsForUserSortTerm.ByCreatedAt;

	public Expression<Func<PostComment, object>> Term => p => p.CreatedAtUtc;
}
