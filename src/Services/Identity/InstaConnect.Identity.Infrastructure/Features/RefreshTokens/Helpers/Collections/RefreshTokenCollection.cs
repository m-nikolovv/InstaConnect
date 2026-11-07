using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Collections;

internal class RefreshTokenCollection : MongoDbCollection<RefreshToken, RefreshTokenId>, IRefreshTokenCollection
{
	private readonly IRefreshTokenFluentFactory _fluentFactory;

	public RefreshTokenCollection(
		ISessionHandler sessionHandler,
		IRefreshTokenFluentFactory fluentFactory,
		IMongoCollection<RefreshToken> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IRefreshTokenFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task UpdateAsync(
		RefreshToken entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		RefreshToken entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<RefreshToken> filter,
		CancellationToken cancellationToken)
	{
		await DeleteRangeAsync(filter, cancellationToken);
	}
}
