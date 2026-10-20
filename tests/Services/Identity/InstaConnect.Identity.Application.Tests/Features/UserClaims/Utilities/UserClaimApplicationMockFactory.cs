using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimApplicationMockFactory
{
	public static IUserClaimCommandService CreateCommandService()
	{
		return Mocker.Mock<IUserClaimCommandService>();
	}

	public static IUserClaimQueryService CreateQueryService()
	{
		return Mocker.Mock<IUserClaimQueryService>();
	}
}
