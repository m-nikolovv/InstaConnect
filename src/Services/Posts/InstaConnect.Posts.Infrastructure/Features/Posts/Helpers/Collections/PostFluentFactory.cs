namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostFluentFactory : IPostFluentFactory
{
	private readonly IPostIncluderFactory _includerFactory;
	private readonly IPostResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public PostFluentFactory(
		IPostIncluderFactory includerFactory,
		IPostResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_includerFactory = includerFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostFluent Create(IAggregateFluent<Post> fluent)
	{
		return new PostFluent(
			_includerFactory,
			_responseFluentFactory,
			_fluentHandlerFactory.Create<Post, PostId>(fluent));
	}
}
