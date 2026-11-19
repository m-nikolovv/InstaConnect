namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentLikeIncluderFactory
	: IncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IPostCommentLikeIncluder, PostCommentLike>, IPostCommentLikeIncluderFactory
{
	public PostCommentLikeIncluderFactory(IEnumerable<IPostCommentLikeIncluder> includers) : base(includers)
	{
	}
}
