namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeCacheHandler
{
	public Task<PostCommentLike?> GetByIdAsync(PostCommentLikeId id, CancellationToken cancellationToken);

	public Task<PostCommentLikeResponse?> GetByIdAsync(PostCommentLikeId id, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken);

	public Task AddAsync(PostCommentLikeResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostCommentLike> entities, CancellationToken cancellationToken);

	public Task<bool?> ExistsByIdAsync(PostCommentLikeId id, CancellationToken cancellationToken);

	public Task AddExistsByIdAsync(PostCommentLikeId id, bool exists, CancellationToken cancellationToken);

	public Task DeleteAsync(PostCommentLikeId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostCommentLikeId> ids, CancellationToken cancellationToken);
}
