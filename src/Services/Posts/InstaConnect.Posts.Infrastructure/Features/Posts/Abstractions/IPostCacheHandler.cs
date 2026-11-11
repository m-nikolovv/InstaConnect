namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostCacheHandler
{
	public Task<Post?> GetByIdAsync(PostId id);

	public Task<PostResponse?> GetByIdAsync(PostId id, CurrentUserQuery currentUser);

	public Task AddAsync(Post entity);

	public Task AddAsync(PostResponse response, CurrentUserQuery currentUser);

	public Task AddRangeAsync(IEnumerable<Post> entities);

	public Task<bool?> ExistsByIdAsync(PostId id);

	public Task AddExistsByIdAsync(PostId id, bool exists);

	public Task DeleteAsync(PostId id);

	public Task DeleteRangeAsync(IEnumerable<PostId> ids);

	public Task DeleteResponseAsync(PostId id);

	public Task DeleteResponseRangeAsync(IEnumerable<PostId> ids);
}
