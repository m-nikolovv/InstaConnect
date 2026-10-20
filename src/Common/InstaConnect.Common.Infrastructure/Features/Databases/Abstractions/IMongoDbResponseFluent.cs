namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface IMongoDbResponseFluent<TEntity>
	where TEntity : ICreatable
{
	public Task<TEntity?> FirstOrDefaultAsync(CancellationToken cancellationToken);
	public Task<ICollection<TEntity>> ToListAsync(CancellationToken cancellationToken);
}
