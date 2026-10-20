using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

namespace InstaConnect.Posts.Domain.Features.PostImages.Abstractions;

public interface IPostImageCommandRepository
{
	public Task<PostImage?> GetByIdAsync(
		PostImageId id,
		CancellationToken cancellationToken);

	public Task<ICollection<PostImage>> GetByIdRangeAsync(
		IEnumerable<PostImageId> ids,
		CancellationToken cancellationToken);

	public Task AddAsync(PostImage entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(PostImage entity, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken);
}
