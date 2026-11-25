using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;

public static class PostInfrastructureMatcher
{
	extension(Post post)
	{
		public PostResponse IsPostResponse(CurrentUserQuery currentUserQuery)
		{
			return Matcher.Is<PostResponse>(p => p.Matches(post.Id, currentUserQuery, post));
		}
	}
}
