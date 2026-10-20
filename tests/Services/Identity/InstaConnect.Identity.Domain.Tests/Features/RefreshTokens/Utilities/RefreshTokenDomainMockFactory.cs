using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenDomainMockFactory
{
	public static IRefreshTokenFactory CreateFactory()
	{
		return Mocker.Mock<IRefreshTokenFactory>();
	}

	public static ISessionTokenGenerator CreateSessionTokenGenerator()
	{
		return Mocker.Mock<ISessionTokenGenerator>();
	}

	public static IRefreshTokenCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IRefreshTokenCommandRepository>();
	}

	public static IOptions<RefreshTokenOptions> CreateOptions()
	{
		return Options.Create(new RefreshTokenOptions(RefreshTokenDataFaker.GetLifetimeSeconds()));
	}
}
