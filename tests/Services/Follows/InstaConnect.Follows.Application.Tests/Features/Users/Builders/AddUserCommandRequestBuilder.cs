using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.DateTimeOffsets.Base;

namespace InstaConnect.Follows.Application.Tests.Features.Users.Builders;

public class AddUserCommandRequestBuilder
{
	private string _id;
	private string _name;
	private string _firstName;
	private string _lastName;
	private string _email;
	private string? _profileImage;
	private DateTimeOffset _createdAtUtc;
	private DateTimeOffset _updatedAtUtc;

	public AddUserCommandRequestBuilder()
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

	public AddUserCommandRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AddUserCommandRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
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

	public AddUserCommandRequestBuilder WithProfileImage(IStringTransformer transformer)
	{
		_profileImage = transformer.Transform(_profileImage ?? string.Empty);

		return this;
	}

	public AddUserCommandRequestBuilder WithCreatedAtUtc(IDateTimeOffsetTransformer transformer)
	{
		_createdAtUtc = transformer.Transform(_createdAtUtc);

		return this;
	}

	public AddUserCommandRequestBuilder WithUpdatedAtUtc(IDateTimeOffsetTransformer transformer)
	{
		_updatedAtUtc = transformer.Transform(_updatedAtUtc);

		return this;
	}

	public AddUserCommandRequest Build()
	{
		return new(_id, _firstName, _lastName, _name, _email, _profileImage, _createdAtUtc, _updatedAtUtc);
	}
}
