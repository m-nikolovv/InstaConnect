namespace InstaConnect.Posts.Tests.Features.PostLikes.Builders;

public class PostLikeIdRangeBuilder
{
	private readonly ICollection<PostLikeIdBuilder> _idBuilders;

	public PostLikeIdRangeBuilder(ICollection<PostLikeIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public PostLikeIdRangeBuilder WithId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithId(transformer);
		}

		return this;
	}

	public PostLikeIdRangeBuilder WithUserId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithUserId(transformer);
		}

		return this;
	}

	public ICollection<PostLikeId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
