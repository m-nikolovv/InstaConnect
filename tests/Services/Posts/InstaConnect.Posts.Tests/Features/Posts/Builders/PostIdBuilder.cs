namespace InstaConnect.Posts.Tests.Features.Posts.Builders;

public class PostIdBuilder
{
	private string _id;

	public PostIdBuilder(PostId id)
	{
		_id = id.Id;
	}

	public PostIdBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public PostIdBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public PostId Build()
	{
		return new(_id);
	}
}
