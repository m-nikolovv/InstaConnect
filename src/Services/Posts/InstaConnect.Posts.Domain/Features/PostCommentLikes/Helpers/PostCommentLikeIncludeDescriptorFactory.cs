namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

public class PostCommentLikeIncludeDescriptorFactory : IPostCommentLikeIncludeDescriptorFactory
{
	public PostsIncludeDescriptor CreateUser()
	{
		return new(PostsDestinationType.PostCommentLike, PostsIncludeType.User);
	}

	public PostsIncludeDescriptor CreatePostComment()
	{
		return new(PostsDestinationType.PostCommentLike, PostsIncludeType.PostComment);
	}
}
