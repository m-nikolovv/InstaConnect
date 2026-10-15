using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.Posts.Builders;

public class PostIdRangeBuilder
{
	private readonly ICollection<PostIdBuilder> _idBuilders;

	public PostIdRangeBuilder(ICollection<PostIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public PostIdRangeBuilder WithId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithId(transformer);
		}

		return this;
	}

	public ICollection<PostId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
