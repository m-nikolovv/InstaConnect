using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;

public static class PostLikeInfrastructureMatcher
{
	extension(PostLike postLike)
	{
		public PostLikeResponse IsPostLikeResponse(CurrentUserQuery currentUserQuery)
		{
			return Matcher.Is<PostLikeResponse>(p => p.Matches(postLike.Id, currentUserQuery, postLike));
		}
	}
}
