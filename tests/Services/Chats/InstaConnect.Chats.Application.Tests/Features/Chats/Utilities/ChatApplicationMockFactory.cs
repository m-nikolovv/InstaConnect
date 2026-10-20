using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatApplicationMockFactory
{
	public static IChatCommandService CreateCommandService()
	{
		return Mocker.Mock<IChatCommandService>();
	}

	public static IChatQueryService CreateQueryService()
	{
		return Mocker.Mock<IChatQueryService>();
	}
}
