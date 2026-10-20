namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeFluentFactory : IPostCommentLikeFluentFactory
{
	private readonly IPostCommentLikeIncluderFactory _includerFactory;
	private readonly IPostCommentLikeResponseFluentFactory _responseFluentFactory;

	public PostCommentLikeFluentFactory(IPostCommentLikeIncluderFactory includerFactory, IPostCommentLikeResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostCommentLikeFluent Create(IAggregateFluent<PostCommentLike> fluent)
	{
		return new PostCommentLikeFluent(fluent, _includerFactory, _responseFluentFactory);
	}
}
