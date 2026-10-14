namespace InstaConnect.Posts.Domain.Features.PostImages.Abstractions;

public interface IPostImageCommandRepository
{
	public Task<PostImage?> GetByIdAsync(
		PostImageId id,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken);
}
