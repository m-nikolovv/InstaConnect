namespace InstaConnect.Chats.Domain.Features.Chats.Models.Entities;

public class Chat : IEntityWithId<ChatId>
{
	private Chat()
	{
		Id = new(new(string.Empty), new(string.Empty));
		ChatMessages = [];
	}

	public Chat(
		ChatId id,
		DateTimeOffset createdAtUtc)
	{
		Id = id;
		ChatMessages = [];
		CreatedAtUtc = createdAtUtc;
	}

	public ChatId Id { get; }

	public User? ParticipantOne { get; private set; }

	public User? ParticipantTwo { get; private set; }

	public ICollection<ChatMessage> ChatMessages { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public Chat AddParticipantOne(User? participantOne)
	{
		ParticipantOne = participantOne;

		return this;
	}

	public Chat AddParticipantTwo(User? participantTwo)
	{
		ParticipantTwo = participantTwo;

		return this;
	}

	public Chat AddChatMessage(ChatMessage chatMessage)
	{
		ChatMessages.Add(chatMessage);

		return this;
	}

	public Chat AddChatMessages(ICollection<ChatMessage> chatMessages)
	{
		ChatMessages.AddRange(chatMessages);

		return this;
	}
}
