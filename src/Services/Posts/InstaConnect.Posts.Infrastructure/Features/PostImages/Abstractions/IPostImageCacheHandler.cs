using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

public interface IPostImageCacheHandler
{
	public Task DeleteAsync(PostImageId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostImageId> ids, CancellationToken cancellationToken);
}
