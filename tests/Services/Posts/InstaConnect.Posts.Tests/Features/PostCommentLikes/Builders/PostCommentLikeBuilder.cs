namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeBuilder
{
	private string _id;
	private string _commentId;
	private readonly PostComment _postComment;
	private string _userId;
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

	public PostCommentLikeBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public PostCommentLikeBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public PostCommentLikeBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public PostCommentLike BuildAttached()
	{
		var postCommentLike = Build();

		_user.AddPostCommentLike(postCommentLike);
		_postComment.AddPostCommentLike(postCommentLike);

		return postCommentLike;
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

		postCommentLike.AddUser(_user);
		postCommentLike.AddPostComment(_postComment);

		return postCommentLike;
	}
}
