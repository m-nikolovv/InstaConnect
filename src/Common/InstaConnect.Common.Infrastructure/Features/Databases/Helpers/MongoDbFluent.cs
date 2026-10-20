namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

public abstract class MongoDbFluent<TEntity>
	: IMongoDbFluent<TEntity> where TEntity : ICreatable
{
	private IAggregateFluent<TEntity> _fluent;

	protected MongoDbFluent(IAggregateFluent<TEntity> fluent)
	{
		_fluent = fluent;
	}

	protected IAggregateFluent<TNewEntity> Project<TNewEntity>(ProjectionDefinition<TEntity, TNewEntity> projectionDefinition)
	{
		return _fluent.Project(projectionDefinition);
	}

	protected void Match(FilterDefinition<TEntity> filterDefinition)
	{
		_fluent = _fluent.Match(filterDefinition);
	}

	protected void ApplyIncludes<TInclude, TIncludeType, TDestinationType, TIncludeDescriptor, TIncluder>(
		IIncluderFactory<TIncludeType, TDestinationType, TIncludeDescriptor, TIncluder, TEntity> includerFactory,
		TInclude include)
		where TDestinationType : Enum
		where TIncludeType : Enum
		where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
		where TIncluder : IIncluder<TEntity, TIncludeType, TDestinationType>
		where TInclude : IInclude<TDestinationType, TIncludeType, TIncludeDescriptor>
	{
		var includers = includerFactory.Create(include.Descriptors);

		foreach (var includer in includers)
		{
			_fluent = includer.Include(_fluent);
		}
	}

	public async Task<TEntity?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluent.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<TEntity>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluent.ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(CancellationToken cancellationToken)
	{
		return await _fluent.AnyAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		var response = await _fluent
						   .Count()
						   .FirstOrDefaultAsync(cancellationToken);

		return response?.Count ?? default;
	}
}
