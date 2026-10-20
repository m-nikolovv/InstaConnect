namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostGenerator
{
	extension(Post basePost)
	{
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
					user.AddPost(post);

					return post;
				}))];
		}
	}
}
