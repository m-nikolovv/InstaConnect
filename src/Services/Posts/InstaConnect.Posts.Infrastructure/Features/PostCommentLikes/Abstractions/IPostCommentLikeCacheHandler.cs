namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeCacheHandler
{
	public Task<PostCommentLikeResponse?> GetByIdAsync(PostCommentLikeId id, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddAsync(PostCommentLikeResponse response, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostCommentLikeResponse> responses, UserId currentUserId, CancellationToken cancellationToken);

	public Task DeleteAsync(PostCommentLikeId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<PostCommentLikeId> ids, CancellationToken cancellationToken);
}
