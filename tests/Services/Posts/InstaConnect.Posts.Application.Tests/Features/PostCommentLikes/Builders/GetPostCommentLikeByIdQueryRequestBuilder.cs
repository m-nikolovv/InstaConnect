namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdQueryRequestBuilder
{
	private string _id;
	private string _commentId;
	private string _userId;
	private string _currentUserId;

	public GetPostCommentLikeByIdQueryRequestBuilder(PostCommentLike postCommentLike, UserId currentUserId)
	{
		_id = postCommentLike.Id.CommentId.Id.Id;
		_commentId = postCommentLike.Id.CommentId.CommentId;
		_userId = postCommentLike.Id.UserId.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetPostCommentLikeByIdQueryRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetPostCommentLikeByIdQueryRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetPostCommentLikeByIdQueryRequestBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public GetPostCommentLikeByIdQueryRequestBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public GetPostCommentLikeByIdQueryRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetPostCommentLikeByIdQueryRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetPostCommentLikeByIdQueryRequestBuilder WithCurrentUserId(User user, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(user.Id.Id);

		return this;
	}

	public GetPostCommentLikeByIdQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetPostCommentLikeByIdQueryRequest Build()
	{
		return new(_id, _commentId, _userId, _currentUserId);
	}
}
