namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentReference
{
	extension(ICollection<PostComment> postComments)
	{
		public ICollection<PostComment> SetUser()
		{
			foreach (var postComment in postComments)
			{
				postComment.SetUser();
			}

			return postComments;
		}

		public ICollection<PostComment> SetPost()
		{
			foreach (var postComment in postComments)
			{
				postComment.SetPost();
			}

			return postComments;
		}
	}

	extension(PostComment? postComment)
	{
		public PostComment? SetUser()
		{
			postComment?.User?.AddPostComment(postComment);

			return postComment;
		}

		public PostComment? SetPost()
		{
			postComment?.Post?.AddPostComment(postComment);
			postComment?.Post?.SetUser();

			return postComment;
		}
	}
}
