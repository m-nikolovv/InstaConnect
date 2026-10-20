namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowResponseFluentFactory
{
	public IFollowResponseFluent Create(IAggregateFluent<FollowResponse> fluent);
}
