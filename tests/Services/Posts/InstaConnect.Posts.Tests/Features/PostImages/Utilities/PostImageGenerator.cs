namespace InstaConnect.Posts.Tests.Features.PostImages.Utilities;

public static class PostImageGenerator
{
	extension(PostImage basePostImage)
	{
		public ICollection<PostImage> GenerateAttached(IEnumerable<Post> posts)
		{
			var postImages = basePostImage.Generate(posts);

			foreach (var postImage in postImages.Where(p => p != basePostImage))
			{
				postImage.Post!.AddPostImage(postImage);
			}

			return postImages;
		}

		public ICollection<PostImage> Generate(IEnumerable<Post> posts)
		{
			return [basePostImage, .. posts
				.SelectMany(post =>
					Enumerable.Range(default, PostImageDataFaker.GetImagesCount()).Select(_ =>
					{
						var postImage = new PostImage(
							new(post.Id, PostImageDataFaker.GetImageId()),
							new(PostImageDataFaker.GetUrl()),
							PostImageDataFaker.GetCreatedAtUtc());

						postImage.AddPost(post);

						return postImage;
					}))];
		}
	}
}
