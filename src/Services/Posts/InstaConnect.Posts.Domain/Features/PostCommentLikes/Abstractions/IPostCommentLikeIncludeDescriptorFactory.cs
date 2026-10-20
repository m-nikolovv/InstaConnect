namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeIncludeDescriptorFactory
{
	public PostsIncludeDescriptor CreateUser();

	public PostsIncludeDescriptor CreatePostComment();
}
