namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

internal static class ChatFilterExtensions
{
	extension(ChatsFilterQuery filter)
	{
		public FilterDefinition<Chat> GetFilter()
		{
			var participantOne = Builders<Chat>.Filter.AndAll(
				filter.ParticipantOneId.GetFilterForIdEquals<Chat>(p => p.Id.ParticipantOneId.Id),
				filter.ParticipantTwoName.GetFilterForNameStartsWith<Chat>(p => p.ParticipantTwo!.Name.Value));

			var participantTwo = Builders<Chat>.Filter.AndAll(
				filter.ParticipantOneId.GetFilterForIdEquals<Chat>(p => p.Id.ParticipantTwoId.Id),
				filter.ParticipantTwoName.GetFilterForNameStartsWith<Chat>(p => p.ParticipantOne!.Name.Value));

			return Builders<Chat>.Filter.OrRange([participantOne, participantTwo]);
		}

		public FilterDefinition<Chat> GetParticipantFilter()
		{
			return Builders<Chat>.Filter.OrRange([
				filter.ParticipantOneId.GetFilterForIdEquals<Chat>(p => p.Id.ParticipantOneId.Id),
				filter.ParticipantOneId.GetFilterForIdEquals<Chat>(p => p.Id.ParticipantTwoId.Id)]);
		}
	}

	extension(ChatId filter)
	{
		public FilterDefinition<Chat> GetFilter()
		{
			return filter.GetFilterForIdEquals<Chat>(
				p => p.Id.ParticipantOneId.Id,
				p => p.Id.ParticipantTwoId.Id);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(
			Expression<Func<T, object>> participantOneIdField,
			Expression<Func<T, object>> participantTwoIdField)
		{
			var participantOneId = Builders<T>.Filter.AndAll(
				filter.ParticipantOneId.GetFilterForIdEquals(participantOneIdField),
				filter.ParticipantTwoId.GetFilterForIdEquals(participantTwoIdField));

			var participantTwoId = Builders<T>.Filter.AndAll(
				filter.ParticipantTwoId.GetFilterForIdEquals(participantOneIdField),
				filter.ParticipantOneId.GetFilterForIdEquals(participantTwoIdField));

			return Builders<T>.Filter.OrRange([participantOneId, participantTwoId]);
		}
	}

	extension(IEnumerable<ChatId> filter)
	{
		public FilterDefinition<Chat> GetFilter()
		{
			return filter.GetFilterForIdRange<Chat>(
				p => p.Id.ParticipantOneId.Id,
				p => p.Id.ParticipantTwoId.Id);
		}

		public FilterDefinition<T> GetFilterForIdRange<T>(
			Expression<Func<T, object>> participantOneIdField,
			Expression<Func<T, object>> participantTwoIdField)
		{
			return Builders<T>.Filter.OrRange(filter.Select(item => item.GetFilterForIdEquals(participantOneIdField, participantTwoIdField)));
		}
	}

	extension(UserId filter)
	{
		public FilterDefinition<Chat> GetChatByParentFilter()
		{
			var participantOneId = filter.GetFilterForIdEquals<Chat>(p => p.Id.ParticipantOneId.Id);
			var participantTwoId = filter.GetFilterForIdEquals<Chat>(p => p.Id.ParticipantTwoId.Id);

			return Builders<Chat>.Filter.OrRange([participantOneId, participantTwoId]);
		}
	}
}
