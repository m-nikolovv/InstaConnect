namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeReference
{
	extension(ICollection<PostLike> postLikes)
	{
		public ICollection<PostLike> SetUser()
		{
			foreach (var postLike in postLikes)
			{
				postLike.SetUser();
			}

			return postLikes;
		}

		public ICollection<PostLike> SetPost()
		{
			foreach (var postLike in postLikes)
			{
				postLike.SetPost();
			}

			return postLikes;
		}
	}

	extension(PostLike? postLike)
	{
		public PostLike? SetUser()
		{
			postLike?.User?.AddPostLike(postLike);

			return postLike;
		}

		public PostLike? SetPost()
		{
			postLike?.Post?.AddPostLike(postLike);
			postLike?.Post?.SetUser();

			return postLike;
		}
	}
}
