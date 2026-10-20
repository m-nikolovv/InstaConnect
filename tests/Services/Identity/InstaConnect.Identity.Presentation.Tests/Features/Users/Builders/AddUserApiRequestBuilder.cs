using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class AddUserApiRequestBuilder
{
	private string _name;
	private string _firstName;
	private string _lastName;
	private string _email;
	private string _password;
	private string _confirmPassword;
	private IFormFile? _profileImage;

	public AddUserApiRequestBuilder()
	{
		_name = UserDataFaker.GetName();
		_firstName = UserDataFaker.GetFirstName();
		_lastName = UserDataFaker.GetLastName();
		_email = UserDataFaker.GetEmail();
		_password = UserDataFaker.GetPassword();
		_confirmPassword = _password;
		_profileImage = UserDataFaker.GetProfileImage();
	}

	public AddUserApiRequestBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public AddUserApiRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public AddUserApiRequestBuilder WithFirstName(IStringTransformer transformer)
	{
		_firstName = transformer.Transform(_firstName);

		return this;
	}

	public AddUserApiRequestBuilder WithLastName(IStringTransformer transformer)
	{
		_lastName = transformer.Transform(_lastName);

		return this;
	}

	public AddUserApiRequestBuilder WithEmail(Email email, IStringTransformer? transformer = null)
	{
		_email = transformer.TryTransform(email.Value);

		return this;
	}

	public AddUserApiRequestBuilder WithEmail(IStringTransformer transformer)
	{
		_email = transformer.Transform(_email);

		return this;
	}

	public AddUserApiRequestBuilder WithPassword(IStringTransformer transformer)
	{
		_password = transformer.Transform(_password);
		_confirmPassword = _password;

		return this;
	}

	public AddUserApiRequestBuilder WithConfirmPassword(IStringTransformer transformer)
	{
		_confirmPassword = transformer.Transform(_confirmPassword);

		return this;
	}

	public AddUserApiRequestBuilder WithProfileImage(IFormFileTransformer transformer)
	{
		_profileImage = transformer.Transform(_profileImage!);

		return this;
	}

	public AddUserApiRequest Build()
	{
		return new(new(_name, _email, _password, _confirmPassword, _firstName, _lastName, _profileImage));
	}
}
