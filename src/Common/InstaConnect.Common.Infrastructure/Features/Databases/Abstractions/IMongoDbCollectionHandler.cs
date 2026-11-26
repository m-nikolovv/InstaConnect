namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface IMongoDbCollectionHandler<TEntity, TEntityId>
	where TEntity : IEntityWithId<TEntityId>
	where TEntityId : IEntityId
{
	public IAggregateFluent<TEntity> AggregateWithIgnoreCaseCollation();

	public Task ReplaceAsync(FilterDefinition<TEntity> filter, TEntity entity, CancellationToken cancellationToken);

	public Task RemoveAsync(FilterDefinition<TEntity> filter, CancellationToken cancellationToken);

	public Task RemoveRangeAsync(FilterDefinition<TEntity> filter, CancellationToken cancellationToken);

	public Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

	public Task InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
}
