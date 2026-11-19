namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeCacheHandler
{
	public Task<PostLikeResponse?> GetByIdAsync(PostLikeId id, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddAsync(PostLikeResponse response, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostLikeResponse> responses, UserId currentUserId, CancellationToken cancellationToken);

	public Task DeleteAsync(PostLikeId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostLikeId> ids, CancellationToken cancellationToken);
}
