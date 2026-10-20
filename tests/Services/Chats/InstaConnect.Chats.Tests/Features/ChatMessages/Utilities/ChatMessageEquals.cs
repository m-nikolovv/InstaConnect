namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
	extension(ChatMessage entity)
	{
		public bool Matches(ChatMessage chatMessage)
		{
			return entity.Id.Matches(chatMessage.Id) &&
				   entity.SenderId.Matches(chatMessage.SenderId) &&
				   entity.Content == chatMessage.Content &&
				   entity.CreatedAtUtc == chatMessage.CreatedAtUtc &&
				   entity.UpdatedAtUtc == chatMessage.UpdatedAtUtc;
		}
	}

	extension(ChatMessageId p)
	{
		public bool Matches(ChatMessageId id)
		{
			return p.Matches(id.Id, id.MessageId);
		}

		public bool Matches(ChatId id, string messageId)
		{
			return p.Matches(id.ParticipantOneId.Id, id.ParticipantTwoId.Id, messageId);
		}

		public bool Matches(string participantOneId, string participantTwoId, string messageId)
		{
			return p.Id.Matches(participantOneId, participantTwoId) &&
				   p.MessageId.EqualsOrdinalIgnoreCase(messageId);
		}
	}
}
