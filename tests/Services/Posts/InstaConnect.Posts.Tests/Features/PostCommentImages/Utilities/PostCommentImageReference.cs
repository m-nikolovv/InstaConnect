using InstaConnect.Posts.Domain.Features.PostCommentImages.Extensions;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageReference
{
	extension(PostComment? postComment)
	{
		public PostComment? SetPostCommentImages()
		{
			postComment?.PostCommentImages.AddPostComment(postComment);

			return postComment;
		}
	}
}
