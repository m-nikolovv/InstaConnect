using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Tests.Features.Chats.Builders;

public class ChatBuilder
{
	private string _participantOneId;
	private string _participantTwoId;
	private User _participantOne;
	private User _participantTwo;
	private readonly ICollection<ChatMessage> _chatMessages;
	private readonly DateTimeOffset _createdAtUtc;

	public ChatBuilder(User participantOne, User participantTwo)
	{
		_participantOneId = participantOne.Id.Id;
		_participantTwoId = participantTwo.Id.Id;
		_participantOne = participantOne;
		_participantTwo = participantTwo;
		_chatMessages = [];
		_createdAtUtc = ChatDataFaker.GetCreatedAtUtc();
	}

	public ChatBuilder(Chat chat)
	{
		_participantOneId = chat.Id.ParticipantOneId.Id;
		_participantTwoId = chat.Id.ParticipantTwoId.Id;
		_participantOne = chat.ParticipantOne!;
		_participantTwo = chat.ParticipantTwo!;
		_chatMessages = [.. chat.ChatMessages];
		_createdAtUtc = chat.CreatedAtUtc;
	}

	public ChatBuilder WithParticipantOne(User participantOne)
	{
		_participantOneId = participantOne.Id.Id;
		_participantOne = participantOne;

		return this;
	}

	public ChatBuilder WithParticipantTwo(User participantTwo)
	{
		_participantTwoId = participantTwo.Id.Id;
		_participantTwo = participantTwo;

		return this;
	}

	public Chat Build()
	{
		var chat = new Chat(
				new(
					new(_participantOneId),
					new(_participantTwoId)),
				_createdAtUtc);

		chat.AddParticipantOne(_participantOne);
		chat.AddParticipantTwo(_participantTwo);
		_participantOne.AddChat(chat);
		_participantTwo.AddChat(chat);
		chat.AddChatMessages(_chatMessages);

		return chat;
	}
}
