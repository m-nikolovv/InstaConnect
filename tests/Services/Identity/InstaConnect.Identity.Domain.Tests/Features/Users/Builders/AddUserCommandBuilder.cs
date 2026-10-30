using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Builders;

public class AddUserCommandBuilder
{
	private string _name;
	private string _firstName;
	private string _lastName;
	private string _email;
	private readonly string _password;
	private readonly string _confirmPassword;
	private IFormFile? _profileImage;

	public AddUserCommandBuilder()
	{
		_name = UserDataFaker.GetName();
		_firstName = UserDataFaker.GetFirstName();
		_lastName = UserDataFaker.GetLastName();
		_email = UserDataFaker.GetEmail();
		_password = UserDataFaker.GetPassword();
		_confirmPassword = _password;
		_profileImage = UserDataFaker.GetProfileImage();
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

	public AddUserCommandBuilder WithProfileImage(IFormFileTransformer transformer)
	{
		_profileImage = transformer.Transform(_profileImage);

		return this;
	}

	public AddUserCommand Build()
	{
		return new(
			new(_name),
			new(_email),
			_password,
			_confirmPassword,
			_firstName,
			_lastName,
			_profileImage);
	}
}
