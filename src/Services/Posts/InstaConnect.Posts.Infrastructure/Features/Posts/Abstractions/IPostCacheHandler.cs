namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostCacheHandler
{
	public Task<PostResponse?> GetByIdAsync(PostId id, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddAsync(PostResponse response, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostResponse> responses, UserId currentUserId, CancellationToken cancellationToken);

	public Task DeleteAsync(PostId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostId> ids, CancellationToken cancellationToken);

	public Task DeleteResponseAsync(PostId id, CancellationToken cancellationToken);

	public Task DeleteResponseRangeAsync(IEnumerable<PostId> ids, CancellationToken cancellationToken);
}
