namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostIncludeDescriptorFactory
{
	public PostsIncludeDescriptor CreateUser();

	public PostsIncludeDescriptor CreatePostLikes();

	public PostsIncludeDescriptor CreatePostComments();

	public PostsIncludeDescriptor CreatePostImages();
}
