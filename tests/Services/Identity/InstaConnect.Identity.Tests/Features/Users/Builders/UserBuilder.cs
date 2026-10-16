using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.Users.Builders;

public class UserBuilder
{
	private string _id;
	private readonly string _name;
	private readonly string _firstName;
	private readonly string _lastName;
	private readonly string _email;
	private bool _isEmailConfirmed;
	private string _passwordHash;
	private readonly string _profileImage;
	private readonly DateTimeOffset _createdAtUtc;
	private readonly DateTimeOffset _updatedAtUtc;

	public UserBuilder(string passwordHash)
	{
		_id = UserDataFaker.GetId();
		_name = UserDataFaker.GetName();
		_firstName = UserDataFaker.GetFirstName();
		_lastName = UserDataFaker.GetLastName();
		_email = UserDataFaker.GetEmail();
		_isEmailConfirmed = UserDataFaker.GetIsEmailConfirmed();
		_passwordHash = passwordHash;
		_profileImage = UserDataFaker.GetProfileImageUrl();
		_createdAtUtc = UserDataFaker.GetCreatedAtUtc();
		_updatedAtUtc = _createdAtUtc;
	}

	public UserBuilder WithId(UserId id)
	{
		_id = id.Id;

		return this;
	}

	public UserBuilder WithPasswordHash(string passwordHash)
	{
		_passwordHash = passwordHash;

		return this;
	}

	public UserBuilder WithConfirmedEmail()
	{
		_isEmailConfirmed = true;

		return this;
	}

	public UserBuilder WithUnconfirmedEmail()
	{
		_isEmailConfirmed = false;

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
			_passwordHash,
			_isEmailConfirmed,
			new(_profileImage),
			_createdAtUtc,
			_updatedAtUtc);
	}
}
