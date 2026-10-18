using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostComments.Helpers;

public class PostCommentIncludeDescriptorFactory : IPostCommentIncludeDescriptorFactory
{
	public PostsIncludeDescriptor CreateUser()
	{
		return new(PostsDestinationType.PostComment, PostsIncludeType.User);
	}

	public PostsIncludeDescriptor CreatePost()
	{
		return new(PostsDestinationType.PostComment, PostsIncludeType.Post);
	}

	public PostsIncludeDescriptor CreatePostCommentLikes()
	{
		return new(PostsDestinationType.PostComment, PostsIncludeType.PostCommentLike);
	}

	public PostsIncludeDescriptor CreatePostCommentImages()
	{
		return new(PostsDestinationType.PostComment, PostsIncludeType.PostCommentImage);
	}
}
