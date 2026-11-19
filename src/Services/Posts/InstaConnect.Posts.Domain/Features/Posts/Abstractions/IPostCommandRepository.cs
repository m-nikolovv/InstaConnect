namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostCommandRepository
{
	public Task AddAsync(Post entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<Post> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(Post entity, CancellationToken cancellationToken);

	public Task<Post?> GetByIdAsync(PostId id, CancellationToken cancellationToken);

	public Task<Post?> GetByIdAsync(PostId id, PostInclude include, CancellationToken cancellationToken);

	public Task<ICollection<Post>> GetByIdRangeAsync(IEnumerable<PostId> ids, CancellationToken cancellationToken);

	public Task<ICollection<Post>> GetByIdRangeAsync(IEnumerable<PostId> ids, PostInclude include, CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(PostId id, CancellationToken cancellationToken);

	public Task UpdateAsync(Post entity, CancellationToken cancellationToken);
}
