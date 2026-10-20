using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Follows.Domain.Features.Follows.Helpers;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

public static class FollowDomainMockFactory
{
	public static IFollowFactory CreateFactory()
	{
		return Mocker.Mock<IFollowFactory>();
	}

	public static IFollowNotificationService CreateNotificationService()
	{
		return Mocker.Mock<IFollowNotificationService>();
	}

	public static IFollowCollectionResponseFactory CreateCollectionResponseFactory()
	{
		return new FollowCollectionResponseFactory(new Paginator());
	}

	public static IFollowCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IFollowCommandRepository>();
	}

	public static IFollowQueryRepository CreateQueryRepository()
	{
		return Mocker.Mock<IFollowQueryRepository>();
	}
}
