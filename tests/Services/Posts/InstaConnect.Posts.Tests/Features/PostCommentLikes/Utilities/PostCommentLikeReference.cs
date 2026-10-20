namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeReference
{
	extension(ICollection<PostCommentLike> postCommentLikes)
	{
		public ICollection<PostCommentLike> SetUser()
		{
			foreach (var postCommentLike in postCommentLikes)
			{
				postCommentLike.SetUser();
			}

			return postCommentLikes;
		}

		public ICollection<PostCommentLike> SetPostComment()
		{
			foreach (var postCommentLike in postCommentLikes)
			{
				postCommentLike.SetPostComment();
			}

			return postCommentLikes;
		}
	}

	extension(PostCommentLike? postCommentLike)
	{
		public PostCommentLike? SetUser()
		{
			postCommentLike?.User?.AddPostCommentLike(postCommentLike);

			return postCommentLike;
		}

		public PostCommentLike? SetPostComment()
		{
			postCommentLike?.PostComment?.AddPostCommentLike(postCommentLike);
			postCommentLike?.PostComment?.SetUser().SetPost();

			return postCommentLike;
		}
	}
}
