namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikesFilterQueryBuilder
{
	private string _id;
	private string _commentId;
	private string _userName;

	public PostCommentLikesFilterQueryBuilder(PostCommentLike postCommentLike)
	{
		_id = postCommentLike.Id.CommentId.Id.Id;
		_commentId = postCommentLike.Id.CommentId.CommentId;
		_userName = DataFaker.GetPrefixString(postCommentLike.User!.Name.Value);
	}

	public PostCommentLikesFilterQueryBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public PostCommentLikesFilterQueryBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public PostCommentLikesFilterQueryBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public PostCommentLikesFilterQueryBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public PostCommentLikesFilterQueryBuilder WithUserName(IStringTransformer transformer)
	{
		_userName = transformer.Transform(_userName);

		return this;
	}

	public PostCommentLikesFilterQuery Build()
	{
		return new(new(new(_id), _commentId), new(_userName));
	}
}
