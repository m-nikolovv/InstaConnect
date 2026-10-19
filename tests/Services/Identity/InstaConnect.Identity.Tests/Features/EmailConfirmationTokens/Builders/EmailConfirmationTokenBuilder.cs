using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;

public class EmailConfirmationTokenBuilder
{
	private readonly string _id;
	private readonly User _user;
	private string _value;
	private DateTimeOffset _expiresAtUtc;
	private readonly DateTimeOffset _createdAtUtc;

	public EmailConfirmationTokenBuilder(User user)
	{
		_id = user.Id.Id;
		_user = user;
		_value = EmailConfirmationTokenDataFaker.GetValue();
		_expiresAtUtc = EmailConfirmationTokenDataFaker.GetExpiresAtUtc();
		_createdAtUtc = EmailConfirmationTokenDataFaker.GetCreatedAtUtc();
	}

	public EmailConfirmationTokenBuilder(EmailConfirmationToken emailConfirmationToken)
	{
		_id = emailConfirmationToken.Id.Id.Id;
		_user = emailConfirmationToken.User!;
		_value = emailConfirmationToken.Id.Value;
		_expiresAtUtc = emailConfirmationToken.ExpiresAtUtc;
		_createdAtUtc = emailConfirmationToken.CreatedAtUtc;
	}

	public EmailConfirmationTokenBuilder WithValue(EmailConfirmationTokenId value)
	{
		_value = value.Value;

		return this;
	}

	public EmailConfirmationTokenBuilder WithAlreadyExpiresAtUtc()
	{
		_expiresAtUtc = DataFaker.GetPastDate(_expiresAtUtc);

		return this;
	}

	public EmailConfirmationToken Build()
	{
		var emailConfirmationToken = new EmailConfirmationToken(
			new(
				new(_id),
				_value),
			_expiresAtUtc,
			_createdAtUtc);

		emailConfirmationToken.AddUser(_user);
		_user.AddEmailConfirmationToken(emailConfirmationToken);

		return emailConfirmationToken;
	}
}
