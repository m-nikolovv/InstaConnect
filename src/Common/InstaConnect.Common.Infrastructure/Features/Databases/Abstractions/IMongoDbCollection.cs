namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface IMongoDbCollection<in TEntity> where TEntity : IEntity
{
	public Task AddAsync(TEntity entity, CancellationToken cancellationToken);
	public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
}
