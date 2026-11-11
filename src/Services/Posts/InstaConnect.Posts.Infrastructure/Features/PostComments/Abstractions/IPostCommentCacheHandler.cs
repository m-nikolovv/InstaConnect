namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentCacheHandler
{
	public Task<PostComment?> GetByIdAsync(PostCommentId id);

	public Task<PostCommentResponse?> GetByIdAsync(PostCommentId id, CurrentUserQuery currentUser);

	public Task AddAsync(PostComment entity);

	public Task AddAsync(PostCommentResponse response, CurrentUserQuery currentUser);

	public Task AddRangeAsync(IEnumerable<PostComment> entities);

	public Task<bool?> ExistsByIdAsync(PostCommentId id);

	public Task AddExistsByIdAsync(PostCommentId id, bool exists);

	public Task DeleteAsync(PostCommentId id);

	public Task DeleteRangeAsync(IEnumerable<PostCommentId> ids);

	public Task DeleteResponseAsync(PostCommentId id);

	public Task DeleteResponseRangeAsync(IEnumerable<PostCommentId> ids);
}
