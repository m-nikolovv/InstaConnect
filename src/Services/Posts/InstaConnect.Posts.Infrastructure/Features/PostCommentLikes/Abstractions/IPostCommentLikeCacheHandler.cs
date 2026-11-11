namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeCacheHandler
{
	public Task<PostCommentLike?> GetByIdAsync(PostCommentLikeId id);

	public Task<PostCommentLikeResponse?> GetByIdAsync(PostCommentLikeId id, CurrentUserQuery currentUser);

	public Task AddAsync(PostCommentLike entity);

	public Task AddAsync(PostCommentLikeResponse response, CurrentUserQuery currentUser);

	public Task<bool?> ExistsByIdAsync(PostCommentLikeId id);

	public Task AddExistsByIdAsync(PostCommentLikeId id, bool exists);

	public Task DeleteAsync(PostCommentLikeId id);

	public Task DeleteRangeAsync(IEnumerable<PostCommentLikeId> ids);
}
