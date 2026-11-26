namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsForUserQueryRequestBuilderFactory
{
	public GetAllPostCommentsForUserQueryRequestBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
