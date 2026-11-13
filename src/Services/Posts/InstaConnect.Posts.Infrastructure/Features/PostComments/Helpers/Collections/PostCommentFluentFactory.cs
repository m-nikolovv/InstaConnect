namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentFluentFactory : IPostCommentFluentFactory
{
	private readonly IPostCommentIncluderFactory _includerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IPostCommentResponseFluentFactory _responseFluentFactory;

	public PostCommentFluentFactory(
		IPostCommentIncluderFactory includerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IPostCommentResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostCommentFluent Create(IAggregateFluent<PostComment> fluent)
	{
		return new PostCommentFluent(
			_includerFactory,
			_responseFluentFactory,
			_fluentHandlerFactory.Create<PostComment, PostCommentId>(fluent));
	}
}
