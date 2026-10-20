namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface IMongoDbFluent<TEntity>
	where TEntity : ICreatable
{
	public Task<TEntity?> FirstOrDefaultAsync(CancellationToken cancellationToken);
	public Task<long> GetCountAsync(CancellationToken cancellationToken);
	public Task<ICollection<TEntity>> ToListAsync(CancellationToken cancellationToken);
	public Task<bool> AnyAsync(CancellationToken cancellationToken);
}
