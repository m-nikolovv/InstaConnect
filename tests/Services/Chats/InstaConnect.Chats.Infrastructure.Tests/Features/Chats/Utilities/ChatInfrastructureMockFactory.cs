using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Utilities;

public static class ChatInfrastructureMockFactory
{
	public static IChatCollection CreateCollection()
	{
		return Mocker.Mock<IChatCollection>();
	}

	public static IChatFluent CreateFluent()
	{
		return Mocker.Mock<IChatFluent>();
	}

	public static IChatResponseFluent CreateResponseFluent()
	{
		return Mocker.Mock<IChatResponseFluent>();
	}

	public static IChatCacheHandler CreateCacheHandler()
	{
		return Mocker.Mock<IChatCacheHandler>();
	}
}
