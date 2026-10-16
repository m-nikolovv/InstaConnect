namespace InstaConnect.Posts.Tests.Features.PostImages.Utilities;

public static class PostImageGenerator
{
	extension(PostImage basePostImage)
	{
		public ICollection<PostImage> Generate(IEnumerable<Post> posts, int numberOfIterations)
		{
			return [basePostImage, .. posts
				.SelectMany(post =>
					Enumerable.Range(default, numberOfIterations).Select(_ =>
					{
						var postImage = new PostImage(
							new(post.Id, PostImageDataFaker.GetImageId()),
							new(PostImageDataFaker.GetUrl()),
							PostImageDataFaker.GetCreatedAtUtc());

						post.AddPostImage(postImage);
						postImage.AddPost(post);

						return postImage;
					}))];
		}
	}
}
