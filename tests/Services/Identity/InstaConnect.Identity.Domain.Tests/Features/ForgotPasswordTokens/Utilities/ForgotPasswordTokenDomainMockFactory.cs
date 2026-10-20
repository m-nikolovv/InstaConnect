using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenDomainMockFactory
{
	public static IForgotPasswordTokenFactory CreateFactory()
	{
		return Mocker.Mock<IForgotPasswordTokenFactory>();
	}

	public static IForgotPasswordTokenEmailSender CreateEmailSender()
	{
		return Mocker.Mock<IForgotPasswordTokenEmailSender>();
	}

	public static IForgotPasswordTokenCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IForgotPasswordTokenCommandRepository>();
	}

	public static IOptions<ForgotPasswordTokenOptions> CreateOptions()
	{
		return Options.Create(new ForgotPasswordTokenOptions(ForgotPasswordTokenDataFaker.GetLifetimeSeconds()));
	}
}
