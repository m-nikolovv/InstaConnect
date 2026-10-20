namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentSummarizeRequestFactory
{
	public ChatMessage Create(PostComment postComment);
}
