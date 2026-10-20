using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
	extension(PostLike p)
	{
		public void ShouldSatisfy(PostLike postLike)
		{
			p.ShouldSatisfy(u => u.Matches(postLike));
		}
	}
}
