using InstaConnect.Follows.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Follows.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Tests.Features.Users.Builders;

public class UserBuilder
{
	private string _id;
	private readonly string _name;
	private readonly string _firstName;
	private readonly string _lastName;
	private readonly string _email;
	private readonly string _profileImage;
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
		_createdAtUtc = UserDataFaker.GetCreatedAtUtc();
		_updatedAtUtc = _createdAtUtc;
	}

	public UserBuilder WithId(UserId id)
	{
		_id = id.Id;

		return this;
	}

	public User Build()
	{
		return new(
			new(_id),
			_firstName,
			_lastName,
			new(_email),
			new(_name),
			new(_profileImage),
			_createdAtUtc,
			_updatedAtUtc);
	}
}
