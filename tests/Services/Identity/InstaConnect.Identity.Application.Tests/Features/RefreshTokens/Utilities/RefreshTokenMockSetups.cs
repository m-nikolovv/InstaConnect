using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockSetups
{
	extension(IRefreshTokenCommandService service)
	{
		public void SetupIssueAsync(
			IssueRefreshTokenCommandRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			service.SetupIssueAsync(request.IsIssueRefreshTokenCommand(), refreshToken.ToResponse(request), cancellationToken);
		}

		public void SetupRotateAsync(
			RotateRefreshTokenCommandRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			service.SetupRotateAsync(request.IsRotateRefreshTokenCommand(), refreshToken.ToResponse(request), cancellationToken);
		}
	}
}
