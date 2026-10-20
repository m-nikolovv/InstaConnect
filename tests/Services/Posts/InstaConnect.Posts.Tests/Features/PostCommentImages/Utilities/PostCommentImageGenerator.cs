namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageGenerator
{
	extension(PostCommentImage basePostCommentImage)
	{
		public ICollection<PostCommentImage> Generate(IEnumerable<PostComment> postComments, int numberOfIterations = 5)
		{
			return [basePostCommentImage, .. postComments
				.SelectMany(postComment =>
					Enumerable.Range(default, numberOfIterations).Select(_ =>
					{
						var postCommentImage = new PostCommentImage(
							new(postComment.Id, PostCommentImageDataFaker.GetImageId()),
							new(PostCommentImageDataFaker.GetUrl()),
							PostCommentImageDataFaker.GetCreatedAtUtc());

						postComment.AddPostCommentImage(postCommentImage);
						postCommentImage.AddPostComment(postComment);

						return postCommentImage;
					}))];
		}
	}
}
