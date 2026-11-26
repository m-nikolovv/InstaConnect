namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdQueryBuilder
{
	private string _id;
	private string _commentId;
	private string _userId;
	private string _currentUserId;

	public GetPostCommentLikeByIdQueryBuilder(PostCommentLike postCommentLike, UserId currentUserId)
	{
		_id = postCommentLike.Id.CommentId.Id.Id;
		_commentId = postCommentLike.Id.CommentId.CommentId;
		_userId = postCommentLike.Id.UserId.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetPostCommentLikeByIdQueryBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetPostCommentLikeByIdQueryBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetPostCommentLikeByIdQueryBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public GetPostCommentLikeByIdQueryBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public GetPostCommentLikeByIdQueryBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetPostCommentLikeByIdQueryBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetPostCommentLikeByIdQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetPostCommentLikeByIdQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetPostCommentLikeByIdQuery Build()
	{
		return new(
			new(
				new(
					new(_id),
					_commentId),
				new(_userId)),
			new(
				new(_currentUserId)));
	}
}
