namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeIdBuilder
{
	private string _id;
	private string _commentId;
	private string _userId;

	public PostCommentLikeIdBuilder(PostCommentLikeId id)
	{
		_id = id.CommentId.Id.Id;
		_commentId = id.CommentId.CommentId;
		_userId = id.UserId.Id;
	}

	public PostCommentLikeIdBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public PostCommentLikeIdBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public PostCommentLikeIdBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public PostCommentLikeIdBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public PostCommentLikeIdBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public PostCommentLikeIdBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public PostCommentLikeId Build()
	{
		return new(
			new(
				new(_id),
				_commentId),
			new(_userId));
	}
}
