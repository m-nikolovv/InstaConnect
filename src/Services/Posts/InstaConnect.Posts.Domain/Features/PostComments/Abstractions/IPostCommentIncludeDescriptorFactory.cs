namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentIncludeDescriptorFactory
{
	public PostsIncludeDescriptor CreateUser();

	public PostsIncludeDescriptor CreatePost();

	public PostsIncludeDescriptor CreatePostCommentLikes();

	public PostsIncludeDescriptor CreatePostCommentImages();
}
