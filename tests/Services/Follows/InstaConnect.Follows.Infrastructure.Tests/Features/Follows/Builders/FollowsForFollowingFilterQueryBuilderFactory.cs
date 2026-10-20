namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Builders;

public class FollowsForFollowingFilterQueryBuilderFactory
{
	public FollowsForFollowingFilterQueryBuilder Create(Follow follow)
	{
		return new(follow);
	}
}
