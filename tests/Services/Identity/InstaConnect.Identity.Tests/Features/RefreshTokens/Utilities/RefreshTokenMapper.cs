namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMapper
{
	extension(RefreshToken refreshToken)
	{
		public RefreshTokenId ToId(
)
		{
			return refreshToken.Id;
		}
	}
}
