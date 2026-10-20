namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentFluentFactory : IPostCommentFluentFactory
{
	private readonly IPostCommentIncluderFactory _includerFactory;
	private readonly IPostCommentResponseFluentFactory _responseFluentFactory;

	public PostCommentFluentFactory(IPostCommentIncluderFactory includerFactory, IPostCommentResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostCommentFluent Create(IAggregateFluent<PostComment> fluent)
	{
		return new PostCommentFluent(fluent, _includerFactory, _responseFluentFactory);
	}
}
