namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeCacheHandler
{
	public Task<PostLike?> GetByIdAsync(PostLikeId id, CancellationToken cancellationToken);

	public Task<PostLikeResponse?> GetByIdAsync(PostLikeId id, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddAsync(PostLike entity, CancellationToken cancellationToken);

	public Task AddAsync(PostLikeResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostLike> entities, CancellationToken cancellationToken);

	public Task<bool?> ExistsByIdAsync(PostLikeId id, CancellationToken cancellationToken);

	public Task AddExistsByIdAsync(PostLikeId id, bool exists, CancellationToken cancellationToken);

	public Task DeleteAsync(PostLikeId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostLikeId> ids, CancellationToken cancellationToken);
}
