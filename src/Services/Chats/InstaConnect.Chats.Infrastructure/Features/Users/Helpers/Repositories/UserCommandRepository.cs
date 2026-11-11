using InstaConnect.Chats.Domain.Features.Users.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Repositories;

internal class UserCommandRepository : IUserCommandRepository
{
	private readonly IUserCollection _collection;
	private readonly IUserCacheHandler _cacheHandler;
	private readonly IUserIncludeBuilderFactory _includeBuilderFactory;

	public UserCommandRepository(
		IUserCollection collection,
		IUserCacheHandler cacheHandler,
		IUserIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<User?> GetByIdAsync(
		UserId id,
		UserInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<User?> GetByIdAsync(
		UserId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _cacheHandler.GetByIdAsync(id);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var include = _includeBuilderFactory.Create().Build();

		var entity = await GetByIdAsync(id, include, cancellationToken);

		if (entity != null)
		{
			await _cacheHandler.AddAsync(entity);
		}

		return entity;
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

	public async Task<User?> GetByNameAsync(
		Name name,
		UserInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(name)
			.ApplyIncludes(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<User?> GetByNameAsync(
		Name name,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _cacheHandler.GetByNameAsync(name);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var include = _includeBuilderFactory.Create().Build();

		var entity = await GetByNameAsync(name, include, cancellationToken);

		if (entity != null)
		{
			await _cacheHandler.AddByNameAsync(entity);
		}

		return entity;
	}

	public async Task<bool> IsNameUniqueAsync(
		Name name,
		CancellationToken cancellationToken)
	{
		return !await _collection
			.AggregateFluent()
			.Match(name)
			.AnyAsync(cancellationToken);
	}

	public async Task<User?> GetByEmailAsync(
		Email email,
		UserInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(email)
			.ApplyIncludes(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<User?> GetByEmailAsync(
		Email email,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _cacheHandler.GetByEmailAsync(email);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var include = _includeBuilderFactory.Create().Build();

		var entity = await GetByEmailAsync(email, include, cancellationToken);

		if (entity != null)
		{
			await _cacheHandler.AddByEmailAsync(entity);
		}

		return entity;
	}

	public async Task<bool> IsEmailUniqueAsync(
		Email email,
		CancellationToken cancellationToken)
	{
		return !await _collection
			.AggregateFluent()
			.Match(email)
			.AnyAsync(cancellationToken);
	}

	public async Task AddAsync(User entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
	{
		await _collection.UpdateAsync(entity, cancellationToken);
	}

	public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
