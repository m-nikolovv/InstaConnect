using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageInfrastructureMockFactory
{
	public static IChatMessageImageCollection CreateCollection()
	{
		return Mocker.Mock<IChatMessageImageCollection>();
	}

	public static IChatMessageImageFluent CreateFluent()
	{
		return Mocker.Mock<IChatMessageImageFluent>();
	}
}
