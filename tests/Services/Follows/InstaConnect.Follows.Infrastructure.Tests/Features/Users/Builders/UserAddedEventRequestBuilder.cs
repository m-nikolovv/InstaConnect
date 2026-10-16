using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Builders;

public class UserAddedEventRequestBuilder
{
	private string _id;
	private string _name;
	private string _firstName;
	private string _lastName;
	private string _email;
	private string? _profileImage;
	private DateTimeOffset _createdAtUtc;
	private DateTimeOffset _updatedAtUtc;

	public UserAddedEventRequestBuilder(User user)
	{
		_id = user.Id.Id;
		_name = user.Name.Value;
		_firstName = user.FirstName;
		_lastName = user.LastName;
		_email = user.Email.Value;
		_profileImage = user.ProfileImageUrl?.Value;
		_createdAtUtc = user.CreatedAtUtc;
		_updatedAtUtc = user.UpdatedAtUtc;
	}

	public UserAddedEventRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public UserAddedEventRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public UserAddedEventRequestBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public UserAddedEventRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public UserAddedEventRequestBuilder WithFirstName(IStringTransformer transformer)
	{
		_firstName = transformer.Transform(_firstName);

		return this;
	}

	public UserAddedEventRequestBuilder WithLastName(IStringTransformer transformer)
	{
		_lastName = transformer.Transform(_lastName);

		return this;
	}

	public UserAddedEventRequestBuilder WithEmail(Email email, IStringTransformer? transformer = null)
	{
		_email = transformer.TryTransform(email.Value);

		return this;
	}

	public UserAddedEventRequestBuilder WithEmail(IStringTransformer transformer)
	{
		_email = transformer.Transform(_email);

		return this;
	}

	public UserAddedEventRequestBuilder WithProfileImage(IStringTransformer transformer)
	{
		_profileImage = transformer.Transform(_profileImage ?? string.Empty);

		return this;
	}

	public UserAddedEventRequestBuilder WithCreatedAtUtc(IDateTimeOffsetTransformer transformer)
	{
		_createdAtUtc = transformer.Transform(_createdAtUtc);

		return this;
	}

	public UserAddedEventRequestBuilder WithUpdatedAtUtc(IDateTimeOffsetTransformer transformer)
	{
		_updatedAtUtc = transformer.Transform(_updatedAtUtc);

		return this;
	}

	public UserAddedEventRequest Build()
	{
		return new(new(_id, _name, _email, _firstName, _lastName, _profileImage, _createdAtUtc, _updatedAtUtc));
	}
}
