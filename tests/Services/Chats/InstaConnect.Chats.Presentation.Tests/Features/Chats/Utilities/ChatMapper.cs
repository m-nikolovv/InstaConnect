using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Models;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;
using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatMapper
{
	extension(Chat chat)
	{
		internal ChatIdCommandResponse ToIdCommandResponse(
)
		{
			return new(chat.Id.ParticipantOneId.Id, chat.Id.ParticipantTwoId.Id);
		}

		internal ChatQueryResponse ToFullQueryResponse()
		{
			return new(chat.Id.ParticipantOneId.Id,
					   chat.Id.ParticipantTwoId.Id,
					   chat.ParticipantOne?.ToFullQueryResponse(),
					   chat.ParticipantTwo?.ToFullQueryResponse(),
					   chat.CreatedAtUtc);
		}

		internal ChatQueryResponse ToQueryResponseWithoutParticipantOne()
		{
			return new(chat.Id.ParticipantOneId.Id,
					   chat.Id.ParticipantTwoId.Id,
					   null,
					   chat.ParticipantTwo?.ToFullQueryResponse(),
					   chat.CreatedAtUtc);
		}

		internal ChatQueryResponse ToQueryResponseWithoutParticipantTwo()
		{
			return new(chat.Id.ParticipantOneId.Id,
					   chat.Id.ParticipantTwoId.Id,
					   chat.ParticipantOne?.ToFullQueryResponse(),
					   null,
					   chat.CreatedAtUtc);
		}

		public AddChatCommandResponse ToResponse(
			AddChatApiRequest request)
		{
			return new(chat.ToIdCommandResponse());
		}

		public GetChatByIdQueryResponse ToResponse(
			GetChatByIdApiRequest request)
		{
			return new(chat.ToFullQueryResponse());
		}
	}

	extension(ICollection<Chat> chats)
	{
		internal ChatCollectionQueryResponse ToQueryResponseWithoutParticipantTwo<TRequest>(
			TRequest request,
			User participantOne,
			Func<TRequest, Chat, bool> filter,
			Func<TRequest, Chat, ChatQueryResponse> transform)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = chats.Count(chat => filter(request, chat));

			return new(participantOne.ToFullQueryResponse(),
					   null,
					   chats.Filter(request, chat => filter(request, chat), chat => transform(request, chat)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public GetAllChatsQueryResponse ToResponse(
			GetAllChatsApiRequest request,
			User participantOne)
		{
			return new(chats.ToQueryResponseWithoutParticipantTwo(
												   request,
												   participantOne,
												   (request, chat) => chat.MatchesFilter(request),
												   (request, chat) => chat.ToQueryResponseWithoutParticipantOne()));
		}
	}
}
