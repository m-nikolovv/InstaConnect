using InstaConnect.Chats.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;

namespace InstaConnect.Chats.Tests.Features.Users.Utilities;

public abstract class BaseUserTest : BaseChatsTest
{
	protected ICollection<Chat> UserChats { get; }
	protected ChatIdRangeBuilderFactory UserChatIdRangeBuilderFactory { get; }
	protected ChatIdRangeBuilder UserChatIdRangeBuilder { get; }
	protected ICollection<ChatId> UserChatIds { get; }

	protected ICollection<ChatMessage> UserChatsChatMessages { get; }
	protected ChatMessageIdRangeBuilderFactory UserChatsChatMessageIdRangeBuilderFactory { get; }
	protected ChatMessageIdRangeBuilder UserChatsChatMessageIdRangeBuilder { get; }
	protected ICollection<ChatMessageId> UserChatsChatMessageIds { get; }

	protected ICollection<ChatMessageImage> UserChatsChatMessagesChatMessageImages { get; }
	protected ChatMessageImageIdRangeBuilderFactory UserChatsChatMessagesChatMessageImageIdRangeBuilderFactory { get; }
	protected ChatMessageImageIdRangeBuilder UserChatsChatMessagesChatMessageImageIdRangeBuilder { get; }
	protected ICollection<ChatMessageImageId> UserChatsChatMessagesChatMessageImageIds { get; }

	protected ICollection<ChatMessage> UserChatMessages { get; }
	protected ChatMessageIdRangeBuilderFactory UserChatMessageIdRangeBuilderFactory { get; }
	protected ChatMessageIdRangeBuilder UserChatMessageIdRangeBuilder { get; }
	protected ICollection<ChatMessageId> UserChatMessageIds { get; }

	protected ICollection<ChatMessageImage> UserChatMessagesChatMessageImages { get; }
	protected ChatMessageImageIdRangeBuilderFactory UserChatMessagesChatMessageImageIdRangeBuilderFactory { get; }
	protected ChatMessageImageIdRangeBuilder UserChatMessagesChatMessageImageIdRangeBuilder { get; }
	protected ICollection<ChatMessageImageId> UserChatMessagesChatMessageImageIds { get; }

	protected BaseUserTest()
	{
		UserChats = [.. User.Chats];
		UserChatIdRangeBuilderFactory = new();
		UserChatIdRangeBuilder = UserChatIdRangeBuilderFactory.Create([.. UserChats.Select(c => c.Id)]);
		UserChatIds = UserChatIdRangeBuilder.Build();

		UserChatsChatMessages = [.. User.Chats.SelectMany(c => c.ChatMessages)];
		UserChatsChatMessageIdRangeBuilderFactory = new();
		UserChatsChatMessageIdRangeBuilder = UserChatsChatMessageIdRangeBuilderFactory.Create([.. UserChatsChatMessages.Select(c => c.Id)]);
		UserChatsChatMessageIds = UserChatsChatMessageIdRangeBuilder.Build();

		UserChatsChatMessagesChatMessageImages = [.. User.Chats.SelectMany(c => c.ChatMessages).SelectMany(c => c.ChatMessageImages)];
		UserChatsChatMessagesChatMessageImageIdRangeBuilderFactory = new();
		UserChatsChatMessagesChatMessageImageIdRangeBuilder = UserChatsChatMessagesChatMessageImageIdRangeBuilderFactory.Create([.. UserChatsChatMessagesChatMessageImages.Select(c => c.Id)]);
		UserChatsChatMessagesChatMessageImageIds = UserChatsChatMessagesChatMessageImageIdRangeBuilder.Build();

		UserChatMessages = [.. User.ChatMessages];
		UserChatMessageIdRangeBuilderFactory = new();
		UserChatMessageIdRangeBuilder = UserChatMessageIdRangeBuilderFactory.Create([.. UserChatMessages.Select(c => c.Id)]);
		UserChatMessageIds = UserChatMessageIdRangeBuilder.Build();

		UserChatMessagesChatMessageImages = [.. User.ChatMessages.SelectMany(c => c.ChatMessageImages)];
		UserChatMessagesChatMessageImageIdRangeBuilderFactory = new();
		UserChatMessagesChatMessageImageIdRangeBuilder = UserChatMessagesChatMessageImageIdRangeBuilderFactory.Create([.. UserChatMessagesChatMessageImages.Select(c => c.Id)]);
		UserChatMessagesChatMessageImageIds = UserChatMessagesChatMessageImageIdRangeBuilder.Build();
	}
}
