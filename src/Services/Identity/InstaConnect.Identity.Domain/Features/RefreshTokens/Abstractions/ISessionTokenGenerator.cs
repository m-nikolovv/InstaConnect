using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface ISessionTokenGenerator
{
	public SessionToken Generate(RefreshToken refreshToken);
}
