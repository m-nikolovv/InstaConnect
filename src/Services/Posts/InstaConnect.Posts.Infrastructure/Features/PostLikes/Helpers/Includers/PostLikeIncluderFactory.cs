namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class PostLikeIncluderFactory
	: IncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IPostLikeIncluder, PostLike>, IPostLikeIncluderFactory
{
	public PostLikeIncluderFactory(IEnumerable<IPostLikeIncluder> includers) : base(includers)
	{
	}
}
