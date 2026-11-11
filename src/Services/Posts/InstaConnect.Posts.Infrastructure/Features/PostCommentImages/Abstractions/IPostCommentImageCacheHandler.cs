using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

public interface IPostCommentImageCacheHandler
{
	public Task<PostCommentImage?> GetByIdAsync(PostCommentImageId id);

	public Task AddAsync(PostCommentImage entity);

	public Task DeleteAsync(PostCommentImageId id);

	public Task DeleteRangeAsync(IEnumerable<PostCommentImageId> ids);
}
