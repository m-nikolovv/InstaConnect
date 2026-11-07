namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortTermers.ForFollowing;

internal class ByCreatedAtSortTermer : IFollowsForFollowingSortTermer
{
	public FollowsForFollowingSortTerm SortTerm => FollowsForFollowingSortTerm.ByCreatedAt;

	public Expression<Func<Follow, object>> Term => p => p.CreatedAtUtc;
}
