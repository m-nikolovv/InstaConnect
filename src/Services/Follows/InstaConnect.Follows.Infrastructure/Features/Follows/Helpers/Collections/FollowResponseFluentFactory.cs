namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowResponseFluentFactory : IFollowResponseFluentFactory
{
	public IFollowResponseFluent Create(IAggregateFluent<FollowResponse> fluent)
	{
		return new FollowResponseFluent(fluent);
	}
}
