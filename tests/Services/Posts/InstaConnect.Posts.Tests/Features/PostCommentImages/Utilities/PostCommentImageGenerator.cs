namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageGenerator
{
	extension(PostCommentImage basePostCommentImage)
	{
		public ICollection<PostCommentImage> GenerateAttached(IEnumerable<PostComment> postComments)
		{
			var postCommentImages = basePostCommentImage.Generate(postComments);

			foreach (var postCommentImage in postCommentImages.Where(p => p != basePostCommentImage))
			{
				postCommentImage.PostComment!.AddPostCommentImage(postCommentImage);
			}

			return postCommentImages;
		}

		public ICollection<PostCommentImage> Generate(IEnumerable<PostComment> postComments)
		{
			return [basePostCommentImage, .. postComments
				.SelectMany(postComment =>
					Enumerable.Range(default, DataFaker.GetAverageNumber(PostCommentConfigurations.ImagesMaxCount) - postComment.PostCommentImages.Count).Select(_ =>
					{
						var postCommentImage = new PostCommentImage(
							new(postComment.Id, PostCommentImageDataFaker.GetImageId()),
							new(PostCommentImageDataFaker.GetUrl()),
							PostCommentImageDataFaker.GetCreatedAtUtc());

						postCommentImage.AddPostComment(postComment);

						return postCommentImage;
					}))];
		}
	}
}
