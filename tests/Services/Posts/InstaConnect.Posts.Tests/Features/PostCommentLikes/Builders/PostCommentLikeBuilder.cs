namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeBuilder
{
	private readonly string _id;
	private readonly string _commentId;
	private readonly PostComment _postComment;
	private readonly string _userId;
	private readonly User _user;
	private readonly DateTimeOffset _createdAtUtc;

	public PostCommentLikeBuilder(PostComment postComment, User user)
	{
		_id = postComment.Id.Id.Id;
		_commentId = postComment.Id.CommentId;
		_postComment = postComment;
		_userId = user.Id.Id;
		_user = user;
		_createdAtUtc = PostCommentLikeDataFaker.GetCreatedAtUtc();
	}

	public PostCommentLikeBuilder(PostCommentLike postCommentLike)
	{
		_id = postCommentLike.Id.CommentId.Id.Id;
		_commentId = postCommentLike.Id.CommentId.CommentId;
		_postComment = postCommentLike.PostComment!;
		_userId = postCommentLike.Id.UserId.Id;
		_user = postCommentLike.User!;
		_createdAtUtc = postCommentLike.CreatedAtUtc;
	}

	public PostCommentLike Build()
	{
		var postCommentLike = new PostCommentLike(
				new(
					new(
						new(_id),
						_commentId),
					new(_userId)),
				_createdAtUtc);

		_user.AddPostCommentLike(postCommentLike);
		_postComment.AddPostCommentLike(postCommentLike);
		postCommentLike.AddUser(_user);
		postCommentLike.AddPostComment(_postComment);

		return postCommentLike;
	}
}
