namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IAccessTokenGenerator
{
	public AccessToken Generate(User user);
}
