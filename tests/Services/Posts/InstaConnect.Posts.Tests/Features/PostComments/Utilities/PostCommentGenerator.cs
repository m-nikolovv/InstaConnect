namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentGenerator
{
	extension(PostComment basePostComment)
	{
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
						user.AddPostComment(postComment);
						post.AddPostComment(postComment);

						return postComment;
				  }))];
		}
	}
}
