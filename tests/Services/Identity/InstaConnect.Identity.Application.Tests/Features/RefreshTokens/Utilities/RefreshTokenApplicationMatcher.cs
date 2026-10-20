using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenApplicationMatcher
{
	extension(IssueRefreshTokenCommandRequest request)
	{
		public IssueRefreshTokenCommand IsIssueRefreshTokenCommand()
		{
			return Matcher.Is<IssueRefreshTokenCommand>(p => p.Matches(request));
		}
	}

	extension(RotateRefreshTokenCommandRequest request)
	{
		public RotateRefreshTokenCommand IsRotateRefreshTokenCommand()
		{
			return Matcher.Is<RotateRefreshTokenCommand>(p => p.Matches(request));
		}
	}

	extension(DeleteCurrentRefreshTokenCommandRequest request)
	{
		public DeleteRefreshTokenCommand IsDeleteRefreshTokenCommand()
		{
			return Matcher.Is<DeleteRefreshTokenCommand>(p => p.Matches(request));
		}
	}
}
