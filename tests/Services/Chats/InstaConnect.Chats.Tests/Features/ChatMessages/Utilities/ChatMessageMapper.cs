using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMapper
{
	extension(ChatMessage chatMessage)
	{
		public ChatMessageId ToId()
		{
			return chatMessage.Id;
		}

		public ChatMessageResponse ToFullResponse()
		{
			return new(chatMessage.Id,
					   chatMessage.Content,
					   chatMessage.Summary,
					   chatMessage.SenderId,
					   chatMessage.Chat?.ToFullResponse(),
					   chatMessage.Sender?.ToFullResponse(),
					   chatMessage.ChatMessageImages.ToFullResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		public ChatMessageResponse ToResponseWithoutChat()
		{
			return new(chatMessage.Id,
					   chatMessage.Content,
					   chatMessage.Summary,
					   chatMessage.SenderId,
					   null,
					   chatMessage.Sender?.ToFullResponse(),
					   chatMessage.ChatMessageImages.ToFullResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		public ChatMessageResponse ToResponseWithoutSender()
		{
			return new(chatMessage.Id,
					   chatMessage.Content,
					   chatMessage.Summary,
					   chatMessage.SenderId,
					   chatMessage.Chat?.ToFullResponse(),
					   null,
					   chatMessage.ChatMessageImages.ToFullResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}
	}

	extension(ICollection<ChatMessage> chatMessages)
	{
		public ICollection<ChatMessageResponse> ToFullResponse()
		{
			return [.. chatMessages.Select(chatMessage => chatMessage.ToFullResponse())];
		}
	}
}
