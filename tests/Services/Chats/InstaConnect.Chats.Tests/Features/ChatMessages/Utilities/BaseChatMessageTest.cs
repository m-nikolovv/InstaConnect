using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Responses;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageTest : BaseChatsTest
{
	protected ICollection<ChatMessageImage> ChatMessageChatMessageImages { get; }
	protected ChatMessageImageIdRangeBuilderFactory ChatMessageChatMessageImageIdRangeBuilderFactory { get; }
	protected ChatMessageImageIdRangeBuilder ChatMessageChatMessageImageIdRangeBuilder { get; }
	protected ICollection<ChatMessageImageId> ChatMessageChatMessageImageIds { get; }
	protected ICollection<ChatMessageImageResponse> ChatMessageChatMessageImageResponses { get; }

	protected BaseChatMessageTest()
	{
		ChatMessageChatMessageImages = [.. ChatMessage.ChatMessageImages];
		ChatMessageChatMessageImageIdRangeBuilderFactory = new();
		ChatMessageChatMessageImageIdRangeBuilder = ChatMessageChatMessageImageIdRangeBuilderFactory.Create([.. ChatMessageChatMessageImages.Select(c => c.Id)]);
		ChatMessageChatMessageImageIds = ChatMessageChatMessageImageIdRangeBuilder.Build();
		ChatMessageChatMessageImageResponses = ChatMessageChatMessageImages.ToFullResponse();
	}
}
