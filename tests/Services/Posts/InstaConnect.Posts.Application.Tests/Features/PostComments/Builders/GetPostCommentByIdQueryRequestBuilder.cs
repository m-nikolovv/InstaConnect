namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdQueryRequestBuilder
{
	private string _id;
	private string _commentId;
	private string _currentUserId;

	public GetPostCommentByIdQueryRequestBuilder(PostComment postComment)
	{
		_id = postComment.Id.Id.Id;
		_commentId = postComment.Id.CommentId;
		_currentUserId = postComment.UserId.Id;
	}

	public GetPostCommentByIdQueryRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetPostCommentByIdQueryRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetPostCommentByIdQueryRequestBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public GetPostCommentByIdQueryRequestBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public GetPostCommentByIdQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetPostCommentByIdQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetPostCommentByIdQueryRequest Build()
	{
		return new(_id, _commentId, _currentUserId);
	}
}
