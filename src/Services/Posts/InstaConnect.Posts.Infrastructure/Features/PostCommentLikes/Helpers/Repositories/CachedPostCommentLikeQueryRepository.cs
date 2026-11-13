using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Repositories;

internal class CachedPostCommentLikeQueryRepository : IPostCommentLikeQueryRepository
{
	private readonly IPostCommentLikeQueryRepository _repository;
	private readonly IPostCommentLikeCacheHandler _commentLikeCacheHandler;

	public CachedPostCommentLikeQueryRepository(
		IPostCommentLikeQueryRepository repository,
		IPostCommentLikeCacheHandler commentLikeCacheHandler)
	{
		_repository = repository;
		_commentLikeCacheHandler = commentLikeCacheHandler;
	}

	public async Task<ICollection<PostCommentLikeResponse>> GetAllAsync(
		PostCommentLikesFilterQuery filter,
		PostCommentLikesSortingQuery sorting,
		PostCommentLikesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		return await _repository.GetAllAsync(filter, sorting, pagination, currentUser, cancellationToken);
	}

	public async Task<ICollection<PostCommentLikeResponse>> GetAllForUserAsync(
		PostCommentLikesForUserFilterQuery filter,
		PostCommentLikesForUserSortingQuery sorting,
		PostCommentLikesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		return await _repository.GetAllForUserAsync(filter, sorting, pagination, currentUser, cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		PostCommentLikesFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _repository.GetTotalCountAsync(filter, cancellationToken);
	}

	public async Task<long> GetTotalCountForUserAsync(
		PostCommentLikesForUserFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _repository.GetTotalCountForUserAsync(filter, cancellationToken);
	}

	public async Task<PostCommentLikeResponse?> GetByIdAsync(
		PostCommentLikeId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _commentLikeCacheHandler.GetByIdAsync(id, currentUser, cancellationToken);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var response = await _repository.GetByIdAsync(id, currentUser, cancellationToken);

		if (response != null)
		{
			await _commentLikeCacheHandler.AddAsync(response, currentUser, cancellationToken);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _commentLikeCacheHandler.ExistsByIdAsync(id, cancellationToken);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _repository.ExistsByIdAsync(id, cancellationToken);

		await _commentLikeCacheHandler.AddExistsByIdAsync(id, exists, cancellationToken);

		return exists;
	}
}
