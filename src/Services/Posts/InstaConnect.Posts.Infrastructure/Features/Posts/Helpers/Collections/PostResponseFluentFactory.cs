namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostResponseFluentFactory : IPostResponseFluentFactory
{
	public IPostResponseFluent Create(IAggregateFluent<PostResponse> fluent)
	{
		return new PostResponseFluent(fluent);
	}
}
