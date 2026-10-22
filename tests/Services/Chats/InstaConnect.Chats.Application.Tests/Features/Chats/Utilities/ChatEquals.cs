using InstaConnect.Chats.Application.Features.Chats.Models;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Events.Features.Chats.Models;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatEquals
{
	extension(ChatAddedEventRequest r)
	{
		public bool Matches(AddChatCommandRequest request, Chat entity)
		{
			return r.Chat.Matches(request, entity);
		}
	}

	extension(ChatEventRequest r)
	{
		public bool Matches(AddChatCommandRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.ParticipantOne.MatchesParticipantOne(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantTwo(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserEventRequest r)
	{
		public bool MatchesParticipantOne(AddChatCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool MatchesParticipantTwo(AddChatCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(GetAllChatsQuery query)
	{
		public bool Matches(GetAllChatsQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllChatsQuery, ChatsSortTerm, ChatsSortingQuery, GetAllChatsQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllChatsQuery, ChatsPaginationQuery, GetAllChatsQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllChatsQueryRequest request)
		{
			return query.Filter.ParticipantOneId.Matches(request.CurrentUserId) &&
				   query.Filter.ParticipantTwoName.Matches(request.ParticipantTwoName);
		}
	}

	extension(GetChatByIdQuery query)
	{
		public bool Matches(GetChatByIdQueryRequest request)
		{
			return query.Id.Matches(request.CurrentUserId, request.ParticipantTwoId) &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddChatCommand command)
	{
		public bool Matches(AddChatCommandRequest request)
		{
			return command.ParticipantOneId.Matches(request.ParticipantOneId) &&
				   command.ParticipantTwoId.Matches(request.ParticipantTwoId);
		}
	}

	extension(AddChatCommandResponse response)
	{
		public bool Matches(AddChatCommandRequest request, Chat chat)
		{
			return response.Response.Matches(chat.Id);
		}
	}

	extension(GetChatByIdQueryResponse response)
	{
		public bool Matches(GetChatByIdQueryRequest request, Chat chat)
		{
			return response.Response.MatchesFull(request, chat);
		}

		public bool MatchesInverted(GetChatByIdQueryRequest request, Chat chat)
		{
			return response.Response.MatchesFullInverted(request, chat);
		}
	}

	extension(GetAllChatsQueryResponse response)
	{
		public bool Matches(
			GetAllChatsQueryRequest request,
			User participantOne,
			ICollection<Chat> chats)
		{
			return response.Response.MatchesWithoutParticipantTwo(
					   request,
					   (response, chat) => response.MatchesWithoutParticipantOne(request, chat),
					   chat => chat.MatchesFilter(request),
					   participantOne,
					   chats);
		}

		public bool Matches(
			GetAllChatsQueryRequest request,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			return response.Response.MatchesWithoutParticipantTwo(
					   request,
					   (response, chat) => response.MatchesWithoutParticipantOne(request, chat),
					   chat => chat.MatchesFilter(request),
					   participantOne,
					   chats,
					   termTransformer);
		}

		public bool MatchesInverted(
			GetAllChatsQueryRequest request,
			User participantTwo,
			ICollection<Chat> chats)
		{
			return response.Response.MatchesWithoutParticipantTwoInverted(
					   request,
					   (response, chat) => response.MatchesWithoutParticipantOneInverted(request, chat),
					   chat => chat.MatchesFilter(request),
					   participantTwo,
					   chats);
		}

		public bool MatchesInverted(
			GetAllChatsQueryRequest request,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			return response.Response.MatchesWithoutParticipantTwoInverted(
					   request,
					   (response, chat) => response.MatchesWithoutParticipantOneInverted(request, chat),
					   chat => chat.MatchesFilter(request),
					   participantTwo,
					   chats,
					   termTransformer);
		}
	}

	extension(Chat chat)
	{
		public bool Matches(AddChatCommandRequest request)
		{
			return chat.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
				   chat.CreatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllChatsQueryRequest request)
		{
			return (chat.Id.ParticipantOneId.Matches(request.CurrentUserId) &&
				   chat.ParticipantTwo.MatchesFilter(request)) ||
				   (chat.Id.ParticipantTwoId.Matches(request.CurrentUserId) &&
				   chat.ParticipantOne.MatchesFilter(request));
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(GetAllChatsQueryRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.ParticipantTwoName);
		}
	}

	extension(ChatIdCommandResponse response)
	{
		public bool Matches(ChatId id)
		{
			return id.Matches(response.ParticipantOneId, response.ParticipantTwoId);
		}
	}

	extension(ChatQueryResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, Chat? chat)
		where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantOne) &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
		}

		public bool MatchesWithoutParticipantOne<TRequest>(TRequest request, Chat? chat)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
		}

		public bool MatchesWithoutParticipantTwo<TRequest>(TRequest request, Chat? chat)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantOne) &&
				   response.ParticipantTwo == null;
		}

		public bool MatchesFullInverted<TRequest>(TRequest request, Chat? chat)
		where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantTwo) &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
		}

		public bool MatchesWithoutParticipantOneInverted<TRequest>(TRequest request, Chat? chat)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
		}

		public bool MatchesWithoutParticipantTwoInverted<TRequest>(TRequest request, Chat? chat)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantTwo) &&
				   response.ParticipantTwo == null;
		}
	}

	extension(ChatCollectionQueryResponse response)
	{
		public bool MatchesWithoutParticipantOne<TRequest>(
			TRequest request,
			Func<ChatQueryResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chats.Count(matchesFilter)) &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(participantTwo) &&
				   response.Chats.MatchesCollection(request,
													chats,
													response => new(new(response.ParticipantOneId), new(response.ParticipantTwoId)),
													chat => chat.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutParticipantOne<TRequest>(
			TRequest request,
			Func<ChatQueryResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chats.Count(matchesFilter)) &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(participantTwo) &&
				   response.Chats.MatchesSortedCollection(request,
														  chats,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutParticipantTwo<TRequest>(
			TRequest request,
			Func<ChatQueryResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chats.Count(matchesFilter)) &&
				   response.ParticipantOne.MatchesFull(participantOne) &&
				   response.ParticipantTwo == null &&
				   response.Chats.MatchesCollection(request,
													chats,
													response => new(new(response.ParticipantOneId), new(response.ParticipantTwoId)),
													chat => chat.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutParticipantTwo<TRequest>(
			TRequest request,
			Func<ChatQueryResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chats.Count(matchesFilter)) &&
				   response.ParticipantOne.MatchesFull(participantOne) &&
				   response.ParticipantTwo == null &&
				   response.Chats.MatchesSortedCollection(request,
														  chats,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutParticipantOneInverted<TRequest>(
			TRequest request,
			Func<ChatQueryResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chats.Count(matchesFilter)) &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(participantTwo) &&
				   response.Chats.MatchesCollection(request,
													chats,
													response => new(new(response.ParticipantTwoId), new(response.ParticipantOneId)),
													chat => chat.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutParticipantOneInverted<TRequest>(
			TRequest request,
			Func<ChatQueryResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chats.Count(matchesFilter)) &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(participantTwo) &&
				   response.Chats.MatchesSortedCollection(request,
														  chats,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutParticipantTwoInverted<TRequest>(
			TRequest request,
			Func<ChatQueryResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chats.Count(matchesFilter)) &&
				   response.ParticipantOne.MatchesFull(participantOne) &&
				   response.ParticipantTwo == null &&
				   response.Chats.MatchesCollection(request,
													chats,
													response => new(new(response.ParticipantTwoId), new(response.ParticipantOneId)),
													chat => chat.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutParticipantTwoInverted<TRequest>(
			TRequest request,
			Func<ChatQueryResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, chats.Count(matchesFilter)) &&
				   response.ParticipantOne.MatchesFull(participantOne) &&
				   response.ParticipantTwo == null &&
				   response.Chats.MatchesSortedCollection(request,
														  chats,
														  matches,
														  termTransformer,
														  matchesFilter);
		}
	}
}
