namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostGenerator
{
	extension(Post basePost)
	{
		public ICollection<Post> GenerateAttached(IEnumerable<User> users, int numberOfIterations = 3)
		{
			var posts = basePost.Generate(users, numberOfIterations);

			foreach (var post in posts.Where(p => p != basePost))
			{
				post.User!.AddPost(post);
			}

			return posts;
		}

		public ICollection<Post> Generate(IEnumerable<User> users, int numberOfIterations = 3)
		{
			return [basePost, .. users
			.SelectMany(user =>
				Enumerable.Range(default, numberOfIterations).Select(_ =>
				{
					var post = new Post(
						new(PostDataFaker.GetId()),
						PostDataFaker.GetTitleWithPrefix(basePost.Title),
						PostDataFaker.GetContent(),
						new(PostDataFaker.GetSummary()),
						user.Id,
						PostDataFaker.GetCreatedAtUtc(),
						PostDataFaker.GetUpdatedAtUtc());

					post.AddUser(user);

					return post;
				}))];
		}
	}
}
