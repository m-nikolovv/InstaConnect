using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

public static class PostCommentInfrastructureMatcher
{
	extension(PostComment postComment)
	{
		public PostCommentResponse IsPostCommentResponse(CurrentUserQuery currentUserQuery)
		{
			return Matcher.Is<PostCommentResponse>(p => p.MatchesFull(currentUserQuery.Id, postComment));
		}
	}
}
