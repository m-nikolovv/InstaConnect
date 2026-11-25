using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenInfrastructureMockFactory
{
	public static IForgotPasswordTokenCollection CreateCollection()
	{
		return Mocker.Mock<IForgotPasswordTokenCollection>();
	}

	public static IForgotPasswordTokenFluent CreateFluent()
	{
		return Mocker.Mock<IForgotPasswordTokenFluent>();
	}

	public static IForgotPasswordTokenCacheHandler CreateCacheHandler()
	{
		return Mocker.Mock<IForgotPasswordTokenCacheHandler>();
	}
}
