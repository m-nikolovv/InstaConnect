using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Events.Features.Chats;
using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatEquals
{
	extension(ChatAddedEventRequest r)
	{
		public bool Matches(AddChatApiRequest request, Chat entity)
		{
			return r.Chat.Matches(request, entity);
		}
	}

	extension(ChatEventRequest r)
	{
		public bool Matches(AddChatApiRequest request, Chat? entity)
		{
			return entity != null &&
				   r.ParticipantOneId.EqualsOrdinalIgnoreCase(request.ParticipantOneId) &&
				   r.ParticipantTwoId.EqualsOrdinalIgnoreCase(request.Body.ParticipantTwoId) &&
				   r.ParticipantOne.MatchesParticipantOne(request, entity.ParticipantOne) &&
				   r.ParticipantTwo.MatchesParticipantTwo(request, entity.ParticipantTwo) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserEventRequest r)
	{
		public bool MatchesParticipantOne(AddChatApiRequest request, User? entity)
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

		public bool MatchesParticipantTwo(AddChatApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Body.ParticipantTwoId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(GetAllChatsQueryRequest query)
	{
		public bool Matches(GetAllChatsApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllChatsQueryRequest, ChatsSortTerm, GetAllChatsApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllChatsApiRequest request)
		{
			return query.ParticipantTwoName == request.ParticipantTwoName;
		}
	}

	extension(GetChatByIdQueryRequest query)
	{
		public bool Matches(GetChatByIdApiRequest request)
		{
			return query.ParticipantTwoId == request.ParticipantTwoId &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddChatCommandRequest command)
	{
		public bool Matches(AddChatApiRequest request)
		{
			return command.ParticipantOneId == request.ParticipantOneId &&
				   command.ParticipantTwoId == request.Body.ParticipantTwoId;
		}
	}

	extension(AddChatApiResponse response)
	{
		public bool Matches(
		AddChatApiRequest request,
		Chat chat)
		{
			return response.Response.Matches(chat.Id);
		}
	}

	extension(GetChatByIdApiResponse response)
	{
		public bool Matches(GetChatByIdApiRequest request, Chat chat)
		{
			return response.Response.MatchesFull(request, chat);
		}

		public bool MatchesInverted(GetChatByIdApiRequest request, Chat chat)
		{
			return response.Response.MatchesFullInverted(request, chat);
		}
	}

	extension(GetAllChatsApiResponse response)
	{
		public bool Matches(
		GetAllChatsApiRequest request,
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
			GetAllChatsApiRequest request,
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
		GetAllChatsApiRequest request,
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
			GetAllChatsApiRequest request,
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
		public bool Matches(AddChatApiRequest request)
		{
			return chat.Id.Matches(request.ParticipantOneId, request.Body.ParticipantTwoId) &&
				   chat.CreatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllChatsApiRequest request)
		{
			return (chat.Id.ParticipantOneId.Matches(request.CurrentUserId) &&
				   chat.ParticipantTwo.MatchesFilter(request)) ||
				   (chat.Id.ParticipantTwoId.Matches(request.CurrentUserId) &&
				   chat.ParticipantOne.MatchesFilter(request));
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(GetAllChatsApiRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.ParticipantTwoName);
		}
	}

	extension(ChatIdApiResponse response)
	{
		public bool Matches(ChatId id)
		{
			return id.Matches(response.ParticipantOneId, response.ParticipantTwoId);
		}
	}

	extension(ChatApiResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, Chat? chat)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantOne) &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
		}

		public bool MatchesWithoutParticipantOne<TRequest>(TRequest request, Chat? chat)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
		}

		public bool MatchesWithoutParticipantTwo<TRequest>(TRequest request, Chat? chat)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantOne) &&
				   response.ParticipantTwo == null;
		}

		public bool MatchesFullInverted<TRequest>(TRequest request, Chat? chat)
		where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantTwo) &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
		}

		public bool MatchesWithoutParticipantOneInverted<TRequest>(TRequest request, Chat? chat)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
		}

		public bool MatchesWithoutParticipantTwoInverted<TRequest>(TRequest request, Chat? chat)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantTwo) &&
				   response.ParticipantTwo == null;
		}
	}

	extension(ChatCollectionApiResponse response)
	{
		public bool MatchesWithoutParticipantOne<TRequest>(
			TRequest request,
			Func<ChatApiResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<ChatApiResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<ChatApiResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<ChatApiResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<ChatApiResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<ChatApiResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<ChatApiResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<ChatApiResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
