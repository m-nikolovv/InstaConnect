namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowFluentFactory : IFollowFluentFactory
{
	private readonly IFollowIncluderFactory _includerFactory;
	private readonly IFollowResponseFluentFactory _responseFluentFactory;

	public FollowFluentFactory(IFollowIncluderFactory includerFactory, IFollowResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IFollowFluent Create(IAggregateFluent<Follow> fluent)
	{
		return new FollowFluent(fluent, _includerFactory, _responseFluentFactory);
	}
}
