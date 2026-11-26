namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsForUserApiRequestBuilderFactory
{
	public GetAllPostCommentsForUserApiRequestBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
