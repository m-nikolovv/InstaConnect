namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
	extension(PostLike postLike)
	{
		public PostLikeId ToId()
		{
			return postLike.Id;
		}
	}
}
