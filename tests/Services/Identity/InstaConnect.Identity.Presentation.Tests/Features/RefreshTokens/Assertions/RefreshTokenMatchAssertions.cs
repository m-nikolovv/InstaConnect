using InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Responses;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMatchAssertions
{
	extension(IssueRefreshTokenApiResponse response)
	{
		public void ShouldSatisfy(IssueRefreshTokenApiRequest request)
		{
			response.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(RotateRefreshTokenApiResponse response)
	{
		public void ShouldSatisfy(RotateRefreshTokenApiRequest request)
		{
			response.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ActionResult<IssueRefreshTokenApiResponse> response)
	{
		public void ShouldSatisfy(
		IssueRefreshTokenApiRequest request)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request));
		}
	}

	extension(ActionResult<RotateRefreshTokenApiResponse> response)
	{
		public void ShouldSatisfy(
		RotateRefreshTokenApiRequest request)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request));
		}
	}

	extension(RefreshToken refreshToken)
	{
		public void ShouldSatisfy(IssueRefreshTokenApiRequest request)
		{
			refreshToken.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(RotateRefreshTokenApiRequest request)
		{
			refreshToken.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ICollection<RefreshToken> refreshTokens)
	{
		public void ShouldSatisfy(IssueRefreshTokenApiRequest request)
		{
			refreshTokens.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(RotateRefreshTokenApiRequest request)
		{
			refreshTokens.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(RefreshTokenCookieApiResponse response)
	{
		public void ShouldSatisfy(IssueRefreshTokenApiRequest request, RefreshToken refreshToken)
		{
			response.ShouldSatisfy(p => p.Matches(request, refreshToken));
		}

		public void ShouldSatisfy(RotateRefreshTokenApiRequest request, RefreshToken refreshToken)
		{
			response.ShouldSatisfy(p => p.Matches(request, refreshToken));
		}
	}
}
