namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortTermers;

internal class ByCreatedAtSortTermer : IFollowsSortTermer
{
	public FollowsSortTerm SortTerm => FollowsSortTerm.ByCreatedAt;

	public Expression<Func<FollowResponse, object>> Term => p => p.CreatedAtUtc;
}
