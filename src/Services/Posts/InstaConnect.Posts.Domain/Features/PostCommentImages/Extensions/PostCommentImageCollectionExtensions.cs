namespace InstaConnect.Posts.Domain.Features.PostCommentImages.Extensions;

public static class PostCommentImageCollectionExtensions
{
	extension(ICollection<PostCommentImage> postCommentImages)
	{
		public ICollection<PostCommentImage> AddPostComment(PostComment postComment)
		{
			foreach (var postCommentImage in postCommentImages)
			{
				postCommentImage.AddPostComment(postComment);
			}

			return postCommentImages;
		}
	}
}
