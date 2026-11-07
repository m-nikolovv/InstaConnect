namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentGenerator
{
	extension(PostComment basePostComment)
	{
		public ICollection<PostComment> GenerateAttached(IEnumerable<Post> posts, IEnumerable<User> users)
		{
			var postComments = basePostComment.Generate(posts, users);

			foreach (var postComment in postComments.Where(p => p != basePostComment))
			{
				postComment.User!.AddPostComment(postComment);
				postComment.Post!.AddPostComment(postComment);
			}

			return postComments;
		}

		public ICollection<PostComment> Generate(IEnumerable<Post> posts, IEnumerable<User> users)
		{
			return [basePostComment, .. posts
			  .SelectMany(post =>
				  users.Select(user =>
				  {
						var postComment = new PostComment(new(
														 post.Id,
														 PostCommentDataFaker.GetId()),
														 PostCommentDataFaker.GetContent(),
														 new(PostCommentDataFaker.GetSummary()),
														 user.Id,
														 PostCommentDataFaker.GetCreatedAtUtc(),
														 PostCommentDataFaker.GetUpdatedAtUtc());

						postComment.AddUser(user);
						postComment.AddPost(post);

						return postComment;
				  }))];
		}
	}
}
