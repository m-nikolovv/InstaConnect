using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Posts.Domain.Tests.Features.Users.Builders;

public class AddUserCommandBuilder
{
	private string _id;
	private string _name;
	private string _firstName;
	private string _lastName;
	private string _email;
	private string? _profileImage;
	private DateTimeOffset _createdAtUtc;
	private DateTimeOffset _updatedAtUtc;

	public AddUserCommandBuilder()
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

	public AddUserCommandBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AddUserCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public AddUserCommandBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public AddUserCommandBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public AddUserCommandBuilder WithFirstName(IStringTransformer transformer)
	{
		_firstName = transformer.Transform(_firstName);

		return this;
	}

	public AddUserCommandBuilder WithLastName(IStringTransformer transformer)
	{
		_lastName = transformer.Transform(_lastName);

		return this;
	}

	public AddUserCommandBuilder WithEmail(Email email, IStringTransformer? transformer = null)
	{
		_email = transformer.TryTransform(email.Value);

		return this;
	}

	public AddUserCommandBuilder WithEmail(IStringTransformer transformer)
	{
		_email = transformer.Transform(_email);

		return this;
	}

	public AddUserCommandBuilder WithProfileImage(IStringTransformer transformer)
	{
		_profileImage = transformer.Transform(_profileImage ?? string.Empty);

		return this;
	}

	public AddUserCommandBuilder WithCreatedAtUtc(IDateTimeOffsetTransformer transformer)
	{
		_createdAtUtc = transformer.Transform(_createdAtUtc);

		return this;
	}

	public AddUserCommandBuilder WithUpdatedAtUtc(IDateTimeOffsetTransformer transformer)
	{
		_updatedAtUtc = transformer.Transform(_updatedAtUtc);

		return this;
	}

	public AddUserCommand Build()
	{
		return new(
			new(_id),
			_firstName,
			_lastName,
			new(_name),
			new(_email),
			_profileImage == null ? null : new(_profileImage),
			_createdAtUtc,
			_updatedAtUtc);
	}
}
