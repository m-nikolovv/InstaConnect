using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenInfrastructureMockFactory
{
	public static IEmailConfirmationTokenCollection CreateCollection()
	{
		return Mocker.Mock<IEmailConfirmationTokenCollection>();
	}

	public static IEmailConfirmationTokenFluent CreateFluent()
	{
		return Mocker.Mock<IEmailConfirmationTokenFluent>();
	}

	public static IEmailConfirmationTokenCacheHandler CreateCacheHandler()
	{
		return Mocker.Mock<IEmailConfirmationTokenCacheHandler>();
	}
}
