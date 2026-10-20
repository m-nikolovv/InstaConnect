using InstaConnect.Chats.Domain.Features.Users.Models.Responses;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

public static class ChatMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			GetAllChatsQuery query)
		{
			return user.ToFullResponse();
		}
	}

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

		public Chat To(AddChatCommand command)
		{
			return new(
				new(command.ParticipantOneId, command.ParticipantTwoId),
				chat.CreatedAtUtc);
		}

		public ChatId ToResponse(
			AddChatCommand command)
		{
			return chat.ToId();
		}

		public ChatResponse ToResponse(
			GetChatByIdQuery query)
		{
			return chat.ToFullResponse();
		}
	}

	extension(ICollection<Chat> chats)
	{
		public ICollection<ChatResponse> ToResponse(
			GetAllChatsQuery query)
		{
			return chats.Filter(query.Pagination, chat => chat.MatchesFilter(query.Filter), chat => chat.ToResponseWithoutParticipantOne());
		}

		public long ToTotalCountResponse(
			GetAllChatsQuery query)
		{
			return chats.Count(chat => chat.MatchesFilter(query.Filter));
		}
	}
}
