namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesApiRequestBuilderFactory
{
	public GetAllPostCommentLikesApiRequestBuilder Create(PostCommentLike postCommentLike, UserId currentUserId)
	{
		return new(postCommentLike, currentUserId);
	}
}
