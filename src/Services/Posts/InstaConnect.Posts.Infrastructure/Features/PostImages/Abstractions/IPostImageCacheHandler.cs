using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

public interface IPostImageCacheHandler
{
	public Task<PostImage?> GetByIdAsync(PostImageId id, CancellationToken cancellationToken);

	public Task AddAsync(PostImage entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(PostImageId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostImageId> ids, CancellationToken cancellationToken);
}
