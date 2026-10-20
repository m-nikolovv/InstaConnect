namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface ISortTermer<TSortTerm, TEntity>
	where TSortTerm : Enum
{
	public TSortTerm SortTerm { get; }

	public Expression<Func<TEntity, object>> Term { get; }
}
