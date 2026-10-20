namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeIncludeDescriptorFactory
{
	public PostsIncludeDescriptor CreateUser();

	public PostsIncludeDescriptor CreatePost();
}
