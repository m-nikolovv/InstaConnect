using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

public interface IPostCommentImageCacheHandler
{
	public Task<PostCommentImage?> GetByIdAsync(PostCommentImageId id, CancellationToken cancellationToken);

	public Task AddAsync(PostCommentImage entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostCommentImage> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(PostCommentImageId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostCommentImageId> ids, CancellationToken cancellationToken);
}
