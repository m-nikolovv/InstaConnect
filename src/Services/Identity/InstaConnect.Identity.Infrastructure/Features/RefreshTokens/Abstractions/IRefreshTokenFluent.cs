using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenFluent : IMongoDbFluent<RefreshToken, RefreshTokenId>
{
	public IRefreshTokenFluent Match(RefreshTokenId filter);
	public IRefreshTokenFluent Match(IEnumerable<RefreshTokenId> filter);
	public IRefreshTokenFluent ApplyIncludes(RefreshTokenInclude include);
}
