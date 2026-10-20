namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostFluentFactory : IPostFluentFactory
{
	private readonly IPostIncluderFactory _includerFactory;
	private readonly IPostResponseFluentFactory _responseFluentFactory;

	public PostFluentFactory(IPostIncluderFactory includerFactory, IPostResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IPostFluent Create(IAggregateFluent<Post> fluent)
	{
		return new PostFluent(fluent, _includerFactory, _responseFluentFactory);
	}
}
