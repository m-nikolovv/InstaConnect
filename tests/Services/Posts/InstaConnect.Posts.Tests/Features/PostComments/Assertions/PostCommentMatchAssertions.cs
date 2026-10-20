using InstaConnect.Posts.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
	extension(PostComment p)
	{
		public void ShouldSatisfy(PostComment postComment)
		{
			p.ShouldSatisfy(u => u.Matches(postComment));
		}
	}
}
