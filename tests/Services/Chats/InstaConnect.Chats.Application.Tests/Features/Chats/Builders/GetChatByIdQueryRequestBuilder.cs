namespace InstaConnect.Chats.Application.Tests.Features.Chats.Builders;

public class GetChatByIdQueryRequestBuilder
{
	private string _participantTwoId;
	private string _currentUserId;

	public GetChatByIdQueryRequestBuilder(Chat chat, UserId currentUserId)
	{
		_participantTwoId = chat.Id.ParticipantTwoId.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetChatByIdQueryRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public GetChatByIdQueryRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public GetChatByIdQueryRequestBuilder WithCurrentUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetChatByIdQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetChatByIdQueryRequest Build()
	{
		return new(_participantTwoId, _currentUserId);
	}
}
