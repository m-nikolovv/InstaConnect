namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowResponseFluentFactory : IFollowResponseFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public FollowResponseFluentFactory(IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IFollowResponseFluent Create(IAggregateFluent<FollowResponse> fluent)
	{
		return new FollowResponseFluent(_fluentHandlerFactory.CreateResponse(fluent));
	}
}
