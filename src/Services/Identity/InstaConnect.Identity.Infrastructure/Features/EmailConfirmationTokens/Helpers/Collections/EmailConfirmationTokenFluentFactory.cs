namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Collections;

internal class EmailConfirmationTokenFluentFactory : IEmailConfirmationTokenFluentFactory
{
	private readonly IEmailConfirmationTokenIncluderFactory _includerFactory;

	public EmailConfirmationTokenFluentFactory(IEmailConfirmationTokenIncluderFactory includerFactory)
	{
		_includerFactory = includerFactory;
	}

	public IEmailConfirmationTokenFluent Create(IAggregateFluent<EmailConfirmationToken> fluent)
	{
		return new EmailConfirmationTokenFluent(fluent, _includerFactory);
	}
}
