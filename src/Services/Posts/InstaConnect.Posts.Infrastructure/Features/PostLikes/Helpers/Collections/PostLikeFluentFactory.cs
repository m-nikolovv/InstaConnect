namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeFluentFactory : IPostLikeFluentFactory
{
	private readonly IPostLikeIncluderFactory _includerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IPostLikeResponseFluentFactory _responseFluentFactory;

	public PostLikeFluentFactory(
		IPostLikeIncluderFactory includerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IPostLikeResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostLikeFluent Create(IAggregateFluent<PostLike> fluent)
	{
		return new PostLikeFluent(
			_includerFactory,
			_responseFluentFactory,
			_fluentHandlerFactory.Create<PostLike, PostLikeId>(fluent));
	}
}
