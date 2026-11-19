using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMockAssertions
{
	extension(IRefreshTokenCommandService refreshTokenService)
	{
		public async Task ShouldHaveReceivedOneIssueAsync(
		IssueRefreshTokenCommandRequest request,
		CancellationToken cancellationToken)
		{
			await refreshTokenService.ShouldHaveReceivedOneIssueAsync(request.IsIssueRefreshTokenCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIssueAsync(
			IssueRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await refreshTokenService.ShouldHaveReceivedOne().IssueAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneRotateAsync(
			RotateRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await refreshTokenService.ShouldHaveReceivedOneRotateAsync(request.IsRotateRefreshTokenCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneRotateAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await refreshTokenService.ShouldHaveReceivedOne().RotateAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteCurrentRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await refreshTokenService.ShouldHaveReceivedOneDeleteAsync(request.IsDeleteRefreshTokenCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await refreshTokenService.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
