namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Builders;

public class GetChatMessageByIdApiRequestBuilder
{
	private string _participantTwoId;
	private string _messageId;
	private string _currentUserId;

	public GetChatMessageByIdApiRequestBuilder(ChatMessage chatMessage, UserId currentUserId)
	{
		_participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
		_messageId = chatMessage.Id.MessageId;
		_currentUserId = currentUserId.Id;
	}

	public GetChatMessageByIdApiRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public GetChatMessageByIdApiRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public GetChatMessageByIdApiRequestBuilder WithMessageId(ChatMessageId messageId, IStringTransformer? transformer = null)
	{
		_messageId = transformer.TryTransform(messageId.MessageId);

		return this;
	}

	public GetChatMessageByIdApiRequestBuilder WithMessageId(IStringTransformer transformer)
	{
		_messageId = transformer.Transform(_messageId);

		return this;
	}

	public GetChatMessageByIdApiRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetChatMessageByIdApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetChatMessageByIdApiRequest Build()
	{
		return new(_participantTwoId, _messageId, _currentUserId);
	}
}
