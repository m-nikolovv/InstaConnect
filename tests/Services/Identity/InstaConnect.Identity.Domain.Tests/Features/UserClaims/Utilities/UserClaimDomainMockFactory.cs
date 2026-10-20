using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimDomainMockFactory
{
	public static IUserClaimFactory CreateFactory()
	{
		return Mocker.Mock<IUserClaimFactory>();
	}

	public static IUserClaimCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IUserClaimCommandRepository>();
	}

	public static IUserClaimQueryRepository CreateQueryRepository()
	{
		return Mocker.Mock<IUserClaimQueryRepository>();
	}

	public static IUserClaimCollectionResponseFactory CreateCollectionResponseFactory()
	{
		return new UserClaimCollectionResponseFactory(new Paginator());
	}

	public static IUserClaimIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new UserClaimIncludeBuilderFactory(new UserClaimIncludeDescriptorFactory());
	}
}
