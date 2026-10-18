using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Builders;

public class PostCommentImageIdRangeBuilder
{
	private readonly ICollection<PostCommentImageIdBuilder> _idBuilders;

	public PostCommentImageIdRangeBuilder(ICollection<PostCommentImageIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public PostCommentImageIdRangeBuilder WithId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithId(transformer);
		}

		return this;
	}

	public PostCommentImageIdRangeBuilder WithCommentId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithCommentId(transformer);
		}

		return this;
	}

	public PostCommentImageIdRangeBuilder WithImageId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithImageId(transformer);
		}

		return this;
	}

	public ICollection<PostCommentImageId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
