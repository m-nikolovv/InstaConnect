namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdQueryRequestBuilderFactory
{
	public GetPostCommentByIdQueryRequestBuilder Create(PostComment postComment, UserId currentUserId)
	{
		return new(postComment, currentUserId);
	}
}
