namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsQueryBuilderFactory
{
	public GetAllPostCommentsQueryBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
