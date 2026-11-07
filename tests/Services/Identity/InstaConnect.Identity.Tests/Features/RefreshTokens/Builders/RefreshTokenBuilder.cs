using InstaConnect.Common.Tests.Features.DataAttributes.Base;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;

public class RefreshTokenBuilder
{
	private string _id;
	private readonly User _user;
	private string _value;
	private DateTimeOffset _expiresAtUtc;
	private readonly DateTimeOffset _createdAtUtc;

	public RefreshTokenBuilder(User user)
	{
		_id = user.Id.Id;
		_user = user;
		_value = RefreshTokenDataFaker.GetValue();
		_expiresAtUtc = RefreshTokenDataFaker.GetExpiresAtUtc();
		_createdAtUtc = RefreshTokenDataFaker.GetCreatedAtUtc();
	}

	public RefreshTokenBuilder(RefreshToken refreshToken)
	{
		_id = refreshToken.Id.Id.Id;
		_user = refreshToken.User!;
		_value = refreshToken.Id.Value;
		_expiresAtUtc = refreshToken.ExpiresAtUtc;
		_createdAtUtc = refreshToken.CreatedAtUtc;
	}

	public RefreshTokenBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public RefreshTokenBuilder WithValue(RefreshTokenId value, IStringTransformer? transformer = null)
	{
		_value = transformer.TryTransform(value.Value);

		return this;
	}

	public RefreshTokenBuilder WithValue(IStringTransformer transformer)
	{
		_value = transformer.Transform(_value);

		return this;
	}

	public RefreshTokenBuilder WithAlreadyExpiresAtUtc()
	{
		_expiresAtUtc = DataFaker.GetPastDate(_expiresAtUtc);

		return this;
	}

	public RefreshToken BuildAttached()
	{
		var refreshToken = Build();

		_user.AddRefreshToken(refreshToken);

		return refreshToken;
	}

	public RefreshToken Build()
	{
		var refreshToken = new RefreshToken(
			new(
				new(_id),
				_value),
			_expiresAtUtc,
			_createdAtUtc);

		refreshToken.AddUser(_user);

		return refreshToken;
	}
}
