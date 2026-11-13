namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostResponseFluentFactory : IPostResponseFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public PostResponseFluentFactory(IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IPostResponseFluent Create(IAggregateFluent<PostResponse> fluent)
	{
		return new PostResponseFluent(_fluentHandlerFactory.CreateResponse(fluent));
	}
}
