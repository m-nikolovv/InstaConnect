using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;

public class RefreshTokenIdRangeBuilder
{
	private readonly ICollection<RefreshTokenIdBuilder> _idBuilders;

	public RefreshTokenIdRangeBuilder(ICollection<RefreshTokenIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public RefreshTokenIdRangeBuilder WithId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithId(transformer);
		}

		return this;
	}

	public RefreshTokenIdRangeBuilder WithValue(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithValue(transformer);
		}

		return this;
	}

	public ICollection<RefreshTokenId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
