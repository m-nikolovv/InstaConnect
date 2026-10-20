using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class AddUserCommandRequestBuilder
{
	private string _name;
	private string _firstName;
	private string _lastName;
	private string _email;
	private string _password;
	private string _confirmPassword;
	private IFormFile? _profileImage;

	public AddUserCommandRequestBuilder()
	{
		_name = UserDataFaker.GetName();
		_firstName = UserDataFaker.GetFirstName();
		_lastName = UserDataFaker.GetLastName();
		_email = UserDataFaker.GetEmail();
		_password = UserDataFaker.GetPassword();
		_confirmPassword = _password;
		_profileImage = UserDataFaker.GetProfileImage();
	}

	public AddUserCommandRequestBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public AddUserCommandRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public AddUserCommandRequestBuilder WithFirstName(IStringTransformer transformer)
	{
		_firstName = transformer.Transform(_firstName);

		return this;
	}

	public AddUserCommandRequestBuilder WithLastName(IStringTransformer transformer)
	{
		_lastName = transformer.Transform(_lastName);

		return this;
	}

	public AddUserCommandRequestBuilder WithEmail(Email email, IStringTransformer? transformer = null)
	{
		_email = transformer.TryTransform(email.Value);

		return this;
	}

	public AddUserCommandRequestBuilder WithEmail(IStringTransformer transformer)
	{
		_email = transformer.Transform(_email);

		return this;
	}

	public AddUserCommandRequestBuilder WithPassword(IStringTransformer transformer)
	{
		_password = transformer.Transform(_password);
		_confirmPassword = _password;

		return this;
	}

	public AddUserCommandRequestBuilder WithConfirmPassword(IStringTransformer transformer)
	{
		_confirmPassword = transformer.Transform(_confirmPassword);

		return this;
	}

	public AddUserCommandRequestBuilder WithProfileImage(IFormFileTransformer transformer)
	{
		_profileImage = transformer.Transform(_profileImage!);

		return this;
	}

	public AddUserCommandRequest Build()
	{
		return new(_name, _email, _password, _confirmPassword, _firstName, _lastName, _profileImage);
	}
}
