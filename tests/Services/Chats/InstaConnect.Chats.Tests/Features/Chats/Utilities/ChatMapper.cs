using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatMapper
{
	extension(Chat chat)
	{
		public ChatId ToId()
		{
			return chat.Id;
		}

		public ChatResponse ToFullResponse()
		{
			return new(chat.Id,
					   chat.ParticipantOne?.ToFullResponse(),
					   chat.ParticipantTwo?.ToFullResponse(),
					   chat.ChatMessages.Count,
					   chat.CreatedAtUtc);
		}

		public ChatResponse ToResponseWithoutParticipantOne()
		{
			return new(chat.Id,
					   null,
					   chat.ParticipantTwo?.ToFullResponse(),
					   chat.ChatMessages.Count,
					   chat.CreatedAtUtc);
		}

		public ChatResponse ToResponseWithoutParticipantTwo()
		{
			return new(chat.Id,
					   chat.ParticipantOne?.ToFullResponse(),
					   null,
					   chat.ChatMessages.Count,
					   chat.CreatedAtUtc);
		}
	}

	extension(ICollection<Chat> chats)
	{
		public ICollection<ChatResponse> ToFullResponse()
		{
			return [.. chats.Select(chat => chat.ToFullResponse())];
		}
	}
}
