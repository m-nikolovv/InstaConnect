namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostCacheHandler
{
	public Task<Post?> GetByIdAsync(PostId id, CancellationToken cancellationToken);

	public Task<PostResponse?> GetByIdAsync(PostId id, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddAsync(Post entity, CancellationToken cancellationToken);

	public Task AddAsync(PostResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<Post> entities, CancellationToken cancellationToken);

	public Task<bool?> ExistsByIdAsync(PostId id, CancellationToken cancellationToken);

	public Task AddExistsByIdAsync(PostId id, bool exists, CancellationToken cancellationToken);

	public Task DeleteAsync(PostId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostId> ids, CancellationToken cancellationToken);

	public Task DeleteResponseAsync(PostId id, CancellationToken cancellationToken);

	public Task DeleteResponseRangeAsync(IEnumerable<PostId> ids, CancellationToken cancellationToken);
}
