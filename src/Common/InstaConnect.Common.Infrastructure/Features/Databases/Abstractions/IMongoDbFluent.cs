namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface IMongoDbFluent<TEntity, TEntityId>
	where TEntity : ICreatable, IEntityWithId<TEntityId>
	where TEntityId : IEntityId
{
	public IMongoDbFluent<TEntity, TEntityId> Match(FilterDefinition<TEntity> filterDefinition);
	public Task<TEntity?> FirstOrDefaultAsync(CancellationToken cancellationToken);
	public Task<long> GetCountAsync(CancellationToken cancellationToken);
	public Task<ICollection<TEntity>> ToListAsync(CancellationToken cancellationToken);
	public Task<bool> AnyAsync(CancellationToken cancellationToken);
	public Task<ICollection<TEntityId>> GetIdsAsync(CancellationToken cancellationToken);
}
