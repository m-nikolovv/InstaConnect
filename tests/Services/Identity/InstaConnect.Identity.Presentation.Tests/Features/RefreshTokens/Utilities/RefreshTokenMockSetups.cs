using InstaConnect.Common.Application.Tests.Features.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
			IssueRefreshTokenApiRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsIssueRefreshTokenCommandRequest(), refreshToken.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			RotateRefreshTokenApiRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsRotateRefreshTokenCommandRequest(), refreshToken.ToResponse(request), cancellationToken);
		}
	}
}
