namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

public interface IPostImageCollection : IMongoDbCollection<PostImage>
{
	public IPostImageFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<PostImage> filter,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<PostImage> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostImage entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<PostImage> filter,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<PostImage> entities,
		CancellationToken cancellationToken);
}
