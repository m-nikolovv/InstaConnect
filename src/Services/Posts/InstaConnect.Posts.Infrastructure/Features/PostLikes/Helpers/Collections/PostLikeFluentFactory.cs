namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeFluentFactory : IPostLikeFluentFactory
{
	private readonly IPostLikeIncluderFactory _includerFactory;
	private readonly IPostLikeResponseFluentFactory _responseFluentFactory;

	public PostLikeFluentFactory(IPostLikeIncluderFactory includerFactory, IPostLikeResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostLikeFluent Create(IAggregateFluent<PostLike> fluent)
	{
		return new PostLikeFluent(fluent, _includerFactory, _responseFluentFactory);
	}
}
