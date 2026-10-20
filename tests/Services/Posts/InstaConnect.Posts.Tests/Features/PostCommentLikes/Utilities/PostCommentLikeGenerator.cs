namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeGenerator
{
	extension(PostCommentLike basePostCommentLike)
	{
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

					  user.AddPostCommentLike(postCommentLike);
					  postComment.AddPostCommentLike(postCommentLike);
					  postCommentLike.AddUser(user);
					  postCommentLike.AddPostComment(postComment);

					  return postCommentLike;
				  }))];
		}
	}
}
