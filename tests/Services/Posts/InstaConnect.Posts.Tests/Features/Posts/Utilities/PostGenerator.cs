namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostGenerator
{
	extension(Post basePost)
	{
		public ICollection<Post> GenerateAttached(IEnumerable<User> users)
		{
			var posts = basePost.Generate(users);

			foreach (var post in posts.Where(p => p != basePost))
			{
				post.User!.AddPost(post);
			}

			return posts;
		}

		public ICollection<Post> Generate(IEnumerable<User> users)
		{
			const int NumberOfIterations = 3;

			return [basePost, .. users
			.SelectMany(user =>
				Enumerable.Range(default, NumberOfIterations).Select(_ =>
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
