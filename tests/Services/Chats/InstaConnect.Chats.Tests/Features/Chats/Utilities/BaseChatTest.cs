using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Responses;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Builders;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public abstract class BaseChatTest : BaseChatsTest
{
	protected ICollection<ChatMessage> ChatChatMessages { get; }
	protected ChatMessageIdRangeBuilderFactory ChatChatMessageIdRangeBuilderFactory { get; }
	protected ChatMessageIdRangeBuilder ChatChatMessageIdRangeBuilder { get; }
	protected ICollection<ChatMessageId> ChatChatMessageIds { get; }
	protected ICollection<ChatMessageResponse> ChatChatMessageResponses { get; }

	protected ICollection<ChatMessageImage> ChatChatMessagesChatMessageImages { get; }
	protected ChatMessageImageIdRangeBuilderFactory ChatChatMessagesChatMessageImageIdRangeBuilderFactory { get; }
	protected ChatMessageImageIdRangeBuilder ChatChatMessagesChatMessageImageIdRangeBuilder { get; }
	protected ICollection<ChatMessageImageId> ChatChatMessagesChatMessageImageIds { get; }
	protected ICollection<ChatMessageImageResponse> ChatChatMessagesChatMessageImageResponses { get; }

	protected BaseChatTest()
	{
		ChatChatMessages = [.. Chat.ChatMessages];
		ChatChatMessageIdRangeBuilderFactory = new();
		ChatChatMessageIdRangeBuilder = ChatChatMessageIdRangeBuilderFactory.Create([.. ChatChatMessages.Select(c => c.Id)]);
		ChatChatMessageIds = ChatChatMessageIdRangeBuilder.Build();
		ChatChatMessageResponses = ChatChatMessages.ToFullResponse();

		ChatChatMessagesChatMessageImages = [.. Chat.ChatMessages.SelectMany(c => c.ChatMessageImages)];
		ChatChatMessagesChatMessageImageIdRangeBuilderFactory = new();
		ChatChatMessagesChatMessageImageIdRangeBuilder = ChatChatMessagesChatMessageImageIdRangeBuilderFactory.Create([.. ChatChatMessagesChatMessageImages.Select(c => c.Id)]);
		ChatChatMessagesChatMessageImageIds = ChatChatMessagesChatMessageImageIdRangeBuilder.Build();
		ChatChatMessagesChatMessageImageResponses = ChatChatMessagesChatMessageImages.ToFullResponse();
	}
}
