using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Repositories;

internal class CachedPostCommentQueryRepository : IPostCommentQueryRepository
{
	private readonly IPostCommentQueryRepository _repository;
	private readonly IPostCommentCacheHandler _commentCacheHandler;

	public CachedPostCommentQueryRepository(
		IPostCommentQueryRepository repository,
		IPostCommentCacheHandler commentCacheHandler)
	{
		_repository = repository;
		_commentCacheHandler = commentCacheHandler;
	}

	public async Task<ICollection<PostCommentResponse>> GetAllAsync(
		PostCommentsFilterQuery filter,
		PostCommentsSortingQuery sorting,
		PostCommentsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		return await _repository.GetAllAsync(filter, sorting, pagination, currentUser, cancellationToken);
	}

	public async Task<ICollection<PostCommentResponse>> GetAllForUserAsync(
		PostCommentsForUserFilterQuery filter,
		PostCommentsForUserSortingQuery sorting,
		PostCommentsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		return await _repository.GetAllForUserAsync(filter, sorting, pagination, currentUser, cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		PostCommentsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _repository.GetTotalCountAsync(filter, cancellationToken);
	}

	public async Task<long> GetTotalCountForUserAsync(
		PostCommentsForUserFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _repository.GetTotalCountForUserAsync(filter, cancellationToken);
	}

	public async Task<PostCommentResponse?> GetByIdAsync(
		PostCommentId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _commentCacheHandler.GetByIdAsync(id, currentUser);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var response = await _repository.GetByIdAsync(id, currentUser, cancellationToken);

		if (response != null)
		{
			await _commentCacheHandler.AddAsync(response, currentUser);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		PostCommentId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _commentCacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _repository.ExistsByIdAsync(id, cancellationToken);

		await _commentCacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}
}
