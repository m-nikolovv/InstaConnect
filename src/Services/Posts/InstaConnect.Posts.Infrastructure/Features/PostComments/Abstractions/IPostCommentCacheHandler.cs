namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentCacheHandler
{
	public Task<PostCommentResponse?> GetByIdAsync(PostCommentId id, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddAsync(PostCommentResponse response, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostCommentResponse> responses, UserId currentUserId, CancellationToken cancellationToken);

	public Task DeleteAsync(PostCommentId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostCommentId> ids, CancellationToken cancellationToken);

	public Task DeleteResponseAsync(PostCommentId id, CancellationToken cancellationToken);

	public Task DeleteResponseRangeAsync(IEnumerable<PostCommentId> ids, CancellationToken cancellationToken);
}
