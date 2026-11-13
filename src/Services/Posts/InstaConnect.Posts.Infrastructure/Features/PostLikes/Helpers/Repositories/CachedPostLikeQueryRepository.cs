using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;

internal class CachedPostLikeQueryRepository : IPostLikeQueryRepository
{
	private readonly IPostLikeQueryRepository _repository;
	private readonly IPostLikeCacheHandler _likeCacheHandler;

	public CachedPostLikeQueryRepository(
		IPostLikeQueryRepository repository,
		IPostLikeCacheHandler likeCacheHandler)
	{
		_repository = repository;
		_likeCacheHandler = likeCacheHandler;
	}

	public async Task<ICollection<PostLikeResponse>> GetAllAsync(
		PostLikesFilterQuery filter,
		PostLikesSortingQuery sorting,
		PostLikesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		return await _repository.GetAllAsync(filter, sorting, pagination, currentUser, cancellationToken);
	}

	public async Task<ICollection<PostLikeResponse>> GetAllForUserAsync(
		PostLikesForUserFilterQuery filter,
		PostLikesForUserSortingQuery sorting,
		PostLikesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		return await _repository.GetAllForUserAsync(filter, sorting, pagination, currentUser, cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		PostLikesFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _repository.GetTotalCountAsync(filter, cancellationToken);
	}

	public async Task<long> GetTotalCountForUserAsync(
		PostLikesForUserFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _repository.GetTotalCountForUserAsync(filter, cancellationToken);
	}

	public async Task<PostLikeResponse?> GetByIdAsync(
		PostLikeId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _likeCacheHandler.GetByIdAsync(id, currentUser, cancellationToken);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var response = await _repository.GetByIdAsync(id, currentUser, cancellationToken);

		if (response != null)
		{
			await _likeCacheHandler.AddAsync(response, currentUser, cancellationToken);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _likeCacheHandler.ExistsByIdAsync(id, cancellationToken);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _repository.ExistsByIdAsync(id, cancellationToken);

		await _likeCacheHandler.AddExistsByIdAsync(id, exists, cancellationToken);

		return exists;
	}
}
