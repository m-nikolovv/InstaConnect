using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMapper
{
	extension(Chat chat)
	{
		public ChatResponse ToResponse(
			GetAllChatMessagesQuery query)
		{
			return chat.ToFullResponse();
		}
	}

	extension(ChatMessage chatMessage)
	{
		internal ChatMessageResponse ToFullResponse()
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

		internal ChatMessageResponse ToResponseWithoutSender()
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

		internal ChatMessageResponse ToResponseWithoutChat()
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

		public ChatMessage To(AddChatMessageCommand command)
		{
			return new(
				new(command.Id, chatMessage.Id.MessageId),
				command.Id.ParticipantOneId,
				command.Content,
				new(string.Empty),
				chatMessage.CreatedAtUtc,
				chatMessage.UpdatedAtUtc);
		}

		public ChatMessageId ToResponse(
			AddChatMessageCommand command)
		{
			return chatMessage.ToId();
		}

		public ChatMessageId ToResponse(
			UpdateChatMessageCommand command)
		{
			return chatMessage.ToId();
		}

		public ChatMessageResponse ToResponse(
			GetChatMessageByIdQuery query)
		{
			return chatMessage.ToFullResponse();
		}
	}

	extension(ICollection<ChatMessage> chatMessages)
	{
		public ICollection<ChatMessageResponse> ToResponse(
			GetAllChatMessagesQuery query)
		{
			return chatMessages.Filter(query.Pagination, chatMessage => chatMessage.MatchesFilter(query), chatMessage => chatMessage.ToResponseWithoutChat());
		}

		public long ToTotalCountResponse(
			GetAllChatMessagesQuery query)
		{
			return chatMessages.Count(chatMessage => chatMessage.MatchesFilter(query));
		}
	}

	extension(ICollection<ChatMessageImage> chatMessageImages)
	{
		public ICollection<ChatMessageImage> To(AddChatMessageCommand command)
		{
			return [.. chatMessageImages.Zip(command.Images, (chatMessageImage, formFile) => new ChatMessageImage(
				chatMessageImage.Id,
				formFile.GetUrl(),
				chatMessageImage.CreatedAtUtc))];
		}
	}
}
