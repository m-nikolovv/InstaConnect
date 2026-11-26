namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;

public class GetAllFollowsForFollowingQueryBuilderFactory
{
	public GetAllFollowsForFollowingQueryBuilder Create(Follow follow, UserId currentUserId)
	{
		return new(follow, currentUserId);
	}
}
