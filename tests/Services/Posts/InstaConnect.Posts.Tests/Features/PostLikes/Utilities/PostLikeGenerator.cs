namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeGenerator
{
	extension(PostLike basePostLike)
	{
		public ICollection<PostLike> GenerateAttached(IEnumerable<Post> posts, IEnumerable<User> users)
		{
			var postLikes = basePostLike.Generate(posts, users);

			foreach (var postLike in postLikes.Where(p => p != basePostLike))
			{
				postLike.User!.AddPostLike(postLike);
				postLike.Post!.AddPostLike(postLike);
			}

			return postLikes;
		}

		public ICollection<PostLike> Generate(IEnumerable<Post> posts, IEnumerable<User> users)
		{
			return [.. posts
			  .SelectMany(post =>
				  users.Select(user =>
				  {
					  var postLike = new PostLike(
						  new(post.Id, user.Id),
						  PostLikeDataFaker.GetCreatedAtUtc());

					  if(basePostLike.Id == postLike.Id)
					  {
						  return basePostLike;
					  }

					  postLike.AddUser(user);
					  postLike.AddPost(post);

					  return postLike;
				  }))];
		}
	}
}
