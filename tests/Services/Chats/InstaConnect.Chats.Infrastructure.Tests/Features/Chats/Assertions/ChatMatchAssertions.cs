using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Assertions;

public static class ChatMatchAssertions
{
	extension(Chat response)
	{
		public void ShouldSatisfy(ChatId id, Chat chat)
		{
			response.ShouldSatisfy(p => p.Matches(id, chat));
		}
	}

	extension(ChatResponse response)
	{
		public void ShouldSatisfy(ChatId id, CurrentUserQuery currentUserQuery, Chat chat)
		{
			response.ShouldSatisfy(p => p.Matches(id, currentUserQuery, chat));
		}

		public void ShouldSatisfyInverted(ChatId id, CurrentUserQuery currentUserQuery, Chat chat)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(id, currentUserQuery, chat));
		}
	}

	extension(ICollection<ChatResponse> response)
	{
		public void ShouldSatisfy(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User participantOne,
			ICollection<Chat> chats)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, participantOne, chats));
		}

		public void ShouldSatisfy(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, participantOne, chats, termTransformer));
		}

		public void ShouldSatisfyInverted(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User participantTwo,
			ICollection<Chat> chats)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(filterQuery, sortingQuery, paginationQuery, currentUserQuery, participantTwo, chats));
		}

		public void ShouldSatisfyInverted(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(filterQuery, sortingQuery, paginationQuery, currentUserQuery, participantTwo, chats, termTransformer));
		}
	}

	extension(long response)
	{
		public void ShouldSatisfy(
			ChatsFilterQuery filterQuery,
			ICollection<Chat> chats)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, chats));
		}
	}

	extension(bool response)
	{
		public void ShouldSatisfy(ChatId id, Chat? chat)
		{
			response.ShouldSatisfy(p => p.Matches(id, chat));
		}
	}
}
