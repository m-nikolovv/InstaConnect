namespace InstaConnect.Chats.Tests.Features.Users.Builders;

public class UserBuilder
{
	private string _id;
	private readonly string _name;
	private readonly string _firstName;
	private readonly string _lastName;
	private readonly string _email;
	private readonly string? _profileImage;
	private readonly ICollection<Chat> _chats;
	private readonly ICollection<ChatMessage> _chatMessages;
	private readonly DateTimeOffset _createdAtUtc;
	private readonly DateTimeOffset _updatedAtUtc;

	public UserBuilder()
	{
		_id = UserDataFaker.GetId();
		_name = UserDataFaker.GetName();
		_firstName = UserDataFaker.GetFirstName();
		_lastName = UserDataFaker.GetLastName();
		_email = UserDataFaker.GetEmail();
		_profileImage = UserDataFaker.GetProfileImage();
		_chats = [];
		_chatMessages = [];
		_createdAtUtc = UserDataFaker.GetCreatedAtUtc();
		_updatedAtUtc = _createdAtUtc;
	}

	public UserBuilder(User user)
	{
		_id = user.Id.Id;
		_name = user.Name.Value;
		_firstName = user.FirstName;
		_lastName = user.LastName;
		_email = user.Email.Value;
		_profileImage = user.ProfileImageUrl?.Value;
		_chats = [.. user.Chats];
		_chatMessages = [.. user.ChatMessages];
		_createdAtUtc = user.CreatedAtUtc;
		_updatedAtUtc = user.UpdatedAtUtc;
	}

	public UserBuilder WithId(UserId id)
	{
		_id = id.Id;

		return this;
	}

	public User Build()
	{
		var user = new User(
			new(_id),
			_firstName,
			_lastName,
			new(_email),
			new(_name),
			_profileImage == null ? null : new(_profileImage),
			_createdAtUtc,
			_updatedAtUtc);

		user.AddChats(_chats);
		user.AddChatMessages(_chatMessages);

		return user;
	}
}
