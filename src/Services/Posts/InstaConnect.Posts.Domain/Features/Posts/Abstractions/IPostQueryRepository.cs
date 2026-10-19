namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostQueryRepository
{
	public Task<ICollection<PostResponse>> GetAllAsync(
		PostsFilterQuery filter,
		PostsSortingQuery sorting,
		PostsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken);

	public Task<ICollection<PostResponse>> GetAllForUserAsync(
		PostsForUserFilterQuery filter,
		PostsForUserSortingQuery sorting,
		PostsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountAsync(
		PostsFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountForUserAsync(
		PostsForUserFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<PostResponse?> GetByIdAsync(
		PostId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		PostId id,
		CancellationToken cancellationToken);
}
