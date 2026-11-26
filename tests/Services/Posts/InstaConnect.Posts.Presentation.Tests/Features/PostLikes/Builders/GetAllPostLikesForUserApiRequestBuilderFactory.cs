namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesForUserApiRequestBuilderFactory
{
	public GetAllPostLikesForUserApiRequestBuilder Create(PostLike postLike, UserId currentUserId)
	{
		return new(postLike, currentUserId);
	}
}
