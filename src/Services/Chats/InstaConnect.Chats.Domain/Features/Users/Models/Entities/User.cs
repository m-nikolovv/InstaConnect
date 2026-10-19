namespace InstaConnect.Chats.Domain.Features.Users.Models.Entities;

public class User : IEntityWithId<UserId>
{
	private User()
	{
		Id = new(string.Empty);
		FirstName = string.Empty;
		LastName = string.Empty;
		Email = new(string.Empty);
		Name = new(string.Empty);
		Chats = [];
		ChatMessages = [];
	}

	public User(
		UserId id,
		string firstName,
		string lastName,
		Email email,
		Name name,
		Url? profileImageUrl,
		DateTimeOffset createdAtUtc,
		DateTimeOffset updatedAtUtc)
	{
		Id = id;
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		Name = name;
		ProfileImageUrl = profileImageUrl;
		Chats = [];
		ChatMessages = [];
		CreatedAtUtc = createdAtUtc;
		UpdatedAtUtc = updatedAtUtc;
	}

	public UserId Id { get; }

	public string FirstName { get; private set; }

	public string LastName { get; private set; }

	public Email Email { get; private set; }

	public Name Name { get; private set; }

	public Url? ProfileImageUrl { get; private set; }

	public ICollection<Chat> Chats { get; private set; }

	public ICollection<ChatMessage> ChatMessages { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public DateTimeOffset UpdatedAtUtc { get; private set; }

	public void Update(
		Email email,
		string firstName,
		string lastName,
		Name name,
		Url? profileImageUrl,
		DateTimeOffset updatedAtUtc)
	{
		Email = email;
		FirstName = firstName;
		LastName = lastName;
		Name = name;
		ProfileImageUrl = profileImageUrl;
		UpdatedAtUtc = updatedAtUtc;
	}

	public User AddChat(Chat chat)
	{
		Chats.Add(chat);

		return this;
	}

	public User AddChats(ICollection<Chat> chats)
	{
		Chats.AddRange(chats);

		return this;
	}

	public User AddChatMessage(ChatMessage chatMessage)
	{
		ChatMessages.Add(chatMessage);

		return this;
	}

	public User AddChatMessages(ICollection<ChatMessage> chatMessages)
	{
		ChatMessages.AddRange(chatMessages);

		return this;
	}
}


