namespace InstaConnect.Posts.Tests.Features.PostComments.Builders;

public class PostCommentIdBuilder
{
	private string _id;
	private string _commentId;

	public PostCommentIdBuilder(PostCommentId id)
	{
		_id = id.Id.Id;
		_commentId = id.CommentId;
	}

	public PostCommentIdBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public PostCommentIdBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public PostCommentIdBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public PostCommentIdBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public PostCommentId Build()
	{
		return new(
			new(_id),
			_commentId);
	}
}
