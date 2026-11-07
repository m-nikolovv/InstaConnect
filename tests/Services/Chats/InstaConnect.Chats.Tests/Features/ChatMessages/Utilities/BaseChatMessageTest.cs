using InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageTest : BaseChatsTest
{
	protected ICollection<ChatMessageImage> ChatMessageChatMessageImages { get; }
	protected ChatMessageImageIdRangeBuilderFactory ChatMessageChatMessageImageIdRangeBuilderFactory { get; }
	protected ChatMessageImageIdRangeBuilder ChatMessageChatMessageImageIdRangeBuilder { get; }
	protected ICollection<ChatMessageImageId> ChatMessageChatMessageImageIds { get; }

	protected BaseChatMessageTest()
	{
		ChatMessageChatMessageImages = [.. ChatMessage.ChatMessageImages];
		ChatMessageChatMessageImageIdRangeBuilderFactory = new();
		ChatMessageChatMessageImageIdRangeBuilder = ChatMessageChatMessageImageIdRangeBuilderFactory.Create([.. ChatMessageChatMessageImages.Select(c => c.Id)]);
		ChatMessageChatMessageImageIds = ChatMessageChatMessageImageIdRangeBuilder.Build();
	}
}
