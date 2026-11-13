using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Caches;

internal class PostCommentCacheHandler : IPostCommentCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostCommentCacheOptions _cacheOptions;

	public PostCommentCacheHandler(ICacheHandler cacheHandler, PostCommentCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<PostComment?> GetByIdAsync(PostCommentId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostComment>(PostCommentCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task<PostCommentResponse?> GetByIdAsync(PostCommentId id, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostCommentResponse>(PostCommentCacheUtilities.GetResponseByIdKey(id, currentUser), cancellationToken);
	}

	public async Task AddAsync(PostComment entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostCommentCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[PostCommentCacheUtilities.GetByIdKeyPrefix],
			[PostCommentCacheUtilities.GetTag(entity.Id),
			 PostCacheUtilities.GetResponseTag(entity.Id.Id)],
			[PostCacheUtilities.GetTag(entity.Id.Id),
			 UserCacheUtilities.GetTag(entity.UserId)],
			cancellationToken);
	}

	public async Task AddAsync(PostCommentResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostCommentCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[PostCommentCacheUtilities.GetResponseByIdKeyPrefix],
			[PostCommentCacheUtilities.GetTag(response.Id),
			 PostCommentCacheUtilities.GetResponseTag(response.Id),
			 PostCacheUtilities.GetResponseTag(response.Id.Id)],
			[PostCacheUtilities.GetTag(response.Id.Id),
			 UserCacheUtilities.GetTag(response.UserId)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostComment> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task<bool?> ExistsByIdAsync(PostCommentId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<bool?>(PostCommentCacheUtilities.ExistsByIdKey(id), cancellationToken);
	}

	public async Task AddExistsByIdAsync(PostCommentId id, bool exists, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync<bool?>(
			PostCommentCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[PostCommentCacheUtilities.ExistsByIdKeyPrefix],
			[PostCommentCacheUtilities.GetTag(id)],
			[PostCacheUtilities.GetTag(id.Id)],
			cancellationToken);
	}

	public async Task DeleteAsync(PostCommentId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(PostCommentCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostCommentId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCommentCacheUtilities.GetTagRange(ids), cancellationToken);
	}

	public async Task DeleteResponseAsync(PostCommentId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(PostCommentCacheUtilities.GetResponseTag(id), cancellationToken);
	}

	public async Task DeleteResponseRangeAsync(IEnumerable<PostCommentId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCommentCacheUtilities.GetResponseTagRange(ids), cancellationToken);
	}
}
