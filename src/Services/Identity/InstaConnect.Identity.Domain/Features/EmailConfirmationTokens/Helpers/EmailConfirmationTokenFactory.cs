using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

internal class EmailConfirmationTokenFactory : IEmailConfirmationTokenFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly EmailConfirmationTokenOptions _emailConfirmationTokenOptions;

	public EmailConfirmationTokenFactory(
		IGuidProvider guidProvider,
		IDateTimeProvider dateTimeProvider,
		IOptions<EmailConfirmationTokenOptions> emailConfirmationTokenOptions)
	{
		_guidProvider = guidProvider;
		_dateTimeProvider = dateTimeProvider;
		_emailConfirmationTokenOptions = emailConfirmationTokenOptions.Value;
	}

	public EmailConfirmationToken Create(UserId id)
	{
		var value = _guidProvider.NewStringGuid();
		var expiresAt = _dateTimeProvider.GetOffsetUtcNow(_emailConfirmationTokenOptions.LifetimeSeconds);
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var emailConfirmationToken = new EmailConfirmationToken(
			new(id, value),
			expiresAt,
			utcNow);

		return emailConfirmationToken;
	}
}
