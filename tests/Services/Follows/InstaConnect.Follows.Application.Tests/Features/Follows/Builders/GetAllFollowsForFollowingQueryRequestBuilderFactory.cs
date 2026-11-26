namespace InstaConnect.Follows.Application.Tests.Features.Follows.Builders;

public class GetAllFollowsForFollowingQueryRequestBuilderFactory
{
	public GetAllFollowsForFollowingQueryRequestBuilder Create(Follow follow, UserId currentUserId)
	{
		return new(follow, currentUserId);
	}
}
