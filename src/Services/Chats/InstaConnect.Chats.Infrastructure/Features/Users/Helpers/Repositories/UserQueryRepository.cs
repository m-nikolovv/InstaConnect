using InstaConnect.Chats.Domain.Features.Users.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Repositories;

internal class UserQueryRepository : IUserQueryRepository
{
	private readonly IUserCollection _collection;
	private readonly IUserCacheHandler _cacheHandler;

	public UserQueryRepository(
		IUserCollection collection,
		IUserCacheHandler cacheHandler)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
	}

	public async Task<UserResponse?> GetByIdAsync(
		UserId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _cacheHandler.GetByIdAsync(id, currentUser);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var response = await _collection
			.AggregateFluent()
			.Match(id)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);

		if (response != null)
		{
			await _cacheHandler.AddAsync(response, currentUser);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		UserId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _cacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);

		await _cacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}
}
