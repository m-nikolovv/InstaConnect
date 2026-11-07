using InstaConnect.Posts.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
	extension(Post p)
	{
		public void ShouldSatisfy(Post post)
		{
			p.ShouldSatisfy(u => u.Matches(post));
		}
	}

	extension(ICollection<Post> p)
	{
		public void ShouldSatisfy(ICollection<Post> posts)
		{
			p.ShouldSatisfy(u => u.Matches(posts));
		}
	}
}
