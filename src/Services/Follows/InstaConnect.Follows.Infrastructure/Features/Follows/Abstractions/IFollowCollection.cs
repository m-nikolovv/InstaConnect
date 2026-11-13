namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowCollection
{
	public IFollowFluent AggregateFluent();

	public Task AddAsync(
		Follow entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<Follow> entities,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		Follow entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<Follow> filter,
		CancellationToken cancellationToken);
}
