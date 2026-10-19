using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;

public class ForgotPasswordTokenBuilder
{
	private readonly string _id;
	private readonly User _user;
	private string _value;
	private DateTimeOffset _expiresAtUtc;
	private readonly DateTimeOffset _createdAtUtc;

	public ForgotPasswordTokenBuilder(User user)
	{
		_id = user.Id.Id;
		_user = user;
		_value = ForgotPasswordTokenDataFaker.GetValue();
		_expiresAtUtc = ForgotPasswordTokenDataFaker.GetExpiresAtUtc();
		_createdAtUtc = ForgotPasswordTokenDataFaker.GetCreatedAtUtc();
	}

	public ForgotPasswordTokenBuilder(ForgotPasswordToken forgotPasswordToken)
	{
		_id = forgotPasswordToken.Id.Id.Id;
		_user = forgotPasswordToken.User!;
		_value = forgotPasswordToken.Id.Value;
		_expiresAtUtc = forgotPasswordToken.ExpiresAtUtc;
		_createdAtUtc = forgotPasswordToken.CreatedAtUtc;
	}

	public ForgotPasswordTokenBuilder WithValue(ForgotPasswordTokenId value)
	{
		_value = value.Value;

		return this;
	}

	public ForgotPasswordTokenBuilder WithAlreadyExpiresAtUtc()
	{
		_expiresAtUtc = DataFaker.GetPastDate(_expiresAtUtc);

		return this;
	}

	public ForgotPasswordToken Build()
	{
		var forgotPasswordToken = new ForgotPasswordToken(
			new(
				new(_id),
				_value),
			_expiresAtUtc,
			_createdAtUtc);

		forgotPasswordToken.AddUser(_user);
		_user.AddForgotPasswordToken(forgotPasswordToken);

		return forgotPasswordToken;
	}
}
