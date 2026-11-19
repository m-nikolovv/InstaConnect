namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdQueryRequestBuilderFactory
{
	public GetPostCommentLikeByIdQueryRequestBuilder Create(PostCommentLike postCommentLike, UserId currentUserId)
	{
		return new(postCommentLike, currentUserId);
	}
}
