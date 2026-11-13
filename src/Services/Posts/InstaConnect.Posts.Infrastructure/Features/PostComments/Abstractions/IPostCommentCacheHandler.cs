namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentCacheHandler
{
	public Task<PostComment?> GetByIdAsync(PostCommentId id, CancellationToken cancellationToken);

	public Task<PostCommentResponse?> GetByIdAsync(PostCommentId id, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddAsync(PostComment entity, CancellationToken cancellationToken);

	public Task AddAsync(PostCommentResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostComment> entities, CancellationToken cancellationToken);

	public Task<bool?> ExistsByIdAsync(PostCommentId id, CancellationToken cancellationToken);

	public Task AddExistsByIdAsync(PostCommentId id, bool exists, CancellationToken cancellationToken);

	public Task DeleteAsync(PostCommentId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostCommentId> ids, CancellationToken cancellationToken);

	public Task DeleteResponseAsync(PostCommentId id, CancellationToken cancellationToken);

	public Task DeleteResponseRangeAsync(IEnumerable<PostCommentId> ids, CancellationToken cancellationToken);
}
