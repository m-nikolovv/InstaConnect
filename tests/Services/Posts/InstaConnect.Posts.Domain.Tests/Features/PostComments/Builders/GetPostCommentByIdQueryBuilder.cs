namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdQueryBuilder
{
	private string _id;
	private string _commentId;
	private string _currentUserId;

	public GetPostCommentByIdQueryBuilder(PostComment postComment)
	{
		_id = postComment.Id.Id.Id;
		_commentId = postComment.Id.CommentId;
		_currentUserId = postComment.UserId.Id;
	}

	public GetPostCommentByIdQueryBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetPostCommentByIdQueryBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetPostCommentByIdQueryBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public GetPostCommentByIdQueryBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public GetPostCommentByIdQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetPostCommentByIdQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetPostCommentByIdQuery Build()
	{
		return new(
			new(
				new(_id),
				_commentId),
			new(
				new(_currentUserId)));
	}
}
