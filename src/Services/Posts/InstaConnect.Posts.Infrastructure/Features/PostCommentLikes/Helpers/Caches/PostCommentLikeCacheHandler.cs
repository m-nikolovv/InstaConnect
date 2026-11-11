using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Caches;

internal class PostCommentLikeCacheHandler : IPostCommentLikeCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostCommentLikeCacheOptions _cacheOptions;

	public PostCommentLikeCacheHandler(ICacheHandler cacheHandler, IOptions<PostCommentLikeCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<PostCommentLike?> GetByIdAsync(PostCommentLikeId id)
	{
		return await _cacheHandler.GetAsync<PostCommentLike>(PostCommentLikeCacheUtilities.GetByIdKey(id));
	}

	public async Task<PostCommentLikeResponse?> GetByIdAsync(PostCommentLikeId id, CurrentUserQuery currentUser)
	{
		return await _cacheHandler.GetAsync<PostCommentLikeResponse>(PostCommentLikeCacheUtilities.GetResponseByIdKey(id, currentUser));
	}

	public async Task AddAsync(PostCommentLike entity)
	{
		await _cacheHandler.SetAsync(
			PostCommentLikeCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[PostCommentLikeCacheUtilities.GetByIdKeyPrefix],
			[PostCommentLikeCacheUtilities.GetTag(entity.Id),
			 PostCommentCacheUtilities.GetTag(entity.Id.CommentId),
			 PostCacheUtilities.GetTag(entity.Id.CommentId.Id),
			 UserCacheUtilities.GetTag(entity.Id.UserId)]);
	}

	public async Task AddAsync(PostCommentLikeResponse response, CurrentUserQuery currentUser)
	{
		List<string> tags =
			[PostCommentLikeCacheUtilities.GetTag(response.Id),
			 PostCommentCacheUtilities.GetTag(response.Id.CommentId),
			 PostCacheUtilities.GetTag(response.Id.CommentId.Id),
			 UserCacheUtilities.GetTag(response.Id.UserId)];

		if (response.PostComment != null)
		{
			tags.Add(UserCacheUtilities.GetTag(response.PostComment.UserId));
		}

		if (response.PostComment?.Post != null)
		{
			tags.Add(UserCacheUtilities.GetTag(response.PostComment.Post.UserId));
		}

		await _cacheHandler.SetAsync(
			PostCommentLikeCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[PostCommentLikeCacheUtilities.GetResponseByIdKeyPrefix],
			tags);
	}

	public async Task AddRangeAsync(IEnumerable<PostCommentLike> entities)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity);
		}
	}

	public async Task<bool?> ExistsByIdAsync(PostCommentLikeId id)
	{
		return await _cacheHandler.GetAsync<bool?>(PostCommentLikeCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(PostCommentLikeId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(
			PostCommentLikeCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[PostCommentLikeCacheUtilities.ExistsByIdKeyPrefix],
			[PostCommentLikeCacheUtilities.GetTag(id),
			 PostCommentCacheUtilities.GetTag(id.CommentId),
			 PostCacheUtilities.GetTag(id.CommentId.Id),
			 UserCacheUtilities.GetTag(id.UserId)]);
	}

	public async Task DeleteAsync(PostCommentLikeId id)
	{
		await _cacheHandler.RemoveByTagAsync(PostCommentLikeCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<PostCommentLikeId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCommentLikeCacheUtilities.GetTagRange(ids));
	}
}
