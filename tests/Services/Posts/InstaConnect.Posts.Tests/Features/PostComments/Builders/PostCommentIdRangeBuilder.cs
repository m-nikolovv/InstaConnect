using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostComments.Builders;

public class PostCommentIdRangeBuilder
{
	private readonly ICollection<PostCommentIdBuilder> _idBuilders;

	public PostCommentIdRangeBuilder(ICollection<PostCommentIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public PostCommentIdRangeBuilder WithId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithId(transformer);
		}

		return this;
	}

	public PostCommentIdRangeBuilder WithCommentId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithCommentId(transformer);
		}

		return this;
	}

	public ICollection<PostCommentId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
