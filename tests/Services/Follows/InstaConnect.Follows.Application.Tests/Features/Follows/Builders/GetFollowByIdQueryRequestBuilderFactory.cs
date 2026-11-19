namespace InstaConnect.Follows.Application.Tests.Features.Follows.Builders;

public class GetFollowByIdQueryRequestBuilderFactory
{
	public GetFollowByIdQueryRequestBuilder Create(Follow follow, UserId currentUserId)
	{
		return new(follow, currentUserId);
	}
}
