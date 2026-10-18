namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageDomainMockFactory
{
	public static IChatMessageImageFactory CreateFactory()
	{
		return Mocker.Mock<IChatMessageImageFactory>();
	}

	public static IChatMessageImageCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IChatMessageImageCommandRepository>();
	}
}
