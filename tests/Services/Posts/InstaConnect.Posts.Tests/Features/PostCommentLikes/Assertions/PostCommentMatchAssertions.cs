using InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
	extension(PostCommentLike p)
	{
		public void ShouldSatisfy(PostCommentLike postCommentLike)
		{
			p.ShouldSatisfy(u => u.Matches(postCommentLike));
		}
	}
}
