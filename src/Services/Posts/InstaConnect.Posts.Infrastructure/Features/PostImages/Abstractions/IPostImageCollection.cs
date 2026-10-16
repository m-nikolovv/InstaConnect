using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

public interface IPostImageCollection : IMongoDbCollection<PostImage>
{
	public IPostImageFluent AggregateFluent();

	public Task DeleteAsync(
		PostImage entity,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<PostImage> entities,
		CancellationToken cancellationToken);
}
