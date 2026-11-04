namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowResponseFluent :
	MongoDbResponseFluent<FollowResponse>, IFollowResponseFluent
{
	public FollowResponseFluent(IAggregateFluent<FollowResponse> fluent) : base(fluent)
	{
	}
}
