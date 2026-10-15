using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;

public class ForgotPasswordTokenIdRangeBuilder
{
	private readonly ICollection<ForgotPasswordTokenIdBuilder> _idBuilders;

	public ForgotPasswordTokenIdRangeBuilder(ICollection<ForgotPasswordTokenIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public ForgotPasswordTokenIdRangeBuilder WithId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithId(transformer);
		}

		return this;
	}

	public ForgotPasswordTokenIdRangeBuilder WithValue(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithValue(transformer);
		}

		return this;
	}

	public ICollection<ForgotPasswordTokenId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
