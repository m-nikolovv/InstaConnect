using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.DeleteCurrent;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenPresentationMatcher
{
	extension(IssueRefreshTokenApiRequest request)
	{
		public SetRefreshTokenCookieApiRequest IsRefreshTokenCookieRequest(RefreshToken refreshToken)
		{
			return Matcher.Is<SetRefreshTokenCookieApiRequest>(p => p.Matches(request, refreshToken));
		}

		public IssueRefreshTokenCommandRequest IsIssueRefreshTokenCommandRequest()
		{
			return Matcher.Is<IssueRefreshTokenCommandRequest>(p => p.Matches(request));
		}
	}

	extension(RotateRefreshTokenApiRequest request)
	{
		public SetRefreshTokenCookieApiRequest IsRefreshTokenCookieRequest(RefreshToken refreshToken)
		{
			return Matcher.Is<SetRefreshTokenCookieApiRequest>(p => p.Matches(request, refreshToken));
		}

		public RotateRefreshTokenCommandRequest IsRotateRefreshTokenCommandRequest()
		{
			return Matcher.Is<RotateRefreshTokenCommandRequest>(p => p.Matches(request));
		}
	}

	extension(DeleteCurrentRefreshTokenApiRequest request)
	{
		public DeleteCurrentRefreshTokenCommandRequest IsDeleteCurrentRefreshTokenCommandRequest()
		{
			return Matcher.Is<DeleteCurrentRefreshTokenCommandRequest>(p => p.Matches(request));
		}
	}
}
