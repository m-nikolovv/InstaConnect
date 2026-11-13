using InstaConnect.Common.Domain.Features.Requests.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface IMongoDbResponseFluentHandler<TEntity>
	where TEntity : ICreatable
{
	public void ApplySorting<TSortTerm, TSortTermer, TSortingQuery>(
		ISortOrdererFactory sortOrdererFactory,
		ISortTermerFactory<TSortTerm, TSortTermer, TEntity> sortTermerFactory,
		TSortingQuery sorting)
			where TSortingQuery : ISortingQuery<TSortTerm>
			where TSortTerm : Enum
			where TSortTermer : ISortTermer<TSortTerm, TEntity>;

	public void ApplyPagination<TPaginationQuery>(
		IPaginator paginator,
		TPaginationQuery pagination)
		where TPaginationQuery : IPaginationQuery;

	public Task<TEntity?> FirstOrDefaultAsync(CancellationToken cancellationToken);

	public Task<ICollection<TEntity>> ToListAsync(CancellationToken cancellationToken);
}
