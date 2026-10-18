using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Users.Models.Requests;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
	extension(ChatMessage m)
	{
		public bool Matches(
			ChatMessageId id,
			ChatMessage chatMessage)
		{
			return m.Matches(chatMessage);
		}

		public bool MatchesFilter(ChatMessagesFilterQuery query)
		{
			return (m.Id.Id.ParticipantOneId.Matches(query.Id.ParticipantOneId) &&
				   m.Id.Id.ParticipantTwoId.Matches(query.Id.ParticipantTwoId)) ||
				   (m.Id.Id.ParticipantOneId.Matches(query.Id.ParticipantTwoId) &&
				   m.Id.Id.ParticipantTwoId.Matches(query.Id.ParticipantOneId));
		}
	}

	extension(ChatMessageResponse? response)
	{
		public bool MatchesFull(
			CurrentUserQuery currentUserQuery,
			ChatMessage? chatMessage)
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.Id) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFull(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFull(currentUserQuery, chatMessage.Chat);
		}

		public bool MatchesFullInverted(
			CurrentUserQuery currentUserQuery,
			ChatMessage? chatMessage)
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(new(response.Id.Id.ParticipantTwoId, response.Id.Id.ParticipantOneId), response.Id.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFullInverted(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFullInverted(currentUserQuery, chatMessage.Chat);
		}

		public bool MatchesWithoutChat(
			CurrentUserQuery currentUserQuery,
			ChatMessage? chatMessage)
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.Id) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFull(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat == null;
		}

		public bool MatchesWithoutChatInverted(
			CurrentUserQuery currentUserQuery,
			ChatMessage? chatMessage)
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(new(response.Id.Id.ParticipantTwoId, response.Id.Id.ParticipantOneId), response.Id.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFullInverted(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat == null;
		}

		public bool Matches(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			ChatMessage chatMessage)
		{
			return response.MatchesFull(currentUserQuery, chatMessage);
		}

		public bool MatchesInverted(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			ChatMessage chatMessage)
		{
			return response.MatchesFullInverted(currentUserQuery, chatMessage);
		}
	}

	extension(ICollection<ChatMessageResponse> response)
	{
		public bool MatchesWithoutSender(
			ChatMessagesPaginationQuery paginationQuery,
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
		{
			return response.MatchesCollection(paginationQuery,
											  chatMessages,
											  response => response.Id,
											  chatMessage => chatMessage.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutSender(
			ChatMessagesPaginationQuery paginationQuery,
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													chatMessages,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool MatchesWithoutSenderInverted(
			ChatMessagesPaginationQuery paginationQuery,
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
		{
			return response.MatchesCollection(paginationQuery,
											  chatMessages,
											  response => new(new(response.Id.Id.ParticipantTwoId, response.Id.Id.ParticipantOneId), response.Id.MessageId),
											  chatMessage => chatMessage.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutSenderInverted(
			ChatMessagesPaginationQuery paginationQuery,
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													chatMessages,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool Matches(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
		{
			return response.MatchesWithoutSender(
					   paginationQuery,
					   (response, chatMessage) => response.MatchesWithoutChat(currentUserQuery, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(filterQuery),
					   chat,
					   chatMessages);
		}

		public bool Matches(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.MatchesWithoutSender(
					   paginationQuery,
					   (response, chatMessage) => response.MatchesWithoutChat(currentUserQuery, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(filterQuery),
					   chat,
					   chatMessages,
					   termTransformer);
		}

		public bool MatchesInverted(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
		{
			return response.MatchesWithoutSenderInverted(
					   paginationQuery,
					   (response, chatMessage) => response.MatchesWithoutChatInverted(currentUserQuery, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(filterQuery),
					   chat,
					   chatMessages);
		}

		public bool MatchesInverted(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.MatchesWithoutSenderInverted(
					   paginationQuery,
					   (response, chatMessage) => response.MatchesWithoutChatInverted(currentUserQuery, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(filterQuery),
					   chat,
					   chatMessages,
					   termTransformer);
		}
	}

	extension(long response)
	{
		public bool Matches(
			ChatMessagesFilterQuery filterQuery,
			ICollection<ChatMessage> chatMessages)
		{
			return response == chatMessages.Count(chatMessage => chatMessage.MatchesFilter(filterQuery));
		}
	}

	extension(bool response)
	{
		public bool Matches(ChatMessageId id, ChatMessage? chatMessage)
		{
			return response == (chatMessage != null);
		}
	}
}
