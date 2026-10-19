using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;

public class RefreshTokenBuilder
{
	private readonly string _id;
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

	public RefreshTokenBuilder WithValue(RefreshTokenId value)
	{
		_value = value.Value;

		return this;
	}

	public RefreshTokenBuilder WithAlreadyExpiresAtUtc()
	{
		_expiresAtUtc = DataFaker.GetPastDate(_expiresAtUtc);

		return this;
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
		_user.AddRefreshToken(refreshToken);

		return refreshToken;
	}
}
