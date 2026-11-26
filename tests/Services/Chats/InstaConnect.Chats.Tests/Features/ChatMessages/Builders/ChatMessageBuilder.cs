using InstaConnect.Common.Tests.Features.DataAttributes.Base;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Builders;

public class ChatMessageBuilder
{
	private string _participantOneId;
	private string _participantTwoId;
	private readonly Chat _chat;
	private string _messageId;
	private string _senderId;
	private User _sender;
	private readonly string _content;
	private readonly string _summary;
	private readonly ICollection<ChatMessageImage> _chatMessageImages;
	private readonly DateTimeOffset _createdAtUtc;
	private readonly DateTimeOffset _updatedAtUtc;

	public ChatMessageBuilder(Chat chat)
	{
		_participantOneId = chat.Id.ParticipantOneId.Id;
		_participantTwoId = chat.Id.ParticipantTwoId.Id;
		_chat = chat;
		_messageId = ChatMessageDataFaker.GetId();
		_senderId = chat.Id.ParticipantOneId.Id;
		_sender = chat.ParticipantOne!;
		_content = ChatMessageDataFaker.GetContent();
		_summary = ChatMessageDataFaker.GetSummary();
		_chatMessageImages = [];
		_createdAtUtc = ChatMessageDataFaker.GetCreatedAtUtc();
		_updatedAtUtc = _createdAtUtc;
	}

	public ChatMessageBuilder(ChatMessage chatMessage)
	{
		_participantOneId = chatMessage.Id.Id.ParticipantOneId.Id;
		_participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
		_chat = chatMessage.Chat!;
		_messageId = chatMessage.Id.MessageId;
		_senderId = chatMessage.SenderId.Id;
		_sender = chatMessage.Sender!;
		_content = chatMessage.Content;
		_summary = chatMessage.Summary.Value;
		_chatMessageImages = [.. chatMessage.ChatMessageImages];
		_createdAtUtc = chatMessage.CreatedAtUtc;
		_updatedAtUtc = chatMessage.UpdatedAtUtc;
	}

	public ChatMessageBuilder WithSender(User sender)
	{
		_senderId = sender.Id.Id;
		_sender = sender;

		return this;
	}

	public ChatMessageBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public ChatMessageBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public ChatMessageBuilder WithMessageId(ChatMessageId messageId, IStringTransformer? transformer = null)
	{
		_messageId = transformer.TryTransform(messageId.MessageId);

		return this;
	}

	public ChatMessageBuilder WithMessageId(IStringTransformer transformer)
	{
		_messageId = transformer.Transform(_messageId);

		return this;
	}

	public ChatMessage BuildAttached()
	{
		var chatMessage = Build();

		_chat.AddChatMessage(chatMessage);
		_sender.AddChatMessage(chatMessage);

		return chatMessage;
	}

	public ChatMessage Build()
	{
		var chatMessage = new ChatMessage(
				new(
					new(
						new(_participantOneId),
						new(_participantTwoId)),
					_messageId),
				new(_senderId),
				_content,
				new(_summary),
				_createdAtUtc,
				_updatedAtUtc);

		chatMessage.AddChat(_chat);
		chatMessage.AddSender(_sender);
		chatMessage.AddChatMessageImages(_chatMessageImages);

		return chatMessage;
	}
}
