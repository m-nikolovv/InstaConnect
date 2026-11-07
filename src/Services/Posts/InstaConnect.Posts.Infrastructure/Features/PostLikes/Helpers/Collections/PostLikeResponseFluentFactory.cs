namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeResponseFluentFactory : IPostLikeResponseFluentFactory
{
	public IPostLikeResponseFluent Create(IAggregateFluent<PostLikeResponse> fluent)
	{
		return new PostLikeResponseFluent(fluent);
	}
}
