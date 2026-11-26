namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowCommandRepository
{
	public Task AddAsync(Follow entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<Follow> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(Follow entity, CancellationToken cancellationToken);

	public Task<Follow?> GetByIdAsync(FollowId id, CancellationToken cancellationToken);

	public Task<Follow?> GetByIdAsync(FollowId id, FollowInclude include, CancellationToken cancellationToken);

	public Task<ICollection<Follow>> GetByIdRangeAsync(IEnumerable<FollowId> ids, CancellationToken cancellationToken);

	public Task<ICollection<Follow>> GetByIdRangeAsync(IEnumerable<FollowId> ids, FollowInclude include, CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(FollowId id, CancellationToken cancellationToken);
}
