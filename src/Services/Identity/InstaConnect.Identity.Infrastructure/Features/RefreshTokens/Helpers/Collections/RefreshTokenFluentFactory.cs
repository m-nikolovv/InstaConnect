namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Collections;

internal class RefreshTokenFluentFactory : IRefreshTokenFluentFactory
{
	private readonly IRefreshTokenIncluderFactory _includerFactory;

	public RefreshTokenFluentFactory(IRefreshTokenIncluderFactory includerFactory)
	{
		_includerFactory = includerFactory;
	}

	public IRefreshTokenFluent Create(IAggregateFluent<RefreshToken> fluent)
	{
		return new RefreshTokenFluent(fluent, _includerFactory);
	}
}
