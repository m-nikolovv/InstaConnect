using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeInfrastructureMatcher
{
	extension(PostCommentLike postCommentLike)
	{
		public PostCommentLikeResponse IsPostCommentLikeResponse(CurrentUserQuery currentUserQuery)
		{
			return Matcher.Is<PostCommentLikeResponse>(p => p.Matches(postCommentLike.Id, currentUserQuery, postCommentLike));
		}
	}
}
