using InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageDomainMockFactory
{
	public static IChatMessageFactory CreateFactory()
	{
		return Mocker.Mock<IChatMessageFactory>();
	}

	public static IChatMessageCollectionResponseFactory CreateCollectionResponseFactory()
	{
		return new ChatMessageCollectionResponseFactory(new Paginator());
	}

	public static IChatMessageCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IChatMessageCommandRepository>();
	}

	public static IChatMessageQueryRepository CreateQueryRepository()
	{
		return Mocker.Mock<IChatMessageQueryRepository>();
	}

	public static IChatMessageNotificationService CreateNotificationService()
	{
		return Mocker.Mock<IChatMessageNotificationService>();
	}
}
