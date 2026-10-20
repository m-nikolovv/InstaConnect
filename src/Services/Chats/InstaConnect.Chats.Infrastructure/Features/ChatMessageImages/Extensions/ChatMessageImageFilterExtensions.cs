namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Extensions;

internal static class ChatMessageImageFilterExtensions
{
	extension(ChatMessageImageId filter)
	{
		public FilterDefinition<ChatMessageImage> GetFilter()
		{
			return filter.GetFilterForIdEquals<ChatMessageImage>(
				p => p.Id.Id.Id.ParticipantOneId.Id,
				p => p.Id.Id.Id.ParticipantTwoId.Id,
				p => p.Id.Id.MessageId,
				p => p.Id.ImageId);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(
			Expression<Func<T, object>> participantOneIdField,
			Expression<Func<T, object>> participantTwoIdField,
			Expression<Func<T, object>> messageIdField,
			Expression<Func<T, object>> imageIdField)
		{
			var id = filter.Id.GetFilterForIdEquals(participantOneIdField, participantTwoIdField, messageIdField);
			var imageId = Builders<T>.Filter.EqualsIgnoreCase(
				imageIdField, filter.ImageId, filter.ImageId.IsNullOrEmptyOrWhiteSpace());

			return Builders<T>.Filter.And(id, imageId);
		}
	}

	extension(IEnumerable<ChatMessageImageId> filter)
	{
		public FilterDefinition<ChatMessageImage> GetFilter()
		{
			return filter.GetFilterForIdRange<ChatMessageImage>(
				p => p.Id.Id.Id.ParticipantOneId.Id,
				p => p.Id.Id.Id.ParticipantTwoId.Id,
				p => p.Id.Id.MessageId,
				p => p.Id.ImageId);
		}

		public FilterDefinition<T> GetFilterForIdRange<T>(
			Expression<Func<T, object>> participantOneIdField,
			Expression<Func<T, object>> participantTwoIdField,
			Expression<Func<T, object>> messageIdField,
			Expression<Func<T, object>> imageIdField)
		{
			return Builders<T>.Filter.Or(filter.Select(item => item.GetFilterForIdEquals(participantOneIdField, participantTwoIdField, messageIdField, imageIdField)));
		}
	}
}
