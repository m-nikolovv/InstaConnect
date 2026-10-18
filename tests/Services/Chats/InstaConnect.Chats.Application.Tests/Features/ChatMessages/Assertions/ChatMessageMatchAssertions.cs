using InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMatchAssertions
{
	extension(AddChatMessageCommandResponse response)
	{
		public void ShouldSatisfy(AddChatMessageCommandRequest request, ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.Matches(request, chatMessage));
		}
	}

	extension(UpdateChatMessageCommandResponse response)
	{
		public void ShouldSatisfy(UpdateChatMessageCommandRequest request, ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.Matches(request, chatMessage));
		}
	}

	extension(GetChatMessageByIdQueryResponse response)
	{
		public void ShouldSatisfy(GetChatMessageByIdQueryRequest request, ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.Matches(request, chatMessage));
		}

		public void ShouldSatisfyInverted(GetChatMessageByIdQueryRequest request, ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(request, chatMessage));
		}
	}

	extension(GetAllChatMessagesQueryResponse response)
	{
		public void ShouldSatisfy(GetAllChatMessagesQueryRequest request, Chat chat, ICollection<ChatMessage> chatMessages)
		{
			response.ShouldSatisfy(p => p.Matches(request, chat, chatMessages));
		}

		public void ShouldSatisfy(GetAllChatMessagesQueryRequest request, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, chat, chatMessages, termTransformer));
		}

		public void ShouldSatisfyInverted(GetAllChatMessagesQueryRequest request, Chat chat, ICollection<ChatMessage> chatMessages)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(request, chat, chatMessages));
		}

		public void ShouldSatisfyInverted(GetAllChatMessagesQueryRequest request, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(request, chat, chatMessages, termTransformer));
		}
	}

	extension(ChatMessage chatMessage)
	{
		public void ShouldSatisfy(AddChatMessageCommandRequest request)
		{
			chatMessage.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(UpdateChatMessageCommandRequest request)
		{
			chatMessage.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfyInverted(AddChatMessageCommandRequest request)
		{
			chatMessage.ShouldSatisfy(p => p.MatchesInverted(request));
		}

		public void ShouldSatisfyInverted(UpdateChatMessageCommandRequest request)
		{
			chatMessage.ShouldSatisfy(p => p.MatchesInverted(request));
		}
	}

	extension(ICollection<ChatMessageImage> chatMessageImages)
	{
		public void ShouldSatisfy(AddChatMessageCommandRequest request)
		{
			chatMessageImages.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ChatMessageAddedNotificationRequest r)
	{
		public void ShouldSatisfy(
			AddChatMessageCommandRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(request, chatMessage));
		}

		public void ShouldSatisfyInverted(
			AddChatMessageCommandRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.MatchesInverted(request, chatMessage));
		}
	}

	extension(ChatMessageUpdatedNotificationRequest r)
	{
		public void ShouldSatisfy(
			UpdateChatMessageCommandRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(request, chatMessage));
		}

		public void ShouldSatisfyInverted(
			UpdateChatMessageCommandRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.MatchesInverted(request, chatMessage));
		}
	}

	extension(ChatMessageDeletedNotificationRequest r)
	{
		public void ShouldSatisfy(
			DeleteChatMessageCommandRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(request, chatMessage));
		}

		public void ShouldSatisfyInverted(
			DeleteChatMessageCommandRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.MatchesInverted(request, chatMessage));
		}
	}
}
