namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

public interface IPostImageCollection
{
	public IPostImageFluent AggregateFluent();

	public Task AddAsync(
		PostImage entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<PostImage> entities,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostImage entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<PostImage> filter,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<PostImage> entities,
		CancellationToken cancellationToken);
}
