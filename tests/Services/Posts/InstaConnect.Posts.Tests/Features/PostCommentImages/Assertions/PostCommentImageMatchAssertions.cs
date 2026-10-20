namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Assertions;

public static class PostCommentImageMatchAssertions
{
	extension(ICollection<PostCommentImage> p)
	{
		public void ShouldSatisfy(ICollection<PostCommentImage> postCommentImages)
		{
			p.ShouldSatisfy(u => u.Matches(postCommentImages));
		}
	}

	extension(PostCommentImage p)
	{
		public void ShouldSatisfy(PostCommentImage postCommentImage)
		{
			p.ShouldSatisfy(u => u.Matches(postCommentImage));
		}
	}
}
