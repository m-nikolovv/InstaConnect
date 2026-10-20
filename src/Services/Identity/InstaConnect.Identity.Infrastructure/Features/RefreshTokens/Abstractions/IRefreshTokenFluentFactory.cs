namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenFluentFactory
{
	public IRefreshTokenFluent Create(IAggregateFluent<RefreshToken> fluent);
}
