namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentResponseFluentFactory : IPostCommentResponseFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public PostCommentResponseFluentFactory(IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IPostCommentResponseFluent Create(IAggregateFluent<PostCommentResponse> fluent)
	{
		return new PostCommentResponseFluent(_fluentHandlerFactory.CreateResponse(fluent));
	}
}
