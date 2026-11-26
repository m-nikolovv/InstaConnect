namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdQueryBuilderFactory
{
	public GetPostCommentByIdQueryBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
