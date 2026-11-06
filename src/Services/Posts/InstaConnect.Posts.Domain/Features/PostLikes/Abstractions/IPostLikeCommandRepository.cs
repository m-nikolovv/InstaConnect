namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeCommandRepository
{
	public Task<PostLike?> GetByIdAsync(
		PostLikeId id,
		PostLikeInclude include,
		CancellationToken cancellationToken);

	public Task<PostLike?> GetByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken);

	public Task<ICollection<PostLike>> GetByIdRangeAsync(
		IEnumerable<PostLikeId> ids,
		PostLikeInclude include,
		CancellationToken cancellationToken);

	public Task<ICollection<PostLike>> GetByIdRangeAsync(
		IEnumerable<PostLikeId> ids,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken);

	public Task AddAsync(PostLike entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostLike> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(PostLike entity, CancellationToken cancellationToken);
}
