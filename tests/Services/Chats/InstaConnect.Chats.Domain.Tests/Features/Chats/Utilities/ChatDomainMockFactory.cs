using InstaConnect.Chats.Domain.Features.Chats.Helpers;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

public static class ChatDomainMockFactory
{
	public static IChatFactory CreateFactory()
	{
		return Mocker.Mock<IChatFactory>();
	}

	public static IChatCollectionResponseFactory CreateCollectionResponseFactory()
	{
		return new ChatCollectionResponseFactory(new Paginator());
	}

	public static IChatCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IChatCommandRepository>();
	}

	public static IChatQueryRepository CreateQueryRepository()
	{
		return Mocker.Mock<IChatQueryRepository>();
	}
}
