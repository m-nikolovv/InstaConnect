using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenApplicationMockFactory
{
	public static IRefreshTokenCommandService CreateCommandService()
	{
		return Mocker.Mock<IRefreshTokenCommandService>();
	}
}
