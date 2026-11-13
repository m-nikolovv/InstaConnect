using InstaConnect.Common.Domain.Features.Requests.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

internal class MongoDbFluentHandler<TEntity, TEntityId>
	: IMongoDbFluentHandler<TEntity, TEntityId>
	where TEntity : ICreatable, IEntityWithId<TEntityId>
	where TEntityId : IEntityId
{
	private IAggregateFluent<TEntity> _fluent;

	public MongoDbFluentHandler(IAggregateFluent<TEntity> fluent)
	{
		_fluent = fluent;
	}

	public IAggregateFluent<TNewEntity> Project<TNewEntity>(ProjectionDefinition<TEntity, TNewEntity> projectionDefinition)
	{
		return _fluent.Project(projectionDefinition);
	}

	public void Match(FilterDefinition<TEntity> filterDefinition)
	{
		_fluent = _fluent.Match(filterDefinition);
	}

	public void ApplyIncludes<TInclude, TIncludeType, TDestinationType, TIncludeDescriptor, TIncluder>(
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

	public void ApplySorting<TSortTerm, TSortTermer, TSortingQuery>(
		ISortOrdererFactory sortOrdererFactory,
		ISortTermerFactory<TSortTerm, TSortTermer, TEntity> sortTermerFactory,
		TSortingQuery sorting)
			where TSortingQuery : ISortingQuery<TSortTerm>
			where TSortTerm : Enum
			where TSortTermer : ISortTermer<TSortTerm, TEntity>
	{
		var order = sortOrdererFactory.Create(sorting.Order);
		var term = sortTermerFactory.Create(sorting.Term);

		_fluent = _fluent.Sort(Builders<TEntity>.Sort.Combine(order.Sort(term.Term), order.Sort<TEntity>(a => a.CreatedAtUtc)));
	}

	public void ApplyPagination<TPaginationQuery>(
		IPaginator paginator,
		TPaginationQuery pagination)
		where TPaginationQuery : IPaginationQuery
	{
		var offset = paginator.GetOffset(pagination.Page, pagination.PageSize);

		_fluent = _fluent
			.Skip(offset)
			.Limit(pagination.PageSize);
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

	public async Task<ICollection<TEntityId>> GetIdsAsync(CancellationToken cancellationToken)
	{
		return await _fluent
			.Project(p => p.Id)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetCountAsync(CancellationToken cancellationToken)
	{
		var response = await _fluent
						   .Count()
						   .FirstOrDefaultAsync(cancellationToken);

		return response?.Count ?? default;
	}
}
