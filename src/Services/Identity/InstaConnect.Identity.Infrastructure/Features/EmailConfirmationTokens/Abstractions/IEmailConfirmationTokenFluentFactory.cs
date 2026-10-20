namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenFluentFactory
{
	public IEmailConfirmationTokenFluent Create(IAggregateFluent<EmailConfirmationToken> fluent);
}
