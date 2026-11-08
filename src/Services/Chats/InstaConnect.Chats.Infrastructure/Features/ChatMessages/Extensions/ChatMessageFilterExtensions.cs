using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;

public static class ChatMessageFilterExtensions
{
	extension(ChatMessagesFilterQuery filter)
	{
		public FilterDefinition<ChatMessage> GetFilter()
		{
			return filter.Id.GetFilterForIdEquals<ChatMessage>(
				p => p.Id.Id.ParticipantOneId.Id, p => p.Id.Id.ParticipantTwoId.Id);
		}
	}

	extension(ChatMessageId filter)
	{
		public FilterDefinition<ChatMessage> GetFilter()
		{
			return filter.GetFilterForIdEquals<ChatMessage>(
				p => p.Id.Id.ParticipantOneId.Id,
				p => p.Id.Id.ParticipantTwoId.Id,
				p => p.Id.MessageId);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(
			Expression<Func<T, object>> participantOneIdField,
			Expression<Func<T, object>> participantTwoIdField,
			Expression<Func<T, object>> messageIdField)
		{
			var chatId = filter.Id.GetFilterForIdEquals(participantOneIdField, participantTwoIdField);
			var messageId = Builders<T>.Filter.EqualsIgnoreCase(
				messageIdField, filter.MessageId, filter.MessageId.IsNullOrEmptyOrWhiteSpace());

			return Builders<T>.Filter.And(chatId, messageId);
		}
	}

	extension(IEnumerable<ChatMessageId> filter)
	{
		public FilterDefinition<ChatMessage> GetFilter()
		{
			return filter.GetFilterForIdRange<ChatMessage>(
				p => p.Id.Id.ParticipantOneId.Id,
				p => p.Id.Id.ParticipantTwoId.Id,
				p => p.Id.MessageId);
		}

		public FilterDefinition<T> GetFilterForIdRange<T>(
			Expression<Func<T, object>> participantOneIdField,
			Expression<Func<T, object>> participantTwoIdField,
			Expression<Func<T, object>> messageIdField)
		{
			return Builders<T>.Filter.OrRange(filter.Select(item => item.GetFilterForIdEquals(participantOneIdField, participantTwoIdField, messageIdField)));
		}
	}

	extension(IEnumerable<ChatId> filter)
	{
		public FilterDefinition<ChatMessage> GetChatMessageCascadeFilter()
		{
			return Builders<ChatMessage>.Filter.In(p => p.Id.Id, filter);
		}
	}
}
