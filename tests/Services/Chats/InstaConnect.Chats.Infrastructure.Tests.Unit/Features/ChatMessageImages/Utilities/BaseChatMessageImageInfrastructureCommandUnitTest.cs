using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessageImages.Utilities;

public abstract class BaseChatMessageImageInfrastructureCommandUnitTest : BaseChatsCommandTest
{
	protected IChatMessageImageFluent Fluent { get; }

	protected IChatMessageImageCollection Collection { get; }

	protected BaseChatMessageImageInfrastructureCommandUnitTest()
	{
		Fluent = ChatMessageImageInfrastructureMockFactory.CreateFluent();
		Collection = ChatMessageImageInfrastructureMockFactory.CreateCollection();
	}
}
