using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostImages.Assertions;

public static class PostImageMatchAssertions
{
	extension(ICollection<PostImage> p)
	{
		public void ShouldSatisfy(ICollection<PostImage> postImages)
		{
			p.ShouldSatisfy(u => u.Matches(postImages));
		}
	}

	extension(PostImage p)
	{
		public void ShouldSatisfy(PostImage postImage)
		{
			p.ShouldSatisfy(u => u.Matches(postImage));
		}
	}
}
