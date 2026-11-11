namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeCacheHandler
{
	public Task<PostLike?> GetByIdAsync(PostLikeId id);

	public Task<PostLikeResponse?> GetByIdAsync(PostLikeId id, CurrentUserQuery currentUser);

	public Task AddAsync(PostLike entity);

	public Task AddAsync(PostLikeResponse response, CurrentUserQuery currentUser);

	public Task AddRangeAsync(IEnumerable<PostLike> entities);

	public Task<bool?> ExistsByIdAsync(PostLikeId id);

	public Task AddExistsByIdAsync(PostLikeId id, bool exists);

	public Task DeleteAsync(PostLikeId id);

	public Task DeleteRangeAsync(IEnumerable<PostLikeId> ids);
}
