namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentMapper
{
	extension(PostComment postComment)
	{
		public PostCommentId ToId()
		{
			return postComment.Id;
		}
	}
}
