namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortTermers;

internal class ByFollowingNameSortTermer : IFollowsSortTermer
{
	public FollowsSortTerm SortTerm => FollowsSortTerm.ByFollowingName;

	public Expression<Func<FollowResponse, object>> Term => p => p.Following!.Name.Value;
}
