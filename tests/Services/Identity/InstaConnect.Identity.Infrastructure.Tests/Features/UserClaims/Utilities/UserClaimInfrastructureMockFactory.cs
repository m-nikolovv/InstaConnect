using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Utilities;

public static class UserClaimInfrastructureMockFactory
{
	public static IUserClaimCollection CreateCollection()
	{
		return Mocker.Mock<IUserClaimCollection>();
	}

	public static IUserClaimFluent CreateFluent()
	{
		return Mocker.Mock<IUserClaimFluent>();
	}

	public static IUserClaimResponseFluent CreateResponseFluent()
	{
		return Mocker.Mock<IUserClaimResponseFluent>();
	}

	public static IUserClaimCacheHandler CreateCacheHandler()
	{
		return Mocker.Mock<IUserClaimCacheHandler>();
	}
}
