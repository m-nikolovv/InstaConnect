using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Collections;

internal class RefreshTokenFluentFactory : IRefreshTokenFluentFactory
{
	private readonly IRefreshTokenIncluderFactory _includerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public RefreshTokenFluentFactory(
		IRefreshTokenIncluderFactory includerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_includerFactory = includerFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IRefreshTokenFluent Create(IAggregateFluent<RefreshToken> fluent)
	{
		return new RefreshTokenFluent(_includerFactory, _fluentHandlerFactory.Create<RefreshToken, RefreshTokenId>(fluent));
	}
}
