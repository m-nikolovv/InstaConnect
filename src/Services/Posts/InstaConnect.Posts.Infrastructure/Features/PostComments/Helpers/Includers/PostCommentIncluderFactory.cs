namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class PostCommentIncluderFactory
	: IncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IPostCommentIncluder, PostComment>, IPostCommentIncluderFactory
{
	public PostCommentIncluderFactory(IEnumerable<IPostCommentIncluder> includers) : base(includers)
	{
	}
}
