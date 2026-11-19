namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;

public class GetChatByIdQueryBuilder
{
	private string _participantTwoId;
	private string _currentUserId;

	public GetChatByIdQueryBuilder(Chat chat, UserId currentUserId)
	{
		_participantTwoId = chat.Id.ParticipantTwoId.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetChatByIdQueryBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public GetChatByIdQueryBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public GetChatByIdQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetChatByIdQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetChatByIdQuery Build()
	{
		return new(
			new(
				new(_currentUserId),
				new(_participantTwoId)),
			new(
				new(_currentUserId)));
	}
}
