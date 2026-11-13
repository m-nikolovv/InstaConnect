namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface IMongoDbFluentHandler<TEntity, TEntityId>
	where TEntity : ICreatable, IEntityWithId<TEntityId>
	where TEntityId : IEntityId
{
	public IAggregateFluent<TNewEntity> Project<TNewEntity>(ProjectionDefinition<TEntity, TNewEntity> projectionDefinition);

	public void Match(FilterDefinition<TEntity> filterDefinition);

	public void ApplyIncludes<TInclude, TIncludeType, TDestinationType, TIncludeDescriptor, TIncluder>(
		IIncluderFactory<TIncludeType, TDestinationType, TIncludeDescriptor, TIncluder, TEntity> includerFactory,
		TInclude include)
		where TDestinationType : Enum
		where TIncludeType : Enum
		where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
		where TIncluder : IIncluder<TEntity, TIncludeType, TDestinationType>
		where TInclude : IInclude<TDestinationType, TIncludeType, TIncludeDescriptor>;

	public Task<TEntity?> FirstOrDefaultAsync(CancellationToken cancellationToken);

	public Task<ICollection<TEntity>> ToListAsync(CancellationToken cancellationToken);

	public Task<bool> AnyAsync(CancellationToken cancellationToken);

	public Task<ICollection<TEntityId>> GetIdsAsync(CancellationToken cancellationToken);

	public Task<long> GetCountAsync(CancellationToken cancellationToken);
}
