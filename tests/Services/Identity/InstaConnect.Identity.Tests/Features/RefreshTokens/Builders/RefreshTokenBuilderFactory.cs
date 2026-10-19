namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;

public class RefreshTokenBuilderFactory
{
	public RefreshTokenBuilder Create(User user)
	{
		return new(user);
	}

	public RefreshTokenBuilder Create(RefreshToken refreshToken)
	{
		return new(refreshToken);
	}
}
