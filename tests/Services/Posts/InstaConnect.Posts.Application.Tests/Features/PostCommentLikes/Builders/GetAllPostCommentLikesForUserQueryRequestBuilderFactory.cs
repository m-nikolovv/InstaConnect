namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesForUserQueryRequestBuilderFactory
{
	public GetAllPostCommentLikesForUserQueryRequestBuilder Create(PostCommentLike postCommentLike, UserId currentUserId)
	{
		return new(postCommentLike, currentUserId);
	}
}
