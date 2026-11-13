using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Caches;

internal class PostCommentLikeCacheHandler : IPostCommentLikeCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostCommentLikeCacheOptions _cacheOptions;

	public PostCommentLikeCacheHandler(ICacheHandler cacheHandler, PostCommentLikeCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<PostCommentLike?> GetByIdAsync(PostCommentLikeId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostCommentLike>(PostCommentLikeCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task<PostCommentLikeResponse?> GetByIdAsync(PostCommentLikeId id, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostCommentLikeResponse>(PostCommentLikeCacheUtilities.GetResponseByIdKey(id, currentUser), cancellationToken);
	}

	public async Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostCommentLikeCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[PostCommentLikeCacheUtilities.GetByIdKeyPrefix],
			[PostCommentLikeCacheUtilities.GetTag(entity.Id),
			 PostCommentCacheUtilities.GetResponseTag(entity.Id.CommentId)],
			[PostCommentCacheUtilities.GetTag(entity.Id.CommentId),
			 UserCacheUtilities.GetTag(entity.Id.UserId)],
			cancellationToken);
	}

	public async Task AddAsync(PostCommentLikeResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostCommentLikeCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[PostCommentLikeCacheUtilities.GetResponseByIdKeyPrefix],
			[PostCommentLikeCacheUtilities.GetTag(response.Id),
			 PostCommentCacheUtilities.GetResponseTag(response.Id.CommentId),
			 PostCacheUtilities.GetResponseTag(response.Id.CommentId.Id)],
			[PostCommentCacheUtilities.GetTag(response.Id.CommentId),
			 UserCacheUtilities.GetTag(response.Id.UserId)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostCommentLike> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task<bool?> ExistsByIdAsync(PostCommentLikeId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<bool?>(PostCommentLikeCacheUtilities.ExistsByIdKey(id), cancellationToken);
	}

	public async Task AddExistsByIdAsync(PostCommentLikeId id, bool exists, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync<bool?>(
			PostCommentLikeCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[PostCommentLikeCacheUtilities.ExistsByIdKeyPrefix],
			[PostCommentLikeCacheUtilities.GetTag(id)],
			[PostCommentCacheUtilities.GetTag(id.CommentId),
			 UserCacheUtilities.GetTag(id.UserId)],
			cancellationToken);
	}

	public async Task DeleteAsync(PostCommentLikeId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(PostCommentLikeCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostCommentLikeId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCommentLikeCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
