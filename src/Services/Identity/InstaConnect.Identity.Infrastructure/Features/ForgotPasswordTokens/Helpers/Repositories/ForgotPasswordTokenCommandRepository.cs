using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Repositories;

internal class ForgotPasswordTokenCommandRepository : IForgotPasswordTokenCommandRepository
{
	private readonly IForgotPasswordTokenCollection _collection;
	private readonly IForgotPasswordTokenIncludeBuilderFactory _includeBuilderFactory;

	public ForgotPasswordTokenCommandRepository(
		IForgotPasswordTokenCollection collection,
		IForgotPasswordTokenIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<ForgotPasswordToken?> GetByIdAsync(
		ForgotPasswordTokenId id,
		ForgotPasswordTokenInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ForgotPasswordToken?> GetByIdAsync(
		ForgotPasswordTokenId id,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().Build();

		return await GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<ICollection<ForgotPasswordToken>> GetByIdRangeAsync(
		IEnumerable<ForgotPasswordTokenId> ids,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ToListAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		ForgotPasswordTokenId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}

	public async Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
	{
		await _collection.UpdateAsync(entity, cancellationToken);
	}

	public async Task DeleteAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken)
	{
		await _collection.DeleteRangeAsync(entities, cancellationToken);
	}
}
