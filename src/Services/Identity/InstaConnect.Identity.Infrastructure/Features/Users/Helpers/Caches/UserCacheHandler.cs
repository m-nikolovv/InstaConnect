using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Users.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.Users.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Caches;

internal class UserCacheHandler : IUserCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly UserCacheOptions _cacheOptions;

	public UserCacheHandler(ICacheHandler cacheHandler, IOptions<UserCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<User?> GetByIdAsync(UserId id)
	{
		return await _cacheHandler.GetAsync<User>(UserCacheUtilities.GetByIdKey(id));
	}

	public async Task<UserResponse?> GetByIdAsync(UserId id, CurrentUserQuery currentUser)
	{
		return await _cacheHandler.GetAsync<UserResponse>(UserCacheUtilities.GetResponseByIdKey(id, currentUser));
	}

	public async Task AddAsync(User entity)
	{
		await _cacheHandler.SetAsync(
			UserCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[UserCacheUtilities.GetByIdKeyPrefix],
			[UserCacheUtilities.GetTag(entity.Id)]);
	}

	public async Task AddAsync(UserResponse response, CurrentUserQuery currentUser)
	{
		await _cacheHandler.SetAsync(
			UserCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[UserCacheUtilities.GetResponseByIdKeyPrefix],
			[UserCacheUtilities.GetTag(response.Id)]);
	}

	public async Task<bool?> ExistsByIdAsync(UserId id)
	{
		return await _cacheHandler.GetAsync<bool?>(UserCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(UserId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(
			UserCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[UserCacheUtilities.ExistsByIdKeyPrefix],
			[UserCacheUtilities.GetTag(id)]);
	}

	public async Task<User?> GetByNameAsync(Name name)
	{
		return await _cacheHandler.GetAsync<User>(UserCacheUtilities.GetByNameKey(name));
	}

	public async Task AddByNameAsync(User entity)
	{
		await _cacheHandler.SetAsync(
			UserCacheUtilities.GetByNameKey(entity.Name),
			entity,
			_cacheOptions.Expirations[UserCacheUtilities.GetByNameKeyPrefix],
			[UserCacheUtilities.GetTag(entity.Id)]);
	}

	public async Task<User?> GetByEmailAsync(Email email)
	{
		return await _cacheHandler.GetAsync<User>(UserCacheUtilities.GetByEmailKey(email));
	}

	public async Task AddByEmailAsync(User entity)
	{
		await _cacheHandler.SetAsync(
			UserCacheUtilities.GetByEmailKey(entity.Email),
			entity,
			_cacheOptions.Expirations[UserCacheUtilities.GetByEmailKeyPrefix],
			[UserCacheUtilities.GetTag(entity.Id)]);
	}

	public async Task DeleteAsync(UserId id)
	{
		await _cacheHandler.RemoveByTagAsync(UserCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<UserId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(UserCacheUtilities.GetTagRange(ids));
	}
}
