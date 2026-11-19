namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeCommandRepository
{
	public Task<PostCommentLike?> GetByIdAsync(
		PostCommentLikeId id,
		PostCommentLikeInclude include,
		CancellationToken cancellationToken);

	public Task<PostCommentLike?> GetByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken);

	public Task<ICollection<PostCommentLike>> GetByIdRangeAsync(
		IEnumerable<PostCommentLikeId> ids,
		PostCommentLikeInclude include,
		CancellationToken cancellationToken);

	public Task<ICollection<PostCommentLike>> GetByIdRangeAsync(
		IEnumerable<PostCommentLikeId> ids,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken);

	public Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostCommentLike> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(PostCommentLike entity, CancellationToken cancellationToken);
}
