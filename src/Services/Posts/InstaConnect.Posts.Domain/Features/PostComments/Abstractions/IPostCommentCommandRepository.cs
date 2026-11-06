namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentCommandRepository
{
	public Task<PostComment?> GetByIdAsync(
		PostCommentId id,
		PostCommentInclude include,
		CancellationToken cancellationToken);

	public Task<PostComment?> GetByIdAsync(
		PostCommentId id,
		CancellationToken cancellationToken);

	public Task<ICollection<PostComment>> GetByIdRangeAsync(
		IEnumerable<PostCommentId> ids,
		PostCommentInclude include,
		CancellationToken cancellationToken);

	public Task<ICollection<PostComment>> GetByIdRangeAsync(
		IEnumerable<PostCommentId> ids,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		PostCommentId id,
		CancellationToken cancellationToken);

	public Task AddAsync(PostComment entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<PostComment> entities, CancellationToken cancellationToken);

	public Task UpdateAsync(PostComment entity, CancellationToken cancellationToken);

	public Task DeleteAsync(PostComment entity, CancellationToken cancellationToken);
}
