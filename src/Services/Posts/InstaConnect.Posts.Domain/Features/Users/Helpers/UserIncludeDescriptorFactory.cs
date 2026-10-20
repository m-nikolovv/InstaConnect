namespace InstaConnect.Posts.Domain.Features.Users.Helpers;

public class UserIncludeDescriptorFactory : IUserIncludeDescriptorFactory
{
	public PostsIncludeDescriptor CreatePosts()
	{
		return new(PostsDestinationType.User, PostsIncludeType.Post);
	}

	public PostsIncludeDescriptor CreatePostLikes()
	{
		return new(PostsDestinationType.User, PostsIncludeType.PostLike);
	}

	public PostsIncludeDescriptor CreatePostComments()
	{
		return new(PostsDestinationType.User, PostsIncludeType.PostComment);
	}

	public PostsIncludeDescriptor CreatePostCommentLikes()
	{
		return new(PostsDestinationType.User, PostsIncludeType.PostCommentLike);
	}
}
