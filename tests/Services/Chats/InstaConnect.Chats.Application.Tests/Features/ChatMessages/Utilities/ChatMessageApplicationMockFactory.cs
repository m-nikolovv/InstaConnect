using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageApplicationMockFactory
{
	public static IChatMessageCommandService CreateCommandService()
	{
		return Mocker.Mock<IChatMessageCommandService>();
	}

	public static IChatMessageQueryService CreateQueryService()
	{
		return Mocker.Mock<IChatMessageQueryService>();
	}
}
