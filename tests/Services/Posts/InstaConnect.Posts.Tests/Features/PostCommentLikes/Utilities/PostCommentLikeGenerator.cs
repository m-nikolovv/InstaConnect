namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeGenerator
{
	extension(PostCommentLike basePostCommentLike)
	{
		public ICollection<PostCommentLike> GenerateAttached(
		IEnumerable<PostComment> postComments,
		IEnumerable<User> users)
		{
			var postCommentLikes = basePostCommentLike.Generate(postComments, users);

			foreach (var postCommentLike in postCommentLikes.Where(p => p != basePostCommentLike))
			{
				postCommentLike.User!.AddPostCommentLike(postCommentLike);
				postCommentLike.PostComment!.AddPostCommentLike(postCommentLike);
			}

			return postCommentLikes;
		}

		public ICollection<PostCommentLike> Generate(
		IEnumerable<PostComment> postComments,
		IEnumerable<User> users)
		{
			return [.. postComments
			  .SelectMany(postComment =>
				  users.Select(user =>
				  {
					  var postCommentLike = new PostCommentLike(
						  new(postComment.Id, user.Id),
						  PostLikeDataFaker.GetCreatedAtUtc());

					  if(basePostCommentLike.Id == postCommentLike.Id)
					  {
						  return basePostCommentLike;
					  }

					  postCommentLike.AddUser(user);
					  postCommentLike.AddPostComment(postComment);

					  return postCommentLike;
				  }))];
		}
	}
}
