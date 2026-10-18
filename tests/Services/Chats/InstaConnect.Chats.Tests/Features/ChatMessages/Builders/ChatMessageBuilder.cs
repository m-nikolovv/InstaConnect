using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Builders;

public class ChatMessageBuilder
{
	private readonly string _participantOneId;
	private readonly string _participantTwoId;
	private readonly Chat _chat;
	private string _messageId;
	private string _senderId;
	private readonly User _sender;
	private readonly string _content;
	private readonly string _summary;
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
		_createdAtUtc = ChatMessageDataFaker.GetCreatedAtUtc();
		_updatedAtUtc = _createdAtUtc;
	}

	public ChatMessageBuilder WithSenderId(UserId senderId)
	{
		_senderId = senderId.Id;

		return this;
	}

	public ChatMessageBuilder WithMessageId(ChatMessageId messageId)
	{
		_messageId = messageId.MessageId;

		return this;
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

		_chat.AddChatMessage(chatMessage);
		_sender.AddChatMessage(chatMessage);
		chatMessage.AddChat(_chat);
		chatMessage.AddSender(_sender);

		return chatMessage;
	}
}
