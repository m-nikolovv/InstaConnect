using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Utilities;

public abstract class BaseChatMessageImageInfrastructureCommandUnitTest : BaseChatMessageImageCommandTest
{
	protected IChatMessageImageFluent Fluent { get; }

	protected IChatMessageImageCollection Collection { get; }

	protected IChatMessageCacheHandler MessageCacheHandler { get; }

	protected IChatMessageImageCacheHandler MessageImageCacheHandler { get; }

	protected BaseChatMessageImageInfrastructureCommandUnitTest()
	{
		Fluent = ChatMessageImageInfrastructureMockFactory.CreateFluent();
		Collection = ChatMessageImageInfrastructureMockFactory.CreateCollection();
		MessageCacheHandler = ChatMessageInfrastructureMockFactory.CreateCacheHandler();
		MessageImageCacheHandler = ChatMessageImageInfrastructureMockFactory.CreateCacheHandler();
	}
}
