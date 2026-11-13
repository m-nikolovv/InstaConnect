using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Users.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Caches;

internal class UserCacheHandler : IUserCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly UserCacheOptions _cacheOptions;

	public UserCacheHandler(ICacheHandler cacheHandler, IOptions<UserCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<User>(UserCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task<UserResponse?> GetByIdAsync(UserId id, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<UserResponse>(UserCacheUtilities.GetResponseByIdKey(id, currentUser), cancellationToken);
	}

	public async Task AddAsync(User entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			UserCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[UserCacheUtilities.GetByIdKeyPrefix],
			[UserCacheUtilities.GetTag(entity.Id)],
			cancellationToken);
	}

	public async Task AddAsync(UserResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			UserCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[UserCacheUtilities.GetResponseByIdKeyPrefix],
			[UserCacheUtilities.GetTag(response.Id)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task<bool?> ExistsByIdAsync(UserId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<bool?>(UserCacheUtilities.ExistsByIdKey(id), cancellationToken);
	}

	public async Task AddExistsByIdAsync(UserId id, bool exists, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync<bool?>(
			UserCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[UserCacheUtilities.ExistsByIdKeyPrefix],
			[UserCacheUtilities.GetTag(id)],
			cancellationToken);
	}

	public async Task<User?> GetByNameAsync(Name name, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<User>(UserCacheUtilities.GetByNameKey(name), cancellationToken);
	}

	public async Task AddByNameAsync(User entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			UserCacheUtilities.GetByNameKey(entity.Name),
			entity,
			_cacheOptions.Expirations[UserCacheUtilities.GetByNameKeyPrefix],
			[UserCacheUtilities.GetTag(entity.Id)],
			cancellationToken);
	}

	public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<User>(UserCacheUtilities.GetByEmailKey(email), cancellationToken);
	}

	public async Task AddByEmailAsync(User entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			UserCacheUtilities.GetByEmailKey(entity.Email),
			entity,
			_cacheOptions.Expirations[UserCacheUtilities.GetByEmailKeyPrefix],
			[UserCacheUtilities.GetTag(entity.Id)],
			cancellationToken);
	}

	public async Task DeleteAsync(UserId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(UserCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<UserId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(UserCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
