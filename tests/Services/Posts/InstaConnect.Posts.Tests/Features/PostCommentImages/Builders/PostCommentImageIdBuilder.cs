using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Builders;

public class PostCommentImageIdBuilder
{
	private string _id;
	private string _imageId;
	private string _commentId;

	public PostCommentImageIdBuilder(PostCommentImageId id)
	{
		_id = id.Id.Id.Id;
		_imageId = id.ImageId;
		_commentId = id.Id.CommentId;
	}

	public PostCommentImageIdBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public PostCommentImageIdBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public PostCommentImageIdBuilder WithImageId(IStringTransformer transformer)
	{
		_imageId = transformer.Transform(_imageId);

		return this;
	}

	public PostCommentImageId Build()
	{
		return new(new(new(_id), _commentId), _imageId);
	}
}
