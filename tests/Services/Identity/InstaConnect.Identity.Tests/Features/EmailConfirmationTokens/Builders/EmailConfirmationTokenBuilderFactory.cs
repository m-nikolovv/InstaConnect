namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;

public class EmailConfirmationTokenBuilderFactory
{
	public EmailConfirmationTokenBuilder Create(User user)
	{
		return new(user);
	}

	public EmailConfirmationTokenBuilder Create(EmailConfirmationToken emailConfirmationToken)
	{
		return new(emailConfirmationToken);
	}
}
