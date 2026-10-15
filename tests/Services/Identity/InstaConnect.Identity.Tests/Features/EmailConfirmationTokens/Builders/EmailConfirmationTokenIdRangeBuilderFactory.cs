using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;

public class EmailConfirmationTokenIdRangeBuilderFactory
{
	private readonly EmailConfirmationTokenIdBuilderFactory _idBuilderFactory;

	public EmailConfirmationTokenIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public EmailConfirmationTokenIdRangeBuilder Create(ICollection<EmailConfirmationTokenId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
