using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Identity.Domain.Features.Users.Helpers;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

public static class UserDomainMockFactory
{
	public static IUserFactory CreateFactory()
	{
		return Mocker.Mock<IUserFactory>();
	}

	public static IUserCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IUserCommandRepository>();
	}

	public static IUserQueryRepository CreateQueryRepository()
	{
		return Mocker.Mock<IUserQueryRepository>();
	}

	public static IUserCollectionResponseFactory CreateCollectionResponseFactory()
	{
		return new UserCollectionResponseFactory(new Paginator());
	}

	public static IUserIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new UserIncludeBuilderFactory(new UserIncludeDescriptorFactory());
	}
}
