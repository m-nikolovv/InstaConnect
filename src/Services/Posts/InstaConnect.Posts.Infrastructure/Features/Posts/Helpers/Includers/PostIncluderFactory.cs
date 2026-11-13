namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includers;

internal class PostIncluderFactory
	: IncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IPostIncluder, Post>, IPostIncluderFactory
{
	public PostIncluderFactory(IEnumerable<IPostIncluder> includers) : base(includers)
	{
	}
}
