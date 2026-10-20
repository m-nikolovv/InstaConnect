using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatMapper
{
	extension(Chat chat)
	{
		internal ChatResponse ToFullResponse()
		{
			return new(chat.Id,
					   chat.ParticipantOne?.ToFullResponse(),
					   chat.ParticipantTwo?.ToFullResponse(),
					   chat.CreatedAtUtc);
		}

		internal ChatResponse ToResponseWithoutParticipantOne()
		{
			return new(chat.Id,
					   null,
					   chat.ParticipantTwo?.ToFullResponse(),
					   chat.CreatedAtUtc);
		}

		internal ChatResponse ToResponseWithoutParticipantTwo()
		{
			return new(chat.Id,
					   chat.ParticipantOne?.ToFullResponse(),
					   null,
					   chat.CreatedAtUtc);
		}

		public ChatId ToResponse(
			AddChatCommandRequest request)
		{
			return chat.ToId();
		}

		public ChatResponse ToResponse(
			GetChatByIdQueryRequest request)
		{
			return chat.ToFullResponse();
		}
	}

	extension(ICollection<Chat> chats)
	{
		internal ChatCollectionResponse ToResponseWithoutParticipantOne<TRequest>(
			TRequest request,
			User participantTwo,
			Func<TRequest, Chat, bool> filter,
			Func<TRequest, Chat, ChatResponse> transform)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = chats.Count(chat => filter(request, chat));

			return new(null,
					   participantTwo.ToFullResponse(),
					   chats.Filter(request, chat => filter(request, chat), chat => transform(request, chat)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal ChatCollectionResponse ToResponseWithoutParticipantTwo<TRequest>(
			TRequest request,
			User participantOne,
			Func<TRequest, Chat, bool> filter,
			Func<TRequest, Chat, ChatResponse> transform)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = chats.Count(chat => filter(request, chat));

			return new(participantOne.ToFullResponse(),
					   null,
					   chats.Filter(request, chat => filter(request, chat), chat => transform(request, chat)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public ChatCollectionResponse ToResponse(
			GetAllChatsQueryRequest request,
			User participantOne)
		{
			return chats.ToResponseWithoutParticipantTwo(
				request,
				participantOne,
				(request, chat) => chat.MatchesFilter(request),
				(request, chat) => chat.ToResponseWithoutParticipantOne());
		}
	}
}
