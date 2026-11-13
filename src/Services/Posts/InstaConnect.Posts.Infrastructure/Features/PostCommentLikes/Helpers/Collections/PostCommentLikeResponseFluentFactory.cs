namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeResponseFluentFactory : IPostCommentLikeResponseFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public PostCommentLikeResponseFluentFactory(IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IPostCommentLikeResponseFluent Create(IAggregateFluent<PostCommentLikeResponse> fluent)
	{
		return new PostCommentLikeResponseFluent(_fluentHandlerFactory.CreateResponse(fluent));
	}
}
