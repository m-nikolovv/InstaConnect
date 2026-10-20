using InstaConnect.Common.Domain.Features.Requests.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

public abstract class MongoDbResponseFluent<TEntity> : IMongoDbResponseFluent<TEntity>
	where TEntity : ICreatable
{
	private IAggregateFluent<TEntity> _fluent;

	protected MongoDbResponseFluent(
		IAggregateFluent<TEntity> fluent)
	{
		_fluent = fluent;
	}

	protected void ApplySorting<TSortTerm, TSortTermer, TSortingQuery>(
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

	protected void ApplyPagination<TPaginationQuery>(
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
}
