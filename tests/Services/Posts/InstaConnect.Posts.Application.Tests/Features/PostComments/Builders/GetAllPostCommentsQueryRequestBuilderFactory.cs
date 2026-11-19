namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsQueryRequestBuilderFactory
{
	public GetAllPostCommentsQueryRequestBuilder Create(PostComment postComment, UserId currentUserId)
	{
		return new(postComment, currentUserId);
	}
}
