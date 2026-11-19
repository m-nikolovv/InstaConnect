namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;

public class GetFollowByIdQueryBuilderFactory
{
	public GetFollowByIdQueryBuilder Create(Follow follow, UserId currentUserId)
	{
		return new(follow, currentUserId);
	}
}
