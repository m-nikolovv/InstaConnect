namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowFluentFactory
{
	public IFollowFluent Create(IAggregateFluent<Follow> fluent);
}
