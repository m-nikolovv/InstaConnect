namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeResponseFluentFactory : IPostLikeResponseFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public PostLikeResponseFluentFactory(IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IPostLikeResponseFluent Create(IAggregateFluent<PostLikeResponse> fluent)
	{
		return new PostLikeResponseFluent(_fluentHandlerFactory.CreateResponse(fluent));
	}
}
