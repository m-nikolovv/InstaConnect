using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;

public class EmailConfirmationTokenIdRangeBuilder
{
	private readonly ICollection<EmailConfirmationTokenIdBuilder> _idBuilders;

	public EmailConfirmationTokenIdRangeBuilder(ICollection<EmailConfirmationTokenIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public EmailConfirmationTokenIdRangeBuilder WithId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithId(transformer);
		}

		return this;
	}

	public EmailConfirmationTokenIdRangeBuilder WithValue(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithValue(transformer);
		}

		return this;
	}

	public ICollection<EmailConfirmationTokenId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
