namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Builders;

public class GetChatByIdApiRequestBuilder
{
	private string _participantTwoId;
	private string _currentUserId;

	public GetChatByIdApiRequestBuilder(Chat chat, UserId currentUserId)
	{
		_participantTwoId = chat.Id.ParticipantTwoId.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetChatByIdApiRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public GetChatByIdApiRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public GetChatByIdApiRequestBuilder WithCurrentUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetChatByIdApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetChatByIdApiRequest Build()
	{
		return new(_participantTwoId, _currentUserId);
	}
}
