namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeFluentFactory : IPostCommentLikeFluentFactory
{
	private readonly IPostCommentLikeIncluderFactory _includerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IPostCommentLikeResponseFluentFactory _responseFluentFactory;

	public PostCommentLikeFluentFactory(
		IPostCommentLikeIncluderFactory includerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IPostCommentLikeResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostCommentLikeFluent Create(IAggregateFluent<PostCommentLike> fluent)
	{
		return new PostCommentLikeFluent(
			_includerFactory,
			_responseFluentFactory,
			_fluentHandlerFactory.Create<PostCommentLike, PostCommentLikeId>(fluent));
	}
}
