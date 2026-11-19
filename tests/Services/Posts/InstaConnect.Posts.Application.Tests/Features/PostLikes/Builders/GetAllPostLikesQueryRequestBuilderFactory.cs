namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesQueryRequestBuilderFactory
{
	public GetAllPostLikesQueryRequestBuilder Create(PostLike postLike, UserId currentUserId)
	{
		return new(postLike, currentUserId);
	}
}
