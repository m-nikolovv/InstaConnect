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
		public FilterDefinition<T> GetFilterForIdRange<T>(
			Expression<Func<T, object>> participantOneIdField,
			Expression<Func<T, object>> participantTwoIdField,
			Expression<Func<T, object>> messageIdField)
		{
			var participantOneId = Builders<T>.Filter.In(participantOneIdField, filter.Select(item => item.Id.ParticipantOneId.Id));
			var participantTwoId = Builders<T>.Filter.In(participantTwoIdField, filter.Select(item => item.Id.ParticipantTwoId.Id));
			var messageId = Builders<T>.Filter.In(messageIdField, filter.Select(item => item.MessageId));

			return Builders<T>.Filter.And(participantOneId, participantTwoId, messageId);
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
