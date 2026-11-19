namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;

public class GetAllFollowsQueryBuilderFactory
{
	public GetAllFollowsQueryBuilder Create(Follow follow, UserId currentUserId)
	{
		return new(follow, currentUserId);
	}
}
