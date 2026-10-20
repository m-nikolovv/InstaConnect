namespace InstaConnect.Posts.Tests.Features.PostImages.Builders;

public class PostImageIdRangeBuilder
{
	private readonly ICollection<PostImageIdBuilder> _idBuilders;

	public PostImageIdRangeBuilder(ICollection<PostImageIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public PostImageIdRangeBuilder WithId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithId(transformer);
		}

		return this;
	}

	public PostImageIdRangeBuilder WithImageId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithImageId(transformer);
		}

		return this;
	}

	public ICollection<PostImageId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
