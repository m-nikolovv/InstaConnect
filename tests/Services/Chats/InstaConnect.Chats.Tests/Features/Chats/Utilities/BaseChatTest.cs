using InstaConnect.Chats.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public abstract class BaseChatTest : BaseChatsTest
{
	protected ICollection<ChatMessage> ChatChatMessages { get; }
	protected ChatMessageIdRangeBuilderFactory ChatChatMessageIdRangeBuilderFactory { get; }
	protected ChatMessageIdRangeBuilder ChatChatMessageIdRangeBuilder { get; }
	protected ICollection<ChatMessageId> ChatChatMessageIds { get; }

	protected ICollection<ChatMessageImage> ChatChatMessagesChatMessageImages { get; }
	protected ChatMessageImageIdRangeBuilderFactory ChatChatMessagesChatMessageImageIdRangeBuilderFactory { get; }
	protected ChatMessageImageIdRangeBuilder ChatChatMessagesChatMessageImageIdRangeBuilder { get; }
	protected ICollection<ChatMessageImageId> ChatChatMessagesChatMessageImageIds { get; }

	protected BaseChatTest()
	{
		ChatChatMessages = [.. Chat.ChatMessages];
		ChatChatMessageIdRangeBuilderFactory = new();
		ChatChatMessageIdRangeBuilder = ChatChatMessageIdRangeBuilderFactory.Create([.. ChatChatMessages.Select(c => c.Id)]);
		ChatChatMessageIds = ChatChatMessageIdRangeBuilder.Build();

		ChatChatMessagesChatMessageImages = [.. Chat.ChatMessages.SelectMany(c => c.ChatMessageImages)];
		ChatChatMessagesChatMessageImageIdRangeBuilderFactory = new();
		ChatChatMessagesChatMessageImageIdRangeBuilder = ChatChatMessagesChatMessageImageIdRangeBuilderFactory.Create([.. ChatChatMessagesChatMessageImages.Select(c => c.Id)]);
		ChatChatMessagesChatMessageImageIds = ChatChatMessagesChatMessageImageIdRangeBuilder.Build();
	}
}
