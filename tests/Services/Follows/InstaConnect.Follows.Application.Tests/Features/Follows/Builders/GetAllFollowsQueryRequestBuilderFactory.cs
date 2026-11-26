namespace InstaConnect.Follows.Application.Tests.Features.Follows.Builders;

public class GetAllFollowsQueryRequestBuilderFactory
{
	public GetAllFollowsQueryRequestBuilder Create(Follow follow, UserId currentUserId)
	{
		return new(follow, currentUserId);
	}
}
