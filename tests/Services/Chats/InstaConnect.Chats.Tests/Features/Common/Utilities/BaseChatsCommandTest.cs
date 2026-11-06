using InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Tests.Features.Chats.Builders;

namespace InstaConnect.Chats.Tests.Features.Common.Utilities;

public abstract class BaseChatsCommandTest : BaseChatsTest
{
	protected ICollection<ChatMessage> ChatChatMessages { get; }
	protected ChatMessageIdRangeBuilderFactory ChatChatMessageIdRangeBuilderFactory { get; }
	protected ChatMessageIdRangeBuilder ChatChatMessageIdRangeBuilder { get; }
	protected ICollection<ChatMessageId> ChatChatMessageIds { get; }

	protected ICollection<ChatMessageImage> ChatChatMessageImages { get; }
	protected ChatMessageImageIdRangeBuilderFactory ChatChatMessageImageIdRangeBuilderFactory { get; }
	protected ChatMessageImageIdRangeBuilder ChatChatMessageImageIdRangeBuilder { get; }
	protected ICollection<ChatMessageImageId> ChatChatMessageImageIds { get; }

	protected ICollection<Chat> UserChats { get; }
	protected ChatIdRangeBuilderFactory UserChatIdRangeBuilderFactory { get; }
	protected ChatIdRangeBuilder UserChatIdRangeBuilder { get; }
	protected ICollection<ChatId> UserChatIds { get; }

	protected ICollection<ChatMessage> UserChatMessages { get; }
	protected ChatMessageIdRangeBuilderFactory UserChatMessageIdRangeBuilderFactory { get; }
	protected ChatMessageIdRangeBuilder UserChatMessageIdRangeBuilder { get; }
	protected ICollection<ChatMessageId> UserChatMessageIds { get; }

	protected ICollection<ChatMessageImage> UserChatMessageImages { get; }
	protected ChatMessageImageIdRangeBuilderFactory UserChatMessageImageIdRangeBuilderFactory { get; }
	protected ChatMessageImageIdRangeBuilder UserChatMessageImageIdRangeBuilder { get; }
	protected ICollection<ChatMessageImageId> UserChatMessageImageIds { get; }

	protected ICollection<ChatMessageImage> ChatMessageChatMessageImages { get; }
	protected ChatMessageImageIdRangeBuilderFactory ChatMessageChatMessageImageIdRangeBuilderFactory { get; }
	protected ChatMessageImageIdRangeBuilder ChatMessageChatMessageImageIdRangeBuilder { get; }
	protected ICollection<ChatMessageImageId> ChatMessageChatMessageImageIds { get; }

	protected BaseChatsCommandTest()
	{
		ChatChatMessages = [.. Chat.ChatMessages];
		ChatChatMessageIdRangeBuilderFactory = new();
		ChatChatMessageIdRangeBuilder = ChatChatMessageIdRangeBuilderFactory.Create([.. ChatChatMessages.Select(c => c.Id)]);
		ChatChatMessageIds = ChatChatMessageIdRangeBuilder.Build();

		ChatChatMessageImages = [.. ChatChatMessages.SelectMany(c => c.ChatMessageImages)];
		ChatChatMessageImageIdRangeBuilderFactory = new();
		ChatChatMessageImageIdRangeBuilder = ChatChatMessageImageIdRangeBuilderFactory.Create([.. ChatChatMessageImages.Select(c => c.Id)]);
		ChatChatMessageImageIds = ChatChatMessageImageIdRangeBuilder.Build();

		UserChats = [.. User.Chats];
		UserChatIdRangeBuilderFactory = new();
		UserChatIdRangeBuilder = UserChatIdRangeBuilderFactory.Create([.. UserChats.Select(c => c.Id)]);
		UserChatIds = UserChatIdRangeBuilder.Build();

		UserChatMessages = [.. UserChats.SelectMany(c => c.ChatMessages)];
		UserChatMessageIdRangeBuilderFactory = new();
		UserChatMessageIdRangeBuilder = UserChatMessageIdRangeBuilderFactory.Create([.. UserChatMessages.Select(c => c.Id)]);
		UserChatMessageIds = UserChatMessageIdRangeBuilder.Build();

		UserChatMessageImages = [.. UserChatMessages.SelectMany(c => c.ChatMessageImages)];
		UserChatMessageImageIdRangeBuilderFactory = new();
		UserChatMessageImageIdRangeBuilder = UserChatMessageImageIdRangeBuilderFactory.Create([.. UserChatMessageImages.Select(c => c.Id)]);
		UserChatMessageImageIds = UserChatMessageImageIdRangeBuilder.Build();

		ChatMessageChatMessageImages = [.. ChatMessage.ChatMessageImages];
		ChatMessageChatMessageImageIdRangeBuilderFactory = new();
		ChatMessageChatMessageImageIdRangeBuilder = ChatMessageChatMessageImageIdRangeBuilderFactory.Create([.. ChatMessageChatMessageImages.Select(c => c.Id)]);
		ChatMessageChatMessageImageIds = ChatMessageChatMessageImageIdRangeBuilder.Build();
	}
}
