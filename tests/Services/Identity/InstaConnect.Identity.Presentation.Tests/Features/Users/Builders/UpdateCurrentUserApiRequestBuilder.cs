using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class UpdateCurrentUserApiRequestBuilder
{
	private string _id;
	private string _name;
	private string _firstName;
	private string _lastName;
	private string _email;
	private IFormFile? _profileImage;

	public UpdateCurrentUserApiRequestBuilder(User user)
	{
		_id = user.Id.Id;
		_name = UserDataFaker.GetName();
		_firstName = UserDataFaker.GetFirstName();
		_lastName = UserDataFaker.GetLastName();
		_email = UserDataFaker.GetEmail();
		_profileImage = UserDataFaker.GetProfileImage();
	}

	public UpdateCurrentUserApiRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public UpdateCurrentUserApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public UpdateCurrentUserApiRequestBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public UpdateCurrentUserApiRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public UpdateCurrentUserApiRequestBuilder WithFirstName(IStringTransformer transformer)
	{
		_firstName = transformer.Transform(_firstName);

		return this;
	}

	public UpdateCurrentUserApiRequestBuilder WithLastName(IStringTransformer transformer)
	{
		_lastName = transformer.Transform(_lastName);

		return this;
	}

	public UpdateCurrentUserApiRequestBuilder WithEmail(Email email, IStringTransformer? transformer = null)
	{
		_email = transformer.TryTransform(email.Value);

		return this;
	}

	public UpdateCurrentUserApiRequestBuilder WithEmail(IStringTransformer transformer)
	{
		_email = transformer.Transform(_email);

		return this;
	}

	public UpdateCurrentUserApiRequestBuilder WithProfileImage(IFormFileTransformer transformer)
	{
		_profileImage = transformer.Transform(_profileImage);

		return this;
	}

	public UpdateCurrentUserApiRequest Build()
	{
		return new(_id, new(_name, _firstName, _lastName, _email, _profileImage));
	}
}
