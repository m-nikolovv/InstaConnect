namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesForUserApiRequestBuilderFactory
{
	public GetAllPostCommentLikesForUserApiRequestBuilder Create(PostCommentLike postCommentLike, UserId currentUserId)
	{
		return new(postCommentLike, currentUserId);
	}
}
