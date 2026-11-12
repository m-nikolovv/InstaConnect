namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostCollection
{
	public IPostFluent AggregateFluent();

	public Task AddAsync(
		Post entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<Post> entities,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		Post entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		Post entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken);
}
