namespace InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;

public interface IPostCommentImageCommandRepository
{
	public Task<PostCommentImage?> GetByIdAsync(
		PostCommentImageId id,
		CancellationToken cancellationToken);

	public Task<ICollection<PostCommentImage>> GetByIdRangeAsync(
		IEnumerable<PostCommentImageId> ids,
		CancellationToken cancellationToken);

	public Task AddAsync(PostCommentImage entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostCommentImage> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(PostCommentImage entity, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostCommentImage> entities, CancellationToken cancellationToken);
}
