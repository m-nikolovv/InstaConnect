using InstaConnect.Chats.Domain.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Events.Features.Chats;
using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

public static class ChatEquals
{
	extension(ChatId response)
	{
		public bool Matches(
			AddChatCommand command,
			Chat chat)
		{
			return response.Matches(chat.Id);
		}
	}

	extension(ChatAddedEventRequest request)
	{
		public bool Matches(AddChatCommand command, Chat entity)
		{
			return request.Chat.Matches(command, entity);
		}
	}

	extension(ChatEventRequest request)
	{
		public bool Matches(AddChatCommand command, Chat? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.ParticipantOneId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.ParticipantTwoId.Id) &&
				   request.ParticipantOne.MatchesParticipantOne(command, entity.ParticipantOne) &&
				   request.ParticipantTwo.MatchesParticipantTwo(command, entity.ParticipantTwo) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserEventRequest request)
	{
		public bool MatchesParticipantOne(AddChatCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.ParticipantOneId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantTwo(AddChatCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.ParticipantTwoId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(Chat chat)
	{
		public bool Matches(AddChatCommand command)
		{
			return chat.Id.Matches(command.ParticipantOneId, command.ParticipantTwoId) &&
				   chat.CreatedAtUtc != default;
		}

		public bool MatchesFilter(ChatsFilterQuery query)
		{
			return (chat.Id.ParticipantOneId.Matches(query.ParticipantOneId) &&
				   chat.ParticipantTwo.MatchesFilter(query)) ||
				   (chat.Id.ParticipantTwoId.Matches(query.ParticipantOneId) &&
				   chat.ParticipantOne.MatchesFilter(query));
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
		public bool MatchesFull<TQuery>(TQuery request, Chat? chat)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantOne) &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
		}

		public bool MatchesFullInverted<TQuery>(TQuery request, Chat? chat)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id.ParticipantTwoId, response.Id.ParticipantOneId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantTwo) &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
		}

		public bool MatchesWithoutParticipantOne<TQuery>(TQuery request, Chat? chat)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
		}

		public bool MatchesWithoutParticipantOneInverted<TQuery>(TQuery request, Chat? chat)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id.ParticipantTwoId, response.Id.ParticipantOneId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
		}

		public bool Matches(GetChatByIdQuery query, Chat chat)
		{
			return response.MatchesFull(query, chat);
		}

		public bool MatchesInverted(GetChatByIdQuery query, Chat chat)
		{
			return response.MatchesFullInverted(query, chat);
		}
	}

	extension(ChatCollectionResponse response)
	{
		public bool MatchesWithoutParticipantTwo<TQuery>(
			TQuery request,
			Func<ChatResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<ChatsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chats.Count(matchesFilter)) &&
				   response.ParticipantOne.MatchesFull(participantOne) &&
				   response.ParticipantTwo == null &&
				   response.Chats.MatchesCollection(request.Pagination,
													chats,
													response => response.Id,
													chat => chat.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutParticipantTwo<TQuery>(
			TQuery request,
			Func<ChatResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<ChatsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chats.Count(matchesFilter)) &&
				   response.ParticipantOne.MatchesFull(participantOne) &&
				   response.ParticipantTwo == null &&
				   response.Chats.MatchesSortedCollection(request.Pagination,
														  chats,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutParticipantTwoInverted<TQuery>(
			TQuery request,
			Func<ChatResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<ChatsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chats.Count(matchesFilter)) &&
				   response.ParticipantOne.MatchesFull(participantTwo) &&
				   response.ParticipantTwo == null &&
				   response.Chats.MatchesCollection(request.Pagination,
													chats,
													response => new(response.Id.ParticipantTwoId, response.Id.ParticipantOneId),
													chat => chat.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutParticipantTwoInverted<TQuery>(
			TQuery request,
			Func<ChatResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<ChatsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chats.Count(matchesFilter)) &&
				   response.ParticipantOne.MatchesFull(participantTwo) &&
				   response.ParticipantTwo == null &&
				   response.Chats.MatchesSortedCollection(request.Pagination,
														  chats,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
			GetAllChatsQuery query,
			User participantOne,
			ICollection<Chat> chats)
		{
			return response.MatchesWithoutParticipantTwo(
					   query,
					   (response, chat) => response.MatchesWithoutParticipantOne(query, chat),
					   chat => chat.MatchesFilter(query.Filter),
					   participantOne,
					   chats);
		}

		public bool Matches(
			GetAllChatsQuery query,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			return response.MatchesWithoutParticipantTwo(
					   query,
					   (response, chat) => response.MatchesWithoutParticipantOne(query, chat),
					   chat => chat.MatchesFilter(query.Filter),
					   participantOne,
					   chats,
					   termTransformer);
		}

		public bool MatchesInverted(
			GetAllChatsQuery query,
			User participantTwo,
			ICollection<Chat> chats)
		{
			return response.MatchesWithoutParticipantTwoInverted(
					   query,
					   (response, chat) => response.MatchesWithoutParticipantOneInverted(query, chat),
					   chat => chat.MatchesFilter(query.Filter),
					   participantTwo,
					   chats);
		}

		public bool MatchesInverted(
			GetAllChatsQuery query,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			return response.MatchesWithoutParticipantTwoInverted(
					   query,
					   (response, chat) => response.MatchesWithoutParticipantOneInverted(query, chat),
					   chat => chat.MatchesFilter(query.Filter),
					   participantTwo,
					   chats,
					   termTransformer);
		}
	}
}
