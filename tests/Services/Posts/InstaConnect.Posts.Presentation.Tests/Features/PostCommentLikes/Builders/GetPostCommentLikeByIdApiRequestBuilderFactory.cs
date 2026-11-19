namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdApiRequestBuilderFactory
{
	public GetPostCommentLikeByIdApiRequestBuilder Create(PostCommentLike postCommentLike, UserId currentUserId)
	{
		return new GetPostCommentLikeByIdApiRequestBuilder(postCommentLike, currentUserId);
	}
}
