using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMatchAssertions
{
	extension(ChatMessageId response)
	{
		public void ShouldSatisfy(AddChatMessageCommand command, ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.Matches(command, chatMessage));
		}

		public void ShouldSatisfy(UpdateChatMessageCommand command, ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.Matches(command, chatMessage));
		}
	}

	extension(ChatMessageResponse response)
	{
		public void ShouldSatisfy(GetChatMessageByIdQuery query, ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.Matches(query, chatMessage));
		}

		public void ShouldSatisfyInverted(GetChatMessageByIdQuery query, ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(query, chatMessage));
		}
	}

	extension(ChatMessageCollectionResponse response)
	{
		public void ShouldSatisfy(
			GetAllChatMessagesQuery query,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
		{
			response.ShouldSatisfy(p => p.Matches(query, chat, chatMessages));
		}

		public void ShouldSatisfy(
			GetAllChatMessagesQuery query,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, chat, chatMessages, termTransformer));
		}

		public void ShouldSatisfyInverted(
			GetAllChatMessagesQuery query,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(query, chat, chatMessages));
		}

		public void ShouldSatisfyInverted(
			GetAllChatMessagesQuery query,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(query, chat, chatMessages, termTransformer));
		}
	}

	extension(ChatMessage chatMessage)
	{
		public void ShouldSatisfy(AddChatMessageCommand command)
		{
			chatMessage.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfy(UpdateChatMessageCommand command)
		{
			chatMessage.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfyInverted(AddChatMessageCommand command)
		{
			chatMessage.ShouldSatisfy(p => p.MatchesInverted(command));
		}

		public void ShouldSatisfyInverted(UpdateChatMessageCommand command)
		{
			chatMessage.ShouldSatisfy(p => p.MatchesInverted(command));
		}
	}

	extension(ICollection<ChatMessageImage> chatMessageImages)
	{
		public void ShouldSatisfy(AddChatMessageCommand command)
		{
			chatMessageImages.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfyInverted(AddChatMessageCommand command)
		{
			chatMessageImages.ShouldSatisfy(p => p.MatchesInverted(command));
		}
	}

	extension(ChatMessageAddedNotificationRequest r)
	{
		public void ShouldSatisfy(
			AddChatMessageCommand command,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(command, chatMessage));
		}

		public void ShouldSatisfyInverted(
			AddChatMessageCommand command,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.MatchesInverted(command, chatMessage));
		}
	}

	extension(ChatMessageUpdatedNotificationRequest r)
	{
		public void ShouldSatisfy(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(command, chatMessage));
		}

		public void ShouldSatisfyInverted(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.MatchesInverted(command, chatMessage));
		}
	}

	extension(ChatMessageDeletedNotificationRequest r)
	{
		public void ShouldSatisfy(
			DeleteChatMessageCommand command,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(command, chatMessage));
		}

		public void ShouldSatisfyInverted(
			DeleteChatMessageCommand command,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.MatchesInverted(command, chatMessage));
		}
	}
}
