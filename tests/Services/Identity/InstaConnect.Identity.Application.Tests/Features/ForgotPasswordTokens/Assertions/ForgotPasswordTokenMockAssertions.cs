using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMockAssertions
{
	extension(IForgotPasswordTokenCommandService forgotPasswordTokenService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddForgotPasswordTokenCommandRequest request,
		CancellationToken cancellationToken)
		{
			await forgotPasswordTokenService.ShouldHaveReceivedOneAddAsync(request.IsAddForgotPasswordTokenCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await forgotPasswordTokenService.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneVerifyAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await forgotPasswordTokenService.ShouldHaveReceivedOneVerifyAsync(request.IsVerifyForgotPasswordTokenCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneVerifyAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await forgotPasswordTokenService.ShouldHaveReceivedOne().VerifyAsync(command, cancellationToken);
		}
	}
}
