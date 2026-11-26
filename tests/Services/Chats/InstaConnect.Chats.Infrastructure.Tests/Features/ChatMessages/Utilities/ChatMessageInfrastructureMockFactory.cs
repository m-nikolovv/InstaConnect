using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageInfrastructureMockFactory
{
	public static IChatMessageCollection CreateCollection()
	{
		return Mocker.Mock<IChatMessageCollection>();
	}

	public static IChatMessageFluent CreateFluent()
	{
		return Mocker.Mock<IChatMessageFluent>();
	}

	public static IChatMessageResponseFluent CreateResponseFluent()
	{
		return Mocker.Mock<IChatMessageResponseFluent>();
	}

	public static IChatMessageCacheHandler CreateCacheHandler()
	{
		return Mocker.Mock<IChatMessageCacheHandler>();
	}
}
