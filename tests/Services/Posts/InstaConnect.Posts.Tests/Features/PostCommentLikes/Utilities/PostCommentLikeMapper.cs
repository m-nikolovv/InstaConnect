namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMapper
{
	extension(PostCommentLike postCommentLike)
	{
		public PostCommentLikeId ToId()
		{
			return postCommentLike.Id;
		}
	}
}
