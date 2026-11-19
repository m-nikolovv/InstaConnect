namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdQueryBuilderFactory
{
	public GetPostCommentByIdQueryBuilder Create(PostComment postComment, UserId currentUserId)
	{
		return new(postComment, currentUserId);
	}
}
