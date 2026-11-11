namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowCollection : IMongoDbCollection<Follow>
{
	public IFollowFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<Follow> filter,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<Follow> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		Follow entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<Follow> filter,
		CancellationToken cancellationToken);
}
