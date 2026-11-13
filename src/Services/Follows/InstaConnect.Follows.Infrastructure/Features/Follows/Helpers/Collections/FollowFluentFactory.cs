namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowFluentFactory : IFollowFluentFactory
{
	private readonly IFollowIncluderFactory _includerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IFollowResponseFluentFactory _responseFluentFactory;

	public FollowFluentFactory(
		IFollowIncluderFactory includerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IFollowResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IFollowFluent Create(IAggregateFluent<Follow> fluent)
	{
		return new FollowFluent(
			_includerFactory,
			_responseFluentFactory,
			_fluentHandlerFactory.Create<Follow, FollowId>(fluent));
	}
}
