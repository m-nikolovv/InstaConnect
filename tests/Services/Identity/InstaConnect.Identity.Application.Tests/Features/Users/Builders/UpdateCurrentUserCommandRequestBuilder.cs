using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class UpdateCurrentUserCommandRequestBuilder
{
	private string _id;
	private string _name;
	private string _firstName;
	private string _lastName;
	private string _email;
	private IFormFile? _profileImage;

	public UpdateCurrentUserCommandRequestBuilder(User user)
	{
		_id = user.Id.Id;
		_name = UserDataFaker.GetName();
		_firstName = UserDataFaker.GetFirstName();
		_lastName = UserDataFaker.GetLastName();
		_email = UserDataFaker.GetEmail();
		_profileImage = UserDataFaker.GetProfileImage();
	}

	public UpdateCurrentUserCommandRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public UpdateCurrentUserCommandRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public UpdateCurrentUserCommandRequestBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public UpdateCurrentUserCommandRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public UpdateCurrentUserCommandRequestBuilder WithFirstName(IStringTransformer transformer)
	{
		_firstName = transformer.Transform(_firstName);

		return this;
	}

	public UpdateCurrentUserCommandRequestBuilder WithLastName(IStringTransformer transformer)
	{
		_lastName = transformer.Transform(_lastName);

		return this;
	}

	public UpdateCurrentUserCommandRequestBuilder WithEmail(Email email, IStringTransformer? transformer = null)
	{
		_email = transformer.TryTransform(email.Value);

		return this;
	}

	public UpdateCurrentUserCommandRequestBuilder WithEmail(IStringTransformer transformer)
	{
		_email = transformer.Transform(_email);

		return this;
	}

	public UpdateCurrentUserCommandRequestBuilder WithProfileImage(IFormFileTransformer transformer)
	{
		_profileImage = transformer.Transform(_profileImage);

		return this;
	}

	public UpdateCurrentUserCommandRequest Build()
	{
		return new(_id, _email, _firstName, _lastName, _name, _profileImage);
	}
}
