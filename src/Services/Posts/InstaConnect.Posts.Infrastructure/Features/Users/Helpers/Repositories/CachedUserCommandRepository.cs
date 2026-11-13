using InstaConnect.Posts.Domain.Features.Users.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Repositories;

internal class CachedUserCommandRepository : IUserCommandRepository
{
	private readonly IUserCacheHandler _cacheHandler;
	private readonly IUserCommandRepository _repository;

	public CachedUserCommandRepository(
		IUserCacheHandler cacheHandler,
		IUserCommandRepository repository)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
	}

	public async Task<User?> GetByIdAsync(
		UserId id,
		UserInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<User?> GetByIdAsync(
		UserId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _cacheHandler.GetByIdAsync(id, cancellationToken);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var entity = await _repository.GetByIdAsync(id, cancellationToken);

		if (entity != null)
		{
			await _cacheHandler.AddAsync(entity, cancellationToken);
		}

		return entity;
	}

	public async Task<bool> ExistsByIdAsync(
		UserId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _cacheHandler.ExistsByIdAsync(id, cancellationToken);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _repository.ExistsByIdAsync(id, cancellationToken);

		await _cacheHandler.AddExistsByIdAsync(id, exists, cancellationToken);

		return exists;
	}

	public async Task<User?> GetByNameAsync(
		Name name,
		UserInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByNameAsync(name, include, cancellationToken);
	}

	public async Task<User?> GetByNameAsync(
		Name name,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _cacheHandler.GetByNameAsync(name, cancellationToken);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var entity = await _repository.GetByNameAsync(name, cancellationToken);

		if (entity != null)
		{
			await _cacheHandler.AddByNameAsync(entity, cancellationToken);
		}

		return entity;
	}

	public async Task<bool> IsNameUniqueAsync(
		Name name,
		CancellationToken cancellationToken)
	{
		return await _repository.IsNameUniqueAsync(name, cancellationToken);
	}

	public async Task<User?> GetByEmailAsync(
		Email email,
		UserInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByEmailAsync(email, include, cancellationToken);
	}

	public async Task<User?> GetByEmailAsync(
		Email email,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _cacheHandler.GetByEmailAsync(email, cancellationToken);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var entity = await _repository.GetByEmailAsync(email, cancellationToken);

		if (entity != null)
		{
			await _cacheHandler.AddByEmailAsync(entity, cancellationToken);
		}

		return entity;
	}

	public async Task<bool> IsEmailUniqueAsync(
		Email email,
		CancellationToken cancellationToken)
	{
		return await _repository.IsEmailUniqueAsync(email, cancellationToken);
	}

	public async Task AddAsync(User entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}

	public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
	{
		await _repository.UpdateAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}
}
