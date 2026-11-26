using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenInfrastructureMockFactory
{
	public static IRefreshTokenCollection CreateCollection()
	{
		return Mocker.Mock<IRefreshTokenCollection>();
	}

	public static IRefreshTokenFluent CreateFluent()
	{
		return Mocker.Mock<IRefreshTokenFluent>();
	}

	public static IRefreshTokenCacheHandler CreateCacheHandler()
	{
		return Mocker.Mock<IRefreshTokenCacheHandler>();
	}
}
