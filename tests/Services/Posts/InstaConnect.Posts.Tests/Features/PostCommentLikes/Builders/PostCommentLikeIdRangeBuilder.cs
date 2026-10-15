using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeIdRangeBuilder
{
	private readonly ICollection<PostCommentLikeIdBuilder> _idBuilders;

	public PostCommentLikeIdRangeBuilder(ICollection<PostCommentLikeIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public PostCommentLikeIdRangeBuilder WithId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithId(transformer);
		}

		return this;
	}

	public PostCommentLikeIdRangeBuilder WithCommentId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithCommentId(transformer);
		}

		return this;
	}

	public PostCommentLikeIdRangeBuilder WithUserId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithUserId(transformer);
		}

		return this;
	}

	public ICollection<PostCommentLikeId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
