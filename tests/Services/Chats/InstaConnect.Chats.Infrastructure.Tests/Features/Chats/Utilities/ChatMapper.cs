using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Utilities;

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
	}

	extension(ICollection<Chat> chats)
	{
		public ICollection<ChatResponse> ToResponse(
			ChatsFilterQuery filterQuery,
			ChatsPaginationQuery paginationQuery)
		{
			return chats.Filter(paginationQuery, chat => chat.MatchesFilter(filterQuery), chat => chat.ToResponseWithoutParticipantOne());
		}

		public long ToTotalCountResponse(
			ChatsFilterQuery filterQuery)
		{
			return chats.Count(chat => chat.MatchesFilter(filterQuery));
		}
	}
}
