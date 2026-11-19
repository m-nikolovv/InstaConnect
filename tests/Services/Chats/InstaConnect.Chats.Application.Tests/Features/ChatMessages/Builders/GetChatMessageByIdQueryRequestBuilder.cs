namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Builders;

public class GetChatMessageByIdQueryRequestBuilder
{
	private string _participantTwoId;
	private string _messageId;
	private string _currentUserId;

	public GetChatMessageByIdQueryRequestBuilder(ChatMessage chatMessage, UserId currentUserId)
	{
		_participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
		_messageId = chatMessage.Id.MessageId;
		_currentUserId = currentUserId.Id;
	}

	public GetChatMessageByIdQueryRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public GetChatMessageByIdQueryRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public GetChatMessageByIdQueryRequestBuilder WithMessageId(ChatMessageId messageId, IStringTransformer? transformer = null)
	{
		_messageId = transformer.TryTransform(messageId.MessageId);

		return this;
	}

	public GetChatMessageByIdQueryRequestBuilder WithMessageId(IStringTransformer transformer)
	{
		_messageId = transformer.Transform(_messageId);

		return this;
	}

	public GetChatMessageByIdQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetChatMessageByIdQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetChatMessageByIdQueryRequest Build()
	{
		return new(_participantTwoId, _messageId, _currentUserId);
	}
}
