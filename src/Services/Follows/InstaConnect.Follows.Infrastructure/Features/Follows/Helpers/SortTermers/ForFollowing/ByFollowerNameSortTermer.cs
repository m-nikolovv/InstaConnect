namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortTermers.ForFollowing;

internal class ByFollowerNameSortTermer : IFollowsForFollowingSortTermer
{
	public FollowsForFollowingSortTerm SortTerm => FollowsForFollowingSortTerm.ByFollowerName;

	public Expression<Func<FollowResponse, object>> Term => p => p.Follower!.Name.Value;
}
