using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMatchAssertions
{
	extension(ChatMessage response)
	{
		public void ShouldSatisfy(ChatMessageId id, ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.Matches(id, chatMessage));
		}
	}

	extension(ChatMessageResponse response)
	{
		public void ShouldSatisfy(ChatMessageId id, CurrentUserQuery currentUserQuery, ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.Matches(id, currentUserQuery, chatMessage));
		}

		public void ShouldSatisfyInverted(ChatMessageId id, CurrentUserQuery currentUserQuery, ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(id, currentUserQuery, chatMessage));
		}
	}

	extension(ICollection<ChatMessageResponse> response)
	{
		public void ShouldSatisfy(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, chat, chatMessages));
		}

		public void ShouldSatisfy(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, chat, chatMessages, termTransformer));
		}

		public void ShouldSatisfyInverted(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(filterQuery, sortingQuery, paginationQuery, currentUserQuery, chat, chatMessages));
		}

		public void ShouldSatisfyInverted(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(filterQuery, sortingQuery, paginationQuery, currentUserQuery, chat, chatMessages, termTransformer));
		}
	}

	extension(long response)
	{
		public void ShouldSatisfy(
			ChatMessagesFilterQuery filterQuery,
			ICollection<ChatMessage> chatMessages)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, chatMessages));
		}
	}

	extension(bool response)
	{
		public void ShouldSatisfy(ChatMessageId id, ChatMessage? chatMessage)
		{
			response.ShouldSatisfy(p => p.Matches(id, chatMessage));
		}
	}
}
