using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Utilities;

public static class ChatEquals
{
	extension(Chat c)
	{
		public bool Matches(
			ChatId id,
			Chat chat)
		{
			return c.Matches(chat);
		}

		public bool MatchesFilter(ChatsFilterQuery query)
		{
			return (c.Id.ParticipantOneId.Matches(query.ParticipantOneId) &&
				   c.ParticipantTwo.MatchesFilter(query)) ||
				   (c.Id.ParticipantTwoId.Matches(query.ParticipantOneId) &&
				   c.ParticipantOne.MatchesFilter(query));
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(ChatsFilterQuery query)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(query.ParticipantTwoName.Value);
		}
	}

	extension(ChatResponse? response)
	{
		public bool MatchesFull(
			CurrentUserQuery currentUserQuery,
			Chat? chat)
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantOne) &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
		}

		public bool MatchesFullInverted(
			CurrentUserQuery currentUserQuery,
			Chat? chat)
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id.ParticipantTwoId, response.Id.ParticipantOneId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantTwo) &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
		}

		public bool MatchesWithoutParticipantOne(
			CurrentUserQuery currentUserQuery,
			Chat? chat)
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
		}

		public bool MatchesWithoutParticipantOneInverted(
			CurrentUserQuery currentUserQuery,
			Chat? chat)
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id.ParticipantTwoId, response.Id.ParticipantOneId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
		}

		public bool Matches(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			Chat chat)
		{
			return response.MatchesFull(currentUserQuery, chat);
		}

		public bool MatchesInverted(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			Chat chat)
		{
			return response.MatchesFullInverted(currentUserQuery, chat);
		}
	}

	extension(ICollection<ChatResponse> response)
	{
		public bool MatchesWithoutParticipantTwo(
			ChatsPaginationQuery paginationQuery,
			Func<ChatResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats)
		{
			return response.MatchesCollectionAndNotEmpty(paginationQuery,
											  chats,
											  response => response.Id,
											  chat => chat.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutParticipantTwo(
			ChatsPaginationQuery paginationQuery,
			Func<ChatResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													chats,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool MatchesWithoutParticipantTwoInverted(
			ChatsPaginationQuery paginationQuery,
			Func<ChatResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats)
		{
			return response.MatchesCollectionAndNotEmpty(paginationQuery,
											  chats,
											  response => new(response.Id.ParticipantTwoId, response.Id.ParticipantOneId),
											  chat => chat.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutParticipantTwoInverted(
			ChatsPaginationQuery paginationQuery,
			Func<ChatResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													chats,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool Matches(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User participantOne,
			ICollection<Chat> chats)
		{
			return response.MatchesWithoutParticipantTwo(
					   paginationQuery,
					   (response, chat) => response.MatchesWithoutParticipantOne(currentUserQuery, chat),
					   chat => chat.MatchesFilter(filterQuery),
					   participantOne,
					   chats);
		}

		public bool Matches(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			return response.MatchesWithoutParticipantTwo(
					   paginationQuery,
					   (response, chat) => response.MatchesWithoutParticipantOne(currentUserQuery, chat),
					   chat => chat.MatchesFilter(filterQuery),
					   participantOne,
					   chats,
					   termTransformer);
		}

		public bool MatchesInverted(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User participantTwo,
			ICollection<Chat> chats)
		{
			return response.MatchesWithoutParticipantTwoInverted(
					   paginationQuery,
					   (response, chat) => response.MatchesWithoutParticipantOneInverted(currentUserQuery, chat),
					   chat => chat.MatchesFilter(filterQuery),
					   participantTwo,
					   chats);
		}

		public bool MatchesInverted(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			return response.MatchesWithoutParticipantTwoInverted(
					   paginationQuery,
					   (response, chat) => response.MatchesWithoutParticipantOneInverted(currentUserQuery, chat),
					   chat => chat.MatchesFilter(filterQuery),
					   participantTwo,
					   chats,
					   termTransformer);
		}
	}

	extension(long response)
	{
		public bool Matches(
			ChatsFilterQuery filterQuery,
			ICollection<Chat> chats)
		{
			return response == chats.Count(chat => chat.MatchesFilter(filterQuery));
		}
	}

	extension(bool response)
	{
		public bool Matches(ChatId id, Chat? chat)
		{
			return response == (chat != null);
		}
	}
}
