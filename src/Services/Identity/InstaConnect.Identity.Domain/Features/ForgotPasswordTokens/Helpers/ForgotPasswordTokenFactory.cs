using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

internal class ForgotPasswordTokenFactory : IForgotPasswordTokenFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly ForgotPasswordTokenOptions _forgotPasswordTokenOptions;

	public ForgotPasswordTokenFactory(
		IGuidProvider guidProvider,
		IDateTimeProvider dateTimeProvider,
		IOptions<ForgotPasswordTokenOptions> forgotPasswordTokenOptions)
	{
		_guidProvider = guidProvider;
		_dateTimeProvider = dateTimeProvider;
		_forgotPasswordTokenOptions = forgotPasswordTokenOptions.Value;
	}

	public ForgotPasswordToken Create(UserId id)
	{
		var value = _guidProvider.NewStringGuid();
		var expiresAt = _dateTimeProvider.GetOffsetUtcNow(_forgotPasswordTokenOptions.LifetimeSeconds);
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var forgotPasswordToken = new ForgotPasswordToken(
			new(id, value),
			expiresAt,
			utcNow);

		return forgotPasswordToken;
	}
}
