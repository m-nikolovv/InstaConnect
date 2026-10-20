namespace InstaConnect.Posts.Tests.Features.PostImages.Builders;

public class PostImageIdBuilder
{
	private string _id;
	private string _imageId;

	public PostImageIdBuilder(PostImageId id)
	{
		_id = id.Id.Id;
		_imageId = id.ImageId;
	}

	public PostImageIdBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public PostImageIdBuilder WithImageId(IStringTransformer transformer)
	{
		_imageId = transformer.Transform(_imageId);

		return this;
	}

	public PostImageId Build()
	{
		return new(new(_id), _imageId);
	}
}
