namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;

public class ForgotPasswordTokenIdBuilderFactory
{
	public ForgotPasswordTokenIdBuilder Create(ForgotPasswordTokenId id)
	{
		return new(id);
	}
}
