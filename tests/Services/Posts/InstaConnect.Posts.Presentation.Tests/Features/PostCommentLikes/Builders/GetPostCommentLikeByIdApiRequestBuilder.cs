namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdApiRequestBuilder
{
	private string _id;
	private string _commentId;
	private string _userId;
	private string _currentUserId;

	public GetPostCommentLikeByIdApiRequestBuilder(PostCommentLike postCommentLike, UserId currentUserId)
	{
		_id = postCommentLike.Id.CommentId.Id.Id;
		_commentId = postCommentLike.Id.CommentId.CommentId;
		_userId = postCommentLike.Id.UserId.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetPostCommentLikeByIdApiRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetPostCommentLikeByIdApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetPostCommentLikeByIdApiRequestBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public GetPostCommentLikeByIdApiRequestBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public GetPostCommentLikeByIdApiRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetPostCommentLikeByIdApiRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetPostCommentLikeByIdApiRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetPostCommentLikeByIdApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetPostCommentLikeByIdApiRequest Build()
	{
		return new(_id, _commentId, _userId, _currentUserId);
	}
}
