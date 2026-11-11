using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

public interface IPostImageCacheHandler
{
	public Task<PostImage?> GetByIdAsync(PostImageId id);

	public Task AddAsync(PostImage entity);

	public Task DeleteAsync(PostImageId id);

	public Task DeleteRangeAsync(IEnumerable<PostImageId> ids);
}
