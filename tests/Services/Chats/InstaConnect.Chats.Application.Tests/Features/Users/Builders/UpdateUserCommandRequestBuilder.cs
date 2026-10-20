using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.DateTimeOffsets.Base;

namespace InstaConnect.Chats.Application.Tests.Features.Users.Builders;

public class UpdateUserCommandRequestBuilder
{
	private string _id;
	private string _name;
	private string _firstName;
	private string _lastName;
	private string _email;
	private string? _profileImage;
	private DateTimeOffset _updatedAtUtc;

	public UpdateUserCommandRequestBuilder(User user)
	{
		_id = user.Id.Id;
		_name = UserDataFaker.GetName();
		_firstName = UserDataFaker.GetFirstName();
		_lastName = UserDataFaker.GetLastName();
		_email = UserDataFaker.GetEmail();
		_profileImage = UserDataFaker.GetProfileImage();
		_updatedAtUtc = UserDataFaker.GetUpdatedAtUtc();
	}

	public UpdateUserCommandRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public UpdateUserCommandRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public UpdateUserCommandRequestBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public UpdateUserCommandRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public UpdateUserCommandRequestBuilder WithFirstName(IStringTransformer transformer)
	{
		_firstName = transformer.Transform(_firstName);

		return this;
	}

	public UpdateUserCommandRequestBuilder WithLastName(IStringTransformer transformer)
	{
		_lastName = transformer.Transform(_lastName);

		return this;
	}

	public UpdateUserCommandRequestBuilder WithEmail(Email email, IStringTransformer? transformer = null)
	{
		_email = transformer.TryTransform(email.Value);

		return this;
	}

	public UpdateUserCommandRequestBuilder WithEmail(IStringTransformer transformer)
	{
		_email = transformer.Transform(_email);

		return this;
	}

	public UpdateUserCommandRequestBuilder WithProfileImage(IStringTransformer transformer)
	{
		_profileImage = transformer.Transform(_profileImage!);

		return this;
	}

	public UpdateUserCommandRequestBuilder WithUpdatedAtUtc(IDateTimeOffsetTransformer transformer)
	{
		_updatedAtUtc = transformer.Transform(_updatedAtUtc);

		return this;
	}

	public UpdateUserCommandRequest Build()
	{
		return new(_id, _firstName, _lastName, _name, _email, _profileImage, _updatedAtUtc);
	}
}
