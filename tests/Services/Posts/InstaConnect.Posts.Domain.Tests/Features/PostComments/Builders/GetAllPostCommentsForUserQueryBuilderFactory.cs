namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsForUserQueryBuilderFactory
{
	public GetAllPostCommentsForUserQueryBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
