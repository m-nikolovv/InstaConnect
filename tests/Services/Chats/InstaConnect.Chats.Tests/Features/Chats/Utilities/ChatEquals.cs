using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatEquals
{
	extension(Chat entity)
	{
		public bool Matches(Chat chat)
		{
			return entity.Id.Matches(chat.Id) &&
				   entity.CreatedAtUtc == chat.CreatedAtUtc;
		}
	}

	extension(ICollection<Chat> entities)
	{
		public bool Matches(ICollection<Chat> chats)
		{
			return entities.MatchesCollectionAndNotEmpty(
				chats,
				e => e.Id,
				e => e.Id,
				(entity, chat) => entity.Matches(chat));
		}
	}

	extension(ChatId p)
	{
		public bool Matches(ChatId id)
		{
			return p.Matches(id.ParticipantOneId, id.ParticipantTwoId);
		}

		public bool Matches(UserId participantOneId, UserId participantTwoId)
		{
			return p.Matches(participantOneId.Id, participantTwoId.Id);
		}

		public bool Matches(string participantOneId, string participantTwoId)
		{
			return p.ParticipantOneId.Id.EqualsOrdinalIgnoreCase(participantOneId) &&
				   p.ParticipantTwoId.Id.EqualsOrdinalIgnoreCase(participantTwoId);
		}
	}

	extension(ChatResponse? response)
	{
		public bool MatchesFull(Chat? chat)
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id) &&
				   chat.ChatMessages.Count == response.MessageCount &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantOne) &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
		}

		public bool MatchesFullInverted(Chat? chat)
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id.ParticipantTwoId, response.Id.ParticipantOneId) &&
				   chat.ChatMessages.Count == response.MessageCount &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantTwo) &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
		}

		public bool MatchesWithoutParticipantOne(Chat? chat)
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id) &&
				   chat.ChatMessages.Count == response.MessageCount &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
		}

		public bool MatchesWithoutParticipantOneInverted(Chat? chat)
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id.ParticipantTwoId, response.Id.ParticipantOneId) &&
				   chat.ChatMessages.Count == response.MessageCount &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
		}
	}
}
