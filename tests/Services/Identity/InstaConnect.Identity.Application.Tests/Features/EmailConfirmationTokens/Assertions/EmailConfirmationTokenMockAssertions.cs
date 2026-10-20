using InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMockAssertions
{
	extension(IEmailConfirmationTokenCommandService emailConfirmationTokenService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddEmailConfirmationTokenCommandRequest request,
		CancellationToken cancellationToken)
		{
			await emailConfirmationTokenService.ShouldHaveReceivedOneAddAsync(request.IsAddEmailConfirmationTokenCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneVerifyAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await emailConfirmationTokenService.ShouldHaveReceivedOneVerifyAsync(request.IsVerifyEmailConfirmationTokenCommand(), cancellationToken);
		}
	}
}
